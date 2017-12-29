/// <reference path="../Common.js" />
var name = sessionStorage.getItem('tlc_app_tmpsetintpsm');
var ut = sessionStorage.getItem(name);
ut = JSON.parse(ut);

var key = '';
var PageSize = 10;
function GetAwardCompleate() { };
function GetAward(PageIndex) {

    pageNum = (PageIndex - 1) * PageSize + 1;

    $.ajax({
        url: HanderServiceUrl + "/Admin/Admin.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: {
            Func: "GetAward", PageIndex: PageIndex, Current: false,
            PageSize: PageSize, Key: key,
            UID: ut.LoginName, dsp: ut.dsp
        },//组合input标签
        success: function (json) {
            CheckValed(json);
            if (json.result.errNum == 0) {
                var data = json.result.retData;              
                GetAwardCompleate(true, data, json.result.PageIndex, json.result.PageCount, json.result.RowCount);
            }
            else {
                GetAwardCompleate(false, data);
            }
        },
        error: function () {
            //接口错误时需要执行的
        }
    });
}



function AddAwardCompleate() { };
function AddAward(Year, Name, StartTime, CloseTime, PrizeContent) {

    $.ajax({
        url: HanderServiceUrl + "/Admin/Admin.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: {
            Func: "AddAward", Year: Year, Name: Name, StartTime: StartTime,
            CloseTime: CloseTime, PrizeContent: PrizeContent,
            CreateUID: ut.LoginName,
            UID: ut.LoginName, dsp: ut.dsp
        },//组合input标签
        success: function (json) {
            CheckValed(json);
            if (json.result.errNum == 0) {
                AddAwardCompleate(true);
            }
            else {
                layer.msg(json.result.errMsg);
                AddAwardCompleate(false);
            }
        },
        error: function () {
            //接口错误时需要执行的
        }
    });
}

function EditAwardCompleate() { };
function EditAward(Id, Year, Name, StartTime, CloseTime, PrizeContent) {

    $.ajax({
        url: HanderServiceUrl + "/Admin/Admin.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: {
            Func: "EditAward", Id: Id, Year: Year, Name: Name, StartTime: StartTime,
            CloseTime: CloseTime, PrizeContent: PrizeContent,
            EditUID: ut.LoginName,
            UID: ut.LoginName, dsp: ut.dsp
        },//组合input标签
        success: function (json) {
            CheckValed(json);
            if (json.result.errNum == 0) {
                EditAwardCompleate(true);
            }
            else {
                layer.msg(json.result.errMsg);
                EditAwardCompleate(false);
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
            if (IsPC())
            {
                parent.parent.parent.location.href = "../../MainClient.html"
            }
            else
            {
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


function isRepeat(arr) {
    var hash = {};
    for (var i in arr) {
        if (hash[arr[i]])
            return true;
        hash[arr[i]] = true;
    }
    return false;

}
