import React, { Component } from 'react';
import Modal from 'react-bootstrap/Modal'
import Button from 'react-bootstrap/Button'
import Form from 'react-bootstrap/Form'

export class Budget extends React.Component
{
    static displayName = Budget.name;
    static flag;

  constructor () {
    super();
      this.state = { show: false, forecasts: [], loading: true }
      fetch('api/Budget')
          .then(response => response.json())
          .then(data => {
              this.setState({ showAddForm: false, forecasts: data, loading: false });
          })
      this.handleClose = this.handleClose.bind(this)
      this.handleShow = this.handleShow.bind(this)
      this.handleSave = this.handleSave.bind(this)
}

    handleClose() {
        this.setState({ showAddForm: false })
    }

    handleShow() {
        this.setState({ showAddForm: true })
    }

    handleSave() {
        this.setState({ showAddForm: false })
    }

    viewAddForm() {
       return (
            <div>
               <Button variant="primary" onClick={this.handleShow}>
                   Add record  
                </Button>
               <Modal show={this.state.showAddForm} onHide={this.handleClose}>
                   <Modal.Header closeButton>
                       <Modal.Title>Add accounting record</Modal.Title>
                   </Modal.Header>
                   <Modal.Body>
                        <Form.Group controlId="formTotal">
                            <Form.Label>Total</Form.Label>
                            <Form.Control type="sm" placeholder="Enter total" />
                        </Form.Group>
                       <Form.Group controlId="formPurse">
                           <Form.Label>Purse</Form.Label>
                           <Form.Control as="select">
                               <option value="1">Наличка</option>
                               <option value="2">Зарплатная карта</option>
                               <option>3</option>
                               <option>4</option>
                               <option>5</option>
                           </Form.Control>
                       </Form.Group>
                       <Form.Group controlId="formDate">
                           <Form.Label>Date</Form.Label>
                           <Form.Control type="sm" placeholder="Enter date" />
                       </Form.Group>
                       <Form.Group controlId="formComment">
                           <Form.Label>Comment</Form.Label>
                           <Form.Control type="sm" placeholder="Enter Comment" />
                       </Form.Group>
                       <Form.Group controlId="formDirect">
                           <Form.Check type="checkbox" label="Incoming" />
                       </Form.Group>
                   </Modal.Body>
                   <Modal.Footer>
                       <Button variant="secondary" onClick={this.handleClose}>
                           Close
                        </Button>
                       <Button variant="primary" onClick={this.handleSave}>
                           Save Changes
                        </Button>
                   </Modal.Footer>
               </Modal>

        </div>
        );
    }

    renderTodoTable(forecasts)
    {
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

    render()
    {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderTodoTable(this.state.forecasts);
        let buttons = this.viewAddForm();
 
    return (
        <div>
            <h1>Current Finance</h1>
            {buttons}
            <p></p>
            {contents}
        </div>
        );
    }
}
