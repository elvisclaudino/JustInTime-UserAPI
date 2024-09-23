namespace JustInTimeUser.Communication.Responses;
public class ResponseErrorJson
{
    public IList<String>? Errors { get; set; }

    public ResponseErrorJson(IList<string>? errors) => Errors = errors;

    public ResponseErrorJson(string error)
    {
        Errors = new List<string>
        {
            error
        };
    }
}
