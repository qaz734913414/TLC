/// <reference path="layer/layer.js" />

HanderServiceUrl = "http://192.168.1.148/Service";

var user_Login_Tmp = '';



/**日期转换成时间字符串**/
/** date日期  **/
/** format要转换的字符串格式，默认为 "yyyy-MM-dd"格式，若没有需要的格式可自己添加 **/
function DateTimeConvert(date, format) {
    if (date == null) {
        return "";
    }
    date = date.replace(/(^\s*)|(\s*$)/g, "");
    if (date == "") {
        return "";
    }
    if (date.indexOf("Date") != -1) {
        date = eval(date.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"));
    } else {
        date = new Date(Date.parse(date));
    }
    //date = eval(date.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"));
    var year = date.getFullYear();
    var month = (date.getMonth() + 1).toString();
    var twoMonth = month.length == 1 ? "0" + month : month; //月份为1位数时，前面加0
    var day = (date.getDate()).toString();
    var twoDay = day.length == 1 ? "0" + day : day; //天数为1位数时，前面加0
    var hour = (date.getHours()).toString();
    var twoHour = hour.length == 1 ? "0" + hour : hour; //小时数为1位数时，前面加0
    var minute = (date.getMinutes()).toString();
    var twoMinute = minute.length == 1 ? "0" + minute : minute; //分钟数为1位数时，前面加0
    var second = (date.getSeconds()).toString();
    var twoSecond = second.length == 1 ? "0" + second : second; //秒数为1位数时，前面加0
    var dateTime;
    if (format == "yyyy-MM-dd HH:mm:ss") {
        dateTime = year + "-" + twoMonth + "-" + twoDay + " " + twoHour + ":" + twoMinute + ":" + twoSecond;
    } else if (format == "年月日") {
        dateTime = year + "年" + month + "月" + day + "日";
    }
    else {
        dateTime = year + "-" + twoMonth + "-" + twoDay
    }
    return dateTime;
}

function OnlyNumLimit(evt) {    
    var event = arguments.callee.caller.arguments[0] || window.event;//消除浏览器差异
    var key = event.keyCode ? event.keyCode : event.which;//兼容IE和Firefox获得keyBoardEvent对象的键值   
    if (key == 190) {
        //event.returnValue = true;
        return true;
    }

    if (!(key == 46) && !(key == 8) && !(key == 37) && !(key == 39))
        if (!((key >= 48 && key <= 57) || (key >= 96 && key <= 105)))
            return false;
}


//获取URL参数
//使用范例：var UrlDate = new GetUrlDate(); //实例化
//          var orderNo = UrlDate.orderNo;//直接.参数名
function GetUrlDate() {
    var name, value;
    var str = location.href; //取得整个地址栏
    var num = str.indexOf("?")
    str = str.substr(num + 1); //取得所有参数   stringvar.substr(start [, length ]

    var arr = str.split("&"); //各个参数放到数组里
    for (var i = 0; i < arr.length; i++) {
        num = arr[i].indexOf("=");
        if (num > 0) {
            name = arr[i].substring(0, num);
            value = arr[i].substr(num + 1);
            this[name] = value;
        }
    }
}


/*************************************IFrame弹框方法***********************************************************/
var curWinindex;
function OpenIFrameWindow(title, url, width, height) {
    //iframe层
    var index = layer.open({
        
        type: 2,
        title: title,
        shadeClose: false,
        shade: 0.2,
        area: [width, height],
        content: url //iframe的url
    });
    curWinindex = index;    
}

function OpenIFrameWindow(title, url, width, height, options) {
    var defaults = {
        type: 2,
        title: title,
        shadeClose: false,
        shade: 0.2,
        area: [width, height],
        content: url //iframe的url
    }
    options = $.extend({}, defaults, (options || {}));
    //iframe层
    var index = layer.open(options);
    curWinindex = index;
}

function CloseIFrameWindow() {
    layer.close(curWinindex);
}
function layerMsg(title) { //msg信息框
    layer.msg(title, {
        time: 0 //不自动关闭
        , btn: ['确定']
        , yes: function (index) {
            layer.close(index);
        }
    });
}

/****************************************结束********************************************************/

/**********************************************ZTree相关方法**********************************************/

//获取选择节点集合(用于ztree插件,且依赖 jquery.ztree.excheck 扩展 js )  
function getChildNodes(ulZtreeId) {
    /// <summary>获取选择节点集合(用于ztree插件,且依赖 jquery.ztree.excheck 扩展 js )</summary>
    /// <param name="ulZtreeId" type="String">Ztree树Id</param>
    /// <param name="getEndChild" type="Bool">是否只获取最低级节点的值,默认获取全部的.</param>
    var getEndChild = arguments[1] || false;

    var treeObj = $.fn.zTree.getZTreeObj(ulZtreeId);
    var treeNode = treeObj.getCheckedNodes(true);
    var data = eval(treeNode);
    var str = "";
    $.each(data, function (n, value) {
        if (getEndChild) {
            if (value.check_Child_State == '-1')  //只获取最底级节点的值
                str += value.id + ',';
        }
        else
            str += value.id + ',';

    });
    return str = str.substr(0, str.length - 1);
}

//设置指定树的节点选中(用于ztree插件,且依赖 jquery.ztree.excheck 扩展 js )  
function setNodesCheck(treeId, nodesList) {
    /// <summary>设置指定树的节点选中(用于ztree插件,且依赖 jquery.ztree.excheck 扩展 js )</summary>
    /// <param name="nodesList" type="String">节点集合(例'1,2,3')</param>
    var treeObj = $.fn.zTree.getZTreeObj(treeId);
    var strArray = nodesList.split(',');
    var nodes = null;
    treeObj.checkAllNodes(false);
    $.each(strArray, function (i, n) {
        nodes = treeObj.getNodeByParam("id", n, null);
        treeObj.checkNode(nodes, true, false, false);
    });
}

//取消指定树的节点的选中状态(用于ztree插件,且依赖 jquery.ztree.excheck 扩展 js )
function setNodesNoCheck(treeId, nodesList) {
    /// <summary>取消指定树的节点的选中状态(用于ztree插件,且依赖 jquery.ztree.excheck 扩展 js )</summary>
    /// <param name="nodesList" type="String">节点集合(例'1,2,3')</param>

    var treeObj = $.fn.zTree.getZTreeObj(treeId);
    var strArray = nodesList.split(',');
    var nodes = null;
    $.each(strArray, function (i, n) {
        nodes = treeObj.getNodeByParam("id", n, null);
        treeObj.checkNode(nodes, false, false, false);
    });
}


/**********************************************结束**********************************************/


//JS操作cookies****************************************
//获取
function getCookie(name) {
    var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
    if (arr = document.cookie.match(reg))
        return unescape(arr[2]);
    else
        return null;
}


//写cookies
function setCookie(name, value) {
    var Days = 1;
    var exp = new Date();
    exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
    document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString();
}
//删除
function delCookie(name) {
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    var cval = getCookie(name);
    if (cval != null)
        document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString();
}
//JS操作cookies****************************************





//序号
var pageNum = 1;
function pageIndex() {
    return pageNum++;
}

//列表名称长度修正
function NameLengthUpdate(Name, Length) {
    if (Name.length > Length) {
        return Name.substr(0, Length) + "...";
    }
    return Name;
}



function CalculateNumForSplit(strText) {
    if (typeof (strText) == "undefined" || strText.length == 0) {
        return 0;
    } else {
        var count = strText.split('|').length;
        return count;
    }
}

//获取当前时间
function getNowFormatDate() {
    var date = new Date();
    var seperator1 = "-";
    var seperator2 = ":";
    var month = date.getMonth() + 1;
    var strDate = date.getDate();
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    if (strDate >= 0 && strDate <= 9) {
        strDate = "0" + strDate;
    }
    var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate
            + " " + date.getHours() + seperator2 + date.getMinutes()
            + seperator2 + date.getSeconds();
    return currentdate;
}



//js 获取地址栏参数
function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return decodeURI(r[2]);
    return null;
}


function IsPC() {
    var userAgentInfo = navigator.userAgent;
    var Agents = ["Android", "iPhone",
                "SymbianOS", "Windows Phone",
                "iPad", "iPod"];
    var flag = true;
    for (var v = 0; v < Agents.length; v++) {
        if (userAgentInfo.indexOf(Agents[v]) > 0) {
            flag = false;
            break;
        }
    }
    return flag;
}
