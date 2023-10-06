using Contracts.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;


namespace CapitalAppTest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkProgramController : ControllerBase
{

    private readonly IServiceManager serviceManager;
    public WorkProgramController(IServiceManager serviceManager)
    {
        this.serviceManager = serviceManager;
    }

    // GET: api/<WorkProgramController>/5
    [HttpGet("{id:Guid}",Name ="ProgramById")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<WorkProgramDto>> GetProgram(Guid id)
    {
        var workProgram = await serviceManager.WorkProgramService.GetWorkProgram(id);
        if (workProgram == null)
        {
            return NotFound();
        }
        return Ok(workProgram);
    }

    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<ActionResult<WorkProgramDto>> GetPrograms()
    {
        var workPrograms = await serviceManager.WorkProgramService.GetAllWorkProgram();

        return Ok(workPrograms);
    }
    // POST api/<WorkProgramController>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<WorkProgramDto>> Post([FromBody] CreateWorkProgramDto workProgramDto)
    {
        var workProgram = await serviceManager.WorkProgramService.CreateWorkProgram(workProgramDto);
        return CreatedAtRoute("ProgramById", new { id = workProgram.Id }, workProgram);
    }

    // PUT api/<ValuesController>/5
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WorkProgramDto>> Put( [FromBody] WorkProgramDto workProgramDto)
    {
        var workProgram = await serviceManager.WorkProgramService.UpdateWorkProgram(workProgramDto);
        return Ok(workProgram);
    }

}
