using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiOrder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        public OrdersController()
        {
        }

        [HttpGet("{id:int?}")]
        public IEnumerable<Order> Get(int? id)
        {
            var faker = new Faker<Order>();
            faker.RuleFor(a => a.Id, (f) => f.IndexFaker);
            faker.RuleFor(a => a.ProductId, (f) => f.IndexFaker);
            faker.RuleFor(a => a.ProductName, (f, p) => f.Commerce.ProductName());

            var orders = faker.Generate(10);
            return orders;
        }
    }
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
