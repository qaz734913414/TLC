var name = sessionStorage.getItem('tlc_app_tmpsetintpsm');
var ut = sessionStorage.getItem(name);
ut = JSON.parse(ut);

var Data = [];
function Get_GlobeCompleate() { };
function Get_Globe(Type) {
    $.ajax({
        url: HanderServiceUrl + "/Globe_Manage/Globe_Manage.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: { Func: "Get_Globe", Type: Type, UID: ut.LoginName, dsp: ut.dsp },//组合input标签
        success: function (json) {
            CheckValed(json);
            if (json.result.errNum == 0) {

                Data = json.result.retData;

                Get_GlobeCompleate(true, Data);
            }
            else {
                Get_GlobeCompleate(false, Data);
            }
        },
        error: function (ex) {
            //接口错误时需要执行的
        }
    });
}

function Globe_PaySettingCompleate() { };
function Globe_PaySetting(Code, Pay1, Pay2, Return_Pay, Return_Pay2) {
    $.ajax({
        url: HanderServiceUrl + "/Globe_Manage/Globe_Manage.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: { Func: "Globe_PaySetting", Code: Code, Pay1: Pay1, Pay2: Pay2, Return_Pay: Return_Pay, Return_Pay2: Return_Pay2, UID: ut.LoginName, dsp: ut.dsp },//组合input标签
        success: function (json) {
            CheckValed(json);

            if (json.result.errNum == 0) {
                Data = json.result.retData;
                layer.msg('操作成功');
                Globe_PaySettingCompleate(true);
            }
            else {
                layer.msg('操作成功');
                Globe_PaySettingCompleate(false);
            }
        },
        error: function (ex) {
            //接口错误时需要执行的
        }
    });
}

function CheckValed(json) {
    if (json.result.errNum == 1000) {
        layer.msg(json.result.errMsg);
        if (IsPC()) {
            parent.parent.parent.location.href = "../../MainClient.html"
        }
        else {
            parent.parent.parent.location.href = "../../../Moblie/IndexClient.html"
        }
    }
}

