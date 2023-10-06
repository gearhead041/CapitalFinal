using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public record WorkProgramDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public IEnumerable<SkillDto> SkillsRequired { get; set; }
    public string Benefits { get; set; }
    public string ApplicationCriteria { get; set; }
    public string ProgramType { get; set; }
    public DateOnly ProgramStart { get; set; }
    public DateOnly ApplicationOpen { get; set; }
    public DateOnly ApplicationClose { get; set; }
    public string Duration { get; set; }
    public string MinQualifications { get; set; }
    public int MaxApplications { get; set; }
    public bool IsPublished { get; set; }
}

public record CreateWorkProgramDto
{
    [Required(ErrorMessage ="Title is required")]
    public string Title { get; set; }
    public string Summary { get; set; }
    [Required(ErrorMessage ="Description is required")]
    public string Description { get;set; }
    public IEnumerable<CreateSkillDto> SkillsRequired { get; set; }
    public string Benefits { get; set; }
    public string ApplicationCriteria { get; set; }
    public DateOnly ProgramStart { get; set; }
    [Required]
    public DateOnly ApplicationOpen { get; set; }
    [Required]
    public DateOnly ApplicationClose { get; set; }
    public string Duration { get; set; }
    public string MinQualifications { get; set; }

    [Range(1,20000, ErrorMessage ="Value must be between 1 and 20,000")]
    public int MaxApplications { get; set; }
}

