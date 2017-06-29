import React, { Component } from 'react';

class ToDoContainer extends Component {
    constructor() {
        super();
        this.state = {toDoList: [{text: "one"}, {text: "two"}]};
    }

     componentWillMount()
     {
        this.refresh();
     }

     onSubmit(newToDo) {
        let api = new ToDoApi();
        api.postTodo({text: newToDo}).then(() => this.refresh);
     }

     refresh()
     {
         let api = new ToDoApi();
         api.get().then(result => {
             this.setState({toDoList: result})
         });
     }

    render() {
        return (
            <div>
                <ToDoList list={this.state.toDoList}/>
                <ToDoAdd onSubmit={(value) => this.onSubmit(value)}/>
            </div>
        )
    }
}

const ToDoList = props => {
    let {list} = props;
    return (<table name="listTable">
        {list.map(item => <ToDoItem text={item.text}/>)}
    </table>);
};

const ToDoItem = props => {
    let {text} = props;
    return (<tr>
          <td>{text}</td>
        </tr>);
}

class ToDoAdd extends Component {
    constructor(){
        super();
        this.state = { value: ''};
    }

   handleSubmit(e){
        this.props.onSubmit(this.state.value)
   }

   handleChange(e){
       this.setState({value: e.target.value});
   }

   render() {
       return (
           <div>
               <input type="text" value={this.state.value} onChange={(e) => this.handleChange(e)}/>
               <input type="submit" value="Submit" onClick={(e) => this.handleSubmit(e)}/>
           </div>);
   }
}

class ToDoApi
{
    constructor(){
        this.url = '//localhost:32964/todo'
    }

    get(){
        return fetch(this.url + "/list?format=json").then(response => response.json());
    }

    postTodo(newTodo){

        let init = new Request( this.url, {
            method: 'POST',
            headers: new Headers({
                'Accept': 'application/json; charset=utf-8',
                'content-type': 'application/json; charset=utf-8'
            }),
            mode: 'no-cors',
            body: JSON.stringify(newTodo)
        });

        return fetch(init);
    }
}

// class ToDoList extends Component{
//   render() {
//       let {list} = this.props;
//     return (
//       <table name="listTable">
//         {list.map(item => <ToDoItem text={item.text}/>)}
//       </table>
//     );
//   }
// }

// class ToDoItem extends Component{
//   render() {
//       let {text} = this.props;
//     return (
//         <tr>
//           <td>{text}</td>
//         </tr>
//     );
//   }
// }

export default ToDoContainer;
