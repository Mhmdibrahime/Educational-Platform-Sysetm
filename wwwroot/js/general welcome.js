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
let home = document.getElementById("home");
let book = document.getElementById("book");
let star = document.getElementsByClassName("star");
let star_regular = document.getElementsByClassName("star-regular");
let star_half = document.getElementById("star-half");
let footer_arrow = document.getElementsByClassName("footer-arrow");
let color = document.getElementById("color");
let background = document.getElementById("background");
let video_color = document.getElementById("video-color");

moon.addEventListener("click", function () {
  document.body.classList.toggle("dark");
  if (moon.src.includes("moon.svg")) {
    moon.src = "images/sun-light.svg";
    search.src = "images/search-light.svg";
    navbar.src = "images/bars-light.svg";
    book.src = "images/book-light.svg";
    arrow.src = "images/right.svg";
    color.style.backgroundImage = "url('images/background dark.png')";
    background.style.backgroundColor = "rgba(54, 56, 94, 0.902)";
    video_color.style.backgroundColor = "rgba(54, 56, 94, 0.902)";

    for (let i = 0; i < star.length; i++) {
      star[i].src = "images/star-solid-dark.svg";
    }

    for (let i = 0; i < star_regular.length; i++) {
      star_regular[i].src = "images/star-dark.svg";
    }

    star_half.src = "images/star-half-dark.svg";

    for (let i = 0; i < footer_arrow.length; i++) {
      footer_arrow[i].src = "images/right-dark.svg";
    }
  } else {
    moon.src = "images/moon.svg";
    search.src = "images/search.svg";
    navbar.src = "images/bars.svg";
    book.src = "images/book.svg";
    arrow.src = "images/arrow.svg";
    color.style.backgroundImage = "url('images/background.png')";
    background.style.backgroundColor = "rgba(230, 237, 250, 0.879)";
    video_color.style.backgroundColor = "rgba(230, 237, 250, 0.879)";

    for (let i = 0; i < star.length; i++) {
      star[i].src = "images/star.svg";
    }

    for (let i = 0; i < star_regular.length; i++) {
      star_regular[i].src = "images/star-regular.svg";
    }

    star_half.src = "images/star-half.svg";

    for (let i = 0; i < footer_arrow.length; i++) {
      footer_arrow[i].src = "images/right.svg";
    }
  }
});

var swiper = new Swiper(".swiper", {
  slidesPerView: getslidesPerView(),
  direction: "horizontal",
  navigation: {
    nextEl: ".swiper-button-next",
    prevEl: ".swiper-button-prev",
  },
  on: {
    resize: function () {
      swiper.params.slidesPerView = getslidesPerView();
      swiper.update();
    },
  },
  pagination: {
    el: ".swiper-pagination",
    clickable: true,
  },
});

function getslidesPerView() {
  var windowWidth = window.innerWidth;
  var slidesPerView = windowWidth <= 992 ? 1 : 3;

  return slidesPerView;
}
