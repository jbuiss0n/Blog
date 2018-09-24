import * as Types from '../types';
import * as Constants from '../constants';

const Posts = (state: Types.IAppState, action): Types.IAppState => {
  if (action.type === Constants.POSTS_SUCCESS) {
    return { ...state, Posts: action.payload.result };
  }

  return state;
};

export default Posts;
