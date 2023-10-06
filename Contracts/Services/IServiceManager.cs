
namespace Contracts.Services;

public interface IServiceManager
{
    IApplicationFormService ApplicationFormService { get; }
    IStageService StageService { get; }
    IWorkProgramService WorkProgramService { get; }
}
