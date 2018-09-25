import * as Types from '../types';
import * as Constants from '../constants';

const PostReducers = (state: Types.IAppState, action): Types.IAppState => {

  switch (action.type) {
    case Constants.POSTS_SUCCESS: {
      state.Posts = action.payload.result;
      break;
    }

    case Constants.POST_TITLE_SUCCESS: {
      for (const id in state.Entities.Comments) {
        if (state.Entities.Comments[id].Id_Post === state.Entities.Posts[action.payload.result].Id) {
          if (!state.Entities.Posts[action.payload.result].Comments) {
            state.Entities.Posts[action.payload.result].Comments = [];
          }

          state.Entities.Posts[action.payload.result].Comments.push(Number(id));
        }
      }
      break;
    }
  }

  return state;
};

export default PostReducers;
