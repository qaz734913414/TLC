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

var select1List = '';
var select2List = '';

var payReturn1 = '';
var payReturn2 = '';

var total1 = 0;
var total2 = 0;
var total_get = 0;

$(function () {
   
    if (select_list1.length > 0) {
        select_list1.filter(function (item) {
            item.singleMoney = singleMoney;
            total1 += Number(singleMoney);
            total_get += Number(singleMoney) * Number(item.PayReturn);

            select1List += item.Code + ',';
            payReturn1 += item.PayReturn + ',';
        });
    }
    if (select_list2.length > 0) {
        select_list2.filter(function (item) {
            item.singleMoney = singleMoney;
            total2 += Number(singleMoney);
            total_get += Number(singleMoney) * Number(item.PayReturn);

            select2List += item.Code + ',';
            payReturn2 += item.PayReturn + ',';
        });
    }

    select1List = select1List.substring(0, select1List.lastIndexOf(','));
    select2List = select2List.substring(0, select2List.lastIndexOf(','));
    payReturn1 = payReturn1.substring(0, payReturn1.lastIndexOf(','));
    payReturn2 = payReturn2.substring(0, payReturn2.lastIndexOf(','));

    $("#tb_buylist").empty();
    $("#buy_Item").tmpl(select_list1).appendTo("#tb_buylist");
    $("#buy_Item").tmpl(select_list2).appendTo("#tb_buylist");
    var allTotal = Number(total1) + Number(total2);
    //总金额
    $('#total').text(allTotal.toFixed(2));
    $('#total_get').text(total_get.toFixed(2));


    GetUserMoneyCompleate = function (result, money) {
        if (result, money) {
            $('#current_money').text('目前余额：' + money);
        }
    };
    GetUserMoney();
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
            BuyGlobeCompleate = function (result) {
                if (result) {
                    layer.msg("买入成功");
                    setTimeout(function () {
                        parent.PrepareInit();
                        if (IsPC())
                        {
                            parent.parent.GetMoney();
                        }                       
                        parent.CloseIFrameWindow();
                    }, 600);
                }
                else {
                    layer.close(layer_index);
                }
            };
            if (select1List != '')
            {
                BuyGlobe(cur_data.Code, code, select1List, "", singleMoney, total1, payReturn1, "")
            }
            if (select_list2 != '')
            {
                BuyGlobe(cur_data.Code, code, "", select2List, singleMoney, total2, "", payReturn2)
            }
           
        }
        else {
            layer.msg('已封盘,无法下注');
        }
    };
    GetAward_Current();
}