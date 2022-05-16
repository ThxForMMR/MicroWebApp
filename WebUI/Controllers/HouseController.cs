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
    public class HouseController : ControllerBase
    {
        private readonly IHouseRepository houseRepository;
        public HouseController(IHouseRepository repository)
        {
            houseRepository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var houses = houseRepository.GetHouse();
            return new OkObjectResult(houses);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var house = houseRepository.GetHouseById(id);
            return new OkObjectResult(house);
        }

        [HttpGet("{field}/{id}")]
        public IActionResult Get(string field, long id)
        {
            var houses = houseRepository.GetHouseByField(field, id);
            return new OkObjectResult(houses);
        }

        [HttpPost]
        public IActionResult Post([FromBody] House house)
        {
            using (var scope = new TransactionScope())
            {
                houseRepository.InsertHouse(house);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = house.Id }, house);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] House house)
        {
            if (house != null)
            {
                using (var scope = new TransactionScope())
                {
                    houseRepository.UpdateHouse(house);
                    scope.Complete();
                    return Ok(house);
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            houseRepository.DeleteHouse(id);
            return new OkResult();
        }
    }
}
