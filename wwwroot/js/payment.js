let loader = document.querySelector(".loader");
let hidden = document.querySelector(".hidden");
console.log(hidden);
setTimeout(function () {
  loader.style.display = "none";
  hidden.classList.add("appear");
}, 2000);
