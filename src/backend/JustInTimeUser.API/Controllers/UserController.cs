﻿using JustInTimeUser.Application.UseCases.User.Register;
using JustInTimeUser.Communication.Requests;
using JustInTimeUser.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace JustInTimeUser.API.Controllers;
[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status200OK)]
    public IActionResult Register(RequestRegisterUserJson request)
    {
        var useCase = new RegisterUserUseCase();

        var result = useCase.Execute(request);

        return Created(string.Empty, result);
    }
}
