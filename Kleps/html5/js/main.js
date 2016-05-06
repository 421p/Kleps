$(function(){
        var Menu = $('#menu');
    Menu.on('mouseenter', 'option', function(e) {
        $(this).css({'background':'red'});
    });
    Menu.on('mouseleave', 'option', function(e) {
        $(this).css({'background':'none'});
    });
    Menu.val(Menu.find("option:first").val()).focus();

    var Music = {
        mute: backend.musicMute,
        flag: true,
        volume: 50,
        start: backend.musicStart,
        setVolume: function(val){
            backend.musicVolume(val);
        }
    };

    Music.start();
    Menu.on("keypress click", function(e){
        switch(e.which){
            case 1:
            case 13:
            case 32:
                backend.log(Menu.find("option:selected").val());
                break;
            default: return;
        }
    });

    $("#audio").click(function(){
        Music.mute();
        if(Music.flag) $(this).text("Music: OFF");
        else $(this).text("Music: ON");
        Music.flag = !Music.flag;
    });
});

