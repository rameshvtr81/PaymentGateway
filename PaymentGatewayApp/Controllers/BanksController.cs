using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentGatewayApp.Models;
using PaymentGatewayApp.Services.interfaces;

namespace PaymentGatewayApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {

        private IBankService _service;
        public BanksController(IBankService service)
        {
            _service = service;
        }
        // GET: api/Banks
        [HttpGet]
        public IActionResult Get()
        {
            var result = _service.GetAll();
            return ResponseModel.Instance.ReturnResult(HttpStatusCode.OK, result);
        }

        // GET: api/Banks/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return ResponseModel.Instance.ReturnResult(HttpStatusCode.NotAcceptable, "Id canot be less or equal to 0.");
            }
            var result = _service.Get(id);
            return ResponseModel.Instance.ReturnResult(HttpStatusCode.OK,result);
        }

        // POST: api/Banks
        [HttpPost]
        public IActionResult Post([FromBody] Bank value)
        {
            if(value == null)
            {
                return ResponseModel.Instance.ReturnResult(HttpStatusCode.NotAcceptable, "value cannot be null.");
            }
            _service.Add(value);
            return ResponseModel.Instance.ReturnResult(HttpStatusCode.OK);
        }

        // PUT: api/Banks/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Bank value)
        {
            if (id <= 0)
            {
                return ResponseModel.Instance.ReturnResult(HttpStatusCode.NotAcceptable, "Id canot be less or equal to 0.");
            }

            if(value == null)
            {
                return ResponseModel.Instance.ReturnResult(HttpStatusCode.NotAcceptable, "value cannot be null");
            }

            value.ID = id;
            _service.Update(value);
            return ResponseModel.Instance.ReturnResult(HttpStatusCode.OK);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(id<= 0)
            {
                return ResponseModel.Instance.ReturnResult(HttpStatusCode.NotAcceptable, "Id canot be less or equal to 0.");
            }

            _service.Delete(id);
            return ResponseModel.Instance.ReturnResult(HttpStatusCode.OK);
        }
    }
}
