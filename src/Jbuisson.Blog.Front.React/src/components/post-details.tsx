import * as Moment from 'moment';
import * as React from 'react';

import * as Types from '../types';

class PostPreview extends React.Component<Types.IPost> {
  public render() {
    return (
      <div className="blog-post">
        <h2 className="blog-post-title">{this.props.Title}</h2>
        <p className="blog-post-meta">{Moment(this.props.PublishedAt).format('d MMM YYYY')} - {this.props.ViewsCount.toLocaleString(navigator.language, { minimumFractionDigits: 0 })} views</p>
        <p>{this.props.Content}</p>
        <hr />
      </div>
    );
  }
};

export default PostPreview;
