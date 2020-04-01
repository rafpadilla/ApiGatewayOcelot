using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiCatalog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        public CatalogController()
        {
        }

        [HttpGet]
        public IEnumerable<Catalog> Get()
        {
            var faker = new Faker<Catalog>();
            faker.RuleFor(a => a.Id, (f) => f.IndexFaker);
            faker.RuleFor(a => a.ProductName, (f, p) => f.Commerce.ProductName());

            var products = faker.Generate(10);
            return products;
        }
    }
    public class Catalog
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
    }
}
