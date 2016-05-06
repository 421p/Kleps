$(function(){
    var Menu = $('#menu');
    MainMenu();
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
        backend.musicClick();
        var m = Menu.find("option:selected");
        switch(e.which){
            case 1:
            case 13:
            case 32:{
                backend.menuAction(m.val());
                switch(m.val()){
                    case "options":
                        OptionsMenu();
                        break;
                    case "back":
                        MainMenu();
                        break;
                    case "music":
                        if(Music.flag) m.text("Music: OFF");
                        else m.text("Music: ON");
                        MusicChange();
                        break;
                    case "volume":

                }


            }

                break;
            default: return;
        }
    });

    $("#audio").click(MusicChange);

    //Options

    function MusicChange(){
        Music.mute();
        if(Music.flag) $("#audio").text("Music: OFF");
        else $("#audio").text("Music: ON");
        Music.flag = !Music.flag;
    }
    function MainMenu(){
        Menu.html('<option value="start">Start Game</option>' +
        '<option value="options">Options</option>' +
        '<option value="credits">Credits</option>' +
        '<option value="exit">Exit</option>');
    }
    function OptionsMenu() {
            Menu.html('<option value="music">' + (Music.flag ? "Music: ON" : "Music: OFF") + '</option>' +
        '<option value="volume">Volume: Medium</option>' +
        '<option value="back">Back</option>');
        }
});

