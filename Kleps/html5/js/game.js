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


    //end Game
})