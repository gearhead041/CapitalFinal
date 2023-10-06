using Contracts.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CapitalAppTest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppFormController : ControllerBase
{
    private readonly IServiceManager serviceManager;
    public AppFormController(IServiceManager serviceManager)
    {
        this.serviceManager = serviceManager;
    }

    [HttpGet("{id:Guid}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<ApplicationFormDto>> GetAppForm(Guid id)
    {
        var appForm = await serviceManager.ApplicationFormService.GetApplicationForm(id);
        if (appForm == null)
        {
            return NotFound();
        }
        return Ok(appForm);
    }

    [HttpPut]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<ApplicationFormDto>> UpdateAppForm([FromBody] ApplicationFormDto applicationFormDto)
    {
        var appForm = await serviceManager.ApplicationFormService.UpdateApplicationForm(applicationFormDto);
        if (appForm == null)
        {
            return BadRequest("Form not found");
        }
        return Ok(appForm);
    }


    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<ApplicationFormDto>> CreateAppForm([FromBody] CreateApplicationFormDto applicationFormDto)
    {
        var appForm = await serviceManager.ApplicationFormService.CreateApplicationForm(applicationFormDto);
        return Ok(appForm);
    }
}
