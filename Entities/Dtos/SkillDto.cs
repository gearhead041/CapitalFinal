namespace Entities.Dtos;

public record SkillDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public record CreateSkillDto
{
    public string Name { get; set; }
}