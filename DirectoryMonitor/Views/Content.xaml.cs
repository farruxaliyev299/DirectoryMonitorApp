using DirectoryMonitor.Helpers;
using DirectoryMonitor.Loaders;
using DirectoryMonitor.Loaders.Contracts;
using DirectoryMonitor.Models;
using DirectoryMonitor.Models.Configuration;
using DirectoryMonitor.ViewModels;
using System.IO;
using System.Windows;

namespace DirectoryMonitor.Views;

public partial class Content : Window
{
    private static ContentVM _contentViewModel;

    public Content(string extension, string filePath)
    {
        InitializeComponent();

        _contentViewModel = new ContentVM { Extension = extension, FilePath = filePath };

        this.Loaded += ContentLoaded;
    }

    private void ContentLoaded(object sender, RoutedEventArgs e)
    {
        try
        {
            LoadData(_contentViewModel.Extension, _contentViewModel.FilePath);
        }
        catch (Exception ex)
        {
            MessageBoxHelper.ShowWarning(ex.Message);
            this.Close();
        }
    }

    public void LoadData(string extension, string filePath)
    {
        ILoader loader = LoaderFactory.GetSpecificLoader(extension);

        var trades = new List<Trade>();

        try
        {
            trades = loader.LoadData(filePath);
        }
        catch (FormatException ex)
        {
            throw new NotSupportedException("Content format is not convertable!");
        }

        tradeData.ItemsSource = trades;

        fileName.Text = Path.GetFileName(filePath);
    }


}
