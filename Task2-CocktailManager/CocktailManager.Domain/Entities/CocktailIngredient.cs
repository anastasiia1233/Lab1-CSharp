namespace CocktailManager.Domain.Entities
{
    public class CocktailIngredient
    {
        public int CocktailId { get; set; }
        public int IngredientId { get; set; }
        public string Measure { get; set; }
    }
}