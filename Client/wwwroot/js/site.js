// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const animal = [
    { name: "Fluffy", species: "cat", class: { name: "mamalia" } },
    { name: "Carlo", species: "dog", class: { name: "vertebrata" } },
    { name: "Nemo", species: "fish", class: { name: "mamalia" } },
    { name: "Hamilton", species: "dog", class: { name: "mamalia" } },
    { name: "Dory", species: "fish", class: { name: "mamalia" } },
    { name: "Ursa", species: "cat", class: { name: "mamalia" } },
    { name: "Taro", species: "cat", class: { name: "vertebrata" } }
];


for (let i in animal) {
    if (animal[i].species == "cat") {
        console.log(animal[i]);
    }
}
console.log("\n\n\n")

for (let j in animal) {
    if (animal[j].class["name"] == "vertebrata") animal[j].class["name"] = "Non-Mamalia";

    /*var string = animal[j].class["name"];
    console.log(string.replace(/^\w/, c => c.toUpperCase()));
    console.log(string.replace(string.charAt(0), string.charAt(0).toUpperCase()))
    console.log(string.charAt(0).toUpperCase() + string.slice(1));*/

    console.log(animal[j]);
}