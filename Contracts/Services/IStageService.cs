
using Entities.Dtos;

namespace Contracts.Services;

public interface IStageService
{
    Task<StageDto> CreateStage(CreateStageDto stage);
    Task<IEnumerable<StageDto>> GetWorkProgramStages(Guid stageId);
    Task<StageDto> UpdateStage(StageDto stage);
    void DeleteStage(Guid stageId);
}
