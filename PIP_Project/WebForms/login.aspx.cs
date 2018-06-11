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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                    Response.Redirect("index.aspx");
            }
        }

        [WebMethod]
        public static string CheckAccess(string _Username,string _Password)
        {
            JavaScriptSerializer TheSerializer = new JavaScriptSerializer();
            PIP_model.AccessCheck getObj = new PIP_model.AccessCheck();
            getObj._Username = _Username;
            getObj._Password = _Password;
            getObj.Response = new PIP_model.ResponseMessage();
            var _Json = "";
            try
            {
                string jsonstring = File.ReadAllText(HttpContext.Current.Server.MapPath("~/data/Users.json"));
                DataSet ds = JsonConvert.DeserializeObject<DataSet>(jsonstring);

                DataTable UserTable = ds.Tables["Admin"];

                int Access = 0;
                Access = (from admin in UserTable.AsEnumerable()
                          where admin.Field<string>("Username") == getObj._Username
                          && admin.Field<string>("Password") == getObj._Password
                          select admin).Count();                
                if (Access == 1)
                {
                    HttpContext.Current.Session["Username"] = getObj._Username;
                    getObj.Response.EMessage = "Login Success";
                    getObj.Response.Result = true;
                }
                else
                {
                    getObj.Response.EMessage = "Login Failed";
                    getObj.Response.Result = false;
                }
                _Json = TheSerializer.Serialize(getObj);
            }
            catch(Exception ex)
            {
                getObj.Response.EMessage = ex.Message;
                getObj.Response.Result = false;
                _Json = TheSerializer.Serialize(getObj);
            }
            return _Json;
        }
    }
}