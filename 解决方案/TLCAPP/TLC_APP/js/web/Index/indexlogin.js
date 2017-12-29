$(function () {
    $('.login').hover(function () {
        $(this).find('.jiantou').addClass('active');
        $(this).find('.login_none').stop().slideDown();
    }, function () {
        $(this).find('.jiantou').removeClass('active');
        $(this).find('.login_none').stop().slideUp();
    })
    $('.login_none>span,.login_none>a').hover(function () {
        $(this).css({ 'background': '#65ce67', 'color': '#fff' });
    }, function () {
        $(this).css({ 'background': '#fff', 'color': '#666' });
    })
})