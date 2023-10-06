namespace Entities.Dtos;

public record EducationDto
{
    public string School { get; set; }
    public string Degree { get; set; }
    public string CourseName { get; set; }
    public string LocationOfStudy { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool IsCurrent { get; set; }
    public bool IsHidden { get; set; }
    public bool IsMandatory { get; set; }
}

public record CreateEducationDto
{
    public string School { get; set; }
    public string Degree { get; set; }
    public string CourseName { get; set; }
    public string LocationOfStudy { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool IsCurrent { get; set; }
    public bool IsHidden { get; set; }
    public bool IsMandatory { get; set; }
}