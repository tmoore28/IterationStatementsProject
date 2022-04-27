console.log("Hello World!\n==========\n");
console.log(
  "Follow the steps in the README.md file to complete the exercises:\n==========\n"
);

// Exercise 1

//1. Declare a variable named firstName using the `const` keyword,
// and assign your name as the string value
const firstName = "Tylor";

//2. Declare a variable named lastName using the `let` keyword,
// and assign your name as the string value
let lastName = "Moore";
//3. Declare a variable named age using the `var` keyword, 
//and assign your age as the number value
var age = 26

// Exercise 2


//1. Declare a variable named fullName using the `let` keyword, and assign your `firstName` plus your `lastName` as the string value
let fullName = `${firstName}, ${lastName}`
//2. Print the value of `fullName` to the console (to open you browser console in Google Chrome, right-click and press "Inspect" or fn+F12)
console.log(firstName + " " + lastName);
//3. BONUS: Complete step two using a template literal instead of concatenation
// Exercise 3
let city = `Troy`;
let pastTime = `Skateboarding with my daughter and video games with my son`;
let myStory =`Hello! My name is ${fullName}. I live in ${city}.
I enjoy ${pastTime}`;
console.log(myStory);