using ExceptionHandlingTutorial.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandlingTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestingController : ControllerBase
    {
        private readonly ITestingService _testingService;
        public TestingController(ITestingService testingService)
        {
            _testingService = testingService;
        }
        
        [HttpGet("/bad")]
        public async Task<String> GetHello()
        {
            return await _testingService.GetBadRequestException();
        }
        [HttpGet("/internal")]
        public async Task<String> GetInternal()
        {
            return await _testingService.GetInternalServerException();
        }
        [HttpGet("/custom")]
        public async Task<String> GetCustomUnprocessableEntityException()
        {
            return await _testingService.GetCustomUnprocessableEntityException();
        }
    }
}
