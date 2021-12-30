using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbolaApi.Models
{
    public class Manufacturers
    {
        public int ManufacturerCode { get; set; }
        public string ManufacturerName { get; set; }
        public string OtherManufacturerDetails { get; set; }

        public IEnumerable<TableModels> TableModels { get; set; }
    }
}
