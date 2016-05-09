$(function () {
    backend.startGame();
    var Teacher = {
        name: $("#teacher-name"),
        health: $("#hp-val"),
        healthBar: $("#hp-bar"),
        healthBarWidth: $("#hp-bar").width(),
        maxHealth: JSON.parse(backend.getTeacherJson()).health
    }
    var output = $("#events");
    var Q = $("#question");
    var A = $("#answer");
    var evil = $("#evil");


    Teacher.name.text(JSON.parse(backend.getTeacherJson()).name);

    var CurrHealth = Teacher.maxHealth;

    //Kostil bug fixer inc®
    backend.healthSound(true);
    var tos = '';
    var game = setInterval(function () {
        var events = JSON.parse(backend.getGameEventsJson());
        var health = JSON.parse(backend.getTeacherJson()).health;
        
        if (health < CurrHealth) {
            backend.healthSound();
            AnswerAnimation("red");
            CurrHealth = health;
        } else if (health < 1) {
            clearInterval(game);
            GameOver();
        }
            

        Teacher.health.text("HP:" + health);
        Teacher.healthBar.width((Teacher.healthBarWidth / 100) * ((health * 100) / Teacher.maxHealth));


        var html = '';
        for (var i in events) {
            html += '<div class="listItem"><div id="timer-' + i + '"></div></div>'; 
        }
            
            
        
        output.html(html);

        for (var i in events) {
            $('#timer-' + i).timer({
                studentName: events[i].owner.name,
                studentId: events[i].id,
                question: events[i].question,
                duration: events[i].lifeTime,
                unit: 's'
            });
            if (backend.isEvil(events[i].id) && tos != events[i].id) {
                tos = events[i].id;
                Toasty('#timer-' + i);
            }
        }
            

    }, 500);

    output.delegate(".listItem", "click", function () {
        A.html("");
        Q.html("");

        var id = localStorage.getItem("id");
        if(id != null)
            backend.startEventCountingById(id);

        id = $(this).attr("data-id");
        localStorage.setItem("id", id);
        var data = JSON.parse(backend.getEventDataById(id));
        if (Object.keys(data).length < 1) return;

        backend.stopEventCountingById(id);

        Q.append("<p>" + data.question + "</p>");

        for (var i = 0; i < data.answers.length; i++)
            A.append("<p>" + (i + 1) + ") <span>" + data.answers[i] + "</span></p>");

        A.find("span").one("click", function () {
            var a = backend.getAnswer(id, $(this).text());
            if (a) AnswerAnimation("green");
            else AnswerAnimation("red");

            localStorage.removeItem("id");
            A.html("");
            Q.html("");
        });

    });

    function AnswerAnimation(color) {
        var tick = 150;
        var timer = setInterval(function(){
            $("html").css("box-shadow", "inset 0px 0px " + tick + "px 0 " + color);
            tick--;
            if (!tick) clearInterval(timer);
        },1)
        
    }

    function Toasty(id) {
        backend.toastySound();
        evil.css("top", $(id).offset().top);
        evil.animate({ left: 0 }, 500, function () {
            setTimeout(function () {
                evil.animate({ left: -100 }, 500)
            }, 500);
        });
    }

    function GameOver() {
        var body = $("body");
        $("html").css("background-color", "#000");
        body.html("");
        body.css({
            background: "url('../img/gameover.jpg')",
            backgroundSize: "cover",
            overflow: "hidden",
            opacity: 0,
            height: "100vh",
            width: "100vw"
        })
        backend.gameOverSound();

        function bodyTick(i) {
            body.css("transform", "scale(1." + i + ")");
            body.animate({ opacity: 1 }, 50, function () {
                body.animate({ opacity: 0 }, 400)
            });
        }
        setTimeout(function () {
            bodyTick(6);
            setTimeout(function () {
                bodyTick(4);
                setTimeout(function () {
                    bodyTick(2);
                    setTimeout(function () {
                        bodyTick(0);
                        setTimeout(function () {
                            body.animate({ opacity: 1 }, 50, function () {
                                body.animate({ opacity: 0 }, 7000, function () {
                                    body.css({
                                        background: "none",
                                        opacity: 1,
                                        display: "flex",
                                        justifyContent: "center",
                                        alignItems: "center",
                                    });
                                    body.append("<a href='#'>Game Over</a>");
                                    body.find("a").one("click", function () {
                                        backend.loadStart();
                                    });
                                });
                            });
                        }, 800)
                    }, 800);
                }, 800);
            }, 800);
        }, 300);

    }
})