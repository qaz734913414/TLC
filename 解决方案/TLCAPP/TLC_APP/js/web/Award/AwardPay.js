
/// <reference path="../../Common/jquery.cookie.js" />
/// <reference path="../../Common/jquery.tmpl.js" />
/// <reference path="../../Common/jquery-1.11.2.min.js" />
/// <reference path="../../webcenter/globe_client.js" />
/// <reference path="../../webcenter/award.js" />
var id = getQueryString("itemid");
var Code = getQueryString("Code");
var yearList = [];
$(function () {

    var yearS = 2017;
    for (var i = 0; i < 50; i++) {
        var yeaobj = { Name: yearS, Code: i };
        yearList.push(yeaobj);
        yearS++;
    }
    $("#select_year").empty();
    $("#yearItem").tmpl(yearList).appendTo("#select_year");

    //关闭事件
    parent.lay_close_compleate = function () {
        $dp.hide();
    };

    GetAward_SelectCompleate = function (result, cur_data) {
        if (result) {
            $('#select_year').find('option[text="' + cur_data.Year + '"]').prop("selected", 'selected');

            $('#txtSection').val(cur_data.Name);
            $('#txtStartTime').val(DateTimeConvert(cur_data.StartTime, 'yyyy-MM-dd HH:mm:ss'));
            $('#txtCloseTime').val(DateTimeConvert(cur_data.CloseTime, 'yyyy-MM-dd HH:mm:ss'));
            $('#txtEndTime').val(DateTimeConvert(cur_data.EndTime, 'yyyy-MM-dd HH:mm:ss'));

            if (cur_data.PrizeContent != null && cur_data.PrizeContent != '') {
                var list = cur_data.PrizeContent.split(',');;

                if (list.length == 7) {
                    $('#txtNum1').val(list[0]);
                    $('#txtNum2').val(list[1]);
                    $('#txtNum3').val(list[2]);
                    $('#txtNum4').val(list[3]);
                    $('#txtNum5').val(list[4]);
                    $('#txtNum6').val(list[5]);
                    $('#txtNum7').val(list[6]);

                }
            }


        }
        else {

        }
    };
    GetAward_Select(id);
});


function sumbit() {


    //输入球
    var contetnt = '';
    var result = true;

    var contentList = [];
    $('.number_n').each(function () {
        var num = $(this).val();
        num = Number(num);
        if (num > 49 || num <= 0) {
            result = false;
        }
        contetnt += num + ',';
        contentList.push(num);
    });

    contetnt = contetnt.substring(0, contetnt.lastIndexOf(','));
    contetnt = result ? contetnt : '';

    if (contetnt != '') {
        if (isRepeat(contentList)) {
            layer.msg('不可设置重复奖号');
            return;
        }
    }
    else {
        layer.msg('请设置奖号');
        return;
    }
    layer_index = layer.load(1, {
        shade: [0.1, '#fff'] //0.1透明度的白色背景
    });
    PayAwardCompleate = function (result) {
        if (result) {
            layer.msg('派奖成功');
            setTimeout(function () {
                parent.Init();
                parent.CurrentInit();
                parent.CloseIFrameWindow();
            }, 300);
        }
        else {
            layer.close(layer_index);
        }
    };

    PayAward(Code, contetnt);
}