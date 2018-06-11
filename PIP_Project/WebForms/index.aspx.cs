using System;
using System.Linq;
using System.Web;
using PIP_Project.Models;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.IO;
using Newtonsoft.Json;

namespace PIP_Project.WebForms
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] == null)
                    Response.Redirect("login.aspx");
            }
        }

        [WebMethod]
        public static string getTotalRecords()
        {
            JavaScriptSerializer jSerializer = new JavaScriptSerializer();
            PIP_model.GetTotalRecordResponse oResponse = new PIP_model.GetTotalRecordResponse();
            oResponse.Response = new PIP_model.ResponseMessage();
            string jsonString = "";
            var _Json = "";
            try
            {
                jsonString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/data/Customers.json"));
                DataSet dsCustomer = JsonConvert.DeserializeObject<DataSet>(jsonString);

                DataTable dtCustomer = dsCustomer.Tables["Customer"];
                oResponse.t_Customer = (from tCount in dtCustomer.AsEnumerable() select tCount).Count();

                jsonString = "";

                jsonString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/data/Products.json"));
                DataSet dsProduct = JsonConvert.DeserializeObject<DataSet>(jsonString);

                DataTable dtProduct = dsProduct.Tables["Products"];
                oResponse.t_Product = (from tCount in dtProduct.AsEnumerable() select tCount).Count();

                jsonString = "";

                jsonString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/data/Invoice.json"));
                DataSet dsInvoice = JsonConvert.DeserializeObject<DataSet>(jsonString);

                DataTable dtInvoice = dsInvoice.Tables["Invoice"];
                oResponse.t_Invoice = (from tCount in dtInvoice.AsEnumerable() select tCount).Count();

                oResponse.Response.EMessage = "Executed successfully";
                oResponse.Response.Result = true;
            }
            catch (Exception ex)
            {
                oResponse.Response.EMessage = ex.Message;
                oResponse.Response.Result = false;
            }
            _Json = jSerializer.Serialize(oResponse);
            return _Json;
        }

        [WebMethod]
        public static string sessionLogout()
        {
            var _result = "";
            HttpContext.Current.Session["Username"] = null;
            return _result;
        }
    }
}