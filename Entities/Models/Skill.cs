using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Skill
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid WorkProgramId { get; set; }
    public WorkProgram WorkProgram { get; set; }
}