import * as Types from '../types';
import * as Constants from '../constants';

const CommentReducers = (state: Types.IAppState, action): Types.IAppState => {

  switch (action.type) {

    case Constants.POST_COMMENTS_SUCCESS: {
      if (state.Entities.Posts[action.payload.title]) {
        state.Entities.Posts[action.payload.title].Comments = action.payload.result;
      }
      break;
    }
  }

  return state;
};

export default CommentReducers;
