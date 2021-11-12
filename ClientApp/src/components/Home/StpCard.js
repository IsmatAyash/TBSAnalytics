import React from 'react';
import { Card, Image, Icon, Grid } from 'semantic-ui-react';
import StpChart from './StpChart';

const dispValue = val => (val ? val : 0);

const StpCard = ({ stps, chartData }) => {
  const sorted = stps
    .filter(
      s =>
        s.id === 'Transfers' ||
        s.id === 'Wires' ||
        s.id === 'Demand Draft' ||
        s.id === 'Port Bills'
    )
    .sort((a, b) => a.key - b.key);

  return (
    <>
      {sorted.map(stp => (
        <Grid.Column key={stp.id}>
          <Card color='teal' fluid>
            <Card.Content>
              <Card.Header>
                <Image floated='right' size='mini' src={stp.image} circular />
                {stp.id} STP {Math.ceil((stp.cnt / stp.cntall) * 100) || 0}%
              </Card.Header>
              <Card.Meta>Year on Year growth</Card.Meta>
              <Card.Description>
                {<StpChart color={stp.color} data={chartData[stp.id]} />}
              </Card.Description>
            </Card.Content>
            <Card.Content extra>
              <Grid columns={3}>
                <Grid.Column width={1}>
                  <Icon name={stp.icon} />
                </Grid.Column>
                <Grid.Column width={8}>
                  Volume: $
                  {dispValue(parseInt(Math.abs(stp.amt))).toLocaleString()}
                </Grid.Column>
                <Grid.Column>
                  Count: {dispValue(parseInt(stp.cnt)).toLocaleString()}
                </Grid.Column>
              </Grid>
            </Card.Content>
          </Card>
        </Grid.Column>
      ))}
    </>
  );
};

export default StpCard;
