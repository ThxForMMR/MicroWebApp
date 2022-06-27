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
    public class SpotController : ControllerBase
    {
        private readonly ISpotRepository spotRepository;
        public SpotController(ISpotRepository repository)
        {
            spotRepository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var spots = spotRepository.GetSpot();
            return new OkObjectResult(spots);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var spot = spotRepository.GetSpotById(id);
            return new OkObjectResult(spot);
        }

        [HttpGet("{field}/{id}")]
        public IActionResult Get(string field, long id)
        {
            var spots = spotRepository.GetSpotByField(field, id);
            return new OkObjectResult(spots);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Spot spot)
        {
            using (var scope = new TransactionScope())
            {
                spotRepository.InsertSpot(spot);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = spot.Id }, spot);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Spot spot)
        {
            if (spot != null)
            {
                using (var scope = new TransactionScope())
                {
                    spotRepository.UpdateSpot(spot);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            spotRepository.DeleteSpot(id);
            return new OkResult();
        }
    }
}
