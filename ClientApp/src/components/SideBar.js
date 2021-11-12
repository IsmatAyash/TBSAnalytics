import React, { useContext } from 'react';
import { Icon, Menu, Sidebar } from 'semantic-ui-react';
import { Link } from 'react-router-dom';
import { TBSContext } from '../services/context';

const sidebar = [
  {
    id: 1,
    path: '/',
    comp: 'Home',
    icon: 'audible',
    label: 'TBS Analytics',
  },
  {
    id: 2,
    path: '/paycards',
    comp: 'PayCards',
    icon: 'area chart',
    label: 'PayCards Dashboard',
  },
];

const SideBar = () => {
  const { updDash, updVisible, homeDash } = useContext(TBSContext);
  const { visible } = homeDash;

  const handleClick = menuItem => {
    updVisible(!visible);
    updDash(menuItem);
  };

  const iconStyle = {
    marginLeft: 10,
  };

  return (
    <>
      <Sidebar
        as={Menu}
        animation='slide along'
        inverted
        vertical
        visible={visible}
        width='wide'>
        {sidebar.map(item => (
          <Menu.Item
            key={item.id}
            as={Link}
            to={item.path}
            onClick={() => handleClick(item.comp)}>
            <div>
              <Icon name={item.icon}></Icon>
              <span style={iconStyle}>{item.label}</span>
            </div>
          </Menu.Item>
        ))}
      </Sidebar>
    </>
  );
};

export default SideBar;
