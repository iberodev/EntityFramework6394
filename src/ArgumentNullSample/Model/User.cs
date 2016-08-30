using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ArgumentNullSample.Model
{
    public class User : IdentityUser
    {
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid? PrimaryBusinessId { get; set; }
        public Business PrimaryBusiness { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return string.Join(" ", FirstName, LastName);
            }
        }

        public DateTime? LastLoggedInOn { get; set; }

        public List<UserBusiness> UserBusinesses { get; set; }
    }
}
