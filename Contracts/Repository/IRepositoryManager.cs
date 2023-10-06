namespace Contracts.Repository;

public interface IRepositoryManager
{
    IApplicationFormRepo applicationFormRepo { get; }
    IWorkProgramRepository workProgramRepo { get; }
    IStageRepository stageRepository { get; }
    ISkillRepository skillsRepository { get; }
    Task Save();
}
