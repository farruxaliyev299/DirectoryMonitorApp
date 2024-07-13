using DirectoryMonitor.Helpers;
using DirectoryMonitor.Models.Configuration;
using DirectoryMonitor.ViewModels;
using System.Collections.ObjectModel;
using System.IO;
using System.Timers;
using System.Windows;
using Timer = System.Timers.Timer;

namespace DirectoryMonitor.Views;

public partial class Main : Window
{
    private Timer _timer;

    private MonitorSettings _monitorSettings;

    private MainVM _mainViewModel { get; set; }

    public Main()
    {
        InitializeComponent();

        _mainViewModel = new MainVM();

        this.DataContext = _mainViewModel;

        try
        {
            InitializeFileLoad();
        }
        catch (Exception ex)
        {
            MessageBoxHelper.ShowWarning(ex.Message);
        }
    }

    public async void InitializeFileLoad()
    {
        try
        {
            await _mainViewModel.LoadFilesAsync();
            _monitorSettings = SettingsReader.GetSettings<MonitorSettings>("appsettings.json");
            SetupTimer(_monitorSettings.FrequencyInSeconds);
        }
        catch (Exception ex)
        {
            MessageBoxHelper.ShowWarning(ex.Message);
        }
    }

    private void SetupTimer(int interval)
    {
        StopTimer();

        _timer = new Timer(interval * 1000);
        _timer.Elapsed += async (sender, e) => await TimerElapsedHandler();
        _timer.AutoReset = true;
        _timer.Enabled = true;
    }

    private async Task TimerElapsedHandler()
    {
        try
        {
            await OnTimedEvent();
        }
        catch (Exception ex)
        {
            MessageBoxHelper.ShowWarning(ex.Message);
        }
    }

    private async Task OnTimedEvent()
    {
        try
        {
            await _mainViewModel.LoadFilesAsync();
            _monitorSettings = SettingsReader.GetSettings<MonitorSettings>("appsettings.json");
            SetupTimer(_monitorSettings.FrequencyInSeconds);
        }
        catch (Exception ex)
        {
            MessageBoxHelper.ShowWarning(ex.Message);
        }
    }

    private void ShowChildWindowButton_Click(object sender, RoutedEventArgs e)
    {
        Settings childWindow = new();
        childWindow.Owner = this; // Set the owner to the current main window
        childWindow.ShowDialog();
    }

    public void StopTimer()
    {
        if (_timer != null)
        {
            _timer.Stop();
            _timer.Dispose();
        }
    }
}
