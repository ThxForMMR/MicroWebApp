using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Repository.Interfaces;
using System.Transactions;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreetController : ControllerBase
    {
        private readonly IStreetRepository streetRepository;
        public StreetController(IStreetRepository repository)
        {
            streetRepository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var streets = streetRepository.GetStreet();
            return new OkObjectResult(streets);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var street = streetRepository.GetStreetById(id);
            return new OkObjectResult(street);
        }
        [HttpGet("{field}/{id}")]
        public IActionResult Get(string field, long id)
        {
            var streets = streetRepository.GetStreetByField(field, id);
            return new OkObjectResult(streets);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Street street)
        {
            using (var scope = new TransactionScope())
            {
                streetRepository.InsertStreet(street);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = street.Id }, street);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Street street)
        {
            if (street != null)
            {
                using (var scope = new TransactionScope())
                {
                    streetRepository.UpdateStreet(street);
                    scope.Complete();
                    return Ok(street);
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            streetRepository.DeleteStreet(id);
            return new OkResult();
        }
    }
}
