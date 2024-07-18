let moon = document.querySelectorAll(".moon");
let students = document.getElementById("students");
let quick = document.getElementById("quiz");
// let courses = document.getElementById("course");
let teacher = document.getElementById("teacher");
let feedback = document.getElementById("feedback");
let book = document.getElementById("book");
let bar = document.getElementById("bars");
let logout = document.getElementById("logout1");
console.log(logout);

moon[0].onclick = function () {
    if (moon[0].src.includes("moon.svg")) {
        document.body.classList.add("dark");
        moon[0].src = "images/sun-light.svg";
        students.src = "images/users-solid.svg";
        quick.src = "images/book-solid.svg";
        // courses.src = "images/readme.svg";
        teacher.src = "images/user-solid (1).svg";
        feedback.src = "images/address-card-solid (1).svg";
        book.src = "images/book.svg";
        bar.src = "images/bars-light.svg";
        logout.src = "images/person-walking-arrow-right-solid.svg";
    } else {
        document.body.classList.remove("dark");
        moon[0].src = "images/moon.svg";
        students.src = "images/users-solid (1).svg";
        quick.src = "images/book-solid (1).svg";
        // courses.src = "images/readme (1).svg";
        teacher.src = "images/user.svg";
        feedback.src = "images/about-us.svg";
        book.src = "images/book-light.svg";
        bar.src = "images/bars.svg";
        logout.src = "images/person-walking-arrow-right-solid (1).svg";
    }
};

let loader = document.querySelector(".loader");
let hidden = document.querySelector(".hidden");

setTimeout(function () {
    loader.style.display = "none";
    document.body.classList.add("appear");
    hidden.classList.add("appear");
}, 2000);