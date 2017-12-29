/// <reference path="../layer/layer.js" />
/// <reference path="../Common/jquery-1.11.2.min.js" />
/// <reference path="../Common/jquery.tmpl.js" />

var name = sessionStorage.getItem('tlc_app_tmpsetintpsm');
var ut = sessionStorage.getItem(name);
ut = JSON.parse(ut);


var PageSize =10;
var key = '';
var IsLast = false;
function GetUserInfoCompleate() { };
function GetUserInfo(PageIndex) {

    pageNum = (PageIndex - 1) * PageSize + 1;
    $.ajax({
        url: HanderServiceUrl + "/Admin/Admin.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: {
            Func: "GetUserInfo", PageIndex: PageIndex, Key: key,IsLast:IsLast,
            PageSize: PageSize, UID: ut.LoginName, dsp: ut.dsp
        },//组合input标签
        success: function (json) {
            CheckValed(json);
            
            if (json.result.errNum == 0) {
                var UserData = json.result.retData;
                GetUserInfoCompleate(true, UserData, json, json.result.PageIndex, json.result.PageCount, json.result.RowCount);
            }
            else {
                GetUserInfoCompleate(false);
            }
        },
        error: function () {
            //接口错误时需要执行的
        }
    });
}
function AddUserCompleate() { };
function AddUser(CreateUID, LoginName, Password, Name,  EnableTime, Role, Remarks) {
    $.ajax({
        url: HanderServiceUrl + "/Admin/Admin.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: {
            Func: "AddUser", CreateUID: CreateUID, LoginName: LoginName,
            Password: Password, Name: Name, EnableTime: EnableTime, Role: Role,
            Remarks: Remarks, UID: ut.LoginName, dsp: ut.dsp
        },//组合input标签
        success: function (json) {
            CheckValed(json);

            if (json.result.errNum == 0) {
                layer.msg('操作成功');
                AddUserCompleate(true);
            }
            else {
                layer.msg('操作失败');
                AddUserCompleate(false);
            }
        },
        error: function () {
            //接口错误时需要执行的
        }
    });
}

function EditUserCompleate() { };
function EditUser(Id, Name, EnableTime, Remarks) {
    $.ajax({
        url: HanderServiceUrl + "/Admin/Admin.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: {
            Func: "EditUser", Id: Id, Name: Name,  EnableTime: EnableTime,
            Remarks: Remarks, UID: ut.LoginName, dsp: ut.dsp
        },//组合input标签
        success: function (json) {
            CheckValed(json);

            if (json.result.errNum == 0) {
                layer.msg('操作成功');
                EditUserCompleate(true);
            }
            else {
                layer.msg('操作失败');
                EditUserCompleate(false);
            }
        },
        error: function () {
            //接口错误时需要执行的
        }
    });
}

function EnableUserCompleate() { };
function EnableUser(Id, IsEnable) {
    $.ajax({
        url: HanderServiceUrl + "/Admin/Admin.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: { Func: "EnableUser", Id: Id, IsEnable: IsEnable, UID: ut.LoginName, dsp: ut.dsp },//组合input标签
        success: function (json) {
            CheckValed(json);

            if (json.result.errNum == 0) {
                layer.msg('操作成功');
                EnableUserCompleate(true);
            }
            else {
                layer.msg('操作失败');
                EnableUserCompleate(false);
            }
        },
        error: function () {
            //接口错误时需要执行的
        }
    });
}

function ResetPasswordCompleate() { };
function ResetPassword(Id, IsEnable) {
    $.ajax({
        url: HanderServiceUrl + "/Admin/Admin.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: { Func: "ResetPassword", Id: Id, UID: ut.LoginName, dsp: ut.dsp },//组合input标签
        success: function (json) {
            CheckValed(json);

            if (json.result.errNum == 0) {
                layer.msg('操作成功');
                ResetPasswordCompleate(true);
            }
            else {
                layer.msg('操作失败');
                ResetPasswordCompleate(false);
            }
        },
        error: function () {
            //接口错误时需要执行的
        }
    });
}


function GetUserCompleate() { };
function GetUser(Id) {
    $.ajax({
        url: HanderServiceUrl + "/Admin/Admin.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: { Func: "GetUser", Id: Id, UID: ut.LoginName, dsp: ut.dsp },//组合input标签
        success: function (json) {
            CheckValed(json);

            if (json.result.errNum == 0) {
                GetUserCompleate(true, json.result.retData);
            }
            else {
                GetUserCompleate(false, null);
            }
        },
        error: function () {
            //接口错误时需要执行的
        }
    });
}

function AddUserMoneyCompleate() { };
function AddUserMoney(Id, Money) {
    $.ajax({
        url: HanderServiceUrl + "/Admin/Admin.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: { Func: "AddUserMoney", Id: Id, Money: Money, UID: ut.LoginName, dsp: ut.dsp },//组合input标签
        success: function (json) {
            CheckValed(json);

            if (json.result.errNum == 0) {
                AddUserMoneyCompleate(true);
            }
            else {
                AddUserMoneyCompleate(false, null);
            }
        },
        error: function () {
            //接口错误时需要执行的
        }
    });
}

function ReduceUserMoneyCompleate() { };
function ReduceUserMoney(Id, Money) {
    $.ajax({
        url: HanderServiceUrl + "/Admin/Admin.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: { Func: "ReduceUserMoney", Id: Id, Money: Money, UID: ut.LoginName, dsp: ut.dsp },//组合input标签
        success: function (json) {
            CheckValed(json);

            if (json.result.errNum == 0) {
                ReduceUserMoneyCompleate(true);
            }
            else {
                ReduceUserMoneyCompleate(false, null);
            }
        },
        error: function () {
            //接口错误时需要执行的
        }
    });
}


var MoneyPageSize = 10;
var MoneyLoginName = "";
function GetMoneyLogCompleate() { };
function GetMoneyLog(PageIndex) {
    $.ajax({
        url: HanderServiceUrl + "/Admin/Admin.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: {
            Func: "GetMoneyLog", LoginName: MoneyLoginName, PageIndex: PageIndex,
            PageSize: MoneyPageSize, UID: ut.LoginName, dsp: ut.dsp
        },//组合input标签
        success: function (json) {
            CheckValed(json);

            if (json.result.errNum == 0) {
                GetMoneyLogCompleate(true, json.result.retData, json.result.PageIndex, json.result.PageCount, json.result.RowCount);
            }
            else {
                GetMoneyLogCompleate(false, null);
            }
        },
        error: function () {
            //接口错误时需要执行的
        }
    });
}

function CheckValed(json) {
    if (json != null) {
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
    else {
        if (IsPC()) {
            parent.parent.parent.location.href = "../../MainClient.html"
        }
        else {
            parent.parent.parent.location.href = "../../../Moblie/IndexClient.html"
        }
    }
}
