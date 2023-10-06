using Contracts.Repository;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class SkillRepository : RepositoryBase<Skill>, ISkillRepository
{
    public SkillRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Skill>> GetProgramSkills(Guid id,bool trackChanges, string include)
        => await FindByCondition( s => s.WorkProgramId == id,trackChanges,include).ToListAsync();

}
