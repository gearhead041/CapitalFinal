using Contracts.Repository;
using Entities.Dtos;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class WorkProgramRepo : RepositoryBase<WorkProgram>, IWorkProgramRepository
{
    public WorkProgramRepo(RepositoryContext repositoryContext): base(repositoryContext)
    {
    }

    public void CreateWorkProgram(WorkProgram workProgram)
        =>Create(workProgram);

    public void DeleteWorkProgram(WorkProgram workProgram)
        => Delete(workProgram);

    public async Task<IEnumerable<WorkProgram>> GetAllWorkProgram(string include)
        => await GetAll(false, include).ToListAsync();

    public async Task<WorkProgram> GetWorkProgram(Guid workProgramId, bool trackchanges, string include)
        => await FindByCondition(w => w.Id == workProgramId,trackchanges, include).FirstOrDefaultAsync();

}
