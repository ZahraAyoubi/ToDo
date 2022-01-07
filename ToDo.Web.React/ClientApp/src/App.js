import React, { Component } from 'react';
import { Route } from "react-router-dom";
import { Home } from './components/Home';
import './custom.css'
import { MyDay } from './components/ToDos/MyDay';
import { Layout } from './components/Layout';
import { Family } from './components/ToDos/Family'
import { ToDo} from './components/ToDos/ToDo'
import { Geroceries } from './components/ToDos/Geroceries'
import { Travel } from './components/ToDos/Travel'
import { Work } from './components/ToDos/Work';
import { NewList } from './components/ToDos/NewList';


export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <Route path="/myday" component={MyDay} />
                <Route path="/family" component={Family} />
                <Route path="/todo" component={ToDo} />
                <Route path="/geroceries" component={Geroceries} />
                <Route path="/travel" component={Travel} />
                <Route path="/work" component={Work} />
                <Route path="/newlist" component={NewList} />
            </Layout>
        );
    }
}

