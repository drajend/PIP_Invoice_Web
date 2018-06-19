using System;
using System.Linq;
using System.Web;
using PIP_Project.Models;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PIP_Project.WebForms
{
    public partial class Customer : System.Web.UI.Page
    {
        public static string customerPath = HttpContext.Current.Server.MapPath("~/data/Customers.json");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] == null)
                    Response.Redirect("login.aspx");
            }
        }

        [WebMethod]
        public static string LoadCustomer()
        {
            var _Json = "";
            JavaScriptSerializer jSerializer = new JavaScriptSerializer();
            PIP_model.GetCustomerJson oResponse = new PIP_model.GetCustomerJson();
            oResponse.Response = new PIP_model.ResponseMessage();
            try
            {
                oResponse.c_CustomerJson = File.ReadAllText(customerPath);
                if(oResponse.c_CustomerJson!=null)                
                    oResponse.Response.EMessage = "Customer Record fetched successfully!!";                                
                else                
                    oResponse.Response.EMessage = "No records found";
                oResponse.Response.Result = true;

            }
            catch(Exception ex)
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

        public static long GenerateRandomID()
        {
            int _min = 1000;
            int _max = 9999;
            var jsonString = "";
            int idCount = 1;
            long ActiveID = 0;
            do
            {
                Random _rdm = new Random();
                ActiveID = _rdm.Next(_min, _max);
                jsonString = File.ReadAllText(customerPath);
                DataSet dsCustomer = JsonConvert.DeserializeObject<DataSet>(jsonString);
                DataTable dtCustomer = dsCustomer.Tables["Customer"];
                idCount = (from tCount in dtCustomer.AsEnumerable() where tCount.Field<long>("ActiveId").Equals(ActiveID) select tCount).Count();
            } while (idCount == 1);
            return ActiveID;
        }

        [WebMethod]
        public static string AddCustomer(string Name, string Email, string Mobile, string Address, string State, string Pin)
        {
            var _Json = "";
            PIP_model.AddCustomers getObj = new PIP_model.AddCustomers();
            getObj.Name = Name;
            getObj.Email = Email;
            getObj.Mobile = Mobile;
            getObj.Address = Address;
            getObj.State = State;
            getObj.Pin = Pin;
            JavaScriptSerializer jSerializer = new JavaScriptSerializer();
            PIP_model.AddCustomerResponse oResponse = new PIP_model.AddCustomerResponse();
            oResponse.Response = new PIP_model.ResponseMessage();
            try
            {
                long ActiveID = GenerateRandomID();
                               
                var newCustomerJson = "{ 'Name':'" + getObj.Name + "', 'Email':'" + getObj.Email + "'," +
                                  "'Mobile':" + getObj.Mobile + ", 'Address':'" + getObj.Address + "', 'State':'" + getObj.State + "'" +
                                  ", 'Pin': '" + getObj.Pin + "', 'ActiveId':" + ActiveID + " }";

                var json = File.ReadAllText(customerPath);
                var jsonObj = JObject.Parse(json);
                var CustomerArrary = jsonObj.GetValue("Customer") as JArray;
                var newCustomer = JObject.Parse(newCustomerJson);
                CustomerArrary.Add(newCustomer);

                jsonObj["Customer"] = CustomerArrary;                ;
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj,
                                       Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(customerPath, newJsonResult);
                oResponse.Response.EMessage = "Customer added successfully";
                oResponse.Response.Result = true;

            }
            catch(Exception ex)
            {
                oResponse.Response.EMessage = ex.Message;
                oResponse.Response.Result = false;
            }
            _Json = jSerializer.Serialize(oResponse);
            return _Json;
        }
        [WebMethod]
        public static string DeleteCustomer(string ActiveId)
        {
            string _Result = string.Empty;
            var json = File.ReadAllText(customerPath);
            try
            {
                var jObject = JObject.Parse(json);
                JArray CusArray = (JArray)jObject["Customer"];
                var cusId = Convert.ToInt32(ActiveId);

                if (cusId > 0)
                {
                    var CusName = string.Empty;
                    var CusToDeleted = CusArray.FirstOrDefault(obj => obj["ActiveId"].Value<int>() == cusId);

                    CusArray.Remove(CusToDeleted);

                    string output = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(customerPath, output);
                }
                else
                {
                    _Result = "Invalid Customer";
                }
                _Result = "success";
            }
            catch (Exception ex)
            {

                _Result = ex.Message;
            }
            return _Result;
        }
    }
}