using EbolaApi.Core.Services;
using EbolaApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbolaAPI.Controllers
{
    [ApiController]
    [Route("api/Cars")]
    public class CarsController : Controller
    {
        protected readonly ICarsService _carsService = null;

        public CarsController(ICarsService carsService)
        {
            _carsService = carsService ?? throw new ArgumentNullException(nameof(carsService));
        }

        [HttpGet]
        public async Task <IEnumerable<Cars>> Get()
        {
            var res = await _carsService.GetAll();
            return res;
        }
    }
}
