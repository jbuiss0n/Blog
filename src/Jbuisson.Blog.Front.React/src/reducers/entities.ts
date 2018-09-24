import merge from 'lodash/merge';

import * as Types from '../types';

const Entities = (state: Types.IAppState, action): Types.IEntities => {
  let entities: Types.IEntities = {
    Posts: {},
    Comments: {},
  };

  if (action.payload && action.payload.entities) {
    entities = merge(entities, state.Entities, action.payload.entities);
  }

  return entities;
};

export default Entities;
