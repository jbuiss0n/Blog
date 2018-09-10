import { Component, OnInit } from '@angular/core';

import * as Models from '../models';

@Component({
  selector: 'post',
  templateUrl: 'post.component.html',
  styleUrls: ['post.component.less']
})
export class PostComponent implements OnInit {

  public Post: Models.IPostModel;

  public async ngOnInit() {



    const response = await fetch('https://localhost:44394/?query={post(id:1){id,title,content,publishedAt,viewsCount,commentsCount,comments{id,author,content,createdAt}}}');
    const json = await response.json();

    this.Post = json.data.post;
  }
}
