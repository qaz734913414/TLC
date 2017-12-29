/// <reference path="../../Moblie/IndexClient.html" />
/// <reference path="../../Moblie/IndexClient.html" />
/// <reference path="../../Moblie/IndexClient.html" />
/// <reference path="../../Moblie/IndexClient.html" />
/// <reference path="../Common.js" />
var name = sessionStorage.getItem('tlc_app_tmpsetintpsm');
var ut = sessionStorage.getItem(name);
if (ut != null) {
    ut = JSON.parse(ut);
}


var Data = [];
function Get_GlobeCompleate() { };
function Get_Globe(Type) {
    $.ajax({
        url: HanderServiceUrl + "/Globe_Manage/Globe_Manage.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: {
            Func: "Get_Globe", Type: Type,
            //UID: ut.LoginName, dsp: ut.dsp
        },//组合input标签
        success: function (json) {
            //CheckValed(json);

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

function BuyGlobeCompleate() { };
function BuyGlobe(AwardCode, ClueCode, Buy_Content, Buy_Content2, UnitPrice, Using_Money, BuyPayReturn, BuyPayReturn2) {
    $.ajax({
        url: HanderServiceUrl + "/Client/OperationManage.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: {
            Func: "BuyGlobe", UserID: ut.LoginName, AwardCode: AwardCode, ClueCode: ClueCode,
            Buy_Content: Buy_Content, Buy_Content2: Buy_Content2, UnitPrice: UnitPrice, Using_Money: Using_Money,
            BuyPayReturn: BuyPayReturn, BuyPayReturn2: BuyPayReturn2
            , UID: ut.LoginName, dsp: ut.dsp
        },//组合input标签
        success: function (json) {
            CheckValed(json);
            if (json.result.errNum == 0) {
                BuyGlobeCompleate(true);
            }
            else {
                layer.msg(json.result.errMsg);
                BuyGlobeCompleate(false);
            }
        },
        error: function (ex) {
            //接口错误时需要执行的
        }
    });
}

function BuyGlobe_GroupCompleate() { };
function BuyGlobe_Group(AwardCode, ClueCode, Buy_Content, Buy_Content2, UnitPrice, Using_Money, BuyPayReturn, BuyPayReturn2, Count) {
    $.ajax({
        url: HanderServiceUrl + "/Client/OperationManage.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: {
            Func: "BuyGlobe_Group", UserID: ut.LoginName, AwardCode: AwardCode, ClueCode: ClueCode, Count: Count,
            Buy_Content: Buy_Content, Buy_Content2: Buy_Content2, UnitPrice: UnitPrice, Using_Money: Using_Money,
            BuyPayReturn: BuyPayReturn, BuyPayReturn2: BuyPayReturn2
            , UID: ut.LoginName, dsp: ut.dsp
        },//组合input标签
        success: function (json) {
            CheckValed(json);
            if (json.result.errNum == 0) {
                BuyGlobe_GroupCompleate(true);
            }
            else {
                layer.msg(json.result.errMsg);
                BuyGlobe_GroupCompleate(false);
            }
        },
        error: function (ex) {
            //接口错误时需要执行的
        }
    });
}


function GetUserMoneyCompleate() { };
function GetUserMoney(name) {

    name = name != undefined && name != '' ? name : ut.LoginName;


    $.ajax({
        url: HanderServiceUrl + "/Client/OperationManage.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: {
            Func: "GetUserMoney", LoginName: name
            , UID: ut.LoginName, dsp: ut.dsp
        },//组合input标签
        success: function (json) {
            CheckValed(json);
            if (json.result.errNum == 0) {
                GetUserMoneyCompleate(true, json.result.retData);
            }
            else {
                GetUserMoneyCompleate(false);
            }
        },
        error: function (ex) {
            //接口错误时需要执行的
        }
    });
}

function DebtGroupCompleate() { };
function DebtGroup(Codes, Count) {
    $.ajax({
        url: HanderServiceUrl + "/Client/OperationManage.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: {
            Func: "DebtGroup", Codes: Codes, Count: Count
            , UID: ut.LoginName, dsp: ut.dsp
        },//组合input标签
        success: function (json) {
            CheckValed(json);
            if (json.result.errNum == 0) {
                DebtGroupCompleate(true, json.result.retData);
            }
            else {
                DebtGroupCompleate(false);
            }
        },
        error: function (ex) {
            //接口错误时需要执行的
        }
    });
}




function LoginOutCompleate() { };
function LoginOut(LoginName, Password) {
    $.ajax({
        url: HanderServiceUrl + "/Admin/Admin.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: {
            Func: "LoginOut", LoginName: ut.LoginName
            , UID: ut.LoginName, dsp: ut.dsp
        },//组合input标签
        success: function (json) {
            if (json.result.errNum == 0) {
                LoginOutCompleate(true);
            }
            else {
                LoginOutCompleate(false);
            }
        },
        error: function (ex) {
            //接口错误时需要执行的
        }
    });
}

