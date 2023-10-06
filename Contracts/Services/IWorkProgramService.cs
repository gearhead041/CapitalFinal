
using Entities.Dtos;

namespace Contracts.Services;

public interface IWorkProgramService
{
    Task<WorkProgramDto> CreateWorkProgram(CreateWorkProgramDto workProgramDto);
    Task<WorkProgramDto> GetWorkProgram(Guid workProgramId);
    Task<WorkProgramDto> UpdateWorkProgram(WorkProgramDto workProgramDto);
    Task<IEnumerable<WorkProgramDto>> GetAllWorkProgram();
    void DeleteWorkProgram(Guid id);
}
