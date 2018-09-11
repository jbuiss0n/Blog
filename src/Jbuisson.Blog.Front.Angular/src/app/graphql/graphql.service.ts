import { Injectable } from '@angular/core';
import { isArray, isString } from 'util';

import { environment } from '../../environments/environment';
import { forEach } from '@angular/router/src/utils/collection';

type IGraphProperty = string | IGraphQuery;

export interface IGraphQuery {
  name: string;
  arguments?: Object;
  properties: Array<IGraphProperty>;
}

@Injectable()
export class GraphService {

  public async Query(query: IGraphQuery | Array<IGraphQuery>) {
    let queryString = this.BuildQueryString(query);

    const response = await fetch(`${environment.graphQLEndpoint}/${queryString}`);
    const json = await response.json();

    if (isArray(query)) {
      return json.data;
    }
    else if (isGraphQuery(query)) {
      return json.data[query.name];
    }
  }

  public BuildQueryString(query: IGraphQuery | Array<IGraphQuery>) {
    let request = '?query={';

    if (isGraphQueryArray(query)) {
      request += this.BuildArrayQueryString(query as Array<IGraphQuery>);
    }
    else if (isGraphQuery(query)) {
      request += this.BuildSingleQueryString(query);
    }

    return request + '}';
  }

  private BuildArrayQueryString(queries: Array<IGraphQuery>): string {
    let request = '';

    for (let i = 0; i < queries.length; i++) {
      request += this.BuildSingleQueryString(queries[i]);
    }

    return request;
  }

  private BuildSingleQueryString(query: IGraphQuery): string {
    let request = query.name;

    if (query.arguments) {
      request += `(${Object.keys(query.arguments).map(key => `${key}:"${query.arguments[key]}"`).join(',')})`;
    }

    request += '{';

    let props = [];

    for (let i = 0; i < query.properties.length; i++) {
      let property = query.properties[i];

      if (isString(property)) {
        props.push(property);
      }
      else if (isGraphQuery(property)) {
        props.push(this.BuildSingleQueryString(property));
      }
    }

    request += props.join(',');

    return request + '}';
  }

  
}

function isGraphQuery(arg: any): arg is IGraphQuery {
  return typeof arg === "object";
}

function isGraphQueryArray(arg: any): arg is Array<IGraphQuery> {
  return typeof arg !== "object";
}
