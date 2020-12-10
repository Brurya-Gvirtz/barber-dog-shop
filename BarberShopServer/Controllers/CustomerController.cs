using BarberShop.BL;
using BarberShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BarberShopServer.Controllers
{
    [Authorize]
    [RoutePrefix("customer")]
    public class CustomerController : ApiController
    {
        [HttpGet]
        [Route("{name}")]
        public HttpResponseMessage GetCusotmerByUserName([FromUri]string name)
        {
            Customer customer = CustomerManager.GetCustomerByName(name);
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }
        [HttpGet]
        [Route("id/{id}")]
        public HttpResponseMessage GetCusotmerById([FromUri]string id)
        {
            Customer customer = CustomerManager.GetCustomerById(id);
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }
    }
}
