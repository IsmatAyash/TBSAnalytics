import React from 'react';
import { Step, Image } from 'semantic-ui-react';
import { groupStatus } from '../../helpers/helper';

const UserStat = ({ custs }) => {
  const steps = groupStatus(custs);
  const titleStyle = title => ({
    color: title === 'Not Enrolled' ? 'red' : '',
    paddingLeft: 10,
  });

  return (
    <Step.Group fluid>
      {steps.map(step => (
        <Step active key={step.key}>
          <Image src={require(`../../images/${step.image}`)} size='mini' />
          <Step.Content>
            <Step.Title style={titleStyle(step.title)}>{step.title}</Step.Title>
            <Step.Description style={{ fontSize: 20, paddingLeft: 10 }}>
              {step.description.toLocaleString()}
              {step.title === 'Penetration Rate' && '%'}
            </Step.Description>
          </Step.Content>
        </Step>
      ))}
    </Step.Group>
  );
};

export default UserStat;
