using System.Configuration;
using System.Data;
using System.Windows;

namespace DirectoryMonitor;

public partial class App : Application
{
    private static Mutex _mutex;

    [STAThread]
    protected override void OnStartup(StartupEventArgs e)
    {
        const string appName = "DirectoryMonitor";
        bool createdNew;

        _mutex = new Mutex(true, appName, out createdNew);

        if (!createdNew)
        {
            MessageBox.Show("The application is already running.", "Instance Already Running", MessageBoxButton.OK, MessageBoxImage.Information);
            Shutdown();
            return;
        }

        base.OnStartup(e);
    }
}
