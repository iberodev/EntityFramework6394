using ArgumentNullSample.Model;
using System.Collections.Generic;

namespace ArgumentNullSample.Repositories
{
    public interface ITestRepository
    {
        IEnumerable<Business> GetBusinesses();
    }
}
