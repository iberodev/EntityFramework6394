using System.Collections.Generic;
using ArgumentNullSample.SqlServer;
using ArgumentNullSample.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ArgumentNullSample.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly SampleContext _context;

        public TestRepository(SampleContext context)
        {
            _context = context;
        }

        public IEnumerable<Business> GetBusinesses()
        {
            var businesses = _context.Businesses
                .Include(b => b.UserBusinesses).ThenInclude(ub => ub.AppAccesses)
                .Include(b => b.UserBusinesses).ThenInclude(ub => ub.GroupMemberships)
                .ToList();
            return businesses;
        }
    }
}
