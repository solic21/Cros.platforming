using EbolaApi.Core.Entities;
using EbolaApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbolaApi.Core.Services
{
    class TableModelsService : ITableModelsService
    {
        private readonly IContext _context;

        public TableModelsService(IContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<TableModels>> GetAll()
        {
            var res = await _context.MyTableModels.ToListAsync();
            return res;
        }

        public TableModels FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int Add(TableModels tableModels)
        {
            throw new NotImplementedException();
        }

        public int Update(TableModels tableModels)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
