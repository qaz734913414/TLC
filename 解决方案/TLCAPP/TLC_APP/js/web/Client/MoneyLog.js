



/// <reference path="../../Common/jquery.cookie.js" />
/// <reference path="../../webcenter/userinfo.js" />
/// <reference path="../../Common/jquery.tmpl.js" />

/// <reference path="../../Common/jquery-1.11.2.min.js" />
/// <reference path="../../webcenter/userinfo.js" />
/// <reference path="../../webcenter/globe_client.js" />

MoneyLoginName = getQueryString("LoginName");
var UserName = getQueryString("UserName");
var Money = getQueryString("Money");
var id = getQueryString("itemid");
$(function () {
    pageNum = 1;

    $('.Save_and_submit').on('click', Save);
    $('.Cash_and_submit').on('click', Cash);
   
    $('#user_M').text('当前用户：' + UserName);


    //关闭事件
    parent.lay_close_compleate = function () {
        //parent.Init();
    };



    Init();
});

function Init() {
    GetMoneyLogCompleate = function (result, UserData, PageIndex, PageCount, RowCount) {
        if (result) {
           
            $("#tb_MoneyList").empty();
            //var data = UserData.filter(function (item) { return item.Name.indexOf(name) > -1 });
            $("#tr_Money").tmpl(UserData).appendTo("#tb_MoneyList");

            //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
            makePageBar(GetMoneyLog, document.getElementById("pageBar"), PageIndex, PageCount, 8, RowCount);
        }
    };
    GetMoneyLog(1);

    GetUserMoneyCompleate = function (result, money) {
        if (result, money) {
            $('#money_M').text('余额：' + money);
        }
    };
    GetUserMoney(MoneyLoginName);

}
function Save()
{
    OpenIFrameWindow('充值', '../../../UserInfo/AddMoney.html?itemid='+id, '620px', '300px');
}

function Cash()
{
    OpenIFrameWindow('提现', '../../../UserInfo/CashMoney.html?itemid=' + id, '620px', '300px');
}


//function submit()
//{
//    
//    var money = $('#chargeMoney').val();
//    money = Number(money);
  
//    if(money >0)
//    {
//        AddUserMoneyCompleate = function (result) {
           
//            if(result)
//            {
//                layer.msg('充值成功');
               
//                Init();
//            }
//        };
//        AddUserMoney(id, money)
//    }
//    else
//    {
//        layer.msg('输入的金额格式不正确');
//    }
//}






