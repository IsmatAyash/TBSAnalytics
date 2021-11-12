import React from 'react';
import { Grid, Segment } from 'semantic-ui-react';
import SegmentHeader from './SegmentHeader';

const HomeSegment = ({
  SegmentComponent,
  icon,
  title,
  subTitle,
  color,
  invert,
  image,
}) => {
  return (
    <Segment basic color={color} inverted={invert}>
      <Grid stackable columns={2}>
        <Grid.Column width={3}>
          <SegmentHeader
            image={image}
            icon={icon}
            title={title}
            subTitle={subTitle}
          />
        </Grid.Column>
        <Grid.Column width={13}>{SegmentComponent}</Grid.Column>
      </Grid>
    </Segment>
  );
};

export default HomeSegment;
