namespace ExceptionHandlingTutorial.CustomExceptions
{
    public class CustomUnprocessableEntityException: Exception
    {
        public List<Dictionary<String, String>> ErrorsList;
        public CustomUnprocessableEntityException(string message, List<Dictionary<String, String>> errosList): base(message)
        {
            this.ErrorsList = errosList;
        }
    }
}
