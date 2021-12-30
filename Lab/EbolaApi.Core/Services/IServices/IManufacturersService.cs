using EbolaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbolaApi.Core.Services
{
    public interface IManufacturersService
    {
        public Task<IEnumerable<Manufacturers>> GetAll();
        public Manufacturers FindById(int id);

        public int Add(Manufacturers manufacturers);
        public int Update(Manufacturers manufacturers);
        public int Delete(int id);
    }
}
