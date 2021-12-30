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
    [Route("api/MechanicsOnServices")]
    public class MechanicsOnServicesController : Controller
    {
        protected readonly IMechanicsOnServicesService _mechanicsOnServicesService = null;

        public MechanicsOnServicesController(IMechanicsOnServicesService mechanicsOnServicesService)
        {
            _mechanicsOnServicesService = mechanicsOnServicesService ?? throw new ArgumentNullException(nameof(mechanicsOnServicesService));
        }

        [HttpGet]
        public async Task <IEnumerable<MechanicsOnServices>> Get()
        {
            var res = await _mechanicsOnServicesService.GetAll();
            return res;
        }
    }
}
