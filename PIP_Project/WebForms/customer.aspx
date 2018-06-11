<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="PIP_Project.WebForms.Customer" %>

<!DOCTYPE html>
<html lang="en">

<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">
  <title>PIP</title>
  <!-- Bootstrap core CSS-->
  <link href="../vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
  <!-- Custom fonts for this template-->
  <link href="../vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
  <!-- Page level plugin CSS-->
  <link href="../vendor/datatables/dataTables.bootstrap4.css" rel="stylesheet">
    <!--Toastr css-->
  <link href="../content/toastr.css" rel="stylesheet" />
  <!-- Custom styles for this template-->
  <link href="../css/sb-admin.css" rel="stylesheet">
</head>

<body class="fixed-nav sticky-footer bg-dark" id="page-top">
  <!-- Navigation-->
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top" id="mainNav">
    <a class="navbar-brand" href="index.aspx">Pristine Products</a>
    <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarResponsive">
      <ul class="navbar-nav navbar-sidenav" id="exampleAccordion">
        <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Dashboard">
          <a class="nav-link" href="index.aspx">
            <i class="fa fa-fw fa-dashboard"></i>
            <span class="nav-link-text">Dashboard</span>
          </a>
        </li>
        <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Customer">
          <a class="nav-link" href="customer.aspx">
            <i class="fa fa-fw fa-users"></i>
            <span class="nav-link-text">Customer</span>
          </a>
        </li>
        <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Invoice">
          <a class="nav-link" href="invoice.aspx">
            <i class="fa fa-fw fa-shopping-bag"></i>
            <span class="nav-link-text">Invoice</span>
          </a>
        </li>      
		<li class="nav-item" data-toggle="tooltip" data-placement="right" title="Product">
          <a class="nav-link" href="product.aspx">
            <i class="fa fa-fw fa-bar-chart"></i>
            <span class="nav-link-text">Product</span>
          </a>
        </li>      
      </ul>
      <ul class="navbar-nav sidenav-toggler">
        <li class="nav-item">
          <a class="nav-link text-center" id="sidenavToggler">
            <i class="fa fa-fw fa-angle-left"></i>
          </a>
        </li>
      </ul>
      <ul class="navbar-nav ml-auto">        
        <li class="nav-item">
          <a class="nav-link" id="_logout">
            <i class="fa fa-fw fa-sign-out"></i>Logout</a>
        </li>
      </ul>
    </div>
  </nav>
  <div class="content-wrapper">
    <div class="container-fluid">
      <!-- Breadcrumbs-->
      <ol class="breadcrumb">
        <li class="breadcrumb-item">
          <a href="#">Dashboard</a>
        </li>
        <li class="breadcrumb-item active">Customer</li>
      </ol>      
      <div class="row" id="divAddbtn">
        <div class="col-2" style="padding-bottom:10px !important;">
            <button type="button" class="btn btn-secondary" id="btnAddcustomer">Add Customer</button>
        </div>
      </div>
      <div class="card mb-3" id="divCustomer">
          <div class="card-header"> 
              <i class="fa fa-table"></i> Customers
          </div>
          <div class="card-body">
              <div class="table-responsive">
                  <table id="tblCustomer" class="table table-bordered">
                      <thead>
                          <tr>           
                              <th>S.no</th>
                              <th>Name</th>
                              <th>Email</th>
                              <th>Mobile</th>
                              <th>Address</th>
                              <th>State</th>
                              <th>Pin</th>                              
                              <th></th>
                          </tr>
                      </thead>
                      <tbody>
                      </tbody>
                  </table>
             </div>
          </div>
        </div>
        <div class="card mb-3" id="divAddCustomer">
            <div class="card-header">
                <i class="fa fa-user-plus"></i> Add Customer
            </div>
            <div class="card-body">
                <div class="form-group">
                    <input type="text" class="form-control" id="txtName" placeholder="Customer Name"/>
                </div>
                <div class="form-group">
                    <input type="email" class="form-control" id="txtEmail" placeholder="Email"/>
                </div>
                <div class="form-group">
                    <input type="number" class="form-control" id="txtMobile" placeholder="Mobile No"/>
                </div>
                <div class="form-group">
                    <input type="text" class="form-control" id="txtAddress" placeholder="Address"/>
                </div>
                <div class="form-group">
                    <input type="text" class="form-control" id="txtState" placeholder="State"/>
                </div>
                <div class="form-group">
                    <input type="number" class="form-control" id="txtPin" placeholder="PinCode"/>
                </div>
                <div>
                    <button class="btn btn-success" id="btnAddCus">Add</button>
                    <button class="btn btn-danger" id="btnCancelCus">Cancel</button>
                </div>
            </div>
        </div>
    </div>
      <div id="divEditCus" style="display:none;">
          <label><h4><i class='fa fa-pencil' aria-hidden='true'></i> Edit Customer</h4></label>
          <form class="form" role="form">
                <div class="form-group">
                    <input type="text" class="form-control" id="txtNameEdit" placeholder="Customer Name"/>
                </div>
                <div class="form-group">
                    <input type="email" class="form-control" id="txtEmailEdit" placeholder="Email"/>
                </div>
                <div class="form-group">
                    <input type="number" class="form-control" id="txtMobileEdit" placeholder="Mobile No"/>
                </div>
                <div class="form-group">
                    <input type="text" class="form-control" id="txtAddressEdit" placeholder="Address"/>
                </div>
                <div class="form-group">
                    <input type="text" class="form-control" id="txtStateEdit" placeholder="State"/>
                </div>
                <div class="form-group">
                    <input type="number" class="form-control" id="txtPinEdit" placeholder="PinCode"/>
                </div>
         </form>
      </div>
    <!-- /.container-fluid-->
    <!-- /.content-wrapper-->
    <footer class="sticky-footer">
      <div class="container">
        <div class="text-center">
          <small>Copyright © Pristine Industrial Products 2018</small>
        </div>
      </div>
    </footer>
    <!-- Scroll to Top Button-->
    <a class="scroll-to-top rounded" href="#page-top">
      <i class="fa fa-angle-up"></i>
    </a>
    <!-- Bootstrap core JavaScript-->
  <script src="../vendor/jquery/jquery.min.js"></script>
  <script src="../vendor/bootstrap/js/moment.js"></script>
  <script src="../vendor/bootstrap/js/popper.min.js"></script>
  <script src="../vendor/bootstrap/js/bootstrap.min.js"></script> 
  <script src="../vendor/bootstrap/js/bootbox.min.js"></script>
      <!--DataTable plugin-->
    <script src="../vendor/datatables/jquery.dataTables.js"></script>
    <script src="../vendor/datatables/dataTables.bootstrap4.js"></script>
      <script src="../Scripts/toastr.min.js"></script>
      <script src="../Scripts/common.js"></script>
    <!-- Custom scripts for all pages-->
    <script src="../js/sb-admin.min.js"></script>        
    <script src="../Scripts/customer.js"></script>
  </div>
</body>

</html>

