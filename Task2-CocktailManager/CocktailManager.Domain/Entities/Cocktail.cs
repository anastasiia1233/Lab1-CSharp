namespace CocktailManager.Domain.Entities
{
    public class Cocktail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alcoholic { get; set; }
        public string Category { get; set; }
        public string GlassType { get; set; }
        public string Instructions { get; set; }
        public string DrinkThumbnail { get; set; }
        public string Ingredients { get; set; }
        public string IngredientMeasures { get; set; }
        public string Text { get; set; }
    }
}