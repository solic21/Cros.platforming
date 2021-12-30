using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbolaApi.Models
{
    public class Cars
    {
        public int LicenceNumber { get; set; }
        public int ModelCode { get; set; }
        public int CustomerId { get; set; }
        public int CurrentMileage { get; set; }
        public int EngineSize { get; set; }
        public string OtherCarDetails { get; set; }

        public TableModels TableModels { get; set; }
        public Customers Customers { get; set; }

        public IEnumerable<ServiceBookings> ServiceBookings { get; set; }
    }
}
