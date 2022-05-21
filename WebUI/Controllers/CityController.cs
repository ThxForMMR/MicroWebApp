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
    public class CityController : ControllerBase
    {
        private readonly ICityRepository cityRepository;
        public CityController(ICityRepository repository)
        {
            cityRepository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cities = cityRepository.GetCity();
            return new OkObjectResult(cities);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var city = cityRepository.GetCityById(id);
            return new OkObjectResult(city);
        }

        [HttpGet("{field}/{id}")]
        public IActionResult Get(string field, long id)
        {
            var cities = cityRepository.GetCityByField(field, id);
            return new OkObjectResult(cities);
        }

        [HttpPost]
        public IActionResult Post([FromBody] City city)
        {
            using (var scope = new TransactionScope())
            {
                cityRepository.InsertCity(city);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = city.Id }, city);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] City city)
        {
            if (city != null)
            {
                using (var scope = new TransactionScope())
                {
                    cityRepository.UpdateCity(city);
                    scope.Complete();
                    return Ok(city);
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

                cityRepository.BindCities(bindClass.SpotId, bindClass.Ids);
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
                cityRepository.UnbindCities(unbindClass.Ids);
                scope.Complete();
                return new OkResult();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            cityRepository.DeleteCity(id);
            return new OkResult();
        }
    }
}
