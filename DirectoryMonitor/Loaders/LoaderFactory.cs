using DirectoryMonitor.Loaders.Contracts;
using System.Windows;

namespace DirectoryMonitor.Loaders;

public class LoaderFactory
{
    public static ILoader GetSpecificLoader(string extension)
    {
        switch (extension)
        {
            case "csv":
                return new CsvLoader();
            case "xml":
                return new XmlLoader();
            case "txt":
                return new TxtLoader();
            default:
                throw new NotSupportedException($"{extension} is not supported!");
        }
    }
}
