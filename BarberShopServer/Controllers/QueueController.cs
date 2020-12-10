using BarberShop.BL;
using BarberShop.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BarberShop.Controllers
{
    [Authorize]
    [RoutePrefix("queue")]
    public class QueueController : ApiController
    {
       
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllQueues()
        {
            List<QueueCustomer> queues = QueueManager.GetAllQueues();
            return Request.CreateResponse(HttpStatusCode.OK, queues);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage AddQueue([FromBody]Queue data)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            Queue queue = QueueManager.AddQueue(data);
            return Request.CreateResponse(HttpStatusCode.OK, queue);
        }

        [HttpPut]
        [Route("{id}")]
        public HttpResponseMessage UpdateQueue([FromUri]string id,[FromBody]Queue data)
        {
            data.Id = id;
            Queue queue = QueueManager.UpdateQueue(id,data);
            return Request.CreateResponse(HttpStatusCode.OK, queue);
        }

        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage DeleteQueue([FromUri]string id)
        {
            QueueManager.DeleteQueue(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("count/{id}")]
        public HttpResponseMessage GetQueuesCount([FromUri]string id)
        {
            int count = QueueManager.GetQueuesCount(id);
            return Request.CreateResponse(HttpStatusCode.OK, count);
        }
    }
}
