using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Repository.Interfaces;
using System.Transactions;
using WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpPut("bind")]
        public IActionResult Put([FromBody] BindClass bindClass)
        {
            if (bindClass.Ids == null) return new NoContentResult();
            using (var scope = new TransactionScope())
            {

                houseRepository.BindHouse(bindClass.SpotId, bindClass.Ids);
                scope.Complete();
                return new OkResult();
            }
        }

        [HttpPut("unbind")]
        public IActionResult Put([FromBody] UnbindClass unbindClass)
        {
            if (unbindClass.Ids == null) return new NoContentResult();
            using (var scope = new TransactionScope())
            {
                houseRepository.UnbindHouse(unbindClass.Ids);
                scope.Complete();
                return new OkResult();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            houseRepository.DeleteHouse(id);
            return new OkResult();
        }
    }
}
