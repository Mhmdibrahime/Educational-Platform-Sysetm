let loader = document.querySelector(".loader");
let hidden = document.querySelector(".hidden");

setTimeout(function () {
  loader.style.display = "none";
  document.body.classList.add("appear");
  hidden.classList.add("appear");
}, 2000);

let header = document.getElementById("header");
window.addEventListener("scroll", function () {
  if (window.scrollY > 0) {
    header.classList.add("shadow");
  } else {
    header.classList.remove("shadow");
  }
});

let bars = document.getElementById("navbar");
let sidebar = document.getElementById("sidebar");
bars.addEventListener("click", function () {
  sidebar.classList.toggle("side");
});

let register_ul = document.getElementById("register_ul");
let login_ul = document.getElementById("login_ul");

register_ul.addEventListener("click", function () {
  sidebar.classList.remove("side");
});

login_ul.addEventListener("click", function () {
  sidebar.classList.remove("side");
});

let moon = document.getElementById("moon");
let book = document.getElementById("book");
let footer_arrow = document.getElementsByClassName("footer-arrow");
let about = document.getElementById("about");
let background = document.getElementById("background");

moon.addEventListener("click", function () {
  document.body.classList.toggle("dark");
  if (moon.src.includes("moon.svg")) {
    moon.src = "images/sun-light.svg";
    search.src = "images/search-light.svg";
    navbar.src = "images/bars-light.svg";
    about.style.backgroundImage = "url('images/background dark.png')";
    background.style.backgroundColor = "rgba(54, 56, 94, 0.902)";

    for (let i = 0; i < footer_arrow.length; i++) {
      footer_arrow[i].src = "images/right-dark.svg";
    }
  } else {
    moon.src = "images/moon.svg";
    search.src = "images/search.svg";
    navbar.src = "images/bars.svg";
    about.style.backgroundImage = "url('images/background.png')";
    background.style.backgroundColor = "rgba(230, 237, 250, 0.879)";

    // book.src = "images/book.svg";

    for (let i = 0; i < footer_arrow.length; i++) {
      footer_arrow[i].src = "images/right.svg";
    }
  }
});
