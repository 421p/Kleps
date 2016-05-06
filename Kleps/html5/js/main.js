// $(document).ready(function() {
//     $('button').click(function () {
//         backend.log($('textarea').val());
//     });
//
//     $('.hw').click(function() {
//         alert(backend.hws.getHelloWorld());
//     });
// });

$(function(){
    $('select').change(function(){
        console.log(123)
    });
    $('select').on('mouseenter', 'option', function(e) {
        $(this).css({'background':'red'});
    });
    $('select').on('mouseleave', 'option', function(e) {
        $(this).css({'background':'none'});
    });
    $("#menu").val($("#menu option:first").val()).focus();
});

