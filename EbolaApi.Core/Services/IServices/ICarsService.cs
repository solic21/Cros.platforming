using EbolaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbolaApi.Core.Services
{
    public interface ICarsService
    {
        public Task<IEnumerable<Cars>> GetAll();
        public Cars FindById(int id);

        public int Add(Cars cars);
        public int Update(Cars cars);
        public int Delete(int id);
    }
}
