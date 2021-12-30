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
    [Route("api/Mechanics")]
    public class MechanicsController : Controller
    {
        protected readonly IMechanicsService _mechanicsService = null;

        public MechanicsController(IMechanicsService mechanicsService)
        {
            _mechanicsService = mechanicsService ?? throw new ArgumentNullException(nameof(mechanicsService));
        }

        [HttpGet]
        public async Task <IEnumerable<Mechanics>> Get()
        {
            var res = await _mechanicsService.GetAll();
            return res;
        }
    }
}
