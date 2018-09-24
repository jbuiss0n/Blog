import * as Entities from './entities';

export * from './entities';

export interface IAppState {
  Entities: Entities.IEntities;
  Posts?: string[];
}
