import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { Router, Route, Switch, Link } from 'react-router-dom';

import DevTools from './containers/dev-tools';
import RegisterServiceWorker from './registerServiceWorker';
import CreateHistory from 'history/createBrowserHistory';
import ConfigureStore from './store';

import Home from './containers/home';
import Post from './containers/post';

const store = ConfigureStore();
const history = CreateHistory();

ReactDOM.render(
  <Provider store={store}>
    <Router history={history}>
      <div className="container" id="top">
        <main role="main" className="container">
          <div className="row">
            <div className="col-md-8 blog-main">
              <h1 className="pb-3 mb-4 font-italic border-bottom"><Link to="/">Jbuisson.Blog.React</Link></h1>
              <Switch>
                <Route path="/:title" component={Post} />
                <Route path="/" component={Home} />
              </Switch>
            </div>
            <aside className="col-md-4 blog-sidebar">
              <div className="p-3 mb-3 bg-light rounded">
                <h4 className="font-italic">About</h4>
                <p className="mb-0">Etiam porta <em>sem malesuada magna</em> mollis euismod. Cras mattis consectetur purus sit amet fermentum. Aenean lacinia bibendum nulla sed consectetur.</p>
              </div>
              <div className="p-3">
                <h4 className="font-italic">Elsewhere</h4>
                <ol className="list-unstyled">
                  <li><a href="#">GitHub</a></li>
                  <li><a href="#">Twitter</a></li>
                  <li><a href="#">Linkedin</a></li>
                </ol>
              </div>
            </aside>
          </div>
        </main>
        <footer className="container blog-footer">
          <p><a href="#top">Back to top</a></p>
        </footer>
        <DevTools />
      </div>
    </Router>
  </Provider>,
  document.getElementById('root')
);

RegisterServiceWorker();
