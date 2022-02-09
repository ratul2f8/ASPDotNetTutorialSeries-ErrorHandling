using ExceptionHandlingTutorial.CustomExceptions;

namespace ExceptionHandlingTutorial.Services
{
    public interface ITestingService
    {
        public Task<String> GetBadRequestException();
        public Task<String> GetInternalServerException();
        public Task<String> GetCustomUnprocessableEntityException();
    }
    public class TestingService: ITestingService
    {
        public async Task<String> GetBadRequestException()
        {
            throw new BadHttpRequestException("This is bad request!");
        }

        public async Task<String> GetInternalServerException()
        {
            throw new Exception("This is internal server error response!");
        }

        public async Task<String> GetCustomUnprocessableEntityException()
        {
            throw new CustomUnprocessableEntityException("This is a custom unprocessable entity exception", new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>
                {
                    {"password", "Password Must be of at least 6 characters long"}
                },
                new Dictionary<string, string>
                {
                    {"email", "Email Must be a valid email"}
                }
            });

        }
    }
}
