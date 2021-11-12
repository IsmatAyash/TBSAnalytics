import React, { useState } from 'react';
import { Icon, Menu, Input, Header, Checkbox, Button } from 'semantic-ui-react';
import './HomeBar.css';

function HomeBar({
  selectedItem,
  onItemSelect,
  onSearch,
  onRefresh,
  onBBU,
  checked,
  custName,
}) {
  const [cid, setCid] = useState('');

  const menuItems = [
    { id: 0, name: 'all', icon: 'recycle', label: 'All' },
    { id: 1, name: 'Corporate', icon: 'users', label: 'Corporate' },
    { id: 3, name: 'Establishment', icon: 'user', label: 'Establishment' },
  ];

  const handleCustidChange = e => {
    setCid(e.target.value);
  };

  const handleRefresh = () => {
    setCid('');
    onRefresh();
  };

  return (
    <>
      <Menu inverted borderless size='small' attached='top' stackable>
        {menuItems.map(item => (
          <Menu.Item
            key={item.id}
            name={item.name}
            active={selectedItem === item.name}
            color='teal'
            onClick={() => onItemSelect(item.name)}>
            <Icon name={item.icon} />
            {item.label}
          </Menu.Item>
        ))}
        <Menu.Item>
          <Checkbox
            label={<label style={{ color: 'white' }}>BBU</label>}
            onChange={onBBU}
            checked={checked}
          />
        </Menu.Item>

        <Menu.Item>
          <Button animated='fade' onClick={handleRefresh}>
            <Button.Content hidden>Clear</Button.Content>
            <Button.Content visible>
              <Icon name='refresh' />
            </Button.Content>
          </Button>
        </Menu.Item>

        <Menu.Item>
          <Input
            action={{
              icon: 'search',
              placeholder: 'Customer ID ...',
              onClick: () => onSearch(cid),
            }}
            value={cid}
            onChange={e => handleCustidChange(e)}
          />
        </Menu.Item>
        <Menu.Item>
          <Header size='small' inverted>
            {custName}
          </Header>
        </Menu.Item>
      </Menu>
    </>
  );
}

export default HomeBar;
