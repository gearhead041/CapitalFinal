
namespace Entities.Models;

public class FileData
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public byte[] Data { get; set; }
}

public class Image : FileData
{ }
public class Resume : FileData
{ }