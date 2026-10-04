using System.Text.Json;
using CocktailManager.Domain.Entities;

namespace CocktailManager.Data.Providers
{
    public class JsonDataProvider
    {
        public List<Cocktail> Load(string filePath)
        {
            string json = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<Cocktail>>(json) 
                ?? new List<Cocktail>();
        }

        public void Save(string filePath, List<Cocktail> cocktails)
        {
            string json = JsonSerializer.Serialize(cocktails, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(filePath, json);
        }
    }
}
