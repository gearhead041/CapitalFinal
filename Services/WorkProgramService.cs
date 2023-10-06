using AutoMapper;
using Contracts.Repository;
using Contracts.Services;
using Entities.Dtos;
using Entities.Models;

namespace Services;

public class WorkProgramService : IWorkProgramService
{
    private readonly IRepositoryManager repositoryManager;
    private readonly IMapper _mapper;
    public WorkProgramService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        this.repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    public async Task<WorkProgramDto> CreateWorkProgram(CreateWorkProgramDto workProgramDto)
    {
        var workProgram = _mapper.Map<WorkProgram>(workProgramDto);
        repositoryManager.workProgramRepo.CreateWorkProgram(workProgram);
        await repositoryManager.Save();
        return _mapper.Map<WorkProgramDto>(workProgram);
    }

    public async void DeleteWorkProgram(Guid id)
    {
        var workProgramToDelete = await repositoryManager.workProgramRepo.GetWorkProgram(id, true, null);
        if (workProgramToDelete != null)
        {
            repositoryManager.workProgramRepo.DeleteWorkProgram(workProgramToDelete);
        }
    }

    public async Task<IEnumerable<WorkProgramDto>> GetAllWorkProgram()
    {
        var workPrograms = await repositoryManager.workProgramRepo.GetAllWorkProgram(null);
        return _mapper.Map<IEnumerable<WorkProgramDto>>(workPrograms);
    }

    public async  Task<WorkProgramDto> GetWorkProgram(Guid workProgramId)
    {
        var workProgram = await repositoryManager.workProgramRepo.GetWorkProgram(workProgramId, false,"SKILLSREQUIRED");
        if (workProgram == null)
        {
            return null;
        }
        var workProgramReturn = _mapper.Map<WorkProgramDto>(workProgram);
        var programSkills = await repositoryManager.skillsRepository.GetProgramSkills(workProgramId,false,null);
        workProgramReturn.SkillsRequired = _mapper.Map<IEnumerable<SkillDto>>(programSkills);
        return workProgramReturn;
    }

    public async Task<WorkProgramDto> UpdateWorkProgram(WorkProgramDto workProgramDto)
    {
        var workProgram = await repositoryManager.workProgramRepo.GetWorkProgram(workProgramDto.Id, true, null);
        if (workProgram == null)
        {
            return null;
        }
        _mapper.Map(workProgramDto, workProgram);
        await repositoryManager.Save();

        return workProgramDto;

    }
}