var TodoList = React.createClass({
    isComplete: function (item) {
        return item.IsComplete ? 'complete' : '';
    },
    render: function () {
        var that = this;
        var createItem = function (item) {

            return React.createElement(
                'li',
                { key: item.Id, className: that.isComplete(item) },
                item.Text,
                React.createElement('img', { onClick: that.props.complete.bind(that, item), src: '../Images/check.png', className: 'check', alt: 'Mark Todo Complete' }),
                React.createElement('img', { onClick: that.props.handleDelete.bind(that, item), src: '../Images/trash.png', alt: 'Delete Todo' })
            );
        };
        return React.createElement(
            'ul',
            null,
            this.props.items.map(createItem)
        );
    }
});

var TodoApp = React.createClass({
    getInitialState: function () {
        return { items: [], Text: '' };
    },
    componentDidMount: function () {
        this.serverRequest = Rest.get("todo/list", function (result) {

            this.setState({
                items: JSON.parse(result.response).Items,
                Text: ''
            });
        }.bind(this));
    },

    onChange: function (e) {
        this.setState({ Text: e.target.value });
    },
    handleSubmit: function (e) {
        e.preventDefault();
        var that = this;

        Rest.post('todo', { Text: this.state.Text }, function (result) {

            var nextItems = that.state.items.concat([JSON.parse(result.response).TodoItem]);

            that.setState({ items: nextItems });
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
    render: function () {
        return React.createElement(
            'div',
            null,
            React.createElement(
                'form',
                { onSubmit: this.handleSubmit },
                React.createElement('input', { placeholder: '+todo', onChange: this.onChange, value: this.state.Text }),
                React.createElement(
                    'button',
                    null,
                    'Add'
                )
            ),
            React.createElement(TodoList, { items: this.state.items, handleDelete: this.handleDelete, complete: this.complete })
        );
    }
});

ReactDOM.render(React.createElement(TodoApp, null), document.getElementById('flexReact'));

//# sourceMappingURL=data:application/json;base64,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QWlDLENBQWpDOztBQUVBLGlCQUFLLFFBQUwsQ0FBYyxFQUFFLE9BQU8sS0FBSyxLQUFMLENBQVcsS0FBcEIsRUFBZDtBQUNILFNBVkQ7QUFXSCxLQTNDMkI7QUE0QzVCLGNBQVUsVUFBVSxJQUFWLEVBQWdCO0FBQ3RCLFlBQUksT0FBTyxJQUFYOztBQUVBLGFBQUssSUFBTCxDQUFVLG1CQUFWLEVBQStCLEVBQUUsTUFBTSxJQUFSLEVBQS9CLEVBQStDLFVBQVUsTUFBVixFQUFrQjtBQUM3RCxnQkFBSSxPQUFPLElBQVAsS0FBZ0IsR0FBcEIsRUFBeUI7QUFDckIsc0JBQU0scUJBQU47QUFDQTtBQUNIOztBQUVEO0FBQ0EsaUJBQUssVUFBTCxHQUFrQixJQUFsQjs7QUFFQSxpQkFBSyxRQUFMLENBQWMsRUFBRSxPQUFPLEtBQUssS0FBTCxDQUFXLEtBQXBCLEVBQWQ7QUFDSCxTQVZEO0FBV0gsS0ExRDJCO0FBMkQ1QixZQUFRLFlBQVc7QUFDZixlQUNJO0FBQUE7QUFBQTtBQUNJO0FBQUE7QUFBQSxrQkFBTSxVQUFVLEtBQUssWUFBckI7QUFDQSwrQ0FBTyxhQUFZLE9BQW5CLEVBQTJCLFVBQVUsS0FBSyxRQUExQyxFQUFvRCxPQUFPLEtBQUssS0FBTCxDQUFXLElBQXRFLEdBREE7QUFFQTtBQUFBO0FBQUE7QUFBQTtBQUFBO0FBRkEsYUFESjtBQUtJLGdDQUFDLFFBQUQsSUFBVSxPQUFPLEtBQUssS0FBTCxDQUFXLEtBQTVCLEVBQW1DLGNBQWMsS0FBSyxZQUF0RCxFQUFvRSxVQUFVLEtBQUssUUFBbkY7QUFMSixTQURKO0FBU1A7QUFyRStCLENBQWxCLENBQWQ7O0FBd0VBLFNBQVMsTUFBVCxDQUFnQixvQkFBQyxPQUFELE9BQWhCLEVBQTZCLFNBQVMsY0FBVCxDQUF3QixXQUF4QixDQUE3QiIsImZpbGUiOiJUb2RvLnJlYWN0LmpzIiwic291cmNlc0NvbnRlbnQiOlsi77u/dmFyIFRvZG9MaXN0ID0gUmVhY3QuY3JlYXRlQ2xhc3Moe1xyXG4gICAgaXNDb21wbGV0ZTogZnVuY3Rpb24oaXRlbSkge1xyXG4gICAgICAgIHJldHVybiBpdGVtLklzQ29tcGxldGUgPyAnY29tcGxldGUnIDogJyc7XHJcbiAgICB9LFxyXG4gICAgcmVuZGVyOiBmdW5jdGlvbiAoKSB7XHJcbiAgICAgICAgdmFyIHRoYXQgPSB0aGlzO1xyXG4gICAgICAgIHZhciBjcmVhdGVJdGVtID0gZnVuY3Rpb24gKGl0ZW0pIHtcclxuXHJcbiAgICAgICAgICAgIHJldHVybiAoXHJcbiAgICAgICAgICAgIDxsaSBrZXk9e2l0ZW0uSWR9IGNsYXNzTmFtZT17dGhhdC5pc0NvbXBsZXRlKGl0ZW0pfT5cclxuICAgICAgICAgICAgICAgIHtpdGVtLlRleHR9XHJcbiAgICAgICAgICAgICAgICA8aW1nIG9uQ2xpY2s9e3RoYXQucHJvcHMuY29tcGxldGUuYmluZCh0aGF0LCBpdGVtKX0gc3JjPVwiLi4vSW1hZ2VzL2NoZWNrLnBuZ1wiIGNsYXNzTmFtZT1cImNoZWNrXCIgYWx0PVwiTWFyayBUb2RvIENvbXBsZXRlXCIgLz5cclxuICAgICAgICAgICAgICAgIDxpbWcgb25DbGljaz17dGhhdC5wcm9wcy5oYW5kbGVEZWxldGUuYmluZCh0aGF0LCBpdGVtKX0gc3JjPVwiLi4vSW1hZ2VzL3RyYXNoLnBuZ1wiIGFsdD1cIkRlbGV0ZSBUb2RvXCIgLz5cclxuICAgICAgICAgICAgPC9saT5cclxuICAgICAgICAgICAgKTtcclxuICAgICAgICB9O1xyXG4gICAgICAgIHJldHVybiA8dWw+e3RoaXMucHJvcHMuaXRlbXMubWFwKGNyZWF0ZUl0ZW0pfTwvdWw+O1xyXG4gICAgfVxyXG59KTtcclxudmFyIFRvZG9BcHAgPSBSZWFjdC5jcmVhdGVDbGFzcyh7XHJcbiAgICBnZXRJbml0aWFsU3RhdGU6IGZ1bmN0aW9uKCkge1xyXG4gICAgICAgIHJldHVybiB7aXRlbXM6IFtdLCBUZXh0OiAnJ307XHJcbiAgICB9LFxyXG4gICAgY29tcG9uZW50RGlkTW91bnQ6IGZ1bmN0aW9uICgpIHtcclxuICAgICAgICB0aGlzLnNlcnZlclJlcXVlc3QgPSBSZXN0LmdldChcInRvZG8vbGlzdFwiLCBmdW5jdGlvbiAocmVzdWx0KSB7XHJcbiAgICAgICAgICAgIFxyXG4gICAgICAgICAgICB0aGlzLnNldFN0YXRlKHtcclxuICAgICAgICAgICAgICAgIGl0ZW1zOiBKU09OLnBhcnNlKHJlc3VsdC5yZXNwb25zZSkuSXRlbXMsXHJcbiAgICAgICAgICAgICAgICBUZXh0OiAnJ1xyXG4gICAgICAgICAgICB9KTtcclxuICAgICAgICB9LmJpbmQodGhpcykpO1xyXG4gICAgfSxcclxuXHJcbiAgICBvbkNoYW5nZTogZnVuY3Rpb24oZSkge1xyXG4gICAgICAgIHRoaXMuc2V0U3RhdGUoe1RleHQ6IGUudGFyZ2V0LnZhbHVlfSk7XHJcbiAgICB9LFxyXG4gICAgaGFuZGxlU3VibWl0OiBmdW5jdGlvbihlKSB7XHJcbiAgICAgICAgZS5wcmV2ZW50RGVmYXVsdCgpO1xyXG4gICAgICAgIHZhciB0aGF0ID0gdGhpcztcclxuXHJcbiAgICAgICAgUmVzdC5wb3N0KCd0b2RvJywgeyBUZXh0OiB0aGlzLnN0YXRlLlRleHQgfSwgZnVuY3Rpb24ocmVzdWx0KSB7XHJcbiAgICAgICAgXHJcbiAgICAgICAgICAgIHZhciBuZXh0SXRlbXMgPSB0aGF0LnN0YXRlLml0ZW1zLmNvbmNhdChbSlNPTi5wYXJzZShyZXN1bHQucmVzcG9uc2UpLlRvZG9JdGVtXSk7XHJcblxyXG4gICAgICAgICAgICB0aGF0LnNldFN0YXRlKHtpdGVtczogbmV4dEl0ZW1zfSk7XHJcbiAgICAgICAgfSk7XHJcbiAgICB9LFxyXG5cclxuICAgIGhhbmRsZURlbGV0ZTogZnVuY3Rpb24gKGl0ZW0pIHtcclxuICAgICAgICB2YXIgdGhhdCA9IHRoaXM7XHJcblxyXG4gICAgICAgIFJlc3QucG9zdCgndG9kby9kZWxldGUnLCB7IElkOiBpdGVtLklkIH0sIGZ1bmN0aW9uIChyZXN1bHQpIHtcclxuICAgICAgICAgICAgaWYgKHJlc3VsdC5jb2RlID09PSA0MDQpIHtcclxuICAgICAgICAgICAgICAgIGFsZXJ0KCdpdGVtIGRvZXMgbm90IGV4aXN0Jyk7XHJcbiAgICAgICAgICAgICAgICByZXR1cm47XHJcbiAgICAgICAgICAgIH1cclxuXHJcbiAgICAgICAgICAgIGxldCBpdGVtSWR4ID0gdGhhdC5zdGF0ZS5pdGVtcy5pbmRleE9mKGl0ZW0pO1xyXG4gICAgICAgICAgICB0aGF0LnN0YXRlLml0ZW1zLnNwbGljZShpdGVtSWR4LCAxKTtcclxuXHJcbiAgICAgICAgICAgIHRoYXQuc2V0U3RhdGUoeyBpdGVtczogdGhhdC5zdGF0ZS5pdGVtcyB9KTtcclxuICAgICAgICB9KTtcclxuICAgIH0sXHJcbiAgICBjb21wbGV0ZTogZnVuY3Rpb24gKGl0ZW0pIHtcclxuICAgICAgICB2YXIgdGhhdCA9IHRoaXM7XHJcblxyXG4gICAgICAgIFJlc3QucG9zdCgndG9kby9tYXJrY29tcGxldGUnLCB7IEl0ZW06IGl0ZW0gfSwgZnVuY3Rpb24gKHJlc3VsdCkge1xyXG4gICAgICAgICAgICBpZiAocmVzdWx0LmNvZGUgPT09IDQwNCkge1xyXG4gICAgICAgICAgICAgICAgYWxlcnQoJ2l0ZW0gZG9lcyBub3QgZXhpc3QnKTtcclxuICAgICAgICAgICAgICAgIHJldHVybjtcclxuICAgICAgICAgICAgfVxyXG5cclxuICAgICAgICAgICAgLy9sZXQgaXRlbUlkeCA9IHRoYXQuc3RhdGUuaXRlbXMuaW5kZXhPZihpdGVtKTtcclxuICAgICAgICAgICAgaXRlbS5Jc0NvbXBsZXRlID0gdHJ1ZTtcclxuXHJcbiAgICAgICAgICAgIHRoYXQuc2V0U3RhdGUoeyBpdGVtczogdGhhdC5zdGF0ZS5pdGVtcyB9KTtcclxuICAgICAgICB9KTtcclxuICAgIH0sXHJcbiAgICByZW5kZXI6IGZ1bmN0aW9uKCkge1xyXG4gICAgICAgIHJldHVybiAoXHJcbiAgICAgICAgICAgIDxkaXY+XHJcbiAgICAgICAgICAgICAgICA8Zm9ybSBvblN1Ym1pdD17dGhpcy5oYW5kbGVTdWJtaXR9PlxyXG4gICAgICAgICAgICAgICAgPGlucHV0IHBsYWNlaG9sZGVyPVwiK3RvZG9cIiBvbkNoYW5nZT17dGhpcy5vbkNoYW5nZX0gdmFsdWU9e3RoaXMuc3RhdGUuVGV4dH0gLz5cclxuICAgICAgICAgICAgICAgIDxidXR0b24+QWRkPC9idXR0b24+XHJcbiAgICAgICAgICAgICAgICA8L2Zvcm0+XHJcbiAgICAgICAgICAgICAgICA8VG9kb0xpc3QgaXRlbXM9e3RoaXMuc3RhdGUuaXRlbXN9IGhhbmRsZURlbGV0ZT17dGhpcy5oYW5kbGVEZWxldGV9IGNvbXBsZXRlPXt0aGlzLmNvbXBsZXRlfSAvPlxyXG4gICAgICAgICAgICA8L2Rpdj5cclxuICAgICAgICApO1xyXG59XHJcbn0pO1xyXG5cclxuUmVhY3RET00ucmVuZGVyKDxUb2RvQXBwIC8+LCBkb2N1bWVudC5nZXRFbGVtZW50QnlJZCgnZmxleFJlYWN0JykpO1xyXG5cclxuIl19