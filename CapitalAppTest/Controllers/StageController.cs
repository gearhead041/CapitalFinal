using Contracts.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CapitalAppTest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StageController : ControllerBase
{
    private readonly IServiceManager serviceManager;

    public StageController(IServiceManager serviceManager)
    {
        this.serviceManager = serviceManager;
    }

    [HttpGet("{id:Guid}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<StageDto>>> GetWorkProgramStages(Guid id)
    {
        var stage = await serviceManager.StageService.GetWorkProgramStages(id);
        if (stage == null)
        {
            return NotFound();
        }
        return Ok(stage);
    }


    [HttpPut]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<StageDto>> UpdateStage([FromBody] StageDto stageDto)
    {
        var stage = await serviceManager.StageService.UpdateStage(stageDto);
        if (stage == null)
        {
            return BadRequest();
        }
        return Ok(stage);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<StageDto>> CreateStage([ValidateNever] CreateStageDto stageDto)
    {
        var stage = await serviceManager.StageService.CreateStage(stageDto);
        return Ok(stage);
    }
}

