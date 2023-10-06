
using Microsoft.AspNetCore.Http;

namespace Entities.Models;

public class Profile
{
    public IEnumerable<Education> Education { get; set; }
    public IEnumerable<Experience> Experience { get; set; }
    public byte[] Resume { get; set; }
}