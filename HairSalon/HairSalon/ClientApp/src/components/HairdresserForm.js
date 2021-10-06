import React, { Component } from 'react';

export class HairdresserForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = { firstName: '', lastName: '' };

        this.handleFirstNameChange = this.handleFirstNameChange.bind(this);
        this.handleLastNameChange = this.handleLastNameChange.bind(this);
        this.handleNickNameChange = this.handleNickNameChange.bind(this);
        this.addHairdresser = this.addHairdresser.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleFirstNameChange(event) {
        this.setState({ firstName: event.target.value });
    }
    
    
    handleLastNameChange(event) {
        this.setState({ lastName: event.target.value });
    }

    handleNickNameChange(event) {
        this.setState({ nickName: event.target.value });
    }
    handleSubmit(event) {
        event.preventDefault();

        this.addHairdresser();
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <label>
                    First Name:
                    <input type="text" value={this.state.firstName} onChange={this.handleFirstNameChange} />
                </label>
                <br />

                <label>
                    Last Name:
                    <input type="text" value={this.state.lastName} onChange={this.handleLastNameChange} />
                </label>

                <br />

                <label>
                    Nick Name:
                    <input type="text" value={this.state.nickName} onChange={this.handleNickNameChange} />
                </label>

                <br />
                <input className="btn btn-primary" type="submit" value="Add hairdresser" />
            </form>
        );
    }

    async addHairdresser() {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ firstName: this.state.firstName, lastName: this.state.lastName, nickName: this.state.nickName })
        };
        var response = await fetch('default/add', requestOptions);
        var data = await response.json();

        this.props.home.setState({ hairdressers: data });
    }
}