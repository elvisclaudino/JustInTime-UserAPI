using AutoMapper;
using JustInTimeUser.Communication.Requests;

namespace JustInTimeUser.Application.Services.AutoMapper;
public class AutoMapping : Profile
{
   public AutoMapping()
   {
       RequestToDomain();
   }
    
   private void RequestToDomain()
    {
        CreateMap<RequestRegisterUserJson, Domain.Entitities.User>()
            .ForMember(dest => dest.Password, opt => opt.Ignore());
    }
}
