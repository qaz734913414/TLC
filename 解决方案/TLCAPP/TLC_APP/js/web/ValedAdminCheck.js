
if (sessionStorage.getItem('tlc_app_tmpsetintpsm') == null) {
    parent.parent.parent.location.href = "../../MainClient.html"
}
else {
    var name = sessionStorage.getItem('tlc_app_tmpsetintpsm');
    var ut = sessionStorage.getItem(name);

    if (ut == null) {
        parent.parent.parent.location.href = "../../MainClient.html"
    }
    else {
        var us = JSON.parse(ut);
        if (us.Valied == 'sll^^^9wefew]loloorerferf') {

        }
        else {
            parent.parent.parent.location.href = "../../MainClient.html"
        }
    }
}
