import React from 'react';
import { Statistic, Icon, Image } from 'semantic-ui-react';

const PayCardStat = ({ items }) => {
  return (
    <Statistic.Group size='mini'>
      {items.map(item => (
        <Statistic
          inverted
          key={item.key}
          color={item.key.substr(0, 3) === 'Fre' ? 'green' : 'olive'}>
          <Statistic.Value>
            {item.icon && <Icon name={item.icon} />}
            {item.image && <Image src={item.image} inline circular />}
            {item.value}
          </Statistic.Value>
          <Statistic.Label>{item.label}</Statistic.Label>
        </Statistic>
      ))}
    </Statistic.Group>
  );
};

export default PayCardStat;
