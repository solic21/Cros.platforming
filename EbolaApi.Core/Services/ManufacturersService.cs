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
    public class ManufacturersService : IManufacturersService
    {
        private readonly IContext _context;

        public ManufacturersService(IContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Manufacturers>> GetAll()
        {
            var res = await _context.MyManufacturers.ToListAsync();
            return res;
        }

        public Manufacturers FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int Add(Manufacturers manufacturers)
        {
            throw new NotImplementedException();
        }

        public int Update(Manufacturers manufacturers)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
