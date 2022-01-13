using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbolaApi.Models
{
    public class ServiceBookings
    {
        public int SvcBookingId { get; set; }
        public int CustomerId { get; set; }
        public int LicenceNumber { get; set; }
        public bool PaymentReceivedYn { get; set; } 
        public string DatatimeOfService { get; set; } 
        public string OtherSvcBookingDetails { get; set; }

        public Cars Cars { get; set; }
        public Customers Customers { get; set; }

        public IEnumerable<MechanicsOnServices> MechanicsOnServices { get; set; }
    }
}
