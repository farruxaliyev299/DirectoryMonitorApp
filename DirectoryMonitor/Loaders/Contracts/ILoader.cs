using DirectoryMonitor.Models;

namespace DirectoryMonitor.Loaders.Contracts;

public interface ILoader
{
    List<Trade> LoadData(string path);
}
