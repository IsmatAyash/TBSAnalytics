import React from 'react';
import { AreaChart, Area, XAxis, Tooltip, ResponsiveContainer } from 'recharts';
import _ from 'lodash';

const StpChart = ({ color, data }) => {
  return (
    <div style={{ width: '100%', height: 100 }}>
      <ResponsiveContainer>
        <AreaChart
          width={200}
          height={60}
          data={_.orderBy(data, 'year')}
          margin={{
            top: 5,
            right: 15,
            left: 18,
            bottom: 5,
          }}>
          <XAxis dataKey='year' />
          <Tooltip />
          <Area type='monotone' dataKey='cnt' stroke='#8884d8' fill={color} />
        </AreaChart>
      </ResponsiveContainer>{' '}
    </div>
  );
};

export default React.memo(StpChart);
