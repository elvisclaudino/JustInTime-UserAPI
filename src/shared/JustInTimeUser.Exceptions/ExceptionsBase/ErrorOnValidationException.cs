namespace JustInTimeUser.Exceptions.ExceptionsBase;
public class ErrorOnValidationException : JustInTimeUserException
{
    public IList<string>? ErrorMessages { get; set; }

    public ErrorOnValidationException(IList<string>? errorMessages)
    {
        ErrorMessages = errorMessages;
    }
}
