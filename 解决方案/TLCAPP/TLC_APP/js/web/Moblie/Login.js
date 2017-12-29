

/// <reference path="../layer/layer.js" />
/// <reference path="../Common/jquery-1.11.2.min.js" />
/// <reference path="../Common/jquery.tmpl.js" />
/// <reference path="../webcenter/login.js" />
$(function () {


    //回车提交事件
    $("body").keydown(function (evt) {
        var event = arguments.callee.caller.arguments[0] || window.event;//消除浏览器差异
        var key = event.keyCode ? event.keyCode : event.which;//兼容IE和Firefox获得keyBoardEvent对象的键值   
        if (key == "13") {//keyCode=13是回车键
            $("#BtnLogin").click();
        }
    });

    //加载验证码
    createCode();
});

var code; //在全局 定义验证码
function createCode() {
    code = "";
    var codeLength = 4;//验证码的长度
    $('#checkCode').text('');
    var selectChar = new Array(1, 2, 3, 4, 5, 6, 7, 8, 9, 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z');

    for (var i = 0; i < codeLength; i++) {
        var charIndex = Math.floor(Math.random() * 60);
        code += selectChar[charIndex];
    }
    if (code.length != codeLength) {
        createCode();
    }
    $('#checkCode').text(code);
}

function Login() {
    var inputCode = $('#inpCode').val().toUpperCase();
    var codeToUp = code.toUpperCase();

    if (inputCode.length <= 0) {
        layer.msg("请输入验证码！");
        return false;
    }
    else if (inputCode != codeToUp) {
        layer.msg("验证码输入错误！");
        createCode();
        $("#inpCode").val('').focus();
        return false;
    }
    else {
        var loginName = $("#txt_loginName").val();
        var passWord = $("#txt_passWord").val();
        Login_SelfCompleate = function (result, retdata) {
            if (result) {
                user_Login_Tmp = retdata.dsp;
                var user_str = JSON.stringify(retdata);
                sessionStorage.setItem('tlc_app_tmpsetintpsm', user_Login_Tmp)
                sessionStorage.setItem(user_Login_Tmp, user_str);
                var s = sessionStorage.getItem(user_Login_Tmp)

                if (retdata.Role == 1) {
                    layer.msg('请使用pc登录管理系统');
                }
                else if (retdata.Role == 2) {
                    parent.parent.parent.location.href = "../../../Moblie/IndexClient.html";
                }
            }
            else {
                layer.msg(retdata);
            }
        };
        Login_Self(loginName, passWord);
    }
}


//屏蔽右键菜单  
document.oncontextmenu = function (event) {
    if (window.event) {
        event = window.event;
    } try {
        var the = event.srcElement;
        if (!((the.tagName == "INPUT" && the.type.toLowerCase() == "text") || the.tagName == "TEXTAREA")) {
            return false;
        }
        return true;
    } catch (e) {
        return false;
    }
}


//屏蔽粘贴  
document.onpaste = function (event) {
    if (window.event) {
        event = window.event;
    } try {
        var the = event.srcElement;
        if (!((the.tagName == "INPUT" && the.type.toLowerCase() == "text") || the.tagName == "TEXTAREA")) {
            return false;
        }
        return true;
    } catch (e) {
        return false;
    }
}


//屏蔽复制  
document.oncopy = function (event) {
    if (window.event) {
        event = window.event;
    } try {
        var the = event.srcElement;
        if (!((the.tagName == "INPUT" && the.type.toLowerCase() == "text") || the.tagName == "TEXTAREA")) {
            return false;
        }
        return true;
    } catch (e) {
        return false;
    }
}


//屏蔽剪切  
document.oncut = function (event) {
    if (window.event) {
        event = window.event;
    } try {
        var the = event.srcElement;
        if (!((the.tagName == "INPUT" && the.type.toLowerCase() == "text") || the.tagName == "TEXTAREA")) {
            return false;
        }
        return true;
    } catch (e) {
        return false;
    }
}


//屏蔽选中  
document.onselectstart = function (event) {
    if (window.event) {
        event = window.event;
    } try {
        var the = event.srcElement;
        if (!((the.tagName == "INPUT" && the.type.toLowerCase() == "text") || the.tagName == "TEXTAREA")) {
            return false;
        }
        return true;
    } catch (e) {
        return false;
    }
}