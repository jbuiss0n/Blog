import { Route } from '@angular/router';

import * as Resolve from './app.resolves';

import { HomeComponent } from './home';
import { PostComponent } from './post';

export const AppRoutes: Route[] = [
  {
    path: '',
    component: HomeComponent,
    resolve: {
      Posts: Resolve.PostsResolve,
    }
  },
  {
    path: ':title',
    component: PostComponent,
    resolve: {
      Post: Resolve.PostResolve,
    }
  },
];
