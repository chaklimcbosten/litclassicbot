$(function () {

    $('<button>Ajax</button>').appendTo('#buttonDiv').click(function (e) {
        $.get('flowers.html', function (data) {
            $(data).filter('div').addClass('dcell')
                .slice(0, 3).appendTo('#row1').end().end()
                .slice(3).appendTo('#row2')
        });

        e.preventDefault();
    });

});