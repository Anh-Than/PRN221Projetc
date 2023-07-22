"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/dashboardHub").build();

$(function () {
    connection.start().then(function () {

        InvokeProducts();
    }).catch(function (err) {
        return console.error(err.toString());
    });
});

function InvokeProducts() {
    connection.invoke("SendProducts").catch(function (err) {
        return console.error(err.toString());
    });
}

connection.on("ReceivedProducts", function (products) {
    BindProductsToGrid(products);
});

function BindProductsToGrid(products) {
    $('#tblProduct tbody').empty();
    var tr;
    console.log(products);
    $.each(products, function (index, product) {
        tr = $('<tr/>');
        console.log(product);
        tr.append(`<td>${product.id}</td>`);
        tr.append(`<td>${product.name}</td>`);
        tr.append(`<td>${product.manufacturer}</td>`);
        tr.append(`<td>${product.price}</td>`);
        tr.append(`<td>${product.releasedYear}</td>`);
        tr.append(`<a href="/Cart?id=${product.id}&handler=buy" class="btn btn-outline-primary m-1">Add to cart</a>`)
        $('#tblProduct').append(tr);
    })
}