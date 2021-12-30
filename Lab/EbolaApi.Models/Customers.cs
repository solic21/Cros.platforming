using System.Collections.Generic;

namespace EbolaApi.Models
{
    public class Customers
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string OtherCustomerDetails { get; set; }

        public IEnumerable<Cars> Cars { get; set; }
        public IEnumerable<ServiceBookings> ServiceBookings { get; set; }
    }
}
