using DialCMS.Application.Queries.GetAllTemplates;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DialCMS.API.Extensions;
using DialCMS.Application.Commands.Templates.CreateTemplate;
using DialCMS.Application.Commands.Templates.UpddateTemplate;
using DialCMS.Domain.Entities;

namespace DialCMS.API.Controllers;

[ApiController]
[Route("templates")]
public class TemplateController(IMediator mediator) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetAllTemplatesQuery();
        var result = await mediator.Send(query);

        return result.Match(
            success => Ok(success),
            this.Problem
        );
    }
    
    [HttpPost()]
    public async Task<IActionResult> PostTemplate(Template template)
    {
        var command = new CreateTemplateCommand(template);
        var result = await mediator.Send(command);

        return result.Match(
            success => Ok(success),
            this.Problem
        );
    }
    
    [HttpPut("{templateId}")]
    public async Task<IActionResult> PutTemplate(Guid templateId, Template template)
    {
        var command = new UpdateTemplateCommand(templateId, template);
        var result = await mediator.Send(command);

        return result.Match(
            Ok,
            this.Problem
        );
    }
}