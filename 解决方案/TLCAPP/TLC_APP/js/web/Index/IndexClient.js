
/// <reference path="../../Common/jquery.cookie.js" />
/// <reference path="../../Common/jquery.tmpl.js" />
/// <reference path="../../Common/jquery-1.11.2.min.js" />
/// <reference path="../../webcenter/globe_client.js" />

var CurState = 1;
$(function () {

    if (IsLoin) {
        GetMoney();
        $('#sp_LoginName').text(ut.Name);
        $("#settingItem").tmpl(1).appendTo("#setting");

        $("#navicate_Item2").tmpl(1).appendTo("#ul_leftmenu");
    }
    else {
        $("#loginItem").tmpl(1).appendTo("#setting");
        $("#navicate_Item").tmpl(1).appendTo("#ul_leftmenu");
    }

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
        }
        else {
            $("#awardCurrent").html("<span >已封盘</span>");
            CurState = 0;
        }
    };
    GetAward_Current();

    $('#login').on('click', function () {
        if (!IsLoin) {
            OpenIFrameWindow('透乐彩模拟器', 'Login.html', '720px', '500px');
        }
    });

    $('#logout').on('click', function () {
        if (IsLoin) {
            LoginOutCompleate = function (result) {
                var name = sessionStorage.getItem('tlc_app_tmpsetintpsm');
                var ut = sessionStorage.getItem(name);

                sessionStorage.removeItem('tlc_app_tmpsetintpsm');
                sessionStorage.removeItem(name);

                if (result) {
                    layer.msg('退出成功');
                    parent.parent.parent.location.href = "../../MainClient.html"
                }
                else {
                    parent.parent.parent.location.href = "../../MainClient.html"
                }
            };
            LoginOut();
        }
        else {
            parent.parent.parent.location.href = "../../MainClient.html"
        }
    });


});

function GetMoney() {
    GetUserMoneyCompleate = function (result, money) {
        if (result, money) {
            $('#current_money').text('目前余额：' + money);
        }
    };
    GetUserMoney();
}

window.setInterval(function () {
    if (CurState == 0)
        return false;


    var nowSeconds = parseInt($("#ssspan").html()) - 1;
    if (nowSeconds < 0) {
        if (parseInt($("#MMspan").html()) == 0 && parseInt($("#hhspan").html()) == 0 && parseInt($("#ddspan").html()) == 0) {
            location.href = location.href;
        }

        nowSeconds = 59;
        var nowMinutes = parseInt($("#MMspan").html()) - 1;
        if (nowMinutes < 0) {
            nowMinutes = 59;
            var nowHourses = parseInt($("#hhspan").html()) - 1;
            if (nowHourses < 0) {
                nowHourses = 23;
                var nowDays = parseInt($("#ddspan").html()) - 1;
                if (nowDays < 0) {

                }
                $("#ddspan").html(nowMinutes);
            }
            $("#hhspan").html(nowMinutes);
        }
        $("#MMspan").html(nowMinutes);
    }

    $("#ssspan").html(nowSeconds);
}, 1000);