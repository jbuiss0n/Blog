import { schema } from 'normalizr';

export const Comment = new schema.Entity('Comments', {}, {
  idAttribute: comment => comment.Id
});

export const Post = new schema.Entity('Posts', {
  Comments: [Comment]
}, {
    idAttribute: post => post.CanonicalTitle
  });
