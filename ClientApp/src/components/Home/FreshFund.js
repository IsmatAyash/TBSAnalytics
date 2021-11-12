import React from 'react';
import { Card, Icon, Image } from 'semantic-ui-react';

let kpis = [
  {
    id: 1,
    balance: 0,
    title: 'Incoming Transfers',
    trxType: 'Incoming Transfers',
    image: 'IncomingFresh.png',
  },
  {
    id: 2,
    balance: 0,
    title: 'Fresh Cash Deposit',
    trxType: 'Cash Deposit',
    image: 'CashDepositFresh.png',
  },
  {
    id: 3,
    balance: 0,
    title: 'Fresh Account balances',
    trxType: 'Account Balances',
    image: 'FreshAccountBalances.png',
  },
  {
    id: 4,
    balance: 0,
    title: 'Outgoing Fresh Payments',
    trxType: 'Wires',
    image: 'OutgoingFreshPayment.png',
  },
  {
    id: 5,
    balance: 0,
    title: 'USD Cash Withdrawals',
    trxType: 'Cash Withdrawal',
    image: 'UsdCashWithdrawal.png',
  },
  {
    id: 6,
    balance: 0,
    title: 'FX from Fresh accounts',
    trxType: 'FX',
    image: 'FxFromFreshAccount.png',
  },
];

const sumKpi = (tt, bb, ttype) => {
  if (ttype === 'FX') return 0;
  if (ttype === 'Account Balances')
    return bb.reduce((s, a) => (s += a.balance), 0);

  return tt
    .filter(t => t.stpType === ttype)
    .reduce((s, a) => (s += a.stpAmount), 0);
};

const FreshFund = ({ freshFunds, ffbals }) => {
  kpis.forEach(
    item => (item.balance = sumKpi(freshFunds, ffbals, item.trxType))
  );
  return (
    <Card.Group itemsPerRow={3}>
      {kpis.map(kpi => (
        <Card key={kpi.id} color={kpi.balance < 0 ? 'red' : 'blue'}>
          <Card.Content>
            <Card.Header>
              {kpi.icon && <Icon name={kpi.icon} size='large' />}
              {kpi.image && (
                <Image
                  src={require(`../../images/${kpi.image}`)}
                  size='mini'
                  color='black'
                />
              )}{' '}
              {kpi.title}
            </Card.Header>
            <Card.Description style={{ fontSize: 16, fontWeight: 'bold' }}>
              ${Number(Math.abs(kpi.balance)).toLocaleString(2)}
            </Card.Description>
          </Card.Content>
        </Card>
      ))}
    </Card.Group>
  );
};

export default FreshFund;
