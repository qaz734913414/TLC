
/// <reference path="../../Common.js" />

/// <reference path="../../Common/jquery.cookie.js" />
/// <reference path="../../Common/jquery.tmpl.js" />
/// <reference path="../../Common/jquery-1.11.2.min.js" />
/// <reference path="../../webcenter/userinfo.js" />
/// <reference path="../../My97DatePicker/WdatePicker.js" />
var id = getQueryString("itemid");
$(function () {
    //关闭事件
    parent.lay_close_compleate = function () {
        $dp.hide();
    };


    GetUserCompleate = function (result, user) {
        if (result) {
            $('#txt_user').val(user.Name);
            $('#txt_money').val(user.Money.toFixed(2));
            $('#txt_enabletime').val(DateTimeConvert(user.EnableTime));
            $('#txt_name').val(user.LoginName);
            $('#txt_remark').val(user.Remarks);
        }
    };
    GetUser(id);
});
function btn_EditUser() {
    var Name = $('#txt_user').val();
    //var Money = $('#txt_money').val();
    var EnableTime = $('#txt_enabletime').val();
    var Remarks = $('#txt_remark').val();
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

    EditUserCompleate = function (result) {        
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
    EditUser(id, Name, EnableTime, Remarks);
}

function btn_ResetPassword() {
    ResetPasswordCompleate = function (result) {
        if (result) {
            setTimeout(function () {
                parent.Init();
                parent.CloseIFrameWindow();
            }, 300);
        }
    };
    ResetPassword(id);
}


