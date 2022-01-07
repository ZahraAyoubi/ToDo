import React, { Component } from 'react';
import { variables } from './Variables';
import { FiDelete, FiEdit } from 'react-icons/fi';
import moment from 'moment'

export class ToDo extends Component {

    constructor(props) {
        super(props);

        this.state = {
            todoItems: []
        };
    }
    
    populatToDoData() {
        fetch(variables.ToDoListAPI + 'todolist',
            {
                method: 'Get', 
                headers: { 'Accept': 'application/json' },
            })
            .then((response) => {
                return response.json()
            })
            .then((res) => {
                this.setState({
                    todoItems: res.data
                })
                console.log('parsed json', res.data)
                console.log('todolist is:', this.state.todoItems)
            })
            .catch((ex) => {
                console.log('parsing failed', ex)
            })       
    }

    componentDidMount(){
        this.populatToDoData();
    }

    render() {
        const { todoItems } = this.state;
        
        return (
            <div>
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Description</th>
                        <th>Create date</th>
                        <th>Completion</th>
                        <th>Options</th>
                    </tr>
                </thead>
                <tbody>
                        {todoItems.map((item, index) =>
                            <tr key={index}>
                                <td>{item.name}</td>
                                <td>{item.description}</td>
                                <td>{moment(item.date).format('LLL')}</td>
                                <td>{item.isCompelete}</td>
                                <td>
                                <button icon={<FiDelete />}></button>
                            </td>
                            <td>
                                <button icon={<FiEdit />}></button>
                            </td>
                    </tr>
                    )}
                </tbody>
                </table>
            </div>
        );
    }
}
