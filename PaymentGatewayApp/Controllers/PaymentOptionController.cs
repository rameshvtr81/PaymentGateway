using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentGatewayApp.Models;
using PaymentGatewayApp.Services;
using PaymentGatewayApp.Services.interfaces;

namespace PaymentGatewayApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentOptionController : ControllerBase
    {

        private IPaymentOptions _service;
        public PaymentOptionController(IPaymentOptions service)
        {
            _service = service;
        }
        // GET: api/PaymentOption
        [HttpGet]
        public IActionResult Get()
        {
            var result = _service.GetAll().ToList();
            return ResponseModel.Instance.ReturnResult(HttpStatusCode.OK, result);
        }

        // GET: api/PaymentOption/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult  Get(int id)
        {
            if (id <= 0)
            {
                return ResponseModel.Instance.ReturnResult(HttpStatusCode.NotAcceptable, "Id canot be less or equal to 0.");
            }
            var result = _service.Get(id);
            return ResponseModel.Instance.ReturnResult(HttpStatusCode.OK, result);
        }

        // POST: api/PaymentOption
        [HttpPost]
        public ActionResult Post([FromBody] PaymentOption value)
        {
            if(value == null)
            {
                return ResponseModel.Instance.ReturnResult(HttpStatusCode.NotAcceptable, "value cannot be null");
            }
            _service.Add(value);
            return ResponseModel.Instance.ReturnResult(HttpStatusCode.OK);
        }

        // PUT: api/PaymentOption/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, PaymentOption value)
        {
            if (id <= 0)
            {
                return ResponseModel.Instance.ReturnResult(HttpStatusCode.NotAcceptable, "Id canot be less or equal to 0.");
            }

            if (value == null)
            {
                return ResponseModel.Instance.ReturnResult(HttpStatusCode.NotAcceptable, "value cannot be null");
            }
            _service.Update(value);
            return ResponseModel.Instance.ReturnResult(HttpStatusCode.OK);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return ResponseModel.Instance.ReturnResult(HttpStatusCode.NotAcceptable, "Id canot be less or equal to 0.");
            }
            _service.Delete(id);
            return ResponseModel.Instance.ReturnResult(HttpStatusCode.OK);
        }
    }
}
