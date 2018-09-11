module.exports = (req, res, next) => {
  if (!req.url.startsWith('/graphql')) return next();

  res.header('Content-Type', 'application/json');

  if (req.url === '/graphql/?query={posts{id,title,preview,publishedAt,viewsCount,commentsCount}}') {
    return res.send(JSON.stringify(require('../mocks/graphql/query-posts.json')));
  }

  if (req.url === '/graphql/?query={post(title:%22this-is-the-first-blog-post%22){id,title,content,publishedAt,viewsCount,commentsCount,comments{id,author,content,createdAt}}}') {
    return res.send(JSON.stringify({ data: { post: require('../mocks/graphql/query-posts.json').data.posts[0] } }));
  }

  if (req.url === '/graphql/?query={post(title:%22this-is-the-second-blog-post%22){id,title,content,publishedAt,viewsCount,commentsCount,comments{id,author,content,createdAt}}}') {
    return res.send(JSON.stringify({ data: { post: require('../mocks/graphql/query-posts.json').data.posts[1] } }));
  }

  if (req.url === '/graphql/?query={post(title:%22this-is-the-third-blog-post%22){id,title,content,publishedAt,viewsCount,commentsCount,comments{id,author,content,createdAt}}}') {
    return res.send(JSON.stringify({ data: { post: require('../mocks/graphql/query-posts.json').data.posts[2] } }));
  }

  res.send(JSON.stringify(require('../mocks/graphql/empty.json')));
};
