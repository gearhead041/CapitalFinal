using Contracts.Repository;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class ApplicationFormRepo : RepositoryBase<ApplicationForm>, IApplicationFormRepo
{
    public ApplicationFormRepo(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateApplicationForm(ApplicationForm applicationForm)
        => Create(applicationForm);

    public void DeleteApplicationForm(ApplicationForm applicationForm)
        => Delete(applicationForm);

    public async Task<ApplicationForm> GetApplicationForm(Guid workProgramId, bool trackchanges, string include)
        => await FindByCondition(a => a.WorkProgramId == workProgramId, trackchanges, include).FirstOrDefaultAsync();
}
