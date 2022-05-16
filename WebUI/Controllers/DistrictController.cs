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
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictRepository districtRepository;
        public DistrictController(IDistrictRepository repository)
        {
            districtRepository = repository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var districts = districtRepository.GetDistrict();
            return new OkObjectResult(districts);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var districts = districtRepository.GetDistrictById(id);
            return new OkObjectResult(districts);
        }

        [HttpGet("{field}/{id}")]
        public IActionResult Get(string field, long id)
        {
            var districts = districtRepository.GetDistrictByField(field, id);
            return new OkObjectResult(districts);
        }

        [HttpPost]
        public IActionResult Post([FromBody] District district)
        {
            using (var scope = new TransactionScope())
            {
                districtRepository.InsertDistrict(district);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = district.Id }, district);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] District district)
        {
            if (district != null)
            {
                using (var scope = new TransactionScope())
                {
                    districtRepository.UpdateDistrict(district);
                    scope.Complete();
                    return Ok(district);
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            districtRepository.DeleteDistrict(id);
            return new OkResult();
        }
    }
}
