import { IPost } from './post';
import { IComment } from './comment';

export * from './post';
export * from './comment';

export interface IEntities {
  Posts: { [title: string]: IPost; };
  Comments: { [id: number]: IComment; };
}
