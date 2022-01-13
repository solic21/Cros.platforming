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
    [Route("api/Manufacturers")]
    public class ManufacturersController : Controller
    {
        protected readonly IManufacturersService _manufacturersService = null;

        public ManufacturersController(IManufacturersService manufacturersService)
        {
            _manufacturersService = manufacturersService ?? throw new ArgumentNullException(nameof(manufacturersService));
        }

        [HttpGet]
        public async Task <IEnumerable<Manufacturers>> Get()
        {
            var res = await _manufacturersService.GetAll();
            return res;
        }
    }
}
