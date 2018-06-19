var table;
var custId = 0;
$(document).ready(function () {
    document.getElementById("divAddCustomer").style.display = "none";
    table = $("#tblCustomer").DataTable({
        "ajax": { "url": '../data/Customers.json', "dataSrc": "Customer" },
        "scrollY": 410,
        "lengthChange": false,
        "bSortable": false,
        "columns": [
            { "data": "ActiveId", "orderable": false, "visible": false, "searchable": false },
            { "data": "Name", "orderable": false },
            { "data": "Email", "orderable": false },
            { "data": "Mobile", "orderable": false },
            { "data": "Address", "orderable": false },
            { "data": "State", "orderable": false },
            { "data": "Pin", "orderable": false },
            {
                "data": null,
                "targets":-1,
                "defaultContent": "<button type='button' id='btnEdit' class='btn btn-info btn-sm'> <i class='fa fa-pencil' aria-hidden='true'></i></button> <button type='button' id='btnDeleteCus' class='btn btn-danger btn-sm'> <i class='fa fa-trash' aria-hidden='true'></i></button>",
                "orderable": false,
                "width": "9%"
            }
        ],

    });
});

function LoadCustomerSuccess(data) {
    data = JSON.parse(data.d);
}

$("#tblCustomer tbody ").on('click', 'button#btnEdit', function (e) {
    var data = table.row($(this).parents('tr')).data();
    console.log(data);
    //alert("Hello " + data.Name + " Your address is " + data.Address);    
    document.getElementById("divEditCus").style.display = "block";
    $("#txtNameEdit").val(data.Name);
    $("#txtEmail").val(data.Email);
    $("#txtMobileEdit").val(data.Mobile);
    $("#txtAddressEdit").val(data.Address);
    $("#txtStateEdit").val(data.State);
    $("#txtPinEdit").val(data.Pin);
    $('#mymodal').modal('show');
    //var modal = bootbox.dialog({        
    //    message: $("#divEditCus").html(),
    //    buttons: [
    //        {
    //            label: "Update",
    //            className: "btn btn-success pull-left",
    //            callback: function () {                    

    //                return false;
    //            }
    //        },
    //        {
    //            label: "Cancel",
    //            className: "btn btn-danger pull-left",
    //            callback: function () {                    
    //            }
    //        }
    //    ],
    //    show: false,
    //    onEscape: function () {
    //        modal.modal("hide");
    //    }
    //});

    //modal.modal("show");
   // document.getElementById("divEditCus").style.display = "none";
});

$("#tblCustomer tbody ").on('click', 'button#btnDeleteCus', function (e) {
    var data = table.row($(this).parents('tr')).data();
    custId = data.ActiveId;
    confirmBox("<i class='fa fa-exclamation-triangle' aria-hidden='true'></i> Are you sure, Do you want to delete this customer?", DeleteCustomer)
    //DeleteCustomer
});

function DeleteCustomer(data) {
    if (data)
        CallControllerMethod("customer.aspx", "DeleteCustomer", DeleteCustomerSuccess, "", "ActiveId", custId);
    else
        custId = 0;
}

function DeleteCustomerSuccess(data) {
    if (data != "success") {
        setInterval(function () {
            table.ajax.reload();
        }, 1000);
        toastr["success"]("Customer Deleted successfully!!");
    }
    else
        toastr["error"](data);
}

$("#btnAddcustomer").click(function () {
    document.getElementById("divAddbtn").style.display = "none";
    document.getElementById("divCustomer").style.display = "none";
    document.getElementById("divAddCustomer").style.display = "block";    
        
});

$("#btnAddCus").click(function () {    
    CallControllerMethod("customer.aspx", "AddCustomer", AddCustomerSuccess, "", "Name", $("#txtName").val(), "Email", $("#txtEmail").val(), "Mobile", $("#txtMobile").val(), "Address", $("#txtAddress").val(), "State", $("#txtState").val(), "Pin", $("#txtPin").val());           
    //var dialog = bootbox.dialog({
    //    message: '<p class="text-center"><i class="fa fa-spin fa-spinner"></i> Please wait your customer details adding...</p>',
    //    closeButton: false
    //});
    //dialog.init(function () {
    //    setTimeout(function () {            
    //        dialog.modal('hide');
    //    }, 2000);
    //});

});

function AddCustomerSuccess(data) {
    data = JSON.parse(data.d);
    if (data.Response.Result) {
        setInterval(function () {
            table.ajax.reload();
        }, 1000);
        document.getElementById("divCustomer").style.display = "block";
        document.getElementById("divAddbtn").style.display = "block";
        document.getElementById("divAddCustomer").style.display = "none";
        toastr["success"]("Customer Added successfully!!!");
    } else {
        toastr["error"]("Adding customer failed!!!");
    }
}
$("#btnCancelCus").click(function () {
    document.getElementById("divCustomer").style.display = "block";
    document.getElementById("divAddbtn").style.display = "block";
    document.getElementById("divAddCustomer").style.display = "none";
});