import React, { memo } from 'react';
import {
  XAxis,
  CartesianGrid,
  Tooltip,
  ResponsiveContainer,
  Area,
  AreaChart,
} from 'recharts';
// import NumberFormat from 'react-number-format';
import { numFormatter } from '../../helpers/helper';
import _ from 'lodash';

const mname = [
  'Jan',
  'Feb',
  'Mar',
  'Apr',
  'May',
  'Jun',
  'Jul',
  'Aug',
  'Sep',
  'Oct',
  'Nov',
  'Dec',
];

export const MonthlyFreshBals = ({ bals, type }) => {
  const grp = _(bals)
    .groupBy('month')
    .map((month, key) => ({
      mnt: key,
      name: mname[key - 1],
      balance: _.sumBy(month, 'balance'),
    }))
    .value();

  // const grp = bals.reduce((r, e) => {
  //   if (!r[e.month])
  //     r[e.month - 1] = {
  //       mnt: e.month,
  //       name: mname[e.month - 1],
  //       balance: e.balance || 0,
  //     };
  //   else r[e.month - 1].balance += e.balance;
  //   return r;
  // }, []);

  // const CustomTooltip = ({ active, payload, label }) => {
  //   if (active && payload && payload.length) {
  //     return (
  //       <div
  //         className='custom-tooltip'
  //         style={{ color: '#000', fontSize: 10, fontWeight: 'bold' }}>
  //         <NumberFormat
  //           value={payload[0].value}
  //           prefix={`${label} $`}
  //           thousandSeparator=','
  //           displayType='text'
  //           color='black'
  //           decimalScale={0}
  //         />
  //       </div>
  //     );
  //   }

  //   return null;
  // };

  return (
    <div style={{ width: '100%', height: 150 }}>
      <ResponsiveContainer>
        <AreaChart
          width={600}
          height={300}
          data={grp}
          margin={{
            top: 0,
            right: 0,
            left: 15,
            bottom: 0,
          }}>
          <CartesianGrid strokeDasharray='3 3' />
          <XAxis dataKey='name' fontSize='9' fontWeight='bold' />
          <Tooltip
            itemStyle={{
              fontWeight: 'bold',
              fontSize: 12,
              fontFamily: 'cursive',
            }}
            formatter={value => numFormatter(value)}
          />
          {/* <Tooltip content={<CustomTooltip />} /> */}
          <Area
            type='monotone'
            dataKey='balance'
            stroke='#8884d8'
            fill={
              type === 'Corporate' ? 'blue' : type === 'all' ? 'teal' : 'red'
            }
            fillOpacity={0.3}
          />
        </AreaChart>
      </ResponsiveContainer>
    </div>
  );
};

export default memo(MonthlyFreshBals);
