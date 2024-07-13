using DirectoryMonitor.Commands;
using DirectoryMonitor.Models;
using DirectoryMonitor.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace DirectoryMonitor.ViewModels;

public class MainVM
{
    public ObservableCollection<DirectoryFile> DirectoryFiles { get; set; }

    public ICommand ShowSettingsWindowCommand { get; set; }

    public ICommand ShowContentWindowCommand { get; set; }

    public MainVM()
    {
        DirectoryFiles = new ObservableCollection<DirectoryFile>();

        ShowSettingsWindowCommand = new RelayCommand<object>(ShowSettingsWindow, CanShowSettingsWindow);

        ShowContentWindowCommand = new RelayCommand<DirectoryFile>(ShowContentWindow, CanShowContentWindow);
    }

    public async Task LoadFilesAsync()
    {
        var files = await FileManager.GetFilesAsync();
        Application.Current.Dispatcher.Invoke(() =>
        {
            DirectoryFiles.Clear();
            foreach (var file in files)
            {
                DirectoryFiles.Add(file);
            }
        });
    }

    public bool CanShowSettingsWindow(object obj) 
    {
        return true;
    }

    public bool CanShowContentWindow(object obj)
    {
        return true;
    }

    public void ShowSettingsWindow(object obj)
    {

        var settingsWindow = new Settings();
        settingsWindow.Owner = Application.Current.MainWindow;
        settingsWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        settingsWindow.ShowDialog();
    }

    public void ShowContentWindow(DirectoryFile file)
    {
        var contentWindow = new Content(file.Extension, file.Path);
        contentWindow.Owner = Application.Current.MainWindow;
        contentWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        contentWindow.ShowDialog();
    }

}
