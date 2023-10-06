namespace Entities.Dtos;

public record ExperienceDto
{
    public string Company { get; set; }
    public string Title { get; set; }
    public string WorkLocation { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool IsCurrent { get; set; }
    public bool IsMandatory { get; set; }
    public bool IsHidden { get; set; }
}

public record CreateExperienceDto
{
    public string Company { get; set; }
    public string Title { get; set; }
    public string WorkLocation { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool IsCurrent { get; set; }
    public bool IsMandatory { get; set; }
    public bool IsHidden { get; set; }
}
