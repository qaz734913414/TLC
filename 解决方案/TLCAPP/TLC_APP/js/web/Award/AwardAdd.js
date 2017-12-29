

/// <reference path="../../Common/jquery.cookie.js" />
/// <reference path="../../Common/jquery.tmpl.js" />
/// <reference path="../../Common/jquery-1.11.2.min.js" />
/// <reference path="../../webcenter/award.js" />

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
});


function sumbit() {



    //输入球
    var contetnt = '';
    var result = true;
    //奖号编辑数量
    var re_count = 0;

    var contentList = [];
    $('.number_n').each(function () {
        var num = $(this).val();
        num = Number(num);
        if (num > 49 || num <= 0) {
            result = false;
        }
        else {
            re_count++;
        }
        contetnt += num + ',';
        contentList.push(num);
    });

    if (re_count >= 1 && re_count < 7) {
        layer.msg('设置奖号不完整');
        $('.number_n').val(0);
        return;
    }



    contetnt = contetnt.substring(0, contetnt.lastIndexOf(','));
    contetnt = result ? contetnt : '';

    if (contetnt != '') {
        if (isRepeat(contentList)) {
            layer.msg('不可设置重复奖号');
            return;
        }
    }

    var year = $('#select_year').find('option:selected').text();
    var section = $('#txtSection').val();
    var startTime = $('#txtStartTime').val();
    var closeTime = $('#txtCloseTime').val();
    var endTime = $('#txtEndTime').val();

    if (section == 0) {
        layer.msg('请填写期号');
        return;
    }
    if (startTime == '') {
        layer.msg('请选择开始时间');
        return;
    }
    if (closeTime == '') {
        layer.msg('请选择封盘时间');
        return;
    }
    //if (endTime == '') {
    //    layer.msg('请选择结束时间');
    //    return;
    //}


    //if (endTime < startTime) {
    //    layer.msg('结束时间必须大于开始时间');
    //    return;
    //}

    if (closeTime < startTime) {
        layer.msg('封盘时间必须大于开始时间');
        return;
    }

    //if (closeTime > endTime) {
    //    layer.msg('封盘时间必须小于结束时间');
    //    return;
    //}
    layer_index = layer.load(1, {
        shade: [0.1, '#fff'] //0.1透明度的白色背景
    });
    AddAwardCompleate = function (result) {
        if (result) {
            setTimeout(function () {
                parent.Init();
                parent.CloseIFrameWindow();
            }, 300);
        }
        else {
            layer.close(layer_index);
        }
    };
    AddAward(year, section, startTime, closeTime, contetnt);
}