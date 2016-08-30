using ArgumentNullSample.Model;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace ArgumentNullSample.SqlServer
{
    public class SampleContextSeeder
    {
        private readonly SampleContext _context;
        private readonly UserManager<User> _userManager;

        public SampleContextSeeder(SampleContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public void EnsureSeedData()
        {
            SeedApps();
            SeedBusinesses();
            SeedUsers();
        }


        private void SeedApps()
        {
            if (!_context.Apps.Any())
            {
                var apps = new List<App>
                {
                    new App
                    {
                        Id = "test_app_1",
                        AppName = "Test Application 1",
                        Description = "A test application"
                    }
                };

                _context.AddRange(apps);
                _context.SaveChanges();
            }
        }

        private void SeedBusinesses()
        {
            if (!_context.Businesses.Any())
            {
                var businesses = new List<Business>
                {
                    new Business
                    {
                        AddressLine1 = "High Street",
                        AddressLine2 = null,
                        BusinessName = "Bussiness One",
                        City = "Tauranga",
                        PostalCode = "3116",
                        Region = "Bay of Plenty",
                        ContactName = "Joe Bloggs",
                        PhoneNumber = "123456",
                        CountryCode = "NZ",
                        TimeZoneId = "New Zealand Standard Time",
                        BillingCurrencyCode = "NZD",
                        IsTestBusiness = false
                    },
                    new Business
                    {
                        AddressLine1 = "Low Street",
                        AddressLine2 = null,
                        BusinessName = "Bussiness Two",
                        City = "Tauranga",
                        PostalCode = "3116",
                        Region = "Bay of Plenty",
                        ContactName = "Jane Bloggs",
                        PhoneNumber = "123456",
                        CountryCode = "NZ",
                        TimeZoneId = "New Zealand Standard Time",
                        BillingCurrencyCode = "NZD",
                        IsTestBusiness = false
                    }
                };
                _context.AddRange(businesses);
                _context.SaveChanges();
            }
        }

        private void SeedUsers()
        {
            if (!_context.Users.Any())
            {
                var user1 = new User
                {
                    Email = "user1@test.com",
                    UserName = "user1",
                    FirstName = "Joe",
                    LastName = "Bloggs"
                };

                _userManager.CreateAsync(user1, "5yrU41BsEgt0WcUeTnlb6CKEtwR75v7FVkiXG0pe39c=").Wait();
                _userManager.SetLockoutEnabledAsync(user1, false).Wait();
            }
        }

        private Business [] GetBusinesses()
        {
            var businesses = new Business[]
            {
            };
            return businesses;
        }
    }
}
