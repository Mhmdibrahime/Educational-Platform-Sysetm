let loader = document.querySelector(".loader");
let hidden = document.querySelector(".hidden");

setTimeout(function () {
  loader.style.display = "none";
  document.body.classList.add("appear");
  hidden.classList.add("appear");
}, 2000);

header = document.getElementById("header");
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

// let login = document.getElementById("login");
// let btn_log = document.getElementById("btn-login");
// let btn_reg = document.getElementById("btn-register");
// let close = document.getElementById("close");

// btn_log.addEventListener("click", function () {
//   login.classList.add("top_login");
// });

// btn_reg.addEventListener("click", function () {
//   login.classList.add("top_login");
// });

// close.addEventListener("click", function () {
//   login.classList.remove("top_login");
// });

// let register_ul = document.getElementById("register_ul");
// let login_ul = document.getElementById("login_ul");

// register_ul.addEventListener("click", function () {
//   sidebar.classList.remove("side");
//   login.classList.add("top_login");
// });

// login_ul.addEventListener("click", function () {
//   sidebar.classList.remove("side");
//   login.classList.add("top_login");
// });

let moon = document.getElementById("moon");
let home = document.getElementById("home");
let book = document.getElementById("book");
let footer_arrow = document.getElementsByClassName("footer-arrow");
let background = document.getElementById("background");
let month = document.getElementById("month");
let user = document.getElementById("user");

moon.addEventListener("click", function () {
  document.body.classList.toggle("dark");
  if (moon.src.includes("moon.svg")) {
    moon.src = "images/sun-light.svg";
    // search.src = "images/search-light.svg";
    navbar.src = "images/bars-light.svg";
    book.src = "images/book-light.svg";
    user.src = "images/user.svg";
    month.style.backgroundImage = "url('images/background dark.png')";
    background.style.backgroundColor = "rgba(54, 56, 94, 0.902)";

    for (let i = 0; i < footer_arrow.length; i++) {
      footer_arrow[i].src = "images/right-dark.svg";
    }
  } else {
    moon.src = "images/moon.svg";
    // search.src = "images/search.svg";
    navbar.src = "images/bars.svg";
    book.src = "images/book.svg";
    month.style.backgroundImage = "url('images/background.png')";
    background.style.backgroundColor = "rgba(230, 237, 250, 0.879)";
    user.src = "images/user-solid (1).svg";

    for (let i = 0; i < footer_arrow.length; i++) {
      footer_arrow[i].src = "images/right.svg";
    }
  }
});

// let collapse = document.getElementsByClassName("collapse");
// let courses_btn = document.getElementsByClassName("courses");

// for (let i = 0; i < collapse.length; i++) {
//   courses_btn[i].addEventListener("click", () => {
//     console.log(collapse[i]);
//     for (let j = 0; j < collapse.length; j++) {
//       if (i !== j) {
//         collapse[j].classList.remove("show");
//       }
//     }
//   });
// }
