/// <reference path="../../webcenter/award.js" />


/// <reference path="../../Common/jquery.cookie.js" />
/// <reference path="../../Common/jquery.tmpl.js" />
/// <reference path="../../Common/jquery-1.11.2.min.js" />
/// <reference path="../../webcenter/operation.js" />
/// <reference path="../../webcenter/globe_client.js" />
var key, key2;
var data_section = [];
var lastYear = '';
var lastSection = '';

var name = sessionStorage.getItem('tlc_app_tmpsetintpsm');
var ut = sessionStorage.getItem(name);
if (ut != null) {
    ut = JSON.parse(ut);
    LoginName = ut.LoginName;
}

$(function () {


    pageNum = 1;
    Init();
    GetAward_CurrentCompleate = function (result, data) {
        if (result) {

            $('#award_year').text('年号：' + data.Year);
            $('#award_Name').text('期号：' + data.Name);
        }
    }
    GetAward_Current();
});

function Init() {

    $("#select_year").on('change', function () {
        Year = $('#select_year').find("option:selected").text();
        section_selct();
        var year_num = Number(Year);
        if (year_num == lastYear) {
            $('#select_section option[Name=' + lastSection + ']').attr("selected", true);
        }

        Section = $('#select_section').find("option:selected").text();
        DataInit();
    });
    $("#select_section").on('change', function () {
        Section = $('#select_section').find("option:selected").text();
        DataInit();
    });
    GetAwardYearCompleate = function (result, data) {
        if (result) {
            $("#select_year").empty();
            $("#yearItem").tmpl(data).appendTo("#select_year");
        }
    };
    GetAwardYear();
    GetAwardSectionCompleate = function (result, data) {
        if (result) {
            data_section = data;
            section_selct();
        }
    };
    GetAwardSection();

    GetAward_LastCompleate = function (result, data) {
        if (result) {
            lastYear = data.Year;
            lastSection = data.Name;
            Year = data.Year;
            Section = data.Name;
        }
    }
    GetAward_Last();


    GetAward_CurrentCompleate = function (result, data) {
        if (result) {
            if (data != undefined && data != null) {
                lastYear = data.Year;
                lastSection = data.Name;
                Year = data.Year;
                Section = data.Name;
            }
        }
    };
    GetAward_Current();

    $('#select_year option[Year=' + Year + ']').attr("selected", true);;
    $('#select_section option[Name=' + Section + ']').attr("selected", true);

    DataInit();
}
function DataInit() {
    PageSize = 10;
    GetOperationCompleate = function (result, UserData, json, PageIndex, PageCount, RowCount) {
        $("#tb_PrizeList,#awardContent").empty();
        if (result) {
            if (UserData.length > 0) {
                HaMessage()
                data_change(UserData);
                $("#tr_Prize").tmpl(UserData).appendTo("#tb_PrizeList");
                //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                makePageBar(GetOperation, document.getElementById("pageBar"), PageIndex, PageCount, 10, RowCount);
                $("#buy_M").text("下注总金额：" + json.result.Using_MoneyTotal);
                $("#get_M").text("获奖总金额：" + json.result.Get_MoneyTotal);
                //$("#araw_return_M").text("和局返回总额：" + json.result.Araw_ReturnMoneyTotal);
                $("#return_M").text("返水总金额：" + json.result.Return_MoneyTotal);

                if (UserData[0].IsWin == 3) {
                    $("#AwardNoItem").tmpl(1).appendTo("#awardContent");
                }
                else {
                    $("#AwardItem").tmpl(UserData[0]).appendTo("#awardContent");
                }
                $('#pageBar').children().eq(2).hide();
                $('#pageBar').children().eq(3).hide();
                $('#pageBar').children().eq(4).hide();
            }
            else {
                NoMessage($("#tb_PrizeList"));

            }
        }
        else {
            NoMessage($("#tb_PrizeList"));
        }
    };
    GetOperation(1);
}

function HaMessage() {
    $('#pageBar,#control').show();
}

function NoMessage(elemnt) {
    $("#NoListItem").tmpl(1).appendTo(elemnt);
    $('#pageBar,#control').hide();
    $("#AwardNoItem").tmpl(1).appendTo("#awardContent");
}


function data_change(UserData) {
    UserData.filter(function (item) {
        if (item.BuyDisplay2 != null && item.BuyDisplay2 != '') {
            //item.BuyDisplay2 = item.BuyDisplay2.substring(0, item.BuyDisplay2.lastIndexOf(','));
            item.BuyDisplay2 = item.BuyDisplay2.replace(/,/g, '、');
        }
        else {
            //item.BuyDisplay = item.BuyDisplay.substring(0, item.BuyDisplay.lastIndexOf(','))
            item.BuyDisplay = item.BuyDisplay.replace(/,/g, '、');
        }
        item.BuyPayReturn += "," + item.BuyPayReturn2;
        if (item.BuyDisplay2 != null) {
            //debugger;
            item.BuyPayReturn += '、';
        }
        item.BuyPayReturn = item.BuyPayReturn.replace(/,/g, '、');

    });
}


function section_selct() {
    var text = $('#select_year').find("option:selected").text();
    var realdata = data_section.filter(function (item) { return item.Year == text })
    $("#select_section").empty();
    $("#sectionItem").tmpl(realdata).appendTo("#select_section");
}



