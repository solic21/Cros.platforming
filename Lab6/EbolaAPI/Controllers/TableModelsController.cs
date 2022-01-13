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
    [Route("api/TableModels")]
    public class TableModelsController : Controller
    {
        protected readonly ITableModelsService _tableModelsService = null;

        public TableModelsController(ITableModelsService tableModelsService)
        {
            _tableModelsService = tableModelsService ?? throw new ArgumentNullException(nameof(tableModelsService));
        }

        [HttpGet]
        public async Task <IEnumerable<TableModels>> Get()
        {
            var res = await _tableModelsService.GetAll();
            return res;
        }
    }
}
