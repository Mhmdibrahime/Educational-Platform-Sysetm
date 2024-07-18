let input = document.querySelector("input");
let btns = document.querySelectorAll("button");
let specialchars = ["%", "*", "/", "+", "-"];
let output = "";

let calculate = function (btn) {
  if (btn === "=") {
    if (output === "" || specialchars.includes(output[output.length - 1])) {
    }
    output = eval(output.replace("%", "/100"));
    input.value = output;
  } else if (btn === "AC") {
    output = "";
    input.value = output;
  } else if (btn === "DEL") {
    output = output.slice(0, -1);
    input.value = output;
  } else {
    output += btn;
    input.value = output;
  }
};

btns.forEach(function (btn) {
  btn.addEventListener("click", (e) => calculate(e.target.dataset.value));
});