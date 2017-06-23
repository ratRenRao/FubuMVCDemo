var TodoList = React.createClass({
    isComplete: function(item) {
        return item.IsComplete ? 'complete' : '';
    },
    render: function () {
        var that = this;
        var createItem = function (item) {

            return (
            <li key={item.Id} className={that.isComplete(item)}>
                {item.Text}
                <img onClick={that.props.complete.bind(that, item)} src="../Images/check.png" className="check" alt="Mark Todo Complete" />
                <img onClick={that.props.handleDelete.bind(that, item)} src="../Images/trash.png" alt="Delete Todo" />
            </li>
            );
        };
        return <ul>{this.props.items.map(createItem)}</ul>;
    }
});
var TodoApp = React.createClass({
    getInitialState: function() {
        return {items: [], Text: ''};
    },
    componentDidMount: function () {
        this.serverRequest = Rest.get("todo/list", function (result) {
            
            this.setState({
                items: JSON.parse(result.response).Items,
                Text: ''
            });
        }.bind(this));
    },

    onChange: function(e) {
        this.setState({Text: e.target.value});
    },
    handleSubmit: function(e) {
        e.preventDefault();
        var that = this;

        Rest.post('todo', { Text: this.state.Text }, function(result) {
        
            var nextItems = that.state.items.concat([JSON.parse(result.response).TodoItem]);

            that.setState({items: nextItems});
        });
    },

    handleDelete: function (item) {
        var that = this;

        Rest.post('todo/delete', { Id: item.Id }, function (result) {
            if (result.code === 404) {
                alert('item does not exist');
                return;
            }

            let itemIdx = that.state.items.indexOf(item);
            that.state.items.splice(itemIdx, 1);

            that.setState({ items: that.state.items });
        });
    },
    complete: function (item) {
        var that = this;

        Rest.post('todo/markcomplete', { Item: item }, function (result) {
            if (result.code === 404) {
                alert('item does not exist');
                return;
            }

            //let itemIdx = that.state.items.indexOf(item);
            item.IsComplete = true;

            that.setState({ items: that.state.items });
        });
    },
    render: function() {
        return (
            <div>
                <form onSubmit={this.handleSubmit}>
                <input placeholder="+todo" onChange={this.onChange} value={this.state.Text} />
                <button>Add</button>
                </form>
                <TodoList items={this.state.items} handleDelete={this.handleDelete} complete={this.complete} />
            </div>
        );
}
});

ReactDOM.render(<TodoApp />, document.getElementById('flexReact'));

