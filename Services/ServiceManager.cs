
using AutoMapper;
using Contracts.Repository;
using Contracts.Services;

namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IApplicationFormService> _appFormService;
    private readonly Lazy<IStageService> _stageService;
    private readonly Lazy<IWorkProgramService> _workProgramService;

    public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _appFormService = new Lazy<IApplicationFormService>(() => 
            new ApplicationFormService(repositoryManager, mapper));
        _stageService = new Lazy<IStageService>(() => new StageService(repositoryManager, mapper));
        _workProgramService = new Lazy<IWorkProgramService>(() => 
            new WorkProgramService(repositoryManager,mapper));
    }



    public IApplicationFormService ApplicationFormService => _appFormService.Value;

    public IStageService StageService =>_stageService.Value;

    public IWorkProgramService WorkProgramService => _workProgramService.Value;
}
