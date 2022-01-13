using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbolaApi.Models
{
    public class TableModels
    {
        public int ModelCode { get; set; }
        public int ManufacturerCode { get; set; }
        public string ModelName { get; set; }
        public string OtherModelDetails { get; set; }

        public IEnumerable<Cars> Cars { get; set; } 

        public Manufacturers Manufacturers { get; set; }
    }
}
