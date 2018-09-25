import { createAction } from 'redux-actions';

import { API_QUERY, IApiResult, IApiError } from './api';

import * as Constants from '../constants';
import * as Schemas from '../schemas';
import * as Types from '../types';

interface IPostResult {
  title: string;
}

export const POSTS_SUCCESS = createAction<IApiResult<Types.IPost[]>>(Constants.POSTS_SUCCESS);
export const POSTS_FAILURE = createAction<IApiError>(Constants.POSTS_FAILURE);
export const POSTS_REQUEST = () => API_QUERY<Types.IPost[]>({
  resource: 'Posts',
  endpoint: 'posts',
  schema: [Schemas.Post],
  onSucces: POSTS_SUCCESS,
  onFailure: POSTS_FAILURE,
});

export const POST_TITLE_SUCCESS = createAction<IPostResult & IApiResult<Types.IPost>>(Constants.POST_TITLE_SUCCESS);
export const POST_TITLE_FAILURE = createAction<IPostResult & IApiError>(Constants.POST_TITLE_FAILURE);
export const POST_TITLE_REQUEST = (title: string) => API_QUERY<Types.IPost>({
  resource: 'Posts',
  endpoint: 'posts/' + title,
  schema: Schemas.Post,
  onSucces: (result) => POST_TITLE_SUCCESS({ ...result, title }),
  onFailure: (error) => POST_TITLE_FAILURE({ ...error, title }),
});
