var uri = "api/Issues/DeleteIssue";
//Remove issue from UI 
//DELETE HTTP req
function deleteIssue(id) {
    
    document.getElementById(id).remove();
    
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
    .catch(error => console.error('Unable to delete item.', error));
}

function updateIssue(id) {

    ev.preventDefault();
    var issue = ev.target.parentElement.parentElement;
    ev.target.parentElement.parentElement.parentElement.removeChild(issue);

    fetch(`${uri}/${id}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(issue)
    })
    .catch(error => console.error('Unable to update item.', error));
}
