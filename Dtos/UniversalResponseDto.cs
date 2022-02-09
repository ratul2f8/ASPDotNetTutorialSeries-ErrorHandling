namespace ExceptionHandlingTutorial.Dtos
{
    public class UniversalResponseDto
    {
        public Boolean success { get; set; }
        public int statusCode { get; set; }
        public Object data { get; set; }
        public string message { get; set; }

    }
}
