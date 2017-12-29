var name = sessionStorage.getItem('tlc_app_tmpsetintpsm');
var ut = sessionStorage.getItem(name);
ut = JSON.parse(ut);

var key = '';
var key2 = '';
var PageSize = 8;
var Year = '';
var Section = '';
var LoginName = '';

function GetOperationCompleate() { };
function GetOperation(PageIndex) {

    pageNum = (PageIndex - 1) * PageSize + 1;

    $.ajax({
        url: HanderServiceUrl + "/Client/OperationManage.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: {
            Func: "GetOperation", PageIndex: PageIndex,Year:Year,Section:Section,
            PageSize: PageSize, Key: key,IsHistory:true,LoginName:LoginName,
            UID: ut.LoginName, dsp: ut.dsp
        },//组合input标签
        success: function (json) {
            CheckValed(json);
            if (json.result.errNum == 0) {
                var data = json.result.retData;
                GetOperationCompleate(true, data, json, json.result.PageIndex, json.result.PageCount, json.result.RowCount);
            }
            else {
                GetOperationCompleate(false, data);
            }
        },
        error: function () {
            //接口错误时需要执行的
        }
    });
}


//序号
var page_CurrentNum = 1;
function pageIndexCurrent() {
    return page_CurrentNum++;
}

function GetOperationCurrentCompleate() { };
function GetOperationCurrent(PageIndex) {

    page_CurrentNum = (PageIndex - 1) * PageSize + 1;

    $.ajax({
        url: HanderServiceUrl + "/Client/OperationManage.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: {
            Func: "GetOperation", PageIndex: PageIndex,
            PageSize: PageSize, Key: key2,  Current: true,
            UID: ut.LoginName, dsp: ut.dsp
        },//组合input标签
        success: function (json) {
            CheckValed(json);
            if (json.result.errNum == 0) {
                var data = json.result.retData;
                GetOperationCurrentCompleate(true, data, json.result.PageIndex, json.result.PageCount, json.result.RowCount);
            }
            else {
                GetOperationCurrentCompleate(false, data);
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