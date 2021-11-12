import React from 'react';
import { Statistic, Image } from 'semantic-ui-react';

const dispValue = val => (val ? val : 0);

const sumCount = array => array.reduce((s, a) => (s += a.stpCount), 0);

const StpStat = ({ trans }) => {
  const digi = sumCount(trans.filter(y => y.channel !== 'BRC'));
  const brcs = sumCount(trans.filter(y => y.channel === 'BRC'));

  return (
    <Statistic.Group widths='four' size='tiny'>
      <Statistic>
        <Statistic.Value>
          {dispValue(digi + brcs).toLocaleString()}
        </Statistic.Value>
        <Statistic.Label>Total</Statistic.Label>
      </Statistic>

      <Statistic color='violet'>
        <Statistic.Value>
          <Image
            style={{ width: 30, height: 33 }}
            src={require('../../images/Digital.png')}
            inline
          />
          {dispValue(digi).toLocaleString()}
        </Statistic.Value>
        <Statistic.Label>Digital</Statistic.Label>
      </Statistic>

      <Statistic>
        <Statistic.Value>
          {/* <Icon name='tasks' />  */}
          <Image
            src={require('../../images/BranchTransactions.png')}
            inline
            style={{ width: 30, height: 30 }}
          />
          {dispValue(brcs).toLocaleString()}
        </Statistic.Value>
        <Statistic.Label>Branches</Statistic.Label>
      </Statistic>

      <Statistic color='red'>
        <Statistic.Value>
          {dispValue(Math.ceil((digi / (digi + brcs)) * 100))}%
        </Statistic.Value>
        <Statistic.Label>Automation Rate</Statistic.Label>
      </Statistic>
    </Statistic.Group>
  );
};

export default StpStat;
