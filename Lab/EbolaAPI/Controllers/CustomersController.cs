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
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        protected readonly ICustomersService _customersService = null;

        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService ?? throw new ArgumentNullException(nameof(customersService));
        }

        [HttpGet]
        public async Task <IEnumerable<Customers>> Get()
        {
            var res = await _customersService.GetAll();
            return res;
        }
    }
}
