import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';

import * as Models from '../models';

@Component({
  selector: 'post',
  templateUrl: 'post.component.html',
  styleUrls: ['post.component.less']
})
export class PostComponent implements OnInit {

  public Post: Models.IPostModel;

  constructor(private route: ActivatedRoute) {
  }

  public ngOnInit() {
    this.route.data.subscribe(data => {
      this.Post = data['Post'];
    });
  }
}
