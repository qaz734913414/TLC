function Login_SelfCompleate() { };
function Login_Self(LoginName, Password) {
    $.ajax({
        url: HanderServiceUrl + "/Admin/Admin.ashx",
        type: "post",
        async: false,
        dataType: "json",
        data: { Func: "Login", LoginName: LoginName, Password: Password },//组合input标签
        success: function (json) {           
            if (json.result.errNum == 0) {
                Login_SelfCompleate(true, json.result.retData);              
            }
            else {
                Login_SelfCompleate(false, json.result.errMsg);
            }
        },
        error: function (ex) {
            //接口错误时需要执行的
        }
    });
}



