﻿import React, { Component } from 'react';

export class Test extends Component {
    static displayName = Test.name;

    constructor(props) {
        super(props);
        this.state = { hairdressers: []};
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
                                <td>{hairdresser.nickName}</td>
                                <td>{hairdresser.lastName}</td>
                                <td>{hairdresser.mobilePhone}</td>
                                <td>{hairdresser.landlinePhone}</td>
                                <td>{hairdresser.address}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        );
    }

    async populateHairdressersData() {
        const response = await fetch('default');
        const data = await response.json();
        this.setState({ hairdressers: data });
    }
}