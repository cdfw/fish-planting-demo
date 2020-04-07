using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Threading;
using System.ComponentModel.DataAnnotations;

namespace FishPlantingApi.Controllers
{
    [ApiController]
    [Route("")]
    public class DefaultController
        : Controller
    {
        private FishPlanting.Api.IFishPlantingService Service { get; }

        public DefaultController([Required] FishPlanting.Api.IFishPlantingService service)
        {
            Service = service;
        }

        [HttpGet, Route("counties/{name}")]
        public async Task<IActionResult> GetCounty([Required(AllowEmptyStrings = false)] string name, CancellationToken cancellationToken)
        {
            var result = (await Service.FindCounties(x => x.Name == name
                , x => x.Name, false, 0, 1, cancellationToken));
            if (result.Error != null)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpGet, Route("counties")]
        public async Task<IActionResult> GetCounties(CancellationToken cancellationToken)
        {
            var items = await Service.GetCounties(cancellationToken);
            return Ok(items);
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> GetFishPlants(string water, string county, CancellationToken cancellationToken)
        {
            Expression<Func<FishPlanting.Api.FishPlant, bool>> filter = null;
            if (!string.IsNullOrWhiteSpace(water) && !string.IsNullOrWhiteSpace(county))
            {
                filter = (x) => x.Water.Name == water && x.Water.Counties.Any(y => y.Name == county);
            }
            else if (!string.IsNullOrWhiteSpace(water))
            {
                filter = (x) => x.Water.Name == water;
            }
            else if (!string.IsNullOrWhiteSpace(county))
            {
                filter = (x) => x.Water.Counties.Any(y => y.Name == county);
            }
            else
            {
                filter = (x) => true;
            }

            var result = await Service.FindFishPlants(
                  filter
                , (x) => x.Water.Name
                , take: 100
                , cancellationToken: cancellationToken);
            if (result.Error == null)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet, Route("waters")]
        public async Task<IActionResult> GetWaters(string water, string county, CancellationToken cancellationToken)
        {
            Expression<Func<FishPlanting.Api.Water, bool>> filter = null;
            if (!string.IsNullOrWhiteSpace(water) && !string.IsNullOrWhiteSpace(county))
            {
                filter = (x) => x.Name == water && x.Counties.Any(y => y.Name == county);
            }
            else if (!string.IsNullOrWhiteSpace(water))
            {
                filter = (x) => x.Name == water;
            }
            else if (!string.IsNullOrWhiteSpace(county))
            {
                filter = (x) => x.Counties.Any(y => y.Name == county);
            }
            else
            {
                filter = (x) => true;
            }

            var result = await Service.FindWaters(filter
                , x => x.Name
                , take: 100
                , cancellationToken: cancellationToken);
            if (result.Error == null)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
