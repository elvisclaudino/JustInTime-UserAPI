using JustInTimeUser.Application.UseCases.User.Register;
using JustInTimeUser.Communication.Requests;
using JustInTimeUser.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace JustInTimeUser.API.Controllers;
[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase 
{ 
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(
        [FromBody] RequestRegisterUserJson request,
        [FromServices] IRegisterUserUseCase useCase)
    {
        var result = await useCase.Execute(request);

        return Created(string.Empty, result);
    }
}
