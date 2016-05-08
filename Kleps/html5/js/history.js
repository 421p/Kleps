$(function () {
    //start Enter Name
    $("#name").focus();
    $(document).on("keydown click", function (e) {
        switch (e.which) {
            case 38:
                $("#name").focus();
                break;
            case 40:
                $("#accept a").focus();
                break;
            case 13:
                if ($("#name").val().length < 1)
                    $("#name").css("border", "1px solid red").focus();
                else {
                    $(document).off("keydown click");
                    startGame();
                }
                break;
            default:
                $("#name").css("border", "none");
                break;
        }
        if ($("#accept a").is(":focus")) {
            switch (e.which) {
                case 1:
                case 13:
                case 32:
                    if ($("#name").val().length < 1)
                        $("#name").css("border","1px solid red").focus();
                    else {
                        $(document).off("keydown click");
                        backend.setName($("#name").val());
                        startGame();
                    }
                    break;
            }
        }
    });
    //end Enter Name

    //start History
    $("body").delegate("#translate", "click", function () {
        var state = backend.historyRusSoundMute();
        if(!state)
            $(this).text("Russian: ON");
        else $(this).text("Russian: OFF");
    });
    function startGame() {
        $(document).one("keydown", function () {
            backend.gameInit();
        })
        $(".container").html('<div class="col-md-12 game-container"><output id="subtitle"></output><output id="translate"><a href="#">Russian: OFF</a></output></div>');
        $("body").css("background", "#000");
        $("#history").fadeIn(1000);
        setTimeout(function () {
            setTimeout(function () {
                backend.startHistory();
                setTimeout(function () {
                    backend.historyRusSound();
                    backend.historyEngSound();
                    setTimeout(function () {
                        $("#subtitle").html("Once upon a time, all students became a zombies...");
                        setTimeout(function () {
                            $("#subtitle").html("But not that type of zombies what you thinking about.");
                            setTimeout(function () {
                                $("#subtitle").html("They should get an answers on their questions....or you will die.");
                            }, 4000);
                        }, 4000);
                    }, 500);
                }, 2000);
                
            }, 1500);
            $("#history").animate({
                marginLeft: '-=650px'
            }, 30000, function () {
                $("#history").fadeOut(1000);
                setTimeout(function () {
                    backend.gameInit();
                }, 1000);
            });
        }, 500);
    }

    //end History
})