console.log("ci sono")
const body = document.querySelector('body');
const toggle = document.getElementById('toggle');
const footer = document.querySelector('footer');

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
    footer.classList.toggle('text-light bg-dark')
    //aggiunta dello sfondo su altre pagine
}

/*WELCOME PAGE*/
window.addEventListener("DOMContentLoaded", function () {
    const textElements = document.querySelectorAll(".text-transition");
    textElements.forEach(function (element) {
        element.classList.add("show"); // Aggiungi la classe "show" per attivare l'animazione
    });
});