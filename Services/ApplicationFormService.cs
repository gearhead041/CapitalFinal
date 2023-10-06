
using AutoMapper;
using Contracts.Repository;
using Contracts.Services;
using Entities.Dtos;
using Entities.Models;

namespace Services;

public class ApplicationFormService : IApplicationFormService
{
    private readonly IRepositoryManager repositoryManager;
    private readonly IMapper _mapper;
    public ApplicationFormService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        this.repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<ApplicationFormDto> CreateApplicationForm(CreateApplicationFormDto applicationForm)
    {
        var appForm = _mapper.Map<ApplicationForm>(applicationForm);
        using (var memoryStream = new MemoryStream())
        {
            await applicationForm.Image.CopyToAsync(memoryStream);
            appForm.Image = memoryStream.ToArray();
        }
        using (var memoryStream = new MemoryStream())
        {
            await applicationForm.Profile.Resume.CopyToAsync(memoryStream);
            appForm.Profile.Resume = memoryStream.ToArray();
        }
        repositoryManager.applicationFormRepo.CreateApplicationForm(appForm);
        await repositoryManager.Save();
        return _mapper.Map<ApplicationFormDto>(appForm);
    }

    public async void DeleteApplicationForm(Guid id)
    {
        var appForm = await repositoryManager.applicationFormRepo.GetApplicationForm(id, true,null);
        if (appForm != null)
        {
            repositoryManager.applicationFormRepo.DeleteApplicationForm(appForm);
            await repositoryManager.Save();
        }
    }

    public async Task<ApplicationFormDto> GetApplicationForm(Guid id)
    {
        var appForm = await repositoryManager.applicationFormRepo.GetApplicationForm(id, false,null);
        return _mapper.Map<ApplicationFormDto>(appForm);
    }

    public async Task<ApplicationFormDto> UpdateApplicationForm(ApplicationFormDto applicationForm)
    {
        var appForm = await repositoryManager.applicationFormRepo.GetApplicationForm(applicationForm.Id, true,null);
        if (appForm != null)
        {
            _mapper.Map(applicationForm, appForm);
            await repositoryManager.Save();
        }

        return applicationForm;

    }
}
