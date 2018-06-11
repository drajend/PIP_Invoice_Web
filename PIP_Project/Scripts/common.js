var aLocation;
var environ = window.location.host;
var pathname = window.location.pathname;
var res = pathname.split("/");
if (location.hostname !== "localhost")
    baseurl = "//" + environ + "/" + res[1];
if (res[1] !== undefined && res[1] !== "")
    aLocation = "/" + res[1];

//Bootbox alertbox
function AlertBox(alertMessage, Size, controlName) {
    bootbox.dialog({
        message: alertMessage,
        size: Size,
        buttons: {
            danger: {
                label: 'Ok',
                className: "btn-primary",
                callback: function () {
                    if (controlName !== null && controlName !== undefined) {
                        setTimeout(function () {
                            $('#' + controlName + '').focus();
                        }, 10);
                    }
                }
            }
        }
    });
}

//Webmethod AJAX call
function CallControllerMethod(methodPage, methodName, onSuccess, onFail) {

    var args = '';
    var l = arguments.length;
    if (l > 4) {
        for (var i = 4; i < l - 1; i += 2) {
            if (args.length != 0) args += ',';

            if (arguments[i + 1].toString().indexOf('[') == 0) {
                args += '"' + arguments[i] + '":' + arguments[i + 1] + '';
            }
            else {
                args += '"' + arguments[i] + '":"' + arguments[i + 1] + '"';
            }

        }
    }
    $.ajax(
        {
            type: 'POST',
            url: methodPage + '/' + methodName,
            cache: false,
            data: '{' + args + '}',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: onSuccess,
            fail: onFail
        });
}

//Toastr alert
toastr.options = {
    "closeButton": false,
    "debug": false,
    "newestOnTop": false,
    "progressBar": false,
    "positionClass": "toast-bottom-right",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}

function confirmBox(message,MethodName) {
    bootbox.confirm(message, function (result) { MethodName(result)});
}

$('a').click(function (event) {
    var id = $(this).attr("id");
    if (id == '_logout') {
        console.log('inside')
        CallControllerMethod(res[2], "sessionLogout", logout, "");
    }
});


function logout() {
    window.location.assign(aLocation + "/login.aspx");
}