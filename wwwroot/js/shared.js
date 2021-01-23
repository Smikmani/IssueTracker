export function updateDropdown(id, propChanged) {

    var newPropColor = document.getElementById(id).childNodes[1].style.background;
    var newPropName = document.getElementById(id).childNodes[3].innerText;
    var newId = id.substring(0, id.indexOf("-"));

    document.getElementById(id).childNodes[1].style.background = document.getElementById(`issue-${propChanged}-box`).style.background;
    document.getElementById(`issue-${propChanged}-box`).style.background = newPropColor;

    document.getElementById(id).childNodes[3].innerText = document.getElementById(`issue-${propChanged}-name`).innerText;
    document.getElementById(`issue-${propChanged}-name`).innerText = newPropName;

    document.getElementById(id).id = document.getElementById(`issue-${propChanged}-id`).innerText + `-${propChanged}`;
    document.getElementById(`issue-${propChanged}-id`).innerText = newId;
}