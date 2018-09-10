import { Component, OnInit } from '@angular/core';

import * as Models from '../models';

@Component({
  selector: 'home',
  templateUrl: 'home.component.html',
  styleUrls: ['home.component.less']
})
export class HomeComponent implements OnInit {

  public Posts: Models.IPostModel[];

  public async ngOnInit() {
    const response = await fetch('https://localhost:44394/?query={posts{id,title,canonicalTitle,preview,publishedAt,viewsCount,commentsCount}}');
    const json = await response.json();

    this.Posts = json.data.posts;
  }
}
