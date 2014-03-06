/// <reference path="jquery-1.9.1.js" />
$(document).ready(function () {
    $("#div_change").click(function () {
        $("#div_img").html("loading");
        var json = "";
        $.ajax({
            type: 'get',
            url: 'lst.aspx',
            cache: false,
            async: true,
            error: function () {
                $("#div_img").html("error");
            },
            success: function (data) {
                json = data;
                var imgurl = "img.aspx?idjson=" + json + "&rn=" + Math.random();
                var data = new Date();
                $("#div_img").html("<img alt=\"\" src=\"" + imgurl + "\" style=\"width:50px;height:50px;\"\>");
                $("#div_des").html("time:" + data.getHours() + ":" + data.getMinutes() + ":" + data.getSeconds() + "");
                $("#div_array").html("id:" + json);
            }
        });


    });
});