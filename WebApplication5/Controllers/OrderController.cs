using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication5.Models;
using WebApplication5.Repository;

namespace WebApplication5.Controllers
{

    public class OrderController : ApiController
    {
        static readonly IOrderRepository repository = new OrderRepository();

        public IEnumerable<Order> Get()
        {
            return repository.GetAll();
        }

        public Order Get(int id)
        {
            Order item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<Order> GetOrderByCusName(string CName)
        {
            return repository.GetAll().Where(
                p => string.Equals(p.CusName, CName, StringComparison.OrdinalIgnoreCase));
        }

        public HttpResponseMessage Post(Order item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Order>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.OrdId });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void Put(int id, Order order)
        {
            order.OrdId = id;
            if (!repository.Update(order))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void Delete(int id)
        {
            Order item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repository.Remove(id);
        }
    }

}