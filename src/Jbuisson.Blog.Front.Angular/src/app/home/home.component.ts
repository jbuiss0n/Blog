import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';

import * as Models from '../models';

@Component({
  selector: 'home',
  templateUrl: 'home.component.html',
  styleUrls: ['home.component.less']
})
export class HomeComponent implements OnInit {

  public Posts: Models.IPostModel[];

  constructor(private route: ActivatedRoute) {
  }

  public ngOnInit() {
    this.route.data.subscribe(data => {
      this.Posts = data['Posts'];
    });
  }
}
