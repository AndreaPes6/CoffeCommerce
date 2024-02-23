console.log("ci sono")
const body = document.querySelector('body');
const toggle = document.getElementById('toggle');
const footer = document.querySelector('.bg-footer');
const publicita = document.querySelector('.contenitoreProdottoPromosso');

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
    footer.classList.toggle('bg-footerSwitch')
    publicita.classList.toggle('promotion-switch')
    //aggiunta commento
}

/*WELCOME PAGE*/
window.addEventListener("DOMContentLoaded", function () {
    const textElements = document.querySelectorAll(".text-transition");
    textElements.forEach(function (element) {
        element.classList.add("show"); 
    });
});