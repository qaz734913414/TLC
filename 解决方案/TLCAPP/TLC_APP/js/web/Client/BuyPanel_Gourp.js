/// <reference path="../../Common/jquery.cookie.js" />
/// <reference path="../../Common/jquery.tmpl.js" />
/// <reference path="../../Common/jquery-1.11.2.min.js" />
/// <reference path="../../Common.js" />
/// <reference path="../../webcenter/globe_client.js" />


var select_list1 = parent.select_list1;
var select_list2 = parent.select_list2;
var First_Type = parent.Type;
var Second_Type = parent.Second_Type;
var code = parent.code;
var singleMoney = parent.singleMoney;
var CurState = parent.CurState;
var current_li = parent.current_li;

var select1List = '';
var select2List = '';

var payReturn1 = [];
var payReturn2 = '';

var total = 0;
var total_get = 0;

$(function () {

    //debugger;
    if (select_list1.length > 0) {
        select_list1.filter(function (item) {
            item.singleMoney = singleMoney;
           
            select1List += item.Code + ',';
        });
    }
    //if (select_list2.length > 0) {
    //    select_list2.filter(function (item) {
    //        item.singleMoney = singleMoney;
    //        //total = Number(singleMoney);
    //        //total_get = Number(singleMoney) * Number(item.PayReturn);
    //        select2List += item.Code + ',';
    //    });
    //}

    select1List = select1List.substring(0, select1List.lastIndexOf(','));
    select2List = select2List.substring(0, select2List.lastIndexOf(','));


    $("#tb_buylist").empty();

    //$("#buy_Item").tmpl(select_list2).appendTo("#tb_buylist");
  


    GetUserMoneyCompleate = function (result, money) {
        if (result, money) {
            $('#current_money').text('目前余额：' + money);
        }
    };
    GetUserMoney();

    DebtGroupCompleate = function (result, data) {
        if (result) {
            for (var i in data) {

                var da_list = data[i].split(',');
                var pareturn_center = 0;
                var Name = '';
                var Money = 0;

                var rep = '';
              
                for (var j in da_list) {
                    var p = select_list1.filter(function (item) { return item.Code == da_list[j] });

                    if (p.length > 0) {
                        p = p[0];
                        if (pareturn_center > p.PayReturn || pareturn_center == 0) {
                            pareturn_center = p.PayReturn;
                            Name = '一注';
                            Money = p.Money;
                        }
                        $("#buy_Item").tmpl(p).appendTo("#tb_buylist");

                        rep += p.PayReturn + ',';
                    }
                }
                rep = rep.substring(0, rep.lastIndexOf(','));
                payReturn1.push(rep);
                var center = { Name: Name, PayReturn: pareturn_center, Money: Money };
                $("#buy_Item_Space").tmpl(center).appendTo("#tb_buylist");

                total += Number(singleMoney);
                total_get += Number(singleMoney) * Number(pareturn_center);

            }
            //总金额
            $('#total').text(total.toFixed(2));
            $('#total_get').text(total_get.toFixed(2));
        }
    }
    DebtGroup(select1List, current_li.Limit_Min);


});

function hideConfirm() {
    parent.CloseIFrameWindow();
}

function subBet() {

    if (CurState == 0) {
        layer.msg('已封盘,无法下注');
        return;
    }

    //BuyType

    GetAward_CurrentCompleate = function (result, cur_data) {
        if (result) {
            layer_index = layer.load(1, {
                shade: [0.1, '#fff'] //0.1透明度的白色背景
            });
            BuyGlobe_GroupCompleate = function (result) {
                if (result) {
                    layer.msg("买入成功");
                    setTimeout(function () {
                        parent.PrepareInit();
                        if (IsPC()) {
                            parent.parent.GetMoney();
                        }
                        parent.CloseIFrameWindow();
                    }, 600);
                }
                else {
                    layer.close(layer_index);
                }
            };
            BuyGlobe_Group(cur_data.Code, code, select1List, select_list2, singleMoney, total, JSON.stringify(payReturn1), JSON.stringify(payReturn2), current_li.Limit_Min)
        }
        else {
            layer.msg('已封盘,无法下注');
        }
    };
    GetAward_Current();
}





