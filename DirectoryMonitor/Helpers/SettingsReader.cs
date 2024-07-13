using DirectoryMonitor.Models.Configuration;
using DirectoryMonitor.Models.Configuration.Contracts;
using System.IO;
using System.Text.Json;

namespace DirectoryMonitor.Helpers;

public static class SettingsReader
{
    public static T GetSettings<T>(string settingFileName) where T : ISetting
    {
        var configPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, settingFileName);
        var json = File.ReadAllText(configPath);

        return JsonSerializer.Deserialize<T>(json);
    }

    public static void SetNewSettings<T>(T setting, string settingFileName)
    {
        var settings = JsonSerializer.Serialize(setting);

        var configPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, settingFileName);
        File.WriteAllText(configPath, settings);
    }

    //public static FileTypeSettings GetFileTypes()
    //{
    //    var configPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "filetypes.json");
    //    var json = File.ReadAllText(configPath);

    //    return JsonSerializer.Deserialize<FileTypeSettings>(json);
    //}
}
