/// <reference path="../../webcenter/award.js" />


/// <reference path="../../Common/jquery.cookie.js" />
/// <reference path="../../Common/jquery.tmpl.js" />
/// <reference path="../../Common/jquery-1.11.2.min.js" />
/// <reference path="../../webcenter/operation.js" />
/// <reference path="../../webcenter/globe_client.js" />

LoginName = getQueryString("LoginName");
var UserName = getQueryString("UserName");
var Money = getQueryString("Money");
$(function () {
    pageNum = 1;
    Init();
    GetAward_CurrentCompleate = function (result, data) {
        if (result) {

            $('#award_year').text('年号：' + data.Year);
            $('#award_Name').text('期号：' + data.Name);
        }
    }
    GetAward_Current();

    $('#user_M').text('当前用户：' + UserName);
    $('#money_M').text('余额：' + Money);
});

function Init() {          
    DataInit();
}
function DataInit() {
    GetOperationCompleate = function (result, UserData, json, PageIndex, PageCount, RowCount) {
        if (result) {
            $("#tb_PrizeList").empty();
            data_change(UserData);
            $("#tr_Prize").tmpl(UserData).appendTo("#tb_PrizeList");
            //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
            makePageBar(GetOperation, document.getElementById("pageBar"), PageIndex, PageCount, 10, RowCount);

            $("#buy_M").text("下注总金额：" + json.result.Using_MoneyTotal);
            $("#get_M").text("获奖总金额：" + json.result.Get_MoneyTotal);
            //$("#araw_return_M").text("和局返回总额：" + json.result.Araw_ReturnMoneyTotal);
            $("#return_M").text("返水总金额：" + json.result.Return_MoneyTotal);          
        }
    };
    GetOperation(1);  
}

function data_change(UserData) {
    UserData.filter(function (item) {
        if (item.BuyDisplay2 != null && item.BuyDisplay2 != '') {
            item.BuyDisplay2 = item.BuyDisplay2.substring(0, item.BuyDisplay2.lastIndexOf(','));
        }
        else {
            item.BuyDisplay = item.BuyDisplay.substring(0, item.BuyDisplay.lastIndexOf(','))
        }
        item.BuyPayReturn += "," + item.BuyPayReturn2;
        item.BuyPayReturn = item.BuyPayReturn.substring(0, item.BuyPayReturn.lastIndexOf(','));
        item.BuyPayReturn = item.BuyPayReturn.replace(/,/g, '、');

    });
}





