"use strict";
var ToDoList;
(function (ToDoList) {
    let toDoList = [];
    const listId = "toDoList";
    const newToDoId = "newToDo";
    class ToDo {
        constructor(title, done) {
            this.title = title;
            this.done = done;
        }
        toHTML(index) {
            if (this.done) {
                return String.raw `
                <li class="d-flex m-1 p-1 px-2 rounded bg-secondary shadow-sm">
                    <input type="checkbox" checked onclick="ToDoList.toggle(${index})" class="me-1 my-auto shadow-sm">
                    <label class="text-light text-truncate"><del>${this.title}</del></label>
                    <i class="fa-solid fa-trash-can ms-auto my-auto" onclick="ToDoList.remove(${index})"></i>
                </li>`;
            }
            else {
                return String.raw `
                <li class="d-flex m-1 p-1 px-2 rounded bg-light shadow-sm">
                    <input type="checkbox" onclick="ToDoList.toggle(${index})" class="me-1 my-auto shadow-sm">
                    <label class="text-truncate">${this.title}</label>
                    <i class="fa-solid fa-trash-can ms-auto my-auto" onclick="ToDoList.remove(${index})"></i>
                </li>`;
            }
        }
    }
    function add() {
        let input = document.getElementById(newToDoId);
        let title = input.value;
        if (title === "") {
            return;
        }
        toDoList.push(new ToDo(title, false));
        input.value = "";
        // add only this item to the html
        let index = toDoList.length - 1;
        let todo = toDoList[index];
        let todoList = document.getElementById(listId);
        if (todoList !== null) {
            todoList.innerHTML += todo.toHTML(index);
        }
        else {
            console.error("todoList is null");
        }
        store();
    }
    ToDoList.add = add;
    function toggle(index) {
        let todo = toDoList[index];
        todo.done = !todo.done;
        render();
        store();
    }
    ToDoList.toggle = toggle;
    function remove(index) {
        toDoList.splice(index, 1);
        render();
        store();
    }
    ToDoList.remove = remove;
    function render() {
        let html = "";
        for (let i = 0; i < toDoList.length; i++) {
            let todo = toDoList[i];
            html += todo.toHTML(i);
        }
        let todoList = document.getElementById(listId);
        if (todoList !== null) {
            todoList.innerHTML = html;
        }
        else {
            console.error("todoList is null");
        }
    }
    const storageKey = "toDoList";
    function load() {
        let data = localStorage.getItem(storageKey);
        if (data != null) {
            toDoList = JSON.parse(data);
        }
        else {
            toDoList = [];
        }
    }
    function store() {
        localStorage.setItem(storageKey, JSON.stringify(toDoList));
    }
    load();
    render();
})(ToDoList || (ToDoList = {}));
