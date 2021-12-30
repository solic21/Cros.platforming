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
    [Route("api/ServiceBookings")]
    public class ServiceBookingsController : Controller
    {
        protected readonly IServiceBookingsService _serviceBookingsService = null;

        public ServiceBookingsController(IServiceBookingsService serviceBookingsService)
        {
            _serviceBookingsService = serviceBookingsService ?? throw new ArgumentNullException(nameof(serviceBookingsService));
        }

        [HttpGet]
        public async Task <IEnumerable<ServiceBookings>> Get()
        {
            var res = await _serviceBookingsService.GetAll();
            return res;
        }
    }
}
