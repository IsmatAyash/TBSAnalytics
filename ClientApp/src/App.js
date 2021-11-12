import React, { useContext } from 'react';
import { Route, Switch } from 'react-router-dom';
import { Segment, Sidebar } from 'semantic-ui-react';
import { TBSContext } from './services/context';
import Menubar from './components/Menubar';
import SideBar from './components/SideBar';
import Home from './components/Home';
import PayCards from './components/PayCards';

const App = () => {
  const { homeDash, updVisible } = useContext(TBSContext);
  const { visible } = homeDash;

  const toggleMenu = () => {
    updVisible(!visible);
  };

  return (
    <div>
      <Menubar onToggleMenu={() => toggleMenu()} />
      <Sidebar.Pushable as={Segment} style={{ height: '100vh', marginTop: 0 }}>
        <SideBar />
        <Sidebar.Pusher dimmed={visible}>
          <Switch>
            <Route exact path='/' component={Home} />
            <Route path='/paycards' component={PayCards} />
          </Switch>
        </Sidebar.Pusher>
      </Sidebar.Pushable>
    </div>
  );
};

export default App;
