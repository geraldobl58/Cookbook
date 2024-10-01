namespace Cookbook.Exceptions.ExceptionBase
{
    public class ErrorOnValidateException : CookbookException
    {
        public IList<string> ErrorMessages { get; set; }

        public ErrorOnValidateException(IList<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}
