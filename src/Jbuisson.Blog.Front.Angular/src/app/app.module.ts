import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import * as Home from './home';
import * as Post from './post';
import * as Graph from './graphql';
import * as Resolve from './app.resolves';

import { AppComponent } from './app.component';
import { AppRoutes } from './app.routes';

@NgModule({
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      ...AppRoutes
    ]),
  ],
  declarations: [
    AppComponent,
    Home.HomeComponent,
    Post.PostComponent,
  ],
  providers: [
    Graph.GraphService,
    Resolve.PostResolve,
    Resolve.PostsResolve,
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
