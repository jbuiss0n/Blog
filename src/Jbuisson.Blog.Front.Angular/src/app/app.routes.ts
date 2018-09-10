import { Route } from '@angular/router';

import { HomeComponent } from './home';
import { PostComponent } from './post';

export const AppRoutes: Route[] = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: ':id',
    component: PostComponent,
  },
];
