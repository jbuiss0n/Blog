import { createAction } from 'redux-actions';

import { API_QUERY, IApiResult, IApiError } from './api';

import * as Constants from '../constants';
import * as Schemas from '../schemas';
import * as Types from '../types';

interface ICommentsResult {
  title: string;
}

export const POST_COMMENTS_SUCCESS = createAction<ICommentsResult & IApiResult<Types.IComment[]>>(Constants.POST_COMMENTS_SUCCESS);
export const POST_COMMENTS_FAILURE = createAction<ICommentsResult & IApiError>(Constants.POST_COMMENTS_FAILURE);
export const POST_COMMENTS_REQUEST = (title: string) => API_QUERY<Types.IComment[]>({
  resource: 'Comments',
  endpoint: `posts/${title}/comments`,
  schema: [Schemas.Comment],
  onSucces: (result) => POST_COMMENTS_SUCCESS({ ...result, title }),
  onFailure: (error) => POST_COMMENTS_FAILURE({ ...error, title }),
});
