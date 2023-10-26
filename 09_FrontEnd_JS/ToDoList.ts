namespace ToDoList {
    let toDoList: ToDo[] = [];

    const listId = "toDoList";
    const newToDoId = "newToDo";

    class ToDo {
        constructor(public title: string, public done: boolean) {
        }

        toHTML(index: number): string {
            if (this.done) {
                return String.raw`
                <li class="d-flex m-1 p-1 px-2 rounded bg-secondary shadow-sm">
                    <input type="checkbox" checked onclick="ToDoList.toggle(${index})" class="me-1 my-auto shadow-sm">
                    <label class="text-light text-truncate"><del>${this.title}</del></label>
                    <i class="fa-solid fa-trash-can ms-auto my-auto" onclick="ToDoList.remove(${index})"></i>
                </li>`
            }
            else {
                return String.raw`
                <li class="d-flex m-1 p-1 px-2 rounded bg-light shadow-sm">
                    <input type="checkbox" onclick="ToDoList.toggle(${index})" class="me-1 my-auto shadow-sm">
                    <label class="text-truncate">${this.title}</label>
                    <i class="fa-solid fa-trash-can ms-auto my-auto" onclick="ToDoList.remove(${index})"></i>
                </li>`
            }
        }
    }

    export function add() {
        let input = document.getElementById(newToDoId) as HTMLInputElement;
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
        } else {
            console.error("todoList is null");
        }
        store();
    }

    export function toggle(index: number) {
        let todo = toDoList[index];
        todo.done = !todo.done;
        render();
        store();
    }


    export function remove(index: number) {
        toDoList.splice(index, 1);
        render();
        store();
    }

    function render() {
        let html = "";
        for (let i = 0; i < toDoList.length; i++) {
            let todo = toDoList[i];
            html += todo.toHTML(i);
        }
        let todoList = document.getElementById(listId);
        if (todoList !== null) {
            todoList.innerHTML = html;
        } else {
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
}