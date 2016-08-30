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
        public IActionResult GetBusinesses()
        {
            var result = _testRepository.GetBusinesses();
            return Ok(result);
        }
    }
}
