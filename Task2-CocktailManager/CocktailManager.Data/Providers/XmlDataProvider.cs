using System.Xml.Serialization;
using CocktailManager.Domain.Entities;

namespace CocktailManager.Data.Providers
{
    public class XmlDataProvider
    {
        public List<Cocktail> Load(string filePath)
        {
            var serializer = new XmlSerializer(typeof(List<Cocktail>));

            using (var reader = new StreamReader(filePath))
            {
                return (List<Cocktail>)serializer.Deserialize(reader);
            }
        }

        public void Save(string filePath, List<Cocktail> cocktails)
        {
            var serializer = new XmlSerializer(typeof(List<Cocktail>));

            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, cocktails);
            }
        }
    }
}