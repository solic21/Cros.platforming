using EbolaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbolaApi.Core.Services
{
    public interface ICustomersService
    {
        public Task<IEnumerable<Customers>> GetAll();
        public Customers FindById(int id);

        public int Add(Customers customers);
        public int Update(Customers customers);
        public int Delete(int id);
    }
}
