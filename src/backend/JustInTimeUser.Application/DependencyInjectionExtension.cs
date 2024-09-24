using JustInTimeUser.Application.Services.AutoMapper;
using JustInTimeUser.Application.Services.Cryptography;
using JustInTimeUser.Application.UseCases.User.Register;
using Microsoft.Extensions.DependencyInjection;

namespace JustInTimeUser.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddPasswordEncripter(services);
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddScoped(option => new AutoMapper.MapperConfiguration(options =>
        {
            options.AddProfile(new AutoMapping());
        }).CreateMapper());
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
    }

    private static void AddPasswordEncripter(IServiceCollection services)
    {
        services.AddScoped(option => new PasswordEncripter());
    }
}
