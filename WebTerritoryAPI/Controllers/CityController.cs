using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTerritoryAPI.Models;
using WebTerritoryAPI.Repository;
using System.Transactions;

namespace WebTerritoryAPI.Controllers
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
        public IActionResult Get( long id)
        {
            var city = cityRepository.GetCityById(id);
            return new OkObjectResult(city);
        }

        [HttpGet("{field}/{id}")]
        public IActionResult Get( string field,  long id)
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
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpPut("bind/{spotId}")]
        public IActionResult Put(long spotId, [FromBody] long[] ids)
        {
            if (ids == null) return new NoContentResult();
            using (var scope = new TransactionScope())
            {
                /*foreach (long id in ids)
                {
                    var city = cityRepository.GetCityById(id);
                    city.SpotId = spotId;
                    cityRepository.UpdateCity(city);
                }     */
                cityRepository.BindCities(spotId, ids);
                scope.Complete();
                return new OkResult();
            }
        }
        [HttpPut("unbind")]
        public IActionResult Put([FromBody] long[] ids)
        {
            if (ids == null) return new NoContentResult();
            using (var scope = new TransactionScope())
            {
                /*  foreach (long id in ids)
                  {
                      var city = cityRepository.GetCityById(id);
                      city.SpotId = null;
                      cityRepository.UpdateCity(city);
                  }*/
                cityRepository.UnbindCities(ids);
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
