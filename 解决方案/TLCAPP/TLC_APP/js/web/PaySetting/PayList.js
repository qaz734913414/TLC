
/// <reference path="../../Common/jquery.cookie.js" />
/// <reference path="../../Common/jquery.tmpl.js" />
/// <reference path="../../Common/jquery-1.11.2.min.js" />
/// <reference path="../../Common.js" />
/// <reference path="../../webcenter/globe.js" />


var Type = getQueryString('Type');
var code = '';
$(function () {

    PrepareInit();
    EventInit();
});

function PrepareInit() {
    $("#div_Top").empty();
    Get_GlobeCompleate = function (result, list) {
        if (result, list) {
            TopItemSet(list, Type);
        }
    };
    Get_Globe(Type);
}

function EventInit() {
    $('#sea1').on('click', SettingAll_1);
    $('#sea2').on('click', SettingAll_2);
    $('#submit').on('click', submit);
}

function submit() {
    debugger;
    var pay1 = '';
    var pay2 = '';

    $('#body1').find('input[type="number"]').each(function () {
        pay1 += $(this).val() + ",";
    });

    $('#body2').find('input[type="number"]').each(function () {
        pay2 += $(this).val() + ",";
    });

    var Return_Pay = $('#txtReturnPay').val();
    var Return_Pay2= $('#txtReturnPay2').val();

    Return_Pay = Return_Pay == '' ? 0 : Return_Pay * 0.01;
    if (Return_Pay < 0) {
        layer.msg("设置的返率格式不正确");
        return;
    }


    Return_Pay2 = Return_Pay2 == '' ? 0 : Return_Pay2 * 0.01;
    if (Return_Pay2 < 0) {
        layer.msg("设置的返率格式不正确");
        return;
    }

    pay1 = pay1.substring(0, pay1.lastIndexOf(','));
    pay2 = pay2.substring(0, pay2.lastIndexOf(','));
    Globe_PaySettingCompleate = function (resullt) {

        if (resullt) {
            PrepareInit();
        }
    };
    //
    Globe_PaySetting(code, pay1, pay2, Return_Pay, Return_Pay2)
}

function SettingAll_1() {

    if ($('#search_1').val() != '') {
        if ($('#search_1').val() > 0) {
            $('#body1').find('input[type="number"]').val($('#search_1').val())
        }
        else {
            layer.msg("设置的赔率格式不正确");
        }

    }
    else {
        layer.msg("请输入赔率大小");
    }
}

function SettingAll_2() {
    if ($('#search_2').val() != '' && $('#search_2').val() > 0) {
        $('#body2').find('input[type="number"]').val($('#search_2').val())
    }
    else {
        layer.msg("请输入赔率大小");
    }
}

function TopItemSet(list, Type) {
    //顶部
    $('#topItem').tmpl(list).appendTo("#div_Top");

    //种类切换
    $('#div_Top a').on('click', function () {
        code = $(this).attr('Code');
        $(this).addClass('selected').siblings().removeClass('selected');
        var li = list.filter(function (item) { return String(item.Code) == code });
        if (li.length > 0) {
            $('#div_search_1').show();

            $('#txtReturnPay').val(li[0].Return_Pay * 100);
            $('#txtReturnPay2').val(li[0].Return_Pay2 * 100);

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
                    Size_NormalS_List($("#body2"), li[0])
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