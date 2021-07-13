// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function loginUser() {
    var obj = {
        "nik": "pandanaran1000@gmail.com",
        "password": "E0001"
    }
    $.ajax({
        url: 'https://localhost:44327/Home/GetLoginView',
        type: 'post',
        data: JSON.stringify(obj),
        contentType: "application/json; charset=utf-8",
        traditional: true,
    }).done(result => {
        console.log(result)
    }).fail(error => {
        console.log(error)
    });
}
