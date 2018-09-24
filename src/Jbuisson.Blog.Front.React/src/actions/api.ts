import { Schema } from 'normalizr';
import { createAction } from 'redux-actions';

import * as Constants from '../constants';
import * as Types from '../types';

export interface IApiQuery<TEntity> {
  [Constants.API_REQUEST]: IApiRequest<TEntity>;
  result?: IApiResult<TEntity>;
  error?: IApiError;
}

export interface IApiCommand<TEntity> {
  [Constants.API_COMMAND]: IApiRequest<TEntity>;
  result?: IApiResult<TEntity>;
  error?: IApiError;
}

export interface IApiRequest<TEntity> {
  data?: any;
  endpoint: string;
  resource: string;
  schema?: Schema;
  onSucces: (result: IApiResult<TEntity>) => void;
  onFailure: (error: IApiError) => void;
}

export interface IApiResult<TEntity> {
  entities: Types.IEntities;
  result: number[];
}

export interface IApiError {
  Code: number;
  Error: string;
}

export function API_QUERY<TEntity>(request: IApiRequest<TEntity>) {
  return createAction<IApiQuery<TEntity>, IApiRequest<TEntity>>(Constants.API_REQUEST, (request) => ({
    [Constants.API_REQUEST]: request
  }))(request);
};

export function API_COMMAND<TEntity>(request: IApiRequest<TEntity>) {
  return createAction<IApiCommand<TEntity>, IApiRequest<TEntity>>(Constants.API_COMMAND, (request) => ({
    [Constants.API_COMMAND]: request
  }))(request);
};