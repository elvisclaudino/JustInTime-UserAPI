using JustInTimeUser.Communication.Requests;
using JustInTimeUser.Communication.Responses;

namespace JustInTimeUser.Application.UseCases.User.Register;
public class RegisterUserUseCase
{
    public ResponseRegisteredUserJson Execute(RequestRegisterUserJson request)
    {
        validate(request);

        return new ResponseRegisteredUserJson
        {
            Name = request.Name,
        };
    }

    private void validate(RequestRegisterUserJson request)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }
    }
}
