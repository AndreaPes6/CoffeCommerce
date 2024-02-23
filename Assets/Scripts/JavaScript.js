console.log("ci sono")
const body = document.querySelector('body');
const toggle = document.getElementById('toggle');

//toggle.onclick = function () {
//    toggle.classList.add('active')
//    body.classList.add('active')
//}

//toggle.addEventListener("click", function (e) {
//    toggle.classList.add("active")
//    body.classList.add("active")
//})

toggle.onclick = function () {
    toggle.classList.toggle('active')
    body.classList.toggle('active')
}