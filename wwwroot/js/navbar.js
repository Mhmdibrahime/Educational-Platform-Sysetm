let flex12 = document.getElementById("flex");
let navbar = document.getElementById("navbar1");

window.addEventListener("DOMContentLoaded", function () {
  // Set the height of .navbar1 to match the computed height of .flex
  navbar1.style.height = flex12.clientHeight + "px";
});

window.addEventListener("resize", function () {
  // Recalculate the height of .flex on window resize
  navbar1.style.height = flex12.clientHeight + "px";
});

let bars = document.querySelectorAll(".bars");

bars[0].addEventListener("click", function () {
  navbar.classList.toggle("appear");
});
