/// <reference path="../webcenter/globe_client.js" />
$(function () {


});

//保存密码
function SavePwd() {
    var oldpwd = $("#txt_OldPwd").val();
    var pwd = $("#txt_Pwd").val();
    var confirmpwd = $("#txt_ConfirmPwd").val();
    var judge = !oldpwd.length || !pwd.length || !confirmpwd.length;
    if (judge) {
        layer.msg("请填写完整信息！");
        return;
    }
    if (pwd != confirmpwd) {
        layer.msg("密码不一致,请重新输入!");
        return;
    }
    layer_index = layer.load(1, {
        shade: [0.1, '#fff'] //0.1透明度的白色背景
    });
    UpdatePasswordCompleate = function (result) {
        if (result) {
            layer.msg('操作成功');
            setTimeout(function () {
                parent.CloseIFrameWindow();
            }, 300);

        }
        else {
            layer.msg('操作失败');
            layer.close(layer_index);
        }
    };
    UpdatePassword(oldpwd, pwd);
}
