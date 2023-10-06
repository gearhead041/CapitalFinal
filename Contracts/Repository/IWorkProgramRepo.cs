using Entities.Models;

namespace Contracts.Repository;

public interface IWorkProgramRepository
{
    void CreateWorkProgram(WorkProgram workProgram);
    void DeleteWorkProgram(WorkProgram workProgram);
    Task<WorkProgram> GetWorkProgram(Guid workProgramId, bool trackchanges, string? include);
    Task<IEnumerable<WorkProgram>> GetAllWorkProgram(string? include);
}