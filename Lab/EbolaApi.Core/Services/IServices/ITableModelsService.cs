using EbolaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbolaApi.Core.Services
{
    public interface ITableModelsService
    {
        public Task<IEnumerable<TableModels>> GetAll();
        public TableModels FindById(int id);

        public int Add(TableModels tableModels);
        public int Update(TableModels tableModels);
        public int Delete(int id);
    }
}
