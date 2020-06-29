function allowDrop(ev) {
    ev.preventDefault();
}

function drag(ev) {
    ev.dataTransfer.setData("text", ev.target.id);
}

function drop(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("text");
    var tar = ev.target.parentElement.parentElement;
    if (tar.nodeName == "THEAD") {
        tar.parentElement.lastElementChild.appendChild(document.getElementById(data));
    }
    else if (tar.nodeName == "TBODY") {
        tar.appendChild(document.getElementById(data));
    }
}

