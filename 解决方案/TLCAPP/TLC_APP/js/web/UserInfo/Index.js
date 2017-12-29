
/// <reference path="../../Common/jquery.cookie.js" />
/// <reference path="../../Common/jquery.tmpl.js" />
/// <reference path="../../Common/jquery-1.11.2.min.js" />
/// <reference path="../../webcenter/userinfo.js" />

$(function () {
    pageNum = 1;
    Init();
});

function SelectWhere() {
    key = $('#search_w').val();
    GetUserInfo(1);
}

function Init() {
    IsLast = true;
    GetUserInfoCompleate = function (result, UserData, json, PageIndex, PageCount, RowCount) {
        $("#tb_UserList").empty();
        if (result) {
            if (UserData.length > 0) {
                HaMessage();

                //var data = UserData.filter(function (item) { return item.Name.indexOf(name) > -1 });
                $("#tr_User").tmpl(UserData).appendTo("#tb_UserList");

                //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                makePageBar(GetUserInfo, document.getElementById("pageBar"), PageIndex, PageCount, 10, RowCount);

                $("#Person_Add").text("新增人数：" + json.result.PersonCount);
                $("#Money_Cash").text("提现总额：" + json.result.CashMoney);
                $("#Money_Left").text("余额：" + json.result.AllMoney);
            }
            else {
                NoMessage($("#tb_UserList"));
            }
        }
        else {
            NoMessage($("#tb_UserList"));
        }
    };
    GetUserInfo(1);
}
function HaMessage() {
    $('#pageBar,#control').show();
}

function NoMessage(elemnt) {
    $("#NoListItem").tmpl(1).appendTo(elemnt);
    $('#pageBar,#control').hide();
}


function ChangeUseStatus(Id, IsEnable) {
    EnableUserCompleate = function (result) {
        if (result) {
            Init();
        }
    };
    EnableUser(Id, IsEnable);
}
