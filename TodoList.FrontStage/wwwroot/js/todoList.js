//DOM
let todoArea = document.querySelector('.content')
let addInput = document.querySelector('.add__input')
let addBtn = document.querySelector('.add__btn')

let headers = {
    "Content-Type": "application/json",
    "Accept": "application/json"
}

let apiUrl = 'https://localhost:44375/api/TodoListApi'

window.onload = function () {
    rander()
    //新增待辦
    addBtn.addEventListener('click', function () {
        let inputValue = addInput.value.trim()

        if (inputValue.length != 0) {
            addData(inputValue)
            addInput.value = ''
        }
    })
}

function rander() {
    //初始化將localStorage物件新增至畫面
    todoArea.innerHTML = ''

    axios({
        method: 'get',
        url: apiUrl,
        headers: headers
    })
        .then((res) => {
            if (res.data != null) {
                let todoList = res.data
                todoList.forEach((item) => {
                    addTodoItem(item.description, item.isDone, item.id)
                })
            } else {
                window.alert("取得資料失敗")
            }
        })
}

function addTodoItem(value, isDone, idx) {
    let todo = `
            <li class="todo__item w-50 mb-2" item="${idx}">
                <div class="input-group">
                    <div class="input-group-text">
                        <input check="${idx}" class="todo__check" type="checkbox" onclick="todoDone(${idx})" ${isDone ? 'checked' : ''}>
                    </div>
                    <input todoInput="${idx}" class="todo__Input form-control" type="text" value="${value}" disabled>
                    <div class="change__btn">
                        <button edit="${idx}" class="btn btn-warning edit__btn" onclick="editData(${idx})">編輯</button>
                        <button save="${idx}" class="btn btn-success save__btn d-none" onclick="saveData(${idx})">保存</button>
                    </div>
                    <button del="${idx}" class="btn btn-danger delete__btn" onclick="deleteData(${idx})">刪除</button>
                </div>
            </li>
            `

    todoArea.innerHTML += todo
}

function addData(description) {
    console.log(description)
    axios({
        method: 'post',
        url: apiUrl + '?description=' + description
    })
        .then((res) => {
            if (res.data.isSuccess) {
                rander()
            } else {
                console.log(res.data.rtnMsg)
                window.alert("新增失敗")
            }
        })
        .catch((err) => {
            console.log(err)
            window.alert('新增失敗')
        })

}

function editData(idx) {
    //UI
    document.querySelector(`[edit="${idx}"]`).classList.add('d-none')
    document.querySelector(`[save="${idx}"]`).classList.remove('d-none')
    document.querySelector(`[todoInput="${idx}"]`).removeAttribute('disabled')
}

function deleteData(id) {
    //UI
    //document.querySelector(`[item="${idx}"]`).remove()

    axios({
        method: 'delete',
        url: apiUrl + '?id=' + id,
    })
        .then((res) => {
            if (res.data.isSuccess) {
                rander()
            } else {
                console.log(res.data.rtnMsg)
                window.alert('移除資料失敗')
            }
        })
        .catch((err) => {
            console.log(err)
            window.alert('移除資料失敗')
        })
}

function saveData(idx) {
    //UI
    document.querySelector(`[edit="${idx}"]`).classList.remove('d-none')
    document.querySelector(`[save="${idx}"]`).classList.add('d-none')
    document.querySelector(`[todoInput="${idx}"]`).setAttribute('disabled', '')

    // saveData
    let value = document.querySelector(`[todoInput="${idx}"]`).value
    updateData(idx, value, false)

}

function todoDone(idx) {
    let todoList = JSON.parse(localStorage.getItem('1'))
    if (document.querySelector(`[check="${idx}"]`).checked) {

        todoList[idx].isDone = true
        document.querySelector(`[edit="${idx}"]`).setAttribute('disabled', '')
    }
    else {
        todoList[idx].isDone = false
        document.querySelector(`[edit="${idx}"]`).removeAttribute('disabled')
    }
}

function updateData(id, description, isDone) {
    let model = {
        Id: id,
        Description: description,
        IsDone: isDone
    }
    axios({
        method: 'put',
        url: apiUrl,
        headers: headers,
        data: model
    })
        .then((res) => {
            if (!res.data.isSuccess) {
                console.log(res.data.rtnMsg)
                window.alert('儲存資料失敗')
            }
            rander()
        })
        .catch((err) => {
            console.log(err)
            window.alert('儲存資料失敗')
            rander()
        })
}