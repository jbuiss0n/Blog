import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';

import * as Models from './models';
import * as GraphQl from './graphql';

@Injectable()
export class PostResolve implements Resolve<Models.IPostModel> {

  constructor(private router: Router,
    private graph: GraphQl.GraphService) {
  }

  resolve(route: ActivatedRouteSnapshot): Promise<Models.IPostModel> {
    var title = route.params['title'];

    return this.graph.Query({
      name: 'post',
      arguments: { title: title },
      properties: [
        'id',
        'title',
        'content',
        'publishedAt',
        'viewsCount',
        'commentsCount',
        {
          name: 'comments',
          properties: [
            'id',
            'author',
            'content',
            'createdAt'
          ]
        }
      ]
    });
  }
}

@Injectable()
export class PostsResolve implements Resolve<Array<Models.IPostModel>> {

  constructor(private router: Router,
    private graph: GraphQl.GraphService) {
  }

  resolve(route: ActivatedRouteSnapshot): Promise<Array<Models.IPostModel>> {
    return this.graph.Query({
      name: 'posts',
      properties: [
        'id',
        'title',
        'preview',
        'publishedAt',
        'viewsCount',
        'commentsCount'
      ]
    });
  }
}
