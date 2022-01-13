using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbolaApi.Models
{
    public class MechanicsOnServices
    {
        public int MechanicsOnServicesId { get; set; }
        public int MechanicId { get; set; }
        public int SvcBookingId { get; set; }

        public Mechanics Mechanics { get; set; }
        public ServiceBookings ServiceBookings { get; set; }
    }
}