function UpdatePasswordCompleate() { };
function UpdatePassword(oldPassword, newPassword) {
    $.ajax({
        url: HanderServiceUrl + "/Admin/Admin.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: {
            Func: "UpdatePassword", LoginName: ut.LoginName, oldPassword: oldPassword, newPassword: newPassword
            , UID: ut.LoginName, dsp: ut.dsp
        },//组合input标签
        success: function (json) {
            if (json.result.errNum == 0) {
                UpdatePasswordCompleate(true);
            }
            else {
                UpdatePasswordCompleate(false);
            }
        },
        error: function (ex) {
            //接口错误时需要执行的
        }
    });
}

function GetAward_LastCompleate() { };
function GetAward_Last() {
    $.ajax({
        url: HanderServiceUrl + "/Admin/Admin.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: {
            Func: "GetAward", IsLast: true,
            //UID: ut.LoginName, dsp: ut.dsp
        },//组合input标签
        success: function (json) {
            //CheckValed(json);
            if (json.result.errNum == 0) {
                var data = json.result.retData;
                GetAward_LastCompleate(true, data);
            }
            else {
                GetAward_LastCompleate(false, data);
            }
        },
        error: function () {
            //接口错误时需要执行的
        }
    });
}

function GetAward_CurrentCompleate() { };
function GetAward_Current() {
    $.ajax({
        url: HanderServiceUrl + "/Admin/Admin.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: {
            Func: "GetAward", Current: true,
            //UID: ut.LoginName, dsp: ut.dsp
        },//组合input标签
        success: function (json) {
            //CheckValed(json);
            if (json.result.errNum == 0) {
                var data = json.result.retData;
                GetAward_CurrentCompleate(true, data);
            }
            else {
                GetAward_CurrentCompleate(false, data);
            }
        },
        error: function () {
            //接口错误时需要执行的
        }
    });
}

function GetAward_SelectCompleate() { };
function GetAward_Select(Id) {
    $.ajax({
        url: HanderServiceUrl + "/Admin/Admin.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: {
            Func: "GetAward", Id: Id,
            UID: ut.LoginName, dsp: ut.dsp
        },//组合input标签
        success: function (json) {
            CheckValed(json);
            if (json.result.errNum == 0) {
                var data = json.result.retData;
                GetAward_SelectCompleate(true, data);
            }
            else {
                GetAward_SelectCompleate(false, data);
            }
        },
        error: function () {
            //接口错误时需要执行的
        }
    });
}


function PayAwardCompleate() { };
function PayAward(Code, PrizeContent) {

    $.ajax({
        url: HanderServiceUrl + "/Admin/Admin.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: {
            Func: "PayAward", Code: Code, PayUID: ut.LoginName, PrizeContent: PrizeContent,
            UID: ut.LoginName, dsp: ut.dsp
        },//组合input标签
        success: function (json) {
            CheckValed(json);
            if (json.result.errNum == 0) {
                PayAwardCompleate(true);
            }
            else {
                layer.msg(json.result.errMsg);
                PayAwardCompleate(false);
            }
        },
        error: function () {
            //接口错误时需要执行的
        }
    });
}

function GetAwardYearCompleate() { };
function GetAwardYear() {

    $.ajax({
        url: HanderServiceUrl + "/Admin/Admin.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: {
            Func: "GetAwardYear",
            UID: ut.LoginName, dsp: ut.dsp
        },//组合input标签
        success: function (json) {
            CheckValed(json);
            if (json.result.errNum == 0) {
                GetAwardYearCompleate(true, json.result.retData);
            }
            else {
                layer.msg(json.result.errMsg);
                GetAwardYearCompleate(false);
            }
        },
        error: function () {
            //接口错误时需要执行的
        }
    });
}

function GetAwardSectionCompleate() { };
function GetAwardSection() {

    $.ajax({
        url: HanderServiceUrl + "/Admin/Admin.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: {
            Func: "GetAwardSection",
            UID: ut.LoginName, dsp: ut.dsp
        },//组合input标签
        success: function (json) {
            CheckValed(json);
            if (json.result.errNum == 0) {
                GetAwardSectionCompleate(true, json.result.retData);
            }
            else {
                layer.msg(json.result.errMsg);
                GetAwardSectionCompleate(false);
            }
        },
        error: function () {
            //接口错误时需要执行的
        }
    });
}


function GetDateTimeNowCompleate() { };
function GetDateTimeNow() {

    $.ajax({
        url: HanderServiceUrl + "/Admin/Admin.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: {
            Func: "GetDateTimeNow",        
        },//组合input标签
        success: function (json) {          
            if (json.result.errNum == 0) {
                GetDateTimeNowCompleate(true, json.result.retData);
            }
            else {
                layer.msg(json.result.errMsg);
                GetDateTimeNowCompleate(false);
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
            var name = sessionStorage.getItem('tlc_app_tmpsetintpsm');
            var ut = sessionStorage.getItem(name);

            sessionStorage.removeItem('tlc_app_tmpsetintpsm');
            sessionStorage.removeItem(name);

            setTimeout(function () {
                if (IsPC()) {
                    parent.parent.parent.location.href = "../../MainClient.html"
                }
                else {
                    parent.parent.parent.location.href = "../../../Moblie/IndexClient.html"
                }

            }, 500);
        }
    }
    else {
        //parent.parent.parent.location.href = "../../IndexClient.html"
    }
}
