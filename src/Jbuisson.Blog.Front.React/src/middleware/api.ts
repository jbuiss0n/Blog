import Config from '../config';
import { normalize } from 'normalizr';
import { Action } from 'redux-actions';
import * as Redux from 'redux';

import * as Constants from '../constants';
import * as Actions from '../actions';

const request = async (action: Actions.IApiRequest<any>, next) => {
  const url = Config.API_URL + action.endpoint;
  const headers = {
    'Accept': 'application/json',
    'Content-Type': 'application/json'
  };

  const response = await fetch(url, { headers });
  const json = await response.json();

  if (!response.ok) {
    return next(action.onFailure({ Code: response.status, Error: json }));
  }

  if (action.schema) {
    return next(action.onSucces(Object.assign({}, normalize(json, action.schema))));
  }

  return next(action.onSucces(json));
};


export default (store: Redux.Store) => next => (action: Action<any>) => {
  if (action.payload && action.payload[Constants.API_REQUEST]) {
    return request(action.payload[Constants.API_REQUEST], next);
  }
  return next(action);
};
