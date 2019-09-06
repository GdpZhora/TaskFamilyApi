import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Budget } from './components/Budget';
import { Counter } from './components/Counter';
import { Todo } from './components/ToDo';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
            <Route path='/Todo' component={Todo} />
            <Route path='/Budget' component={Budget} />
      </Layout>
    );
  }
}
