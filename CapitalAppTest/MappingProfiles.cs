namespace CapitalAppTest;
using AutoMapper;
using Entities.Dtos;
using Entities.Models;

public class MappingProfiles : AutoMapper.Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateApplicationFormDto, ApplicationForm>().ReverseMap();
        CreateMap<ApplicationFormDto, ApplicationForm>().ReverseMap();
        //CreateMap<CreateProfileDto, Entities.Models.Profile>().ReverseMap();
        //CreateMap<ProfileDto, Entities.Models.Profile>().ReverseMap();
        //CreateMap<CreateEducationDto, Education>().ReverseMap();
        //CreateMap<EducationDto,Education>().ReverseMap();
        //CreateMap<ExperienceDto, Experience>().ReverseMap();
        //CreateMap<CreateExperienceDto,Experience>().ReverseMap();
        //CreateMap<QuestionDto, Question>().ReverseMap();
        //CreateMap<DropdownQuestionDto, Dropdown>().ReverseMap();
        CreateMap<CreateStageDto,Stage>().ReverseMap();
        CreateMap<StageDto,Stage>().ReverseMap();
        CreateMap<VideoInterviewStageDto,VideoInterView>().ReverseMap();
        CreateMap<WorkProgramDto, WorkProgram>().ReverseMap();
        CreateMap<CreateWorkProgramDto,WorkProgram>().ReverseMap();
        CreateMap<SkillDto,Skill>().ReverseMap();
        CreateMap<CreateSkillDto,Skill>().ReverseMap();
        CreateMap<QuestionDto,Question>().ReverseMap();
        CreateMap<DateOnly, string>().ConvertUsing(new DateOnlyToStringConverter());
        CreateMap<string, DateOnly>().ConvertUsing(new StringToDateOnlyConverter());
    }
}

public class DateOnlyToStringConverter : ITypeConverter<DateOnly, string>
{
    public string Convert(DateOnly source, string destination, ResolutionContext context)
    {
        // Customize the format as needed (e.g., "yyyy-MM-dd")
        return source.ToString("yyyy-MM-dd");
    }
}
public class StringToDateOnlyConverter : ITypeConverter<string, DateOnly>
{
    public DateOnly Convert(string source, DateOnly destination, ResolutionContext context)
    {
        if (DateOnly.TryParse(source, out DateOnly dateOnly))
        {
            return dateOnly;
        }

        // Handle conversion errors as needed (e.g., throw an exception or return a default value)
        throw new AutoMapperMappingException($"Could not convert '{source}' to DateOnly.");
    }
}