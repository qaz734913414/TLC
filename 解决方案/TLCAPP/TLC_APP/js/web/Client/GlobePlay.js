

/// <reference path="../../Common/jquery.cookie.js" />
/// <reference path="../../Common/jquery.tmpl.js" />
/// <reference path="../../Common/jquery-1.11.2.min.js" />
/// <reference path="../../Common.js" />
/// <reference path="../../webcenter/globe_client.js" />

var Type = getQueryString('Type');
var Second_Type = '';
var code = '';

//可供子窗体使用
var select_list1 = [];
var select_list2 = [];
var current_li = null;
var singleMoney;

var CurState = parent.CurState;

$(function () {
    PrepareInit();

    $('.btn-bottom-reset').on('click', function () {
        PrepareInit();
    });

    $('.btn-bottom-bet').on('click', function () {

        if (IsLoin) {
            singleMoney = $('#singleMoney').val();
            if (Type == 1 || Type == 2 || Type == 3 || Type == 4 || Type == 6 || Type == 7 || Type == 8) {
                
                if (select_list1.length == 0 && select_list2.length == 0) {
                    layer.msg('请选择码');
                }
                else if (singleMoney == '') {
                    layer.msg('请输入金额');
                }
                else if (!isPositiveInteger(singleMoney)) {
                    layer.msg('输入金额格式错误');
                }
                else {
                    OpenPanel();
                }
            }
            else {
                if (current_li != null) {
                    if (select_list1.length >= current_li.Limit_Min) {
                        if (singleMoney == '') {
                            layer.msg('请输入金额');
                        }
                        else if (!isPositiveInteger(singleMoney)) {
                            layer.msg('输入金额格式错误');
                        }
                        else {
                            OpenPanel_Gourp();
                        }
                    }
                    else {
                        layer.msg('请至少选择' + current_li.Limit_Min + '个码');
                    }
                }
                else {
                    layer.msg('出现异常');
                }
            }
        }
        else {
            layer.msg('请先登录');

            OpenIFrameWindow('透乐彩模拟器', '../../../Login.html', '720px', '500px');
        }

    });
});


function isPositiveInteger(s) {//是否为正整数
    var re = /^[0-9]+$/;
    return re.test(s)
}

function OpenPanel() {

    OpenIFrameWindow('下注面板', 'BuyPanel.html', '620px', '400px');
}

function OpenPanel_Gourp() {
    OpenIFrameWindow('下注面板', 'BuyPanel_Gourp.html', '620px', '400px');
}

function PrepareInit() {

    //if (Type == 1 || Type == 2 || Type == 3 || Type == 4 || Type == 6 || Type == 7) {
    //    $('#singleMoney').show();
    //}
    //else {
    //    $('#singleMoney').hide();
    //}

    $("#div_Top").empty();
    select_list1 = [];
    select_list2 = [];
    Get_GlobeCompleate = function (result, list) {
        if (result, list) {
            TopItemSet(list, Type);
        }
    };
    Get_Globe(Type);
}

function EventInit() {
    $('#body1').find('.textConter').on('click', ItemSelect1);
    $('#body2').find('.textConter').on('click', ItemSelect2);
}

function ItemSelect1() {
   
    if ($(this).hasClass('td_select')) {
        $(this).removeClass('td_select');
        var tds = $(this).parent().find('td[part="line_part"]');
        if (tds.length > 0) {
            tds.removeClass('td_select');
        }
        var code = $(this).find('label[class="pay_return"]').attr('code');
        select_list1 = select_list1.filter(function (item) { return item.Code != code });
    }
    else {
        $(this).addClass('td_select');
        var tds = $(this).parent().find('td[part="line_part"]');
        if (tds.length > 0) {
            tds.addClass('td_select');
        }

        var code = $(this).find('label[class="pay_return"]').attr('code');
        var list = null;
        if (Type == '1' || Type == '2' || Type == '3' || Type == '5' || Type == '12') {
            list = current_li.Globe_S_List;
        }
        else if (Type == '4') {
            list = current_li.Size_Six_S_List;
        }
        else if (Type == '6') {
            list = current_li.Wave_List;
        }
        else if (Type == '7' || Type == '8' || Type == '9' || Type == '10') {
            list = current_li.Animal_List;
        }
        else if (Type == '11') {
            list = current_li.Detail_List;
        }
        list = list.filter(function (item) { return item.Code == code });
        if (list.length > 0) {
            select_list1.push(list[0]);
        }
    }

}

function ItemSelect2() {
   
    if ($(this).hasClass('td_select')) {
        $(this).removeClass('td_select');
        debugger
        var code = $(this).find('label[class="pay_return"]').attr('code');
        select_list2 = select_list2.filter(function (item) { return item.Code != code });
    }
    else {
        $(this).addClass('td_select');

        var code = $(this).find('label[class="pay_return"]').attr('code');
        var list = null;
        if (Type == '1') {
            list = current_li.Size_S_List;
        }
        else if (Type == '3') {
            list = current_li.Size_NormalS_List;
        }
        else if (Type == '7') {
            list = current_li.Detail_List;
        }
        list = list.filter(function (item) { return item.Code == code });
        if (list.length > 0) {
            select_list2.push(list[0]);
        }
    }

}

function submit() {
    BuyGlobeCompleate = function (result) {
        if (result) {

        }
    };
    BuyGlobe(AwardCode, ClueCode, Buy_Content, Piece, Using_Money, BuyPayReturn);
}

