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
    public class MechanicsOnServicesService : IMechanicsOnServicesService
    {
        private readonly IContext _context;

        public MechanicsOnServicesService(IContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<MechanicsOnServices>> GetAll()
        {
            var res = await _context.MyMechanicsOnServices.ToListAsync();
            return res;
        }

        public MechanicsOnServices FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int Add(MechanicsOnServices mechanicsOnServices)
        {
            throw new NotImplementedException();
        }

        public int Update(MechanicsOnServices mechanicsOnServices)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
