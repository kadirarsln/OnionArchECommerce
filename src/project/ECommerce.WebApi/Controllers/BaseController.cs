using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controllers;

public class BaseController(IMediator _mediator) : ControllerBase
{
}

