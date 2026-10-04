using ClosedXML.Excel;
using CocktailManager.Domain.Entities;

namespace CocktailManager.Data.Providers
{
    public class XlsxDataProvider
    {
        public List<Cocktail> Load(string filePath)
        {
            var cocktails = new List<Cocktail>();

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1);
                var rows = worksheet.RowsUsed();

                foreach (var row in rows.Skip(1))
                {
                    var cocktail = new Cocktail
                    {
                        Id = row.Cell(1).GetValue<int>(),
                        Name = row.Cell(2).GetValue<string>(),
                        Alcoholic = row.Cell(3).GetValue<string>(),
                        Category = row.Cell(4).GetValue<string>(),
                        GlassType = row.Cell(5).GetValue<string>(),
                        Instructions = row.Cell(6).GetValue<string>(),
                        DrinkThumbnail = row.Cell(7).GetValue<string>(),
                        Ingredients = row.Cell(8).GetValue<string>(),
                        IngredientMeasures = row.Cell(9).GetValue<string>(),
                        Text = row.Cell(10).GetValue<string>()
                    };

                    cocktails.Add(cocktail);
                }
            }

            return cocktails;
        }
        public void Save(string filePath, List<Cocktail> cocktails)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Cocktails");

                worksheet.Cell(1, 1).Value = "Id";
                worksheet.Cell(1, 2).Value = "Name";
                worksheet.Cell(1, 3).Value = "Alcoholic";
                worksheet.Cell(1, 4).Value = "Category";
                worksheet.Cell(1, 5).Value = "GlassType";
                worksheet.Cell(1, 6).Value = "Instructions";
                worksheet.Cell(1, 7).Value = "DrinkThumbnail";
                worksheet.Cell(1, 8).Value = "Ingredients";
                worksheet.Cell(1, 9).Value = "IngredientMeasures";
                worksheet.Cell(1, 10).Value = "Text";

                int row = 2;

                foreach (Cocktail cocktail in cocktails)
                {
                    worksheet.Cell(row, 1).Value = cocktail.Id;
                    worksheet.Cell(row, 2).Value = cocktail.Name;
                    worksheet.Cell(row, 3).Value = cocktail.Alcoholic;
                    worksheet.Cell(row, 4).Value = cocktail.Category;
                    worksheet.Cell(row, 5).Value = cocktail.GlassType;
                    worksheet.Cell(row, 6).Value = cocktail.Instructions;
                    worksheet.Cell(row, 7).Value = cocktail.DrinkThumbnail;
                    worksheet.Cell(row, 8).Value = cocktail.Ingredients;
                    worksheet.Cell(row, 9).Value = cocktail.IngredientMeasures;
                    worksheet.Cell(row, 10).Value = cocktail.Text;

                    row++;
                }

                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(filePath);
            }
        }
    }
}