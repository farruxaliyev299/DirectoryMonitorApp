using DirectoryMonitor.Loaders.Contracts;
using DirectoryMonitor.Models;
using System.IO;
using System.Xml.Linq;

namespace DirectoryMonitor.Loaders;

public class XmlLoader : IXmlLoader
{
    public List<Trade> LoadData(string path)
    {
        try
        {
            var trades = new List<Trade>();

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"File couldn't found in this path: {path}");
            }

            var doc = XDocument.Load(path);

            foreach (var valueElement in doc.Root.Elements("value"))
            {
                var trade = new Trade
                {
                    Date = DateTime.Parse(valueElement.Attribute("date").Value),
                    Open = decimal.Parse(valueElement.Attribute("open").Value),
                    High = decimal.Parse(valueElement.Attribute("high").Value),
                    Low = decimal.Parse(valueElement.Attribute("low").Value),
                    Close = decimal.Parse(valueElement.Attribute("close").Value),
                    Volume = long.Parse(valueElement.Attribute("volume").Value)
                };

                trades.Add(trade);
            }

            return trades;
        }
        catch (Exception ex)
        {
            return new List<Trade>();
        }
    }
}
