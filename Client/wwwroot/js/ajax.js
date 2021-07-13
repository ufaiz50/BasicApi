// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function validation() {
    var obj = new Object();
    
    var dataJson = JSON.stringify(obj)
    /*$.ajax({
        url: 'https://localhost:5001/Api/Employees/Register',
        type: 'post',
        data: dataJson,
        contentType: "application/json; charset=utf-8",
        traditional: true,
    }).done(result => {
        alert("Data Berhasil di simpan")
    }).fail(error => {
        console.log(error);
        console.log(dataJson);
        
    });*/

    obj.nik = $('#inputNik').val();
    obj.firstName = $("#inputFirstName").val();
    obj.lastName = $("#inputLastName").val();
    obj.email = $("#inputEmail").val();
    obj.salary = parseInt($("#inputSalary").val());
    obj.phoneNumber = $("#inputPhoneNumber").val();
    obj.birthDate = $("#inputBirthDate").val();
    obj.gender = parseInt($("#inputGender").val());
    obj.password = $("#inputPassword").val();
    obj.degree = $("#inputDegree").val();
    obj.gpa = $("#inputGpa").val();
    obj.universityId = parseInt($("#inputUniversity").val());

    // Regular Expression For Email
    emailReg = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    passReg = /^[0-9a-zA-Z]{8,}$/;

    if (obj.firstName != '' && obj.lastName != '' && obj.phoneNumber != ''
        && obj.birthDate != '' && obj.gender != '' && obj.salary != ''
        && obj.email != '' && obj.password != '' && obj.degree != ''
        && obj.gpa != '' && obj.university != '') {
        obj.gender = $("#inputGender").val() == "male" ? 0 : 1;
        if (obj.email.match(emailReg)) {
            if (obj.password.match(passReg)) {
                insert(obj);
                return true;
            } else {
                alert("Invalid Password, Password setidaknya memiliki 8 character")
                return false
            }
        } else {
            alert("Invalid Email Address...!!!");
            return false;
        }
    } else {
        alert("All fields are required.....!");
        return false;
    }
 }

function insert(item) {
    $.ajax({
        url: 'https://localhost:5001/Api/Employees/Register',
        type: 'post',
        data: JSON.stringify(item),
        contentType: "application/json; charset=utf-8",
        traditional: true,
    }).done(result => {
        alert("Data Berhasil di simpan")
    }).fail(error => {
        alert("Data tidak berhasil disimpan")
    });
}

function getNik() {
    var nik = "";
    $.ajax({
        url: "https://localhost:5001/Api/Employees/ShowData"
    }).done(result => {
        $.each(result.result, function (index, val) {
            nik = val['nik'];
        })
        manipulat = nik.slice(-2);
        result = parseInt(manipulat);
        result++;
        result = result.toString();
        nik = nik.replace(nik.slice(-2), result)
        document.getElementById('inputNik').value = nik;
    }).fail(error => {
        alert("Data tidak berhasil di dapat");
    })
}



$(document).ready(function () {
    $('#example').DataTable({
        dom: 'Bfrtip',
        "ajax": {
            url: "https://localhost:44327/Employee/GetRegistrasiView",
            dataType : "json",
            dataSrc: ""
        },
        "columns": [
            { "data" : "nik" },
            { "data": 'firstname',
                "render": function (data, type, full) {
                    return data + ' ' + full["lastname"];
                }
            },
            { "data" : "email" },
            { "data" : "salary" },
            {
                "data": "phonenumber",
                "render": function (data, type, full) {
                    return full["phoneNumber"].replace(full["phoneNumber"].charAt(0), "+62" );
                }
            },
            { "data" : "birthdate" },
            {
                "data": "gender",
                "render": function (data, type, full) {
                    return data == 0 ? "Male" : "Female";
                }
            },
            { "data": "degree" },
            { "data": "gpa" },
            { "data": "universityId" },
            {
                "data": null,
                "render": function () {
                    return "<button type='button' class='btn btn-primary' data-toggle='modal' data-target='#exampleModal'>Action</button>"
                },
                orderable : false
            }
        ],
        buttons: {
            buttons: [
                { extend: 'copy', className: 'btn btn-primary' },
                { extend: 'excel', className: 'btn btn-primary' },
                { extend: 'csv', className: 'btn btn-primary' },
                {
                    extend: 'pdf',
                    className: 'btn btn-primary',
                    orientation: 'landscape'
                },
                { extend: 'print', className: 'btn btn-primary' }
            ],
        }
    }).ajax.reload();

    //show Univ
    var univ = "";
    $.ajax({
        url: "https://localhost:5001/Api/Universities"
    }).done(result => {
        $.each(result.result, function (index, val) {
            univ += `<option id="inputUniversity" value="${val['universityId']}">${val['universityName']}</option>`;
        })
        $('#showUniv').html(univ);
    }).fail(error => {
        alert("Data tidak berhasil di simpan");
    })

});

function showDegree(i) {
    var degree = "";
    $.ajax({
        url: "https://localhost:5001/Api/Educations"
    }).done(result => {
        $.each(result.result, function (index, val) {
            
        })
    }).fail(error => {
        alert("Data tidak berhasil di simpan");
    })
}

/*$.ajax({
    url: "https://pokeapi.co/api/v2/pokemon/"
}).done(result => {
    text = "";
    no = 1;
    $.each(result.results, function (key, val) {
        text += `<tr>
                    <th scope="row">${++key}</th>
                    <td>${val.name}</td>
                    <td>${val.url}</td>

                    <td>
                        <button type="button" id="${val.url}" onclick="myFunction(this.id)"
                            class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
                            Lihat Detail
                        </button>
                    </td>
                </tr>`;
    })
    $("#show").html(text);
}).fail(error => console.log(error));*/
