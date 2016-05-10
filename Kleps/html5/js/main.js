$(function () {
    var ROOT = window.location.href;
    
    var Menu = $('#menu');
    MainMenu();
    Menu.on('mouseenter', 'option', function(e) {
        $(this).css({'background':'red'});
    });
    Menu.on('mouseleave', 'option', function(e) {
        $(this).css({'background':'none'});
    });
    Menu.val(Menu.find("option:first").val());

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
    Menu.on("keydown click", function (e) {
        backend.musicClick();
        var m = Menu.find("option:selected");
        switch(e.which){
            case 1:
            case 13:
            case 32:{
                backend.menuAction(m.val());
                switch (m.val()) {
                    case "options":
                        OptionsMenu();
                        break;
                    case "back":
                        MainMenu();
                        break;
                    case "music":
                        if(Music.flag) m.text("Music: OFF");
                        else m.text("Music: ON");
                        Music.mute();
                        Music.flag = !Music.flag;
                        break;
                    case "volume":
                        switch(m.text()){
                            case "Volume: MEDIUM":
                                backend.musicVolume(100);
                                m.text("Volume: HIGH");
                                break;
                            case "Volume: HIGH":
                                backend.musicVolume(20);
                                m.text("Volume: LOW");
                                break;
                            case "Volume: LOW":
                                backend.musicVolume(50);
                                m.text("Volume: MEDIUM");
                                break;
                        }
                        break;
                    case "screen":
                        switch (m.text()) {
                            case "Screen: FULL":
                                backend.changeScreenSize(false);
                                m.text("Screen: WINDOW");
                                break;
                            case "Screen: WINDOW":
                                backend.changeScreenSize(true);
                                m.text("Screen: FULL");
                                break;
                        }
                        break;
                    case "credits":
                        Credits();

                }


            }

                break;
            default: return;
        }
    });
    function MainMenu(){
        Menu.html('<option value="start" >Start Game</option>' +
        '<option value="options">Options</option>' +
        '<option value="credits">Credits</option>' +
        '<option value="exit">Exit</option>');
    }
    function OptionsMenu() {
            Menu.html('<option value="music">' + (Music.flag ? "Music: ON" : "Music: OFF") + '</option>' +
        '<option value="volume">Volume: MEDIUM</option>' +
        '<option value="screen">Screen: FULL</option>' +
        '<option value="back">Back</option>');
        }

    function Credits(){
        Menu.hide();
        var Credit = false;
        var Credits = $("#credits");
        Credits.show();
        var translate = Credits.height();
        backend.startSubtitleMusic();
        var animate = setInterval(function () {
            Credits.css("transform", "perspective(50px) rotateX(3deg) translate3d(0px, " + (translate--) + "px, 10px)");
            if (translate < -(Credits.height() * 2))
                $(document).click();
        }, 1000 / 30);
        $(document).on("keydown click", function () {
            if (Credit) {
                Credits.hide();
                backend.stopSubtitleMusic();
                clearInterval(animate);
                Credits.css("transform", "perspective(50px) rotateX(5deg) translate3d(0px, 0px, 10px)");
                Menu.show();
                $(document).off("keypress click");
                Menu.focus();
            }
            Credit = true;

        })

    }
});

