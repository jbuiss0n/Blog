import * as React from 'react';
import { compose } from 'redux';
import { connect } from 'react-redux';
import { Action } from 'redux-actions';
import { withRouter } from 'react-router';

import PostPreview from '../components/post-preview';

import * as Types from '../types';
import * as Actions from '../actions';

interface IHomeDispatchProps {
  LoadPosts: () => Promise<Action<Actions.IApiResult<Types.IPost[]>>>;
}

interface IHomeStateProps {
  Posts: Types.IPost[];
}

class Home extends React.Component<IHomeDispatchProps & IHomeStateProps, Types.IAppState> {

  public async componentDidMount() {
    await this.props.LoadPosts();
  }

  public render() {
    const { Posts } = this.props;

    if (!Posts) {
      return (<div>loading...</div>);
    }

    return Posts.map(post => <PostPreview key={post.Id} {...post} />);
  }
}

const mapStateToProps = (state: Types.IAppState) => {
  return {
    Posts: state.Posts && state.Posts.map(title => state.Entities!.Posts[title]),
  };
}

const mapDispatchToProps = (dispatch) => {
  return {
    LoadPosts: () => dispatch(Actions.POSTS_REQUEST()),
  };
}

export default compose(withRouter, connect(mapStateToProps, mapDispatchToProps))(Home);
