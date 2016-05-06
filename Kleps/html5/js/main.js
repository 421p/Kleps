$(function(){
    var Menu = $('#menu');

    Menu.on('mouseenter', 'option', function(e) {
        $(this).css({'background':'red'});
    });
    Menu.on('mouseleave', 'option', function(e) {
        $(this).css({'background':'none'});
    });
    Menu.val(Menu.find("option:first").val()).focus();
    Menu.on("keypress click", function(e){
        switch(e.which){
            case 1:
            case 13:
            case 32:
                frontendHelper.select(Menu.find("option:selected").val());
                break;
            default: return;
        }
    });
    $("#audio").click(function(){
        
        if(BackgroundSong.muted) $(this).text("Music: OFF");
        else $(this).text("Music: ON");
    });
});

