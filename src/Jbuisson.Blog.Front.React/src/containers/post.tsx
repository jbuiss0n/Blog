import * as React from 'react';
import { compose } from 'redux';
import { connect } from 'react-redux';
import { Action } from 'redux-actions';
import { withRouter, RouteComponentProps } from 'react-router';

import PostDetails from '../components/post-details';
import Comment from '../components/comment';

import * as Types from '../types';
import * as Actions from '../actions';

interface IPostDispatchProps {
  LoadPost: () => Promise<Action<Actions.IApiResult<Types.IPost>>>;
  LoadComments: () => Promise<Action<Actions.IApiResult<Types.IComment[]>>>;
}

interface IPostStateProps {
  Post?: Types.IPost;
  Comments?: Types.IComment[];
}

interface IPostRouteProps {
  title: string;
}

class Post extends React.Component<IPostDispatchProps & IPostStateProps & RouteComponentProps<IPostRouteProps>, Types.IAppState> {

  public async componentDidMount() {

    if (!this.props.Comments) {
      await this.props.LoadComments();
    }
    if (!this.props.Post) {
      await this.props.LoadPost();
    }
  }

  public render() {
    const { Post, Comments } = this.props;

    if (!Post) {
      return (<div>Loading...</div>);
    }

    return (
      <div className="post">
        <PostDetails {...Post} />
        <div className="post-comments">{Comments
          ? Comments.map(comment => <Comment key={comment.Id} {...comment} />)
          : <div>Loading comments...</div>}
        </div>
      </div>
    );
  }
}

const mapStateToProps = (state: Types.IAppState, route: RouteComponentProps<IPostRouteProps>): IPostStateProps => {
  const post = state.Entities.Posts[route.match.params.title];

  return {
    Post: post,
    Comments: post && post.Comments && post.Comments.map(id => state.Entities.Comments[id]),
  };
}

const mapDispatchToProps = (dispatch, route: RouteComponentProps<IPostRouteProps>): IPostDispatchProps => {
  return {
    LoadPost: () => dispatch(Actions.POST_TITLE_REQUEST(route.match.params.title)),
    LoadComments: () => dispatch(Actions.POST_COMMENTS_REQUEST(route.match.params.title)),
  };
}

export default compose(withRouter, connect(mapStateToProps, mapDispatchToProps))(Post);
