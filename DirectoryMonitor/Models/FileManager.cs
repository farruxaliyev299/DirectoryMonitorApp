using DirectoryMonitor.Helpers;
using DirectoryMonitor.Models.Configuration;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Threading;

namespace DirectoryMonitor.Models;

public class FileManager
{
    private static ObservableCollection<DirectoryFile> _inputDirectoryFiles { get; set; } = new();

    public static ObservableCollection<DirectoryFile> GetFiles()
    {
        var settings = SettingsReader.GetSettings<MonitorSettings>("appsettings.json");

        var fileTypeSettings = SettingsReader.GetSettings<FileTypeSettings>("filetypes.json");

        var files = fileTypeSettings.FileTypes.SelectMany(file => Directory.GetFiles(settings.InputDirectory, file, SearchOption.AllDirectories));

        Application.Current.Dispatcher.Invoke(() =>
        {
            _inputDirectoryFiles.Clear();
            foreach (var file in files)
            {
                _inputDirectoryFiles.Add(new DirectoryFile
                {
                    Name = Path.GetFileName(file),
                    Path = file,
                    Extension = Path.GetExtension(file).Substring(1)
                });
            }
        });

        return _inputDirectoryFiles;
    }

    public static void AddFile(DirectoryFile file)
    {
        Application.Current.Dispatcher.Invoke(() => _inputDirectoryFiles.Add(file));
    }

    public static Task<ObservableCollection<DirectoryFile>> GetFilesAsync()
    {
        return Task.Run(() => GetFiles());
    }
}
