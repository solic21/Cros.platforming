using EbolaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbolaApi.Core.Services
{
    public interface IMechanicsService
    {
        public Task<IEnumerable<Mechanics>> GetAll();
        public Mechanics FindById(int id);

        public int Add(Mechanics mechanics);
        public int Update(Mechanics mechanics);
        public int Delete(int id);
    }
}
