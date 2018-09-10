import { Injectable } from '@angular/core';

import { environment } from '../../environments/environment';
import { isArray, isString } from 'util';
import { forEach } from '@angular/router/src/utils/collection';

// graph.query({name: 'post', args: { id: 1 }, properties: ['id', 'title', { 'comments': ['id', 'author'] }]});

type IGraphProperty = string | { [relation: string]: Array<IGraphProperty> };

export interface IGraphQuery {
  name: string;
  arguments?: Object;
  properties: Array<IGraphProperty>;
}

@Injectable()
export class GraphService {
  public Query(query: IGraphQuery | Array<IGraphQuery>) {
    let request = '?query={';

    if (isArray(query)) {
    }
    else {
      request += query.name;

      if (query.arguments) {
        request += `(${Object.keys(query.arguments).map(key => `${key}:${query.arguments[key]}`).join(',')})`;
      }

      for (var property in query.properties) {

        if (!isString(property)) {
          
        }

      }
    }

    request += '}';
  }
}
