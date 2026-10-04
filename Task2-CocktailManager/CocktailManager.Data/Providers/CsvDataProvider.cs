using CsvHelper;
using CsvHelper.Configuration;
using CocktailManager.Domain.Entities;
using System.Globalization;
using System.Text;

namespace CocktailManager.Data.Providers
{
    public class CsvDataProvider
    {
        public List<Cocktail> Load(string filePath)
        {
            string firstLine;

            try
            {
                using (StreamReader testReader = new StreamReader(filePath, new UTF8Encoding(false, true), true))
                {
                    firstLine = testReader.ReadLine();

                    if (string.IsNullOrWhiteSpace(firstLine))
                        throw new Exception("CSV-файл порожній.");
                }
            }
            catch (DecoderFallbackException)
            {
                throw new Exception("Не вдалося прочитати CSV-файл. Перевірте кодування файлу.");
            }

            string delimiter = DetectDelimiter(firstLine);

            if (!HasHeader(firstLine, delimiter))
                throw new Exception("У CSV-файлі не знайдено правильний рядок заголовків.");

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = delimiter,
                PrepareHeaderForMatch = args => args.Header.ToLower()
            };

            try
            {
                using (var reader = new StreamReader(filePath, new UTF8Encoding(false, true), true))
                using (var csv = new CsvReader(reader, config))
                {
                    return csv.GetRecords<Cocktail>().ToList();
                }
            }
            catch (DecoderFallbackException)
            {
                throw new Exception("Помилка кодування CSV-файлу.");
            }
            catch (CsvHelperException)
            {
                throw new Exception("Неправильний формат CSV-файлу. Перевірте роздільник та заголовки.");
            }
        }

        private string DetectDelimiter(string firstLine)
        {
            int commaCount = firstLine.Count(c => c == ',');
            int semicolonCount = firstLine.Count(c => c == ';');

            if (commaCount == 0 && semicolonCount == 0)
                throw new Exception("Не вдалося визначити роздільник CSV-файлу.");

            if (semicolonCount > commaCount)
                return ";";

            return ",";
        }

        private bool HasHeader(string firstLine, string delimiter)
        {
            string[] headers = firstLine.Split(new[] { delimiter }, StringSplitOptions.None);

            foreach (string header in headers)
            {
                string value = header.Trim().ToLower();

                if (value == "id" || value == "name" || value == "category" || value == "alcoholic" || value == "glass")
                    return true;
            }

            return false;
        }

        public void Save(string filePath, List<Cocktail> cocktails)
        {
            using (var writer = new StreamWriter(filePath, false, new UTF8Encoding(false)))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(cocktails);
            }
        }
    }
}
