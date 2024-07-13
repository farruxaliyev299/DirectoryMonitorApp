using DirectoryMonitor.Models.Configuration.Contracts;

namespace DirectoryMonitor.Models.Configuration;

public class MonitorSettings : ISetting
{
    public string InputDirectory { get; set; }

    public int FrequencyInSeconds { get; set; }
}
