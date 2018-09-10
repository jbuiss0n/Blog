import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import * as Home from './home';
import * as Post from './post';

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
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule { }
