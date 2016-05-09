(function ($) {
  'use strict';

  $.fn.timer = function (options) {

    var settings = $.extend({
        studentName: "Jhon Doe",
        studentId : "qwe1234sadasd",
        question: "What is the day today?",
        duration: 30,
        unit: 's'
    }, options);

    return this.each(function () {

        var studentName = settings.studentName,
            studentId = settings.studentId,
            question = settings.question,
            duration = settings.duration,
            unit = settings.unit;

      var $$ = $(this);

      $$.html('<div class="timer-bg"><span class="duration"></span><small class="unit"></small></div>' +
        '<div class="timer-half-container right"><div class="timer-half right"></div></div>' +
        '<div class="timer-half-container left"><div class="timer-half left"></div></div>')
          .parent().append('<div class="student"><span class="studentName">'+studentName+'</span>' +
                    '<span class="studentQuestion">' + question + '</span>' +
                '</div>');

      $$.addClass('timer');
      $$.find('.unit').html(unit);

      $$.attr('data-duration', duration);
      $$.parent().attr('data-id', studentId);
      $$.find('.duration').html(duration);

    });

  };
}(jQuery));

