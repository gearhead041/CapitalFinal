using Contracts.Repository;

namespace Repository;
public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext context;
    private readonly Lazy<IWorkProgramRepository> _workProgramRepository;
    private readonly Lazy<IStageRepository> _stageRepository;
    private readonly Lazy<IApplicationFormRepo> _applicationFormRepository;
    private readonly Lazy<ISkillRepository> _skillRepository;

    public RepositoryManager(RepositoryContext context)
    {
        this.context = context;
        this._workProgramRepository = new Lazy<IWorkProgramRepository>(() => new WorkProgramRepo(context));
        _stageRepository = new Lazy<IStageRepository>(() => new StageRepository(context));
        _applicationFormRepository = new Lazy<IApplicationFormRepo>(() => new ApplicationFormRepo(context));
        _skillRepository = new Lazy<ISkillRepository>(() => new SkillRepository(context));
    }
    public IApplicationFormRepo applicationFormRepo => _applicationFormRepository.Value;

    public IWorkProgramRepository workProgramRepo => _workProgramRepository.Value;

    public IStageRepository stageRepository => _stageRepository.Value;
    public ISkillRepository skillsRepository => _skillRepository.Value;

    public async Task Save()
    {
        Console.WriteLine("And THe is Database is Create!");
        Console.WriteLine(await context.Database.EnsureCreatedAsync());
        await context.SaveChangesAsync();
        
    }
}
