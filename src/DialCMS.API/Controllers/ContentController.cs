using DialCMS.Application.Commands.CreateContent;
using DialCMS.Application.Queries.GetContentById;
using DialCMS.API.Extensions;
using DialCMS.Application.Commands.UpdateContentValues;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DialCMS.API.Controllers;

[ApiController]
[Route("contents")]
public class ContentController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetContentByIdQuery { Id = id };
        var result = await _mediator.Send(query);

        return result.Match(
            success => Ok(success),
            this.Problem
        );
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateContentCommand command)
    {
        var result = await _mediator.Send(command);
        
        return result.Match(
            success => CreatedAtAction(nameof(GetById), new { id = success }, success),
            this.Problem
        );
    }
    
    [HttpPatch("{id:guid}/values")]
    public async Task<IActionResult> UpdateValues(Guid id, [FromBody] Dictionary<string, Dictionary<string, object>> values)
    {
        var command = new UpdateContentValuesCommand
        {
            ContentId = id,
            Values = values
        };

        var result = await _mediator.Send(command);

        return result.Match(
            success => NoContent(),
            this.Problem
        );
    }
}