using ArgumentNullSample.Model;
using System.Linq;

namespace ArgumentNullSample.SqlServer
{
    public class SampleContextSeeder
    {
        private readonly SampleContext _context;

        public SampleContextSeeder(SampleContext context)
        {
            _context = context;
        }
        public void EnsureSeedData()
        {
            
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
