using DirectoryMonitor.Loaders.Contracts;
using DirectoryMonitor.Models;
using System.Globalization;
using System.IO;

namespace DirectoryMonitor.Loaders;

public class TxtLoader : ITxtLoader
{
    public List<Trade> LoadData(string path)
    {
        var trades = new List<Trade>();

        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"File couldn't found in this path: {path}");
        }

        var lines = File.ReadAllLines(path);


        foreach (var line in lines.Skip(4))
        {
            var columns = line.Split(',');

            var trade = new Trade
            {
                Date = DateTime.ParseExact(columns[0], "yyyy-M-d", CultureInfo.InvariantCulture),
                Open = decimal.Parse(columns[1], CultureInfo.InvariantCulture),
                High = decimal.Parse(columns[2], CultureInfo.InvariantCulture),
                Low = decimal.Parse(columns[3], CultureInfo.InvariantCulture),
                Close = decimal.Parse(columns[4], CultureInfo.InvariantCulture),
                Volume = long.Parse(columns[5], CultureInfo.InvariantCulture)
            };

            trades.Add(trade);
        }

        return trades;
    }
}
