
/// <reference path="../../Common/jquery.cookie.js" />
/// <reference path="../../Common/jquery.tmpl.js" />
/// <reference path="../../Common/jquery-1.11.2.min.js" />
/// <reference path="../../webcenter/userinfo.js" />
/// <reference path="../../My97DatePicker/WdatePicker.js" />

$(function () {
    //关闭事件
    parent.lay_close_compleate = function () {
        $dp.hide();
    };
});
function btn_AddUser() {

    var LoginName = $('#txt_name').val();
    var Name = $('#txt_user').val();
    //var Money = $('#txt_money').val();
    var EnableTime = $('#txt_enabletime').val();
    var Remarks = $('#txt_remark').val();
    var Role = 2;

    if (LoginName == '') {
        layer.msg("登录名不能为空");
        return;
    }
    if (Name == '') {
        layer.msg("用户名不能为空");
        return;
    }
    //if (Money == '') {
    //    layer.msg("请输入金额");
    //    return;
    //}
    if (EnableTime == '请设置启用时间') {
        layer.msg("姓名不能为空");
        return;
    }
    layer_index = layer.load(1, {
        shade: [0.1, '#fff'] //0.1透明度的白色背景
    });
    AddUserCompleate = function (result) {
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
    AddUser("", LoginName, "", Name, EnableTime, Role, Remarks);
}