function TopItemSet(list, Type) {
    //顶部
    $('#topItem').tmpl(list).appendTo("#div_Top");
    //种类切换
    $('#div_Top a').on('click', function () {
        select_list1 = [];
        select_list2 = [];

        code = $(this).attr('Code');
        $(this).addClass('selected').siblings().removeClass('selected');
        var li = list.filter(function (item) { return String(item.Code) == code });

        if (li.length > 0) {
            current_li = li[0];
            Second_Type = current_li.Second_Type;
            $('#div_search_1').show();
            switch (Type) {
                case "1":
                    $('#div_search_2').show();
                    //第一部
                    Globe_S_List($("#body1"), li[0]);
                    Size_S_List($("#body2"), li[0]);

                    break;
                case "2":
                    //第一部
                    Globe_S_List($("#body1"), li[0]);
                    break;
                case "3":
                    $('#div_search_2').show();
                    //第一部
                    Globe_S_List($("#body1"), li[0]);
                    Size_NormalS_List($("#body2"), li[0]);

                    break;

                case "4":
                    //第一部
                    Size_Six_S_List($("#body1"), li[0]);
                    break;
                case "5":
                    //第一部
                    Globe_S_List($("#body1"), li[0]);
                    break;
                case "6":
                    //第一部
                    Wave_List($("#body1"), li[0]);
                    break;
                case "7":
                    $('#div_search_2').show();
                    //第一部
                    Animal_List($("#body1"), li[0]);
                    Detail_List($("#body2"), li[0]);
                    break;
                case "8":
                    //第一部
                    Animal_List($("#body1"), li[0]);
                    break;
                case "9":
                    //第一部
                    Animal_List($("#body1"), li[0]);
                    break;
                case "10":
                    //第一部
                    Animal_List($("#body1"), li[0]);
                    break;
                case "11":
                    //第一部
                    Detail_List($("#body1"), li[0]);
                    break;
                case "12":
                    //第一部
                    Globe_S_List($("#body1"), li[0]);
                    break;
                default:
            }

            EventInit();
        }
    });
    if (code != '') {
        $('#div_Top').find('a[code="' + code + '"]').trigger('click');
    }
    else {
        $('#div_Top a').eq(0).trigger('click');
    }

}

function Globe_S_List(body, li) {
    body.empty();
    var count = 0;
    var indedity = '';
    for (var i in li.Globe_S_List) {
        var globe = li.Globe_S_List[i];
        globe.PayReturn = Number(globe.PayReturn).toFixed(2);
        if (count == 0) {
            indedity = globe.Name + count;
            body.append('<tr id=' + indedity + '></tr>');
        }
        $('#globeItem').tmpl(globe).appendTo("#" + indedity);
        count++;
        if (count == 6) {
            count = 0;
        }
    }
}

function Size_NormalS_List(body, li) {
    body.empty();
    var count = 0;
    var indedity = '';

    for (var i in li.Size_NormalS_List) {
        var size = li.Size_NormalS_List[i];
        size.PayReturn = Number(size.PayReturn).toFixed(2);
        if (count == 0) {
            indedity = size.Name + count;
            body.append('<tr id=' + indedity + '></tr>');
        }
        $('#sizeItem').tmpl(size).appendTo("#" + indedity);
        count++;
        if (count == 6) {
            count = 0;
        }
    }
}

function Size_S_List(body, li) {
    body.empty();
    var count = 0;
    var indedity = '';

    for (var i in li.Size_S_List) {
        var size = li.Size_S_List[i];
        size.PayReturn = Number(size.PayReturn).toFixed(2);
        if (count == 0) {
            indedity = size.Name + count;
            body.append('<tr id=' + indedity + '></tr>');
        }
        $('#sizeItem').tmpl(size).appendTo("#" + indedity);
        count++;
        if (count == 6) {
            count = 0;
        }
    }
}

function Size_Six_S_List(body, li) {
    body.empty();
    var count = 0;
    var indedity = '';
    for (var i in li.Size_Six_S_List) {
        var size = li.Size_Six_S_List[i];
        size.PayReturn = Number(size.PayReturn).toFixed(2);
        if (count == 0) {
            indedity = size.Name + count;
            body.append('<tr id=' + indedity + '></tr>');
        }
        $('#sizeItem').tmpl(size).appendTo("#" + indedity);
        count++;
        if (count == 6) {
            count = 0;
        }
    }
}

function Wave_List(body, li) {
    body.empty();
    var count = 0;
    var indedity = '';

    for (var i in li.Wave_List) {
        var size = li.Wave_List[i];
        size.PayReturn = Number(size.PayReturn).toFixed(2);
        $('#waveItem').tmpl(size).appendTo(body);
    }
}

function Animal_List(body, li) {
    body.empty();
    var count = 0;
    var indedity = '';
    for (var i in li.Animal_List) {
        var size = li.Animal_List[i];
        size.PayReturn = Number(size.PayReturn).toFixed(2);
        $('#waveItem').tmpl(size).appendTo(body);
    }
}

function Detail_List(body, li) {
    body.empty();
    var count = 0;
    var indedity = '';
    for (var i in li.Detail_List) {
        var detail = li.Detail_List[i];
        detail.PayReturn = Number(detail.PayReturn).toFixed(2);
        if (count == 0) {
            indedity = detail.Name + count;
            body.append('<tr id=' + indedity + '></tr>');
        }
        $('#detailItem').tmpl(detail).appendTo("#" + indedity);
        count++;
        if (count == 3) {
            count = 0;
        }
    }
}



