using JustInTimeUser.Communication.Requests;
using JustInTimeUser.Communication.Responses;

namespace JustInTimeUser.Application.UseCases.User.Register;
public interface IRegisterUserUseCase
{
    public Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
}
