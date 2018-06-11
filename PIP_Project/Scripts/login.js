
$("#btnLogin").click(function () {
    var UserName = $("#txtUser").val();
    var Paswrd = $("#txtPswrd").val();
    if (UserName == undefined || UserName == null || UserName == "") {
        AlertBox("Enter Username", "small", "txtUser");
        return;
    }
    if (Paswrd == undefined || Paswrd == null || Paswrd == "") {
        AlertBox("Enter Password", "small", "txtPswrd");
        return;
    }
    CallControllerMethod("login.aspx", "CheckAccess", SuccessUser, "", "_Username", UserName, "_Password", Paswrd);
});

function SuccessUser(data) {
    data = JSON.parse(data.d);
    if (data.Response.Result)
        window.location.assign(aLocation + "/index.aspx");
    else
        AlertBox(data.Response.EMessage, "small");
}