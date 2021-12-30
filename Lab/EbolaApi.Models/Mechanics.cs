using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbolaApi.Models
{
    public class Mechanics
    {
        public int MechanicId { get; set; }
        public string MechanicName { get; set; }
        public string OtherMechanicDetails { get; set; }

        public IEnumerable<MechanicsOnServices> MechanicsOnServices { get; set; }
    }
}
