using Entities.Models;

namespace Contracts.Repository;

public interface IApplicationFormRepo
{
    Task<ApplicationForm> GetApplicationForm(Guid workProgramId, bool trackchanges, string? include);
    void DeleteApplicationForm(ApplicationForm applicationForm);
    void CreateApplicationForm(ApplicationForm applicationForm);
}
