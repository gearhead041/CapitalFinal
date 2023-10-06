using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class ApplicationForm
{
    [Key]
    public Guid Id { get; set; }
    public Guid WorkProgramId { get; set; }
    public WorkProgram WorkProgram { get; set; }
    public byte[] Image { get; set; }
    public PersonalInfo PersonalInformation { get; set; } = null!;
    public Profile Profile { get; set; } = null!;
    public IEnumerable<Question> AdditionalQuestions { get; set; }
}
