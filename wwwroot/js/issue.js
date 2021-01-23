import { updateDropdown } from './shared.js'

var uri = 'api/Issues';

function NameUpdateHandler(event) {
    var el = event.target;
    if (el.value == issue.Name) {
        return;
    }

    var valid = validateInput(el);
    if (!valid) {
        el.value = issue.Name;
        return;
    }

    var issueName = {
        text: el.value
    };
    fetch(`${uri}/${issue.Id}/name`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(issueName)
    })
    .then(response => {
        if (response.status != 200) el.value = issue.Name;
    })
    .catch(error => console.error('Unable to update item.', error));
}

function DescUpdateHandler(event) {
    var el = event.target;

    if (el.innerText == issue.Description) {
        return;
    }

    
    if (el.innerText.length==0) {
        el.innerText = issue.Description;
        return;
    }

    var issueDesc = {
        text: el.innerText
    };

    fetch(`${uri}/${issue.Id}/desc`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(issueDesc)
    })
        .then(response => {
            if (response.status != 200) el.value = issue.Name;
        })
        .catch(error => console.error('Unable to update item.', error));
}

function TypeUpdateHandler(event) {

    var id = event.currentTarget.id;

    var issueTypeId = {
        id: parseInt(id)
    };

    fetch(`${uri}/${issue.Id}/type`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(issueTypeId)
    })
        .then(response => {
            if (response.status != 200) {
                return;
            }
            return response.json();
        })
        .then(data => {
            if (data == null) return;
            updateDropdown(id,"type");

            postChange(data);
        })
        .catch(error => console.error('Unable to update item.', error)); 
}

function StatusUpdateHandler(event) {

    var id = event.currentTarget.id ;
    var issueStatusId = {
        id: parseInt(id)
    };

    fetch(`${uri}/${issue.Id}/status`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(issueStatusId)
    })
        .then(response => {
            if (response.status != 200) {
                return;
            }
            return response.json();
        })
        .then(data => {
            if (data == null) return;

            updateDropdown(id, "status");

            postChange(data);
        })
        .catch(error => console.error('Unable to update item.', error));
}

function DueDateUpdateHandler(event) {

    var issueDueDate = {
        date: event.currentTarget.value
    };

    fetch(`${uri}/${issue.Id}/date`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(issueDueDate)
    })
        .then(response => {
            return response.status;
        })
        .then(status => {
            if (status == 204) {
                console.log("good")
            }
        })
        .catch(error => console.error('Unable to update item.', error));
}

function CommentPost(event) {

    var comm = document.getElementById("issue-comm").innerText;

    comm = comm.trim();

    if (comm.length > 300 || comm.length == 0) {
        return;
    }

    var comment = {
        body: comm
    };

    fetch(`${uri}/${issue.Id}`, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(comment)
    })
        .then(response => {
            return response.json();
        })
        .then(data => {
            addComment(data);
        })
        .catch(error => console.error('Unable to update item.', error));
}

function addComment(data) {
    
    var dateString = getDateString(data.creationDate);

    var div = document.createElement('div');
    div.innerHTML =
        `<div class="issue-comm border mb-3 " id = "${data.id}" >
        <div class="d-flex flex-row mb-2 p-2 border-bottom">
            <span class="mr-1 font-weight-bold">By: </span>
            <span class="issue-comm-userid  mr-1">#${data.userId}</span>
            <span class="issue-comm-username mr-auto">${data.userName}</span>
            <span class="mr-1 font-weight-bold">At: </span>
            <span class="issue-comm-created ">${dateString}</span>
            <button class="btn btn-danger btn-sm ml-2" onclick="deleteComment(${data.id})"><i class="far fa-trash-alt fa-sm"></i></button>
            
        </div>
        <div class="mb-2 p-2 pl-4">
            <span class="input issue-comm-body "
                role="textbox"
                spellcheck="false">
                ${data.body}
            </span>
        </div>
    </div>`;
    
    document.getElementById("comm-section").prepend(div);
}

function deleteComment(id) {
    
    fetch(`${uri}/comment/${id}`, {
        method: 'DELETE'
    })
        .then(response => {
            if (response.status == 200) {
                var el = document.getElementById(id);
                el.remove();
            }
        })
        .catch(error => console.error('Unable to delete item.', error));
}



