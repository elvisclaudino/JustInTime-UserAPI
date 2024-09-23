using JustInTimeUser.Application.Services.AutoMapper;
using JustInTimeUser.Application.Services.Cryptography;
using JustInTimeUser.Communication.Requests;
using JustInTimeUser.Communication.Responses;
using JustInTimeUser.Domain.Repositories.User;
using JustInTimeUser.Exceptions.ExceptionsBase;

namespace JustInTimeUser.Application.UseCases.User.Register;
public class RegisterUserUseCase
{
    private readonly IUserWriteOnlyRepository _writeOnlyRepository;
    private readonly IUserReadOnlyRepository _readOnlyRepository;

    public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
    {
        // Validate request
        Validate(request);

        // Mapping request to entity
        var autoMapper = new AutoMapper.MapperConfiguration(options =>
        {
            options.AddProfile(new AutoMapping());
        }).CreateMapper();

        var user = autoMapper.Map<Domain.Entitities.User>(request);

        // Password Cryptography
        var passwordCriptography = new PasswordEncripter();
        user.Password = PasswordEncripter.Encrypt(request.Password);


        // Save into database
        await _writeOnlyRepository.Add(user);

        return new ResponseRegisteredUserJson
        {
            Name = request.Name,
        };
    }

    private void Validate(RequestRegisterUserJson request)
    {
        var validator = new RegisterUserValidator();

        var result = validator.Validate(request);

        if (!result.IsValid) {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
