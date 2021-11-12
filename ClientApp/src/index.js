import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter as Router } from 'react-router-dom';
import { TBSProvider } from './services/context';

import App from './App';
import 'semantic-ui-css/semantic.min.css';

const rootElement = document.getElementById('root');

ReactDOM.render(
  <Router>
    <TBSProvider>
      <App />
    </TBSProvider>
  </Router>,
  rootElement
);
