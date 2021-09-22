import React, { Component } from 'react';

export class Test extends Component {
    static displayName = Test.name;

    constructor(props) {
        super(props);
        this.state = { hairdressers: [] };
    }

    componentDidMount() {
        this.populateHairdressersData();
    }

    render() {
        return (
            <div>
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>First name</th>
                            <th>Last name</th>
                            <th>Nick name</th>
                            <th>Mobile phone</th>
                            <th>Landline phone</th>
                            <th>Address</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.hairdressers.map(hairdresser =>
                            <tr key={hairdresser.firstName}>
                                <td>{hairdresser.firstName}</td>
                                <td>{hairdresser.lastName}</td>
                                <td>{hairdresser.nickName}</td>
                                <td>{hairdresser.mobilePhone}</td>
                                <td>{hairdresser.landlinePhone}</td>
                                <td>{hairdresser.address}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
                <br />
                <button className="btn btn-primary" onClick={this.addHairdresser}>Add hairdresser</button>

                <button className="btn btn-primary btn-margin" onClick={this.updateHairdresser}>Update hairdresser</button>
            </div>
        );
    }

    addHairdresser() {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ firstName: 'Ilija', lastName: 'Petrovic' })
        };
        fetch('default/add', requestOptions)
            .then(response => response.json());
    }

    async updateHairdresser() {
        const requestOptions = {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ firstName: 'Ilija', lastName: 'Jankovic', address: 'New Address', mobilePhone: '123', landlinePhone: '123' })
        };

        const response = await fetch('default/update', requestOptions);
        var data = await response.json();

        alert(`Successfuly updated hairdreser ${data[0].firstName} ${data[0].lastName}`);
        alert('Successfuly updated hairdreser ' + data[0].firstName + ' ' + data[0].lastName);
    }

    async populateHairdressersData() {
        const response = await fetch('default');
        const data = await response.json();
        this.setState({ hairdressers: data });
    }
}