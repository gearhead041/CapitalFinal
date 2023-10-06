using Contracts.Repository;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class StageRepository : RepositoryBase<Stage>, IStageRepository
{
    public StageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateStage(Stage stage)
        => Create(stage);

    public void DeleteStage(Stage stage)
        => Delete(stage);

    public async Task<IEnumerable<Stage>> GetAllProgramStages(Guid workProgramId, bool trackChanges, string? include)
        => await FindByCondition( s =>  s.WorkProgramId == workProgramId, trackChanges,include).ToListAsync();


    public async Task<Stage> GetStage(Guid stageId, bool trackchanges, string? include)
        => await FindByCondition(s => s.Id == stageId, trackchanges,include).FirstOrDefaultAsync();
}
