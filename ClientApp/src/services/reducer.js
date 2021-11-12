import {
  CUSTTYPE,
  DASHBOARD,
  YEAR,
  CUSTID,
  BBUFLAG,
  VISIBLE,
  ERROR,
} from './actionTypes';

const reducer = (state, { type, payload }) => {
  switch (type) {
    case CUSTTYPE:
      return { ...state, custtype: payload };
    case DASHBOARD:
      return { ...state, dashboard: payload };
    case YEAR:
      return { ...state, year: payload };
    case BBUFLAG:
      return { ...state, bbuflag: payload };
    case CUSTID:
      return {
        ...state,
        custid: {
          id: payload.id ? payload.id.trim() : 'all',
          name: payload.name,
        },
      };
    case VISIBLE:
      return { ...state, visible: payload };
    case ERROR:
      return { ...state, error: 'Something went wrong' };
    default:
      return state;
  }
};

export default reducer;
