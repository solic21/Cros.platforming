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
    public class CarsService : ICarsService
    {
        private readonly IContext _context;

        public CarsService(IContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Cars>> GetAll()
        {
            var res = await _context.MyCars.ToListAsync();
            return res;
        }

        public Cars FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int Add(Cars cars)
        {
            throw new NotImplementedException();
        }

        public int Update(Cars cars)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
