
var id = getQueryString("itemid");
$(function () {
    $('#Save_and_submit').on('click', submit);
});

function submit() {
    var money = $('#chargeMoney').val();
    money = Number(money);

    if (money > 0) {
        layer_index = layer.load(1, {
            shade: [0.1, '#fff'] //0.1透明度的白色背景
        });
        AddUserMoneyCompleate = function (result) {

            if (result) {
                layer.msg('充值成功');

                setTimeout(function () {
                    parent.Init();
                    parent.parent.Init();
                    parent.CloseIFrameWindow();
                }, 300);
            }
            else {
                layer.close(layer_index);
            }
        };
        AddUserMoney(id, money)
    }
    else {
        layer.msg('输入的金额格式不正确');
    }
}
