
using AutoMapper;
using Contracts.Repository;
using Contracts.Services;
using Entities.Dtos;
using Entities.Models;

namespace Services;

public class StageService : IStageService
{
    private readonly IRepositoryManager repositoryManager;
    private readonly IMapper mapper;

    public StageService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        this.repositoryManager = repositoryManager;
        this.mapper = mapper;
    }

    public async Task<StageDto> CreateStage(CreateStageDto stage)
    {
        var stageToSave = mapper.Map<Stage>(stage);
        if (stage.StageType.ToLower().Trim() == "videointerview")
        {
            var videoInterviewInfo = mapper.Map<VideoInterView>(stage.VideoInterviewStageDto);
            stageToSave.VideoInterView = videoInterviewInfo;
        }
        repositoryManager.stageRepository.CreateStage(stageToSave);
        await repositoryManager.Save();
        var stageToReturn = mapper.Map<StageDto>(stageToSave);
        stageToReturn.VideoInterviewStageDto = stage.VideoInterviewStageDto;
        return stageToReturn;
    }

    public async void DeleteStage(Guid stageId)
    {
        var stage = await repositoryManager.stageRepository.GetStage(stageId, true, null);
        if (stage != null)
        {
            repositoryManager.stageRepository.DeleteStage(stage);
            await repositoryManager.Save();
        }
    }

    public async Task<IEnumerable<StageDto>> GetWorkProgramStages(Guid stageId)
    {
        var stages = await repositoryManager.stageRepository.GetAllProgramStages(stageId, false,null);
        var stagesReturn = mapper.Map<IEnumerable<StageDto>>(stages);
        foreach (var stage in stagesReturn)
        {
            var stageFromDb = stages.Where(s => s.Id == stage.Id).FirstOrDefault();
            if (stageFromDb.VideoInterView != null && stageFromDb.StageType.ToLower().Trim() == "videointerview")
            {
                stage.VideoInterviewStageDto = mapper
                    .Map<VideoInterviewStageDto>(stageFromDb.VideoInterView);
            }
        }
        return stagesReturn;
    }

    public async Task<StageDto> UpdateStage(StageDto stage)
    {
        var stageFromDb = await repositoryManager.stageRepository.GetStage(stage.Id, true, null);
        if (stage != null)
        {
            mapper.Map(stage, stageFromDb);
            await repositoryManager.Save();
        }
        return mapper.Map<StageDto>(stageFromDb);
    }
}
