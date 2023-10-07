
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
        if (applicationForm.Image != null)
        {
            using var memoryStream = new MemoryStream();
            await applicationForm.Image.CopyToAsync(memoryStream);
            appForm.Image.Data = memoryStream.ToArray();
        }
        if (applicationForm.Profile.Resume !=
            null)
        {
            using var memoryStream = new MemoryStream();
            await applicationForm.Profile.Resume.CopyToAsync(memoryStream);
            appForm.Profile.Resume.Data = memoryStream.ToArray();
        }
        repositoryManager.applicationFormRepo.CreateApplicationForm(appForm);
        await repositoryManager.Save();
        return _mapper.Map<ApplicationFormDto>(appForm);
    }

    public async void DeleteApplicationForm(Guid id)
    {
        var appForm = await repositoryManager.applicationFormRepo.GetApplicationForm(id, true, null);
        if (appForm != null)
        {
            repositoryManager.applicationFormRepo.DeleteApplicationForm(appForm);
            await repositoryManager.Save();
        }
    }

    public async Task<ApplicationFormDto> GetApplicationForm(Guid id)
    {
        var appForm = await repositoryManager.applicationFormRepo.GetApplicationForm(id, false, null);
        var appFormReturn = _mapper.Map<ApplicationFormDto>(appForm);
        foreach (var question in appForm.PersonalInformation.Questions)
        {
            switch (question.QuestionType.ToLower().Trim())
            {
                case "multiple choice":
                    appFormReturn.PersonalInformation.Questions.ToList().Add(_mapper.Map<MultipleChoiceDto>(question));
                    break;
                case "YesNo":
                    appFormReturn.PersonalInformation.Questions.ToList().Add(_mapper.Map<YesNoDto>(question));
                    break;
                case "dropdown":
                    appFormReturn.PersonalInformation.Questions.ToList().Add(_mapper.Map<DropDownDto>(question));
                    break;
                default:
                    appFormReturn.PersonalInformation.Questions.ToList().Add(_mapper.Map<QuestionDto>(question));
                    break;
            }
        }
        return appFormReturn;
    }

    public async Task<ApplicationFormDto> UpdateApplicationForm(ApplicationFormDto applicationForm)
    {
        var appForm = await repositoryManager.applicationFormRepo.GetApplicationForm(applicationForm.Id, true, null);
        if (appForm != null)
        {
            _mapper.Map(applicationForm, appForm);
            await repositoryManager.Save();
        }

        return applicationForm;

    }
}
