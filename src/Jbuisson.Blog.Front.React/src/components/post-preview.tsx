import * as Moment from 'moment';
import * as React from 'react';
import { Link } from "react-router-dom";

import * as Types from '../types';

class PostPreview extends React.Component<Types.IPost> {
  public render() {
    return (
      <div className="blog-post">
        <h2 className="blog-post-title"><Link to={this.props.CanonicalTitle}>{this.props.Title}</Link></h2 >
        <p className="blog-post-meta">{Moment(this.props.PublishedAt).format('MMM D, YYYY')}</p>
        <p className="blog-post-preview">{this.props.Preview}</p>
        <hr />
        <p>
          <span className="blog-post-meta-views">{this.props.ViewsCount.toLocaleString('en-US', { minimumFractionDigits: 0 })} views</span>
          <span> - </span>
          {this.props.CommentsCount
            ? (<Link className="blog-post-meta-comments" to={this.props.CanonicalTitle}>{this.props.CommentsCount.toLocaleString('en-US', { minimumFractionDigits: 0 })} comments</Link>)
            : (<Link className="blog-post-meta-comments" to={this.props.CanonicalTitle}>no comments</Link>)}
        </p>
      </div>
    );
  }
};

export default PostPreview;
