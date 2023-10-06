
using Entities.Dtos;

namespace Contracts.Services;

public interface IApplicationFormService
{
    Task<ApplicationFormDto> CreateApplicationForm(CreateApplicationFormDto applicationForm);
    Task<ApplicationFormDto> GetApplicationForm(Guid  id);
    Task<ApplicationFormDto> UpdateApplicationForm(ApplicationFormDto applicationForm);
    void DeleteApplicationForm(Guid id);
}
