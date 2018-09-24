import * as Redux from 'redux';
import * as Types from '../types';
import thunk from 'redux-thunk';

import reducers from '../reducers';
import api from '../middleware/api';
import DevTools from '../containers/dev-tools';

const defaultState: Types.IAppState = {
  Entities: { Posts: {}, Comments: {} }
};

const configureStore = () => Redux.createStore(
  reducers,
  defaultState,
  Redux.compose(
    Redux.applyMiddleware(thunk, api),
    DevTools.instrument()
  )
);

export default configureStore;
