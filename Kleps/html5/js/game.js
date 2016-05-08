$(function () {
    backend.startGame();
    var Teacher = {
        name: $("#teacher-name"),
        health: $("#hp-val"),
        healthBar: $("#hp-bar")
    }
    var output = $("#events");

    Teacher.name.text(JSON.parse(backend.getTeacherJson()).name);

    setInterval(function () {
        var events = JSON.parse(backend.getGameEventsJson());

        Teacher.health.text("HP:" + JSON.parse(backend.getTeacherJson()).health);

        var html = '';
        for (var i in events)
                html += '<div class="listItem"><div id="timer-' + i + '"></div></div>';
            
        
        output.html(html);

        for (var i in events)
            $('#timer-' + i).timer({
                studentName: events[i].owner.name,
                question: events[i].question,
                duration: events[i].lifeTime,
                unit: 's'
            });

    }, 100);
})