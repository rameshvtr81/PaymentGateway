using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGatewayApp.Models
{
    public class ResponseModel 
    {

        private static readonly Lazy<ResponseModel> _instance = new Lazy<ResponseModel>();

        public static ResponseModel Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        

        public ObjectResult ReturnResult(HttpStatusCode statusCode, object response)
        {
            //var jsonResponse = JsonConvert.SerializeObject(response);
            ObjectResult result = new ObjectResult(response);
            result.StatusCode = (int)statusCode;
            return result;
        }

        public ObjectResult ReturnResult(HttpStatusCode statusCode)
        {
            ObjectResult result = new ObjectResult(null);
            result.StatusCode = (int)statusCode;
            return result;
        }

        public override string ToString()
        {

            return base.ToString();
        }
    }
}
