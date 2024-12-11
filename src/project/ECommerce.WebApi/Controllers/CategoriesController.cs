using Core.Application.Requests;
using ECommerce.Application.Features.Categories.Commands.Create;
using ECommerce.Application.Features.Categories.Commands.Delete;
using ECommerce.Application.Features.Categories.Queries.GetById;
using ECommerce.Application.Features.Categories.Queries.GetListByPaginate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(IMediator _mediator) : BaseController(_mediator)
{
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CategoryAddCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok();
    }

    [HttpGet("paginate")]
    public async Task<IActionResult> GetPaginate([FromQuery] PageRequest pageRequest)
    {
        var query = new GetListByPaginateCategoryQuery
        {
            PageRequest = pageRequest
        };

        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("getbyid")]
    public async Task<IActionResult> GetById([FromQuery] int id) => Ok(await _mediator.Send(new GetByIdCategoryQuery { Id = id }));
    //{
    //    var query = new GetByIdCategoryQuery
    //    {
    //        Id = id
    //    };
    //    var response = await _mediator.Send(query);
    //    return Ok(response);
    //}

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        var command = new CategoryDeleteCommand
        {
            Id = id
        };

        var response = await _mediator.Send(command);
        return Ok(response);
    }
}

