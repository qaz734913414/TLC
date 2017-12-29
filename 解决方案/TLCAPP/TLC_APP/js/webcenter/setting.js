var name = sessionStorage.getItem('tlc_app_tmpsetintpsm');
var ut = sessionStorage.getItem(name);
ut = JSON.parse(ut);

function ServiceTempClearCompleate() { };
function ServiceTempClear(PageIndex) {

    pageNum = (PageIndex - 1) * PageSize + 1;

    $.ajax({
        url: HanderServiceUrl + "/Admin/Admin.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: {
            Func: "ServiceTempClear",
            UID: ut.LoginName, dsp: ut.dsp
        },//组合input标签
        success: function (json) {
            CheckValed(json);
            if (json.result.errNum == 0) {             
                ServiceTempClearCompleate(true);
            }
            else {
                ServiceTempClearCompleate(false);
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

