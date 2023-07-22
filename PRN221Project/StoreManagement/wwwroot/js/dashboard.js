"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/dashboardHub").build();

$(function () {
    connection.start().then(function () {
        InvokeProduct();
        InvokeEmployee();
    }).catch(function (err) {
        return console.error(err.ToString());
    });
});

function InvokeProduct() {
    connection.invoke("SendProducts").catch(function (err) {
        return console.error(err.ToString());
    });
}

function InvokeEmployee() {
    connection.invoke("SendEmployees").catch(function (err) {
        return console.error(err.ToString());
    });
}

connection.on("ReceivedProducts", function (products) {
    BindProductsToGrid(products);
});

connection.on("ReceivedEmployees", function (emps) {
    BindEmployeesToGrid(emps);
});

function BindProductsToGrid(products) {
    $('#tblProduct tbody').empty();
    var tr;
    console.log(products);
    $.each(products, function (index, product) {
        tr = $('<tr/>');
        tr.append(`<td>${product.productId}</td>`);
        tr.append(`<td>${product.productName}</td>`);
        tr.append(`<td>${product.categoryId}</td>`);
        tr.append(`<td>${product.unitPrice}</td>`);
        tr.append(`<td>${product.unitsInStock}</td>`);
        $('#tblProduct').append(tr);
    });
}

function BindEmployeesToGrid(emps) {
    $('#tblEmployee tbody').empty();
    var tr;
    $.each(emps, function (index, emp) {
        tr = $('<tr/>');
        tr.append(`<td>${emp.employeeId}</td>`);
        tr.append(`<td>${emp.lastName}</td>`);
        tr.append(`<td>${emp.firstName}</td>`);
        tr.append(`<td>${emp.title}</td>`);
        tr.append(`<td>${emp.birthDate}</td>`);
        $('#tblEmployee').append(tr);
    });
}

connection.on("ReceivedProductsForGraph", function (productsForGraph) {
    BindProductsToGraph(productsForGraph);
});

connection.on("ReceivedEmployeesForGraph", function (empsForGraph) {
    BindEmployeesToGraph(empsForGraph);
});

function BindProductsToGraph(productsForGraph) {
    var labels = [];
    var data = [];

    console.log(productsForGraph);
    $.each(productsForGraph, function (index, item) {
        labels.push(item.category);
        data.push(item.products);
    });

    DestroyCanvasIfExists('canvasProducts');

    const context = $('#canvasProducts');
    const myChart = new Chart(context, {
        type: 'doughnut',
        data: {
            labels: labels,
            datasets: [{
                label: 'Number of products',
                data: data,
                backgroundColor: backgroundColors,
                borderColor: borderColors,
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
}

function BindEmployeesToGraph(empsForGraph) {
    var datasets = [];
    var labels = ['Employees']
    var data = [];
    $.each(empsForGraph, function (index, item) {
        data = [];
        data.push(item.employees);
        var dataset = {
            label: item.title,
            data: data,
            backgroundColor: backgroundColors[index],
            borderColor: borderColors[index],
            borderWidth: 1
        };

        datasets.push(dataset);
    });

    DestroyCanvasIfExists('canvasEmployees');

    const context = $('#canvasEmployees');
    const myChart = new Chart(context, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: datasets,
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
}

function DestroyCanvasIfExists(canvasId) {
    let chartStatus = Chart.getChart(canvasId);
    if (chartStatus != undefined) {
        console.log("here");
        chartStatus.destroy();
    }
}

var backgroundColors = [
    'rgba(255,99,132,0.2)',
    'rgba(54,162,235,0.2)',
    'rgba(255,206,86,0.2)',
    'rgba(75,192,192,0.2)',
    'rgba(153,102,255,0.2)',
    'rgba(255,159,64,0.2)',
]

var borderColors = [
    'rgba(255,99,132,1)',
    'rgba(54,162,235,1)',
    'rgba(255,206,86,1)',
    'rgba(75,192,192,1)',
    'rgba(153,102,255,1)',
    'rgba(255,159,64,1)',
]