import * as React from 'react';
import { compose } from 'redux';
import { connect } from 'react-redux';
import { Action } from 'redux-actions';
import { withRouter, RouteComponentProps } from 'react-router';

import PostDetails from '../components/post-details';

import * as Types from '../types';
import * as Actions from '../actions';

interface IPostDispatchProps {
  LoadPost: () => Promise<Action<Actions.IApiResult<Types.IPost>>>;
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
    await this.props.LoadPost();
  }

  public render() {

    const { Post, Comments } = this.props;

    if (!Post) {
      return (<div>loading...</div>);
    }

    return (
      <div>
        <PostDetails {...Post} />
        <div>{Comments
          ? Comments.map(comment => <div key={comment.Id}>{comment.Content}</div>)
          : <div>loading...</div>}
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
  };
}

export default compose(withRouter, connect(mapStateToProps, mapDispatchToProps))(Post);
