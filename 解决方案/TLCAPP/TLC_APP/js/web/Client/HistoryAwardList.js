
/// <reference path="../layer/layer.js" />
/// <reference path="../Common/jquery-1.11.2.min.js" />
/// <reference path="../Common/jquery.tmpl.js" />
/// <reference path="../../webcenter/award.js" />

$(function () {
    pageNum = 1;
    Init();
});

function SelectWhere() {
    key = $('#search_w').val();  
}

function Init() {
    GetAwardCompleate = function (result, data, PageIndex, PageCount, RowCount) {
        $("#tb_AwardList").empty();
        if (result) {
           
            if (data.length > 0)
            {
                HaMessage();
                //var name = $('#search_w').val();
                //var data = UserData.filter(function (item) { return item.Name.indexOf(name) > -1 });
                $("#award_Item").tmpl(data).appendTo("#tb_AwardList");
                //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                makePageBar(GetAward, document.getElementById("pageBar"), PageIndex, PageCount, 10, RowCount);

                CurrentInit();

                if(!IsPC())
                {
                    $('#pageBar').children().eq(2).hide();
                    $('#pageBar').children().eq(3).hide();
                    $('#pageBar').children().eq(5).hide();
                }
            }
            else
            {
                NoMessage($("#tb_AwardList"))
            }
            
        }
        else {
            NoMessage($("#tb_AwardList"))
        }
    };
    GetAward(1);
}

function HaMessage() {
    $('#pageBar,#control').show();
}

function NoMessage(elemnt) {
    $("#NoListItem").tmpl(1).appendTo(elemnt);
    $('#pageBar,#control').hide();
}
