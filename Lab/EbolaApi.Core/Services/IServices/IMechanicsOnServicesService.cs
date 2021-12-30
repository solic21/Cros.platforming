using EbolaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbolaApi.Core.Services
{
    public interface IMechanicsOnServicesService
    {
        public Task<IEnumerable<MechanicsOnServices>> GetAll();
        public MechanicsOnServices FindById(int id);

        public int Add(MechanicsOnServices mechanicsOnServices);
        public int Update(MechanicsOnServices mechanicsOnServices);
        public int Delete(int id);
    }
}
