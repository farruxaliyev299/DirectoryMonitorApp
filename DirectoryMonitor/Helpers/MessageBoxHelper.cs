using System.Windows;

namespace DirectoryMonitor.Helpers;

public static class MessageBoxHelper
{
    public static void ShowWarning(string message)
    {
        MessageBox.Show(message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
    }
}
