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
            case 1:
            case 13:
            case 32:
                if ($("#name").val().length < 1)
                    $("#name").css("border","1px solid red").focus();
                else {
                    $(document).off("keydown click");
                    startGame();
                }
                break;
            default:
                $("#name").css("border", "none");
                break;
        }
    });
    //end Enter Name

    //start Game
    function startGame() {
        $(".container").html('<div class="col-md-12 game-container"><output></output></div>');
        $("body").css("background", "#000");
        $("#history").fadeIn(1000);
        setTimeout(function () {
            setTimeout(function () {
                bakend.startHistory();
                $("output").html("Once upon a time, all students became a zombies...");
            }, 1500);
            $("#history").animate({
                marginLeft: '-=650px'
            }, 30000, function () {
                $("#history").fadeOut(1000);
            });
        }, 500);
    }

    //end Game
})