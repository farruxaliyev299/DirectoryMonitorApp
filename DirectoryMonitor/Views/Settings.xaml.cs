using DirectoryMonitor.Helpers;
using DirectoryMonitor.Models.Configuration;
using DirectoryMonitor.ViewModels;
using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace DirectoryMonitor.Views;

public partial class Settings : Window
{
    private SettingsVM _settingsViewModel { get; set; }

    public Settings()
    {
        InitializeComponent();

        _settingsViewModel = new SettingsVM();

        var monitorSettings = new MonitorSettings();

        try
        {
            monitorSettings = SettingsReader.GetSettings<MonitorSettings>("appsettings.json");
        }
        catch (Exception ex)
        {
            MessageBoxHelper.ShowWarning(ex.Message);
            this.Close();
            return;
        }

        _settingsViewModel.InputDirectory = monitorSettings.InputDirectory;
        _settingsViewModel.FrequencyInSeconds = monitorSettings.FrequencyInSeconds;

        this.DataContext = _settingsViewModel;
    }

    private void NumberValidation(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }

    private void SaveSettings(object sender, RoutedEventArgs e)
    {
        var settings = new MonitorSettings();

        settings.InputDirectory = DirectoryPath.Text;
        settings.FrequencyInSeconds = Convert.ToInt32(FrequencyNumber.Text);

        this.Close();

        SettingsReader.SetNewSettings(settings, "appsettings.json");

        var mainWindow = this.Owner as Main;

        mainWindow.StopTimer();

        mainWindow.InitializeFileLoad();
    }

    private void OpenFileExplorer(object sender, RoutedEventArgs e)
    {
        OpenFolderDialog openFileDialog = new();

        if (openFileDialog.ShowDialog() == true && Path.Exists(openFileDialog.FolderName))
        {
            DirectoryPath.Text = Path.GetFullPath(openFileDialog.FolderName);
        }
    }
}
