// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {
    $.ajax({
        url: "https://localhost:44327/Employee/GetRegistrasiView",
        dataType: "json",
        dataSrc: ""
    }).done(result => {
        tableBody = "";
        $.each(result, function (key, val) {
            if (key < 7) {
                tableBody += `
                <tr>
                    <td>${val['nik']}</td>
                    <td>${val['firstname']} ${val['lastname']}</td>
                    <td>${val['email']}</td>
                    <td>${val['degree']}</td>
                </tr>`
            }
        })
        $('#recent').html(tableBody);
    }).fail(error => {

    })
    /*$('#employee').DataTable({
        dom: 'Bfrtip',
        "ajax" : {
            url : "https://localhost:44327/Employee/GetRegistrasiView",
            dataType : "json",
            dataSrc : ""
        },
        "columns": [
            { "data": "nik" },
            {
                "data": 'firstname',
                "render": function (data, type, full) {
                    return data + ' ' + full["lastname"];
                }
            },
            { "data": "email" },
            { "data": "degree" },
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
    })*/

    showBarChart();
    showPieChart();

})

function showBarChart() {
    years = [];
    $.ajax({
        url: "https://localhost:44327/Employee/GetRegistrasiView"
    }).done(result => {
        $.each(result, function (key, val) {
            year = val["birthdate"];
            years.push(new Date(year).getFullYear());

        })

        var sortArray = years.sort((a, b) => a - b);
        var count = {};
        sortArray.forEach(function (i) { count[i] = (count[i] || 0) + 1; })
        var arrayData = Object.keys(count).map(key => count[key]);
        getCategories = [...new Set(sortArray)];
        var options = {
            chart: {
                type: 'bar'
            },
            series: [{
                name: 'sales',
                data: arrayData
            }],
            xaxis: {
                categories: getCategories
            }
        }

        var chart = new ApexCharts(document.querySelector("#columnChart"), options);

        chart.render();
    }).fail(error => {
        alert("Tidak bisa mengambil data")
    })
    
}

function showPieChart() {
    male = 0;
    female = 0;
    $.ajax({
        url: "https://localhost:44327/Employee/GetRegistrasiView"
    }).done(result => {
        $.each(result, function (key, val) {
            val['gender'] == 0 ? male++ : female++;
        })
        var options = {
            chart: {
                type: 'pie'
            },
            series: [male, female],
            labels: ['Male', 'Female']
        }

        var chart = new ApexCharts(document.querySelector("#pieChart"), options);

        chart.render()
    }).fail(error => {
        alert("Data tidak berhasil di dapat");
    })
}
