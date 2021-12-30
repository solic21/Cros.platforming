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
    public class MechanicsService : IMechanicsService
    {
        private readonly IContext _context;

        public MechanicsService(IContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Mechanics>> GetAll()
        {
            var res = await _context.MyMechanics.ToListAsync();
            return res;
        }

        public Mechanics FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int Add(Mechanics mechanics)
        {
            throw new NotImplementedException();
        }

        public int Update(Mechanics mechanics)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
