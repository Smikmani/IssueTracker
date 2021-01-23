import { updateDropdown } from "./shared.js"

function TypeUpdateHandler(event) {

    var id = event.currentTarget.id;

    chnageValue(id, "type");
    updateDropdown(id, "type");
}

function StatusUpdateHandler(event) {

    var id = event.currentTarget.id;

    chnageValue(id, "status");
    updateDropdown(id, "status");
}


function chnageValue(id,propChanged){
    var newId = id.substring(0, id.indexOf("-"));
    if (propChanged == "type") {
        var el = document.getElementById("Filter_TypeId");
        el.value = newId;
        return;
    }
    var el = document.getElementById("Filter_StatusId");
    el.value = newId;

}

const typeItems = document.querySelectorAll(".type-item");
const statusItems = document.querySelectorAll(".status-item");

typeItems.forEach(el => { el.addEventListener('click', TypeUpdateHandler) });
statusItems.forEach(el => { el.addEventListener('click', StatusUpdateHandler) });