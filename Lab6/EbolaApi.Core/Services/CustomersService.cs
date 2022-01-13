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
    public class CustomersService : ICustomersService
    {
        private readonly IContext _context;

        public CustomersService(IContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Customers>> GetAll()
        {
            var res = await _context.MyCustomers.ToListAsync();
            return res;
        }

        public Customers FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int Add(Customers customers)
        {
            throw new NotImplementedException();
        }

        public int Update(Customers customers)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id) 
        {
            throw new NotImplementedException();
        }
    }
}
