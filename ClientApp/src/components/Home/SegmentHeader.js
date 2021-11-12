import React from 'react';
import { Header, Icon, Image } from 'semantic-ui-react';

const SegmentHeader = ({ icon, image, title, subTitle }) => {
  return (
    <Header as='h2' inverted={title === 'Business PayCards'}>
      {image && <Image size='large' src={require(`../../images/${image}`)} />}
      {icon && <Icon name={icon} />}
      <Header.Content>
        {title}
        <Header.Subheader>{subTitle}</Header.Subheader>
      </Header.Content>
    </Header>
  );
};

export default SegmentHeader;
