import Entities from './entities';

import * as Types from '../types';
import * as Constants from '../constants';

const reducer = (state, action) => {
  const newState: Types.IAppState = {
    Entities: Entities(state, action),
  };

  if (action.type === Constants.POSTS_SUCCESS) {
    newState.Posts = action.payload.result;
  }

  return newState;
};

export default reducer;