function postChange(data) {

    var dateString = getDateString(data.creationDate);

    var div = document.createElement('div');

    div.innerHTML =             
        `<div class="issue-comm border mb-3 ">
            <div class="d-flex flex-row mb-2 p-2 border-bottom">
                <span class="mr-1 font-weight-bold">${data.property}</span>
                <span class="issue-comm-username mr-auto"></span>
                <span class="mr-1 font-weight-bold">At: </span>
                <span class="issue-comm-created ">${dateString}</span>
            </div>
            <div class="d-flex justify-content-between ">
                <div class="mb-2 p-2 pl-4">
                    <span class="input issue-comm-body "
                          role="textbox"
                          spellcheck="false">
                            ${data.before}
                    </span>
                </div>
                <i class="fas fa-long-arrow-alt-right my-auto"></i>
                <div class="mb-2 p-2 pl-4">
                    <span class="input issue-comm-body "
                          role="textbox"
                          spellcheck="false">
                            ${data.after}
                    </span>
                </div>
            </div>
         </div>`

    document.getElementById("change-section").prepend(div);
}

function getDateString(date) {
    var date = new Date(date);

    var dateString = date.getMonth() + 1 + "/"
        + date.getDate() + "/"
        + date.getFullYear() + " "
        + (date.getHours() > 11 ? date.getHours() - 12 : date.getHours()) + ":"
        + (date.getMinutes() > 9 ? date.getMinutes() : "0" + date.getMinutes()) + ":"
        + (date.getSeconds() > 9 ? date.getSeconds() : "0" + date.getSeconds())
        + (date.getHours() > 11 ? " PM" : " AM");
    return dateString;
}

function postFile(oFormElement) {

    const formData = new FormData(oFormElement);

    fetch(`${uri}/${issue.Id}/file`, {
            method: 'POST',
            body: formData
    })
        .then(res => {
            return res.json();
        })
        .then(data => {
            if (data.text) {
                alert(data.text);
            }
            postNewFileLink(data);
        })
        .catch(error => console.error('Unable to update item.', error));

    
}
function deleteFile(id) {
    fetch(`${uri}/file/${id}`, {
        method: 'DELETE'
    })
        .then(response => {
            if (response.status == 200) {
                var el = document.getElementById("file-"+id);
                el.remove();
            }
        })
        .catch(error => console.error('Unable to delete item.', error));
}

function postNewFileLink(data) {
    var ext = data.uri.substring(data.uri.lastIndexOf('.') + 1).toUpperCase();
    var fontA;

    if (ext.startsWith("D")) {
        fontA = "<i class='fas fa-file-word mr-3'></i>";
    }
    else if (ext.startsWith("T")) {
        fontA = "<i class='fas fa-file-alt mr-3'></i>";
    }
    else if (ext.startsWith("PD")) {
        fontA = "<i class='fas fa-file-pdf mr-3'></i>";
    }
    else if (ext.StartsWith("P") || ext.StartsWith("J")) {
        fontA = "<i class='fas fa-file-image mr-3'></i>";
    }
    else if (ext.StartsWith("X") || ext.StartsWith("C")) {
        fontA = "<i class='fas fa-file-excel mr-3'></i>";
    } else {
        return;
    }
    var div = document.createElement('div');
    div.innerHTML =
        `<div class="d-flex flex-row file mb-1" id="file-${data.id}">
        <a class="pd" href="${data.uri}" download>
            <span>${fontA}${data.uri.substring(data.uri.lastIndexOf('/') + 1)}</span>
        </a>
        <button class="ml-auto btn btn-danger" onclick="deleteFile(${data.id})"><i class="fas fa-trash-alt"></i></button>
    </div>`;
    document.getElementById("files-section").prepend(div);
}
function validateInput(el) {
    var maxLength = parseInt(el.getAttribute("data-val-length-max"))

    if (el.value.length > maxLength ||
        el.value.length == 0) {
        return false;
    }

    return true;
}

const typeItems = document.querySelectorAll(".type-item");
const statusItems = document.querySelectorAll(".status-item");

typeItems.forEach(el => { el.addEventListener('click', TypeUpdateHandler) });
statusItems.forEach(el => { el.addEventListener('click', StatusUpdateHandler) });
    