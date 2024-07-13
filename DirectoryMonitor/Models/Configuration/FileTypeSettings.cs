using DirectoryMonitor.Models.Configuration.Contracts;

namespace DirectoryMonitor.Models.Configuration;

public class FileTypeSettings : ISetting
{
    public List<string> FileTypes { get; set; }
}
