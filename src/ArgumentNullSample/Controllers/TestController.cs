using ArgumentNullSample.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ArgumentNullSample.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly ITestRepository _testRepository;

        public TestController(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        [HttpGet]
        public object GetBusinesses()
        {
            var result = _testRepository.GetBusinesses();
            // this won't return the real result because there
            // self referencing loop detected for property 'business'
            return result;
        }
    }
}
