



/// <reference path="../../Common/jquery.cookie.js" />
/// <reference path="../../Common/jquery.tmpl.js" />
/// <reference path="../../Common/jquery-1.11.2.min.js" />
/// <reference path="../../webcenter/globe_client.js" />

var CurState = 1;
$(function () {

    if (IsLoin) {
        GetUserMoneyCompleate = function (result, money) {
            if (result, money) {
                $('#current_money').text('目前余额：' + money);
            }
        };
        GetUserMoney();
        $('#sp_LoginName').text(ut.Name);
        $("#settingItem").tmpl(1).appendTo("#setting");
    }
    else {
        $("#loginItem").tmpl(1).appendTo("#setting");
    }

    GetAward_LastCompleate = function (result, data) {
        if (result) {

            $("#awardLast").empty();
            $("#awarLastItem").tmpl(data).appendTo("#awardLast");

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
        }
    }
    GetAward_Last();


    $('#div_Top a').on('click', function () {
        $(this).addClass('selected').siblings().removeClass('selected');
    });
    $('#div_Top a:first').trigger('click');


    $('#login').on('click', function () {
        if (!IsLoin) {
            OpenIFrameWindow('透乐彩模拟器', '../../../Moblie/Login.html', '80%', '270px', { offset: '30px' });
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
                    parent.parent.parent.location.href = "../../../Moblie/IndexClient.html";
                }
                else {
                    parent.parent.parent.location.href = "../../../Moblie/IndexClient.html";
                }
            };
            LoginOut();
        }
        else {
            parent.parent.parent.location.href = "../../../Moblie/IndexClient.html";
        }
    });


});

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
                $("#ddspan").html(nowMinutes);
            }
            $("#hhspan").html(nowMinutes);
        }
        $("#MMspan").html(nowMinutes);
    }
    $("#ssspan").html(nowSeconds);
}, 1000);