$(function () {

    var twithub = $.connection.twithub;
    twithub.client.NewTwit = function (data) {
        console.log("New twit: " + data);
        
        $.ajax({
            url: '/Home/TwitPartial/' + data,
            success: function (html) {
                var newTwit = $(html);
                newTwit.hide();
                $("#twits").prepend(newTwit);
                newTwit.fadeIn();
            },
        });


    };
    $.connection.hub.start();

});
