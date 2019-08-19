import React, { Component } from 'react';

export class Todo extends Component {
    static displayName = Todo.name;

  constructor (props) {
    super(props);
    this.state = { forecasts: [], loading: true };
    
      fetch('api/Todo')
          .then(response => response.json())
          .then(data => {
              this.setState({ forecasts: data, loading: false });
          }); }


    static renderTodoTable(forecasts) {
        return (
            <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>Описание</th>
                        <th>Подробно</th>
                        <th>Выполнить до</th>
                        <th>Выполнено</th>
                    </tr>
                </thead>
                <tbody>
                    {forecasts.map(forecast =>
                        <tr key={forecast.id}>
                            <td>{forecast.description}</td>
                            <td>{forecast.detail}</td>
                            <td>{forecast.deadLine}</td>
                            <td>{forecast.complete}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }



  render () {
      let contents = this.state.loading
          ? <p><em>Loading...</em></p>
          : Todo.renderTodoTable(this.state.forecasts)
    return (
        <div>
            <h1>Current Todos</h1>
            <p></p>
            {contents}
        </div>

    );
  }
}
