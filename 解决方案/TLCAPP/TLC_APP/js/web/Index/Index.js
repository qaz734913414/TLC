/// <reference path="../../Common/jquery.cookie.js" />
/// <reference path="../../Common/jquery.tmpl.js" />
/// <reference path="../../Common/jquery-1.11.2.min.js" />
/// <reference path="../../webcenter/globe_client.js" />

var CurState = 1;
$(function () {
   
    Init();
    $('#logout').on('click', function () {
        LoginOutCompleate = function (result) {
            if (result) {
                layer.msg('退出成功');

                var name = sessionStorage.getItem('tlc_app_tmpsetintpsm');
                var ut = sessionStorage.getItem(name);

                sessionStorage.removeItem('tlc_app_tmpsetintpsm');
                sessionStorage.removeItem(name);
                parent.parent.parent.location.href = "../../MainClient.html"
            }
            else {
                parent.parent.parent.location.href = "../../MainClient.html"
            }
        };
        LoginOut();
    });
});

function Init()
{
    GetAward_LastCompleate = function (result, data) {
        if (result) {

            $("#awardLast").empty();
            $("#awarLastItem").tmpl(data).appendTo("#awardLast");
        }
    }
    GetAward_Last();

    GetAward_CurrentCompleate = function (result, cur_data) {
        if (result) {
            $("#awardCurrent").empty();
            $("#awardCurrentItem").tmpl(cur_data).appendTo("#awardCurrent");
            debugger
        }
        else {
            $("#awardCurrent").html("<span >已封盘</span>");
            CurState = 0;
        }
    };
    GetAward_Current();
}


window.setInterval(function () {
    if (CurState == 0)
        return false;


    var nowSeconds = parseInt($("#ssspan").html()) - 1;
    if (nowSeconds < 0) {
        nowSeconds = 59;
        var nowMinutes = parseInt($("#MMspan").html()) - 1;
        if (nowMinutes < 0) {
            nowMinutes = 59;
            var nowHourses = parseInt($("#hhspan").html()) - 1;
            if (nowHourses < 0) {
                nowHourses = 23;
                var nowDays = parseInt($("#ddspan").html()) - 1;
                if (nowDays < 0) {
                    GetAward_Last();
                }
                $("#ddspan").html(nowDays);
            }
            $("#hhspan").html(nowHourses);
        }
        $("#MMspan").html(nowMinutes);
    }
    $("#ssspan").html(nowSeconds);
}, 1000);