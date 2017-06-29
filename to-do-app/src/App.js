import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import ToDoContainer from "./containers/to-do-list";

class App extends Component {
  render() {
    return (
      <div className="App">
        <div className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h2>To-Do App</h2>
        </div>
        <div id="list">
            <ToDoContainer/>
        </div>
        <div id="info">

        </div>
      </div>
    );
  }
}

export default App;
