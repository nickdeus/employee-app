using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace APIV1.Services
{
    public interface ICSVService
    {
        public IEnumerable<T> ReadCSV<T>(Stream file);
        void WriteCSV<T>(List<T> records);
    }

    public class CSVService : ICSVService
{
    public IEnumerable<T> ReadCSV<T>(Stream file)
    {
        var reader = new StreamReader(file);
        var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        var records = csv.GetRecords<T>();
        return records;
    }

    public void WriteCSV<T>(List<T> records)
    {
        var configPersons = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
                HasHeaderRecord = false
        };
        using (var stream = File.Open("Data.csv", FileMode.Append))
        using (var writer = new StreamWriter(stream))
        using (var csv = new CsvWriter(writer, configPersons))
        {
            csv.WriteRecords(records);
        }
    }
}
}