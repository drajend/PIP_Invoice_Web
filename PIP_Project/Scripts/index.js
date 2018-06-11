

$(document).ready(function () {
    CallControllerMethod("index.aspx", "getTotalRecords", getTotalRecordsSuccess, "");
});

function getTotalRecordsSuccess(data) {
    data = JSON.parse(data.d);
    if (data.Response.Result) {
        $('#i_divCustomer').text(data.t_Customer + " Customers!");
        $('#i_divInvoice').text(data.t_Invoice + " Invoices!");
        $('#i_divProducts').text(data.t_Product + " Products!");
    } else {
        AlertBox("Check getTotalRecords method " + data.Response.EMessage, "small");
    }
}
