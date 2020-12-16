using BarberShop.BL;
using BarberShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BarberShop.Controllers
{
    [RoutePrefix("auth")]
    public class AuthenticaionController : ApiController
    {
        [HttpPost]
        [Route("")]
        public HttpResponseMessage SignUpCustomer([FromBody]Customer data)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if (CustomerManager.IsCustomerExist(data.UserName))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "customer already exist");
            Customer customer = CustomerManager.AddCustomer(data);
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }
    }
}
