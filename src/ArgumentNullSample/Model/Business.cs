using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArgumentNullSample.Model
{
    public class Business
    {
        public Guid Id { get; set; }
        public List<UserBusiness> UserBusinesses { get; set; }
        public List<BusinessApp> BusinessApps { get; set; }
        public List<Group> Groups { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public byte[] RowVersion { get; set; }
        public string BusinessName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string CountryCode { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public string TimeZoneId { get; set; }
        public string BillingCurrencyCode { get; set; }
        public bool IsTestBusiness { get; set; }
    }
}
