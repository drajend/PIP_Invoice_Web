using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIP_Project.Models
{
    public class PIP_model
    {
        public class ResponseMessage
        {
            public string EMessage { get; set; }
            public bool Result { get; set; }
        }
        public class AccessCheck
        {
            public string _Username { get; set; }
            public string _Password { get; set; }
            public ResponseMessage Response { get; set; }
        }

        public class GetTotalRecordResponse
        {
            public int t_Invoice { get; set; }
            public int t_Customer { get; set; }
            public int t_Product { get; set; }
            public ResponseMessage Response { get; set; }
        }
        
        public class GetCustomerJson
        {
            public string c_CustomerJson { get; set; }
            public ResponseMessage Response { get; set; }
        }

        public class AddCustomers
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Mobile { get; set; }
            public string Address { get; set; }
            public string State { get; set; }
            public string Pin { get; set; }
        }

        public class AddCustomerResponse
        {
            public ResponseMessage Response { get; set; }
        }
    }
}