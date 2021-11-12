import React, { createContext, useReducer } from 'react';
import {
  CUSTTYPE,
  DASHBOARD,
  YEAR,
  CUSTID,
  VISIBLE,
  BBUFLAG,
} from './actionTypes';
import { initialState } from './initialState';
import reducer from './reducer';

const TBSContext = createContext();

const TBSProvider = ({ children }) => {
  const [homeDash, dispatch] = useReducer(reducer, initialState);

  const value = {
    homeDash,
    updCusttype: ct => dispatch({ type: CUSTTYPE, payload: ct }),
    updDash: dash => dispatch({ type: DASHBOARD, payload: dash }),
    updYear: yr => dispatch({ type: YEAR, payload: yr }),
    updVisible: vz => dispatch({ type: VISIBLE, payload: vz }),
    updBBUflag: ff => dispatch({ type: BBUFLAG, payload: ff }),
    updCustid: cid => dispatch({ type: CUSTID, payload: cid }),
  };

  return <TBSContext.Provider value={value}>{children}</TBSContext.Provider>;
};

export { TBSProvider, TBSContext };
