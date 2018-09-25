import * as Types from '../types';

import Entities from './entities';
import PostReducers from './posts';
import CommentReducers from './comments';

const reducer = (state: Types.IAppState, action) => {
  const newState: Types.IAppState = {
    Entities: Entities(state, action),
  };

  PostReducers(newState, action);
  CommentReducers(newState, action);

  return newState;
};

export default reducer;
