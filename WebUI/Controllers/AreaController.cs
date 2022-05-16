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
    public class AreaController : ControllerBase
    {
        private readonly IAreaRepository areaRepository;
        public AreaController(IAreaRepository repository)
        {
            areaRepository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var areas = areaRepository.GetArea();
            return new OkObjectResult(areas);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            var area = areaRepository.GetAreaById(id);
            return new OkObjectResult(area);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Area area)
        {
            using (var scope = new TransactionScope())
            {
                areaRepository.InsertArea(area);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = area.Id }, area);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Area area)
        {
            if (area != null)
            {
                using (var scope = new TransactionScope())
                {
                    areaRepository.UpdateArea(area);
                    scope.Complete();
                    return Ok(area);
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            areaRepository.DeleteArea(id);
            return new OkResult();
        }
    }
}
