import _ from 'lodash';

export function groupStps(array, idx) {
  // Trans data preparation displayed in stpCard
  return _(array)
    .groupBy('stpType')
    .map((stpType, id) => ({
      id: id,
      ['amt' + idx]: _.sumBy(stpType, 'stpAmount'),
      ['cnt' + idx]: _.sumBy(stpType, 'stpCount'),
      color: Color(id),
      icon: Icon(id),
      image: Image(id),
    }))
    .value();
}

function Color(stp) {
  switch (stp) {
    case 'Wires':
      return 'red';
    case 'Transfers':
      return 'blue';
    case 'Demand Draft':
      return 'green';
    default:
      return 'orange';
  }
}

function Icon(stp) {
  switch (stp) {
    case 'Wires':
      return 'exchange';
    case 'Transfers':
      return 'send';
    case 'Demand Draft':
      return 'newspaper outline';
    default:
      return 'list alternate';
  }
}

function Image(stp) {
  switch (stp) {
    case 'Wires':
      return require('../images/WiresSTP.png');
    case 'Transfers':
      return require('../images/TransfersSTP.png');
    case 'Demand Draft':
      return require('../images/DemandDraftSTP.png');
    default:
      return require('../images/PortBillsSTP.png');
  }
}

// merge join two arrays by key
export const mergeByKey = (a1, a2, key) =>
  a1.map(itm => ({
    ...a2.find(item => item[key] === itm[key] && item),
    ...itm,
  }));

export function groupStpByYear(stps) {
  // chart data preparation displayed in stpCard
  // group by compsite key
  const result = Object.values(
    stps.reduce((r, e) => {
      const key = e.type + '|' + e.year;
      if (!r[key]) r[key] = e;
      else {
        r[key].amt += e.amt;
        r[key].cnt += e.cnt;
      }
      return r;
    }, {})
  );

  return _(result).groupBy('type').value();
}

export function groupStatus(array) {
  // enrollments data preparation
  let steps = _(array)
    .groupBy('custStatus')
    .map((custStatus, key) => ({
      key,
      image: StatusImage(key),
      title: key,
      description: _.sumBy(custStatus, 'custStatusCount'),
    }))
    .value();
  const total = _.sumBy(steps, 'description');
  const enrolled = _.find(steps, { key: 'Enrolled' });
  if (enrolled) {
    const ratio = enrolled.description / total;
    steps.push(statObj('Customers', 'Customers', total));
    steps.push(statObj('Penetration Rate', 'Ratio', Math.ceil(ratio * 100)));
  }
  return _.orderBy(steps, 'key');
}

const StatusImage = stat =>
  stat === 'Enrolled' ? 'Enrolled.png' : 'NotEnrolled.png';
const statObj = (title, key, description) => ({
  key,
  image: key === 'Customers' ? 'UserStatistics.png' : 'PenetrationRate.png',
  title,
  description,
});

function paycardGroup(cards, key1, key2) {
  return Object.values(
    cards.reduce((r, e) => {
      const key = e[key1] + '|' + e[key2];
      if (!r[key])
        r[key] = {
          [key1]: e[key1],
          [key2]: e[key2],
          cardCount: e.cardCount,
          usdBal: e.usdBal,
          lbpBal: e.lbpBal || 0,
        };
      else {
        r[key].usdBal += e.usdBal;
        r[key].lbpBal += e.lbpBal || 0;
        r[key].cardCount += e.cardCount;
      }
      return r;
    }, {})
  );
}

export function cardStatsArray(cards, key1, key2) {
  const grouped = paycardGroup(cards, key1, key2);

  let items = [];
  grouped.forEach((itm, index) => {
    items.push({
      key: `${itm.cardType.substr(0, 3)}${index}A`,
      label:
        itm.cardType === 'BusinessCard'
          ? `Active ${itm.curAbv}`
          : 'Fresh Active',
      value: parseInt(itm.cardCount).toLocaleString(),
    });
    items.push({
      key: `${itm.cardType.substr(0, 3)}${index}B`,
      label:
        itm.cardType === 'BusinessCard'
          ? `Balance ${itm.curAbv}`
          : 'Fresh Balance',
      icon: itm.curAbv === 'USD' ? 'dollar' : '',
      value:
        itm.curAbv === 'USD'
          ? parseInt(itm.usdBal).toLocaleString()
          : parseInt(itm.lbpBal).toLocaleString(),
    });
  });
  return items;
}

export function cardUsageArray(cards, key1, key2) {
  const grouped = paycardGroup(cards, key1, key2);

  let items = [];
  grouped.forEach((itm, index) => {
    items.push({
      key: `${itm[key1]}${index}A`,
      label: `${itm[key1]} Usage`,
      icon: 'dollar',
      value: parseInt(Math.abs(itm.usdBal)).toLocaleString(),
    });
    items.push({
      key: `${itm[key1]}${index}B`,
      label: `${itm[key1]} Trx`,
      value: parseInt(itm.cardCount).toLocaleString(),
    });
  });
  return items;
}

export function numFormatter(num) {
  if (num > 999 && num < 1000000) {
    return '$' + (num / 1000).toFixed(1) + 'K'; // convert to K for number from > 1000 < 1 million
  } else if (num > 1000000) {
    return '$' + (num / 1000000).toFixed(1) + 'M'; // convert to M for number from > 1 million
  } else if (num < 900) {
    return '$' + num; // if value < 1000, nothing to do
  }
}
