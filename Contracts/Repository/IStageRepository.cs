using Entities.Models;

namespace Contracts.Repository;

public interface IStageRepository
{
    void CreateStage(Stage stage);
    Task<Stage> GetStage(Guid stageId, bool trackchanges, string? include);
    Task<IEnumerable<Stage>> GetAllProgramStages(Guid workProgramId, bool trackChanges, string? include);
    void DeleteStage(Stage stage);
}
