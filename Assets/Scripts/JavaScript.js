const body = document.querySelector('body');
const toggle = document.getElementsById('toggle');
toggle.onclick = function () {
    toggle.classList.add('active')
    body.classList.add('active')
}