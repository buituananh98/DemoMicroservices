using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderDbContext _orderDbContext;
        public OrderController(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetAll()
        {
            return _orderDbContext.Orders;
        }
    }
}
