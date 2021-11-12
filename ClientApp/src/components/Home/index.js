import React, { useState, useEffect, useContext } from 'react';
import { Grid, Segment, Container, Card } from 'semantic-ui-react';

import StpCard from './StpCard';
import StpStat from './StpStat';
import SegmentHeader from './SegmentHeader';
import {
  groupStps,
  groupStpByYear,
  mergeByKey,
  cardStatsArray,
  cardUsageArray,
} from '../../helpers/helper';
import {
  getTrans,
  getCustomers,
  getTransYoy,
  getTransYoyById,
  getCardStats,
  getCardUsage,
  getFreshFund,
  getMbals,
  getBals,
} from '../../services/HomeService';
import { TBSContext } from '../../services/context';
import UserStat from './UserStat';
import FreshFund from './FreshFund';
import PayCardStat from './PayCardStat';
import HomeSegment from './HomeSegment';
import { MonthlyFreshBals } from './MonthlyFreshBals';

const Home = () => {
  const { homeDash } = useContext(TBSContext);
  const { custid, custtype } = homeDash;
  const [trans, setTrans] = useState([]);
  const [custs, setCusts] = useState([]);
  const [yoys, setYoys] = useState([]);
  const [cardStat, setCardStat] = useState([]);
  const [cardUsage, setCardUsage] = useState([]);
  const [freshFunds, setFreshFunds] = useState([]);
  const [mBals, setMbals] = useState([]);
  const [bals, setBals] = useState([]);

  useEffect(() => {
    // get all transactions
    const fetchData = async () => {
      const [{ data: resTran }, { data: resYoy }, { data: resCust }] =
        await Promise.all([getTrans(), getTransYoy(), getCustomers()]);
      if (custid.id !== 'all') {
        setTrans(resTran.filter(c => c.custId.trim() === custid.id));
        const { data } = await getTransYoyById(custid.id);
        setYoys(data);
      } else if (custtype !== 'all') {
        setTrans(resTran.filter(t => t.custType === custtype));
        setYoys(resYoy.filter(t => t.custType === custtype));
        setCusts(resCust.filter(t => t.custType === custtype));
      } else {
        setTrans(resTran);
        setYoys(resYoy);
        setCusts(resCust);
      }
    };
    fetchData();
  }, [custtype, custid]);

  useEffect(() => {
    // get fresh funds
    const fetchFreshFunds = async () => {
      const [{ data: resFreshFunds }, { data: resBals }, { data: resMbals }] =
        await Promise.all([getFreshFund(), getBals(), getMbals()]);
      if (custid.id !== 'all') {
        setFreshFunds(resFreshFunds.filter(c => c.custId.trim() === custid.id));
        setBals(resBals.filter(c => c.custId.trim() === custid.id));
        setMbals(resMbals.filter(c => c.custId.trim() === custid.id));
      } else if (custtype !== 'all') {
        setFreshFunds(resFreshFunds.filter(t => t.custType === custtype));
        setBals(resBals.filter(t => t.custType === custtype));
        setMbals(resMbals.filter(t => t.custType === custtype));
      } else {
        setFreshFunds(resFreshFunds);
        setBals(resBals);
        setMbals(resMbals);
      }
    };
    fetchFreshFunds();
  }, [custid, custtype]);

  useEffect(() => {
    // get cards info
    const fetchCards = async () => {
      const [{ data: resCardStat }, { data: resCardUsage }] = await Promise.all(
        [getCardStats(), getCardUsage()]
      );
      if (custid.id !== 'all') {
        setCardStat(resCardStat.filter(c => c.custId.trim() === custid.id));
        setCardUsage(resCardUsage.filter(c => c.custId.trim() === custid.id));
      } else {
        setCardStat(resCardStat);
        setCardUsage(resCardUsage);
      }
    };
    fetchCards();
  }, [custid]);

  const stpyoy = groupStpByYear(
    yoys.map(y => ({
      type: y.stpType,
      year: y.stpYear,
      amt: y.stpAmount,
      cnt: y.stpCount,
    }))
  );

  const digis = groupStps(
    trans.filter(y => y.channel !== 'BRC'),
    ''
  );
  const allTrx = groupStps(trans, 'all');
  const stps = mergeByKey(allTrx, digis, 'id');

  // business cards  stats and usage
  const usages = cardUsageArray(cardUsage, 'trxType', 'cardType');
  const stats = cardStatsArray(cardStat, 'curAbv', 'cardType').concat(usages);

  return (
    <Container fluid>
      <HomeSegment
        SegmentComponent={<UserStat custs={custs} />}
        // icon='users'
        image='UserStatistics.png'
        title='User Statistics'
        subTitle='Enrolled versus not Enrolled'
      />
      <Segment color='teal'>
        <Grid stackable columns={2}>
          <Grid.Column width={4}>
            <SegmentHeader
              // icon='th list'
              image='TransactionAutomation.png'
              title='Transactions Automation'
              subTitle='Digital versus Branch'
            />
          </Grid.Column>
          <Grid.Column>
            <StpStat trans={trans} />
          </Grid.Column>
        </Grid>
        <Grid stackable columns={4}>
          <StpCard stps={stps} chartData={stpyoy} />
        </Grid>
      </Segment>
      <Segment>
        <Grid stackable columns={2}>
          <Grid.Column width={12}>
            <Segment basic>
              <HomeSegment
                SegmentComponent={
                  <FreshFund freshFunds={freshFunds} ffbals={bals} />
                }
                // icon='money'
                image='FreshFunds.png'
                title='Fresh Funds'
                subTitle='Statistics'
              />
            </Segment>
          </Grid.Column>
          <Grid.Column width={4}>
            <Card fluid>
              <Card.Content
                header={`Monthly Fresh Fund Balances - ${custtype}`}
              />
              <Card.Content>
                <MonthlyFreshBals bals={mBals} type={custtype} />
              </Card.Content>
            </Card>
          </Grid.Column>
        </Grid>
      </Segment>
      <HomeSegment
        SegmentComponent={<PayCardStat items={stats} />}
        // icon='cc mastercard'
        image='PayCards.png'
        title='Business PayCards'
        subTitle='Statistics & Usage'
        invert
      />
      {/* <HomeSegment
        SegmentComponent={<PayCardStat items={usages} />}
        // icon='cc mastercard'
        image='PayCards.png'
        title='Business PayCards'
        subTitle='Usage'
        invert
      /> */}
    </Container>
  );
};

export default Home;
