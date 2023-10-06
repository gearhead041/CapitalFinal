using Entities.Models;

namespace Contracts.Repository;

public interface ISkillRepository
{
    Task<IEnumerable<Skill>> GetProgramSkills(Guid id, bool trackChagnes, string include);
}
