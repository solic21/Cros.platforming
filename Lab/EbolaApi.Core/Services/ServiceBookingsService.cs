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
    public class ServiceBookingsService : IServiceBookingsService
    {
        private readonly IContext _context;

        public ServiceBookingsService(IContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<ServiceBookings>> GetAll()
        {
            var res = await _context.MyServiceBookings.ToListAsync();
            return res;
        }

        public ServiceBookings FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int Add(ServiceBookings serviceBookings)
        {
            throw new NotImplementedException();
        }

        public int Update(ServiceBookings serviceBookings)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
