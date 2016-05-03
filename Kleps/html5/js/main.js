$(document).ready(function() {
    $('button').click(function () {
        backend.log($('textarea').val());
    });

    $('.hw').click(function() {
        alert(backend.hws.getHelloWorld());
    });
});

