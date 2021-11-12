import React, { useContext, useState, useEffect } from 'react';
import HomeBar from './Home/HomeBar';
import { Menu, Icon } from 'semantic-ui-react';
import { TBSContext } from '../services/context';
import { getCustomer } from '../services/HomeService';

const Menubar = ({ onToggleMenu }) => {
  const [cname, setCname] = useState('');

  const { updYear, homeDash, updCusttype, updCustid, updBBUflag } =
    useContext(TBSContext);
  const { bbuflag, custid, custtype, dashboard, year } = homeDash;

  const today = new Date();
  const years = [today.getFullYear(), today.getFullYear() - 1];
  const menuTitle =
    dashboard !== 'Home'
      ? `${today.toLocaleString('default', {
          month: 'long',
        })} ${today.getFullYear()}`
      : `TBS Analytics - ${today.toLocaleString('default', {
          month: 'long',
        })} ${today.getFullYear()}`;

  const handleCusttypeSelect = name => {
    updCusttype(name);
  };

  const handleYearSelect = yr => {
    updYear(yr);
  };

  const handleSearch = async cid => {
    try {
      const { data } = await getCustomer(cid);
      updCustid({ id: data.custId, name: data.custName });
    } catch (ex) {
      updCustid({ id: 'all', name: '' });
    }
  };

  const handleRefresh = () => updCustid({ id: 'all', name: '' });

  useEffect(() => setCname(custid.name), [custid]);

  const toggle = () => updBBUflag(!bbuflag);

  return (
    <Menu stackable attached='top' borderless inverted compact>
      <Menu.Item onClick={onToggleMenu}>
        <div className='ui transparent icon'>
          <Icon name='bars'></Icon> Menu
        </div>
      </Menu.Item>
      <Menu.Menu>
        {dashboard === 'Home' && (
          <>
            <HomeBar
              onItemSelect={handleCusttypeSelect}
              onSearch={handleSearch}
              onRefresh={handleRefresh}
              onBBU={toggle}
              selectedItem={custtype}
              custName={cname}
              checked={bbuflag}
            />
          </>
        )}
        {dashboard === 'PayCards' && (
          <HomeBar
            onTeamSelect={handleCusttypeSelect}
            selectedTeam={custtype}
          />
        )}
      </Menu.Menu>
      <Menu.Menu position='right'>
        {dashboard !== 'Home' ? (
          <>
            <div className='ui right aligned item'>
              <div className='ui transparent icon'>
                <Icon name='hand point right' />
              </div>
            </div>
            {years.map(yr => (
              <Menu.Item
                key={yr}
                name={yr.toString()}
                color='teal'
                active={yr === year}
                onClick={() => handleYearSelect(yr)}>
                {yr}
              </Menu.Item>
            ))}
          </>
        ) : (
          <div className='ui right aligned item'>
            <div className='ui transparent icon'>
              <Icon
                name={dashboard !== 'Home' ? 'database' : 'dashboard'}
                size='large'></Icon>
              <span style={{ margin: 5, fontSize: 13 }}>{menuTitle}</span>
            </div>
          </div>
        )}
      </Menu.Menu>
    </Menu>
  );
};

export default Menubar;
