import * as Moment from 'moment';
import * as React from 'react';

import * as Types from '../types';

class Comment extends React.Component<Types.IComment> {
  public render() {
    return (
      <div className="blog-comment">
        <p>{this.props.Content}</p>
        <p className="blog-comment-meta">{Moment(this.props.CreateddAt).format('MMM D, YYYY')}, by {this.props.Author}</p>
      </div>
    );
  }
};

export default Comment;
