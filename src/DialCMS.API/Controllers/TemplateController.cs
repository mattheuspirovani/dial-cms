using DialCMS.Application.Queries.GetAllTemplates;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DialCMS.API.Extensions;
using DialCMS.Application.Commands.CreateTemplate;
using DialCMS.Domain.Entities;

namespace DialCMS.API.Controllers;

[ApiController]
[Route("templates")]
public class TemplateController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    
    [HttpGet()]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetAllTemplatesQuery();
        var result = await _mediator.Send(query);

        return result.Match(
            success => Ok(success),
            this.Problem
        );
    }
    
    [HttpPost()]
    public async Task<IActionResult> PostTemplate(Template template)
    {
        var query = new CreateTemplateCommand(template);
        var result = await _mediator.Send(query);

        return result.Match(
            success => Ok(success),
            this.Problem
        );
    }
}