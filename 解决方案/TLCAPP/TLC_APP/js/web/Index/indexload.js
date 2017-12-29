$(function () {
    function reSize() {
        $('.box .left').height($(window).height() - 60 + 'px');
        $('.box .right,#iframbox').height($(window).height() - 60 + 'px');
    }
    reSize();
    $(window).resize(function () {
        reSize();
    })


    $('#ul_leftmenu').find('.li_menu').each(function () {
        var parent_this = $(this);
        if (parent_this.find('li').length == 1) {
            parent_this.on('click', function () {
                //
                //if (parent_this.find('.submenu').css('display') == true) {
                //    alert(1);
                //}
            });
        }
    });
    $("#menubox").find(".menuclick").click(function () {
        $(this).parent().toggleClass("selected").siblings().removeClass("selected");
        $(this).next().slideToggle("fast").end().parent().siblings().find(".submenu")
        .addClass("animated flipInX")
        .slideUp("fast").end().find("i").text("+");
        var t = $(this).find("i").text();
        $(this).find("i").text((t == "+" ? "-" : "+"));
    });
    //默认进入视图显示第一个页面
    $('#menubox').find('li:eq(0)').children('ul').show();
    $('#menubox').find('li:eq(0)').children('ul').children('li:eq(0)').addClass('selected');
    $('#menubox').find('li:eq(0)').find('.icon-icoxiala').addClass('active');
})
function loading() {
    var silderBox = document.getElementById("sliderbox");//dom对象
    var adoms = silderBox.getElementsByTagName("a");//这是一个集合对象HTMLCollection对象
    //document.getElementsByClassName document.querySelectorAll(".items");
    var len = adoms.length;
    while (len--) {
        adoms[len].onclick = function () {
            var src = this.getAttribute("data-src");

            //$(".submenu li").each(function(){
            //$(this).removeClass("selected");
            // });

            $(this).parent().addClass("selected").siblings().removeClass("selected");
            if (src != null) {
                document.getElementById("iframbox").src = src;
            }
        }
    };
};
window.onload = loading;

