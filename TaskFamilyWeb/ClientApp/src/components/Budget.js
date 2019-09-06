import React, { Component } from 'react';

export class Budget extends Component {
    static displayName = Budget.name;

  constructor (props) {
    super(props);
    this.state = { forecasts: [], loading: true };
    
      fetch('api/Budget')
          .then(response => response.json())
          .then(data => {
              this.setState({ forecasts: data, loading: false });
          }); }


    static renderTodoTable(forecasts) {
        return (
            <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>Description</th>
                        <th>Balance</th>
                    </tr>
                </thead>
                <tbody>
                    {forecasts.map(forecast =>
                        <tr key={forecast.purseId}>
                            <td>{forecast.purseDescription}</td>
                            <td>{forecast.balance}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }



  render () {
      let contents = this.state.loading
          ? <p><em>Loading...</em></p>
          : Budget.renderTodoTable(this.state.forecasts)
    return (
        <div>
            <h1>Current Finance</h1>
            <p></p>
            {contents}
        </div>

    );
  }
}
