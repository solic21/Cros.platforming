using EbolaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbolaApi.Core.Services
{
    public interface IServiceBookingsService
    {
        public Task<IEnumerable<ServiceBookings>> GetAll();
        public ServiceBookings FindById(int id);

        public int Add(ServiceBookings serviceBookings);
        public int Update(ServiceBookings serviceBookings);
        public int Delete(int id);
    }
}
