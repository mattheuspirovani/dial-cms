using DialCMS.API.Extensions;
using DialCMS.Application.Commands.CreateContentType;
using DialCMS.Application.Queries.GetContentTypeById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DialCMS.API.Controllers;

[ApiController]
[Route("content-types")]
public class ContentTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContentTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetContentTypeByIdQuery { Id = id };
        var result = await _mediator.Send(query);

        return result.Match(
            success => Ok(success),
            errors => this.Problem(errors)
        );
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateContentTypeCommand command)
    {
        var result = await _mediator.Send(command);

        return result.Match(
            success => CreatedAtAction(nameof(GetById), new { id = success }, success),
            errors => this.Problem(errors)
        );
    }
}