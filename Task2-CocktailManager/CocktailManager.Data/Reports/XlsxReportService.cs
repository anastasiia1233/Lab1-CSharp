using ClosedXML.Excel;
using CocktailManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CocktailManager.Data.Reports
{
    public class XlsxReportService
    {
        public void CreateReport(string filePath, List<Cocktail> cocktails, string categoriesPath, string alcoholicPath, string glassesPath)
        {
            using (var workbook = new XLWorkbook())
            {
                CreateSummarySheet(workbook, cocktails);
                CreateCategorySheet(workbook, cocktails);
                CreateAlcoholicSheet(workbook, cocktails);
                CreateChartsSheet(workbook, categoriesPath, alcoholicPath, glassesPath);

                workbook.SaveAs(filePath);
            }
        }

        private void CreateSummarySheet(XLWorkbook workbook, List<Cocktail> cocktails)
        {
            var worksheet = workbook.Worksheets.Add("Summary");

            worksheet.Cell(1, 1).Value = "ЗВІТ ПО КОКТЕЙЛЯХ";
            worksheet.Cell(3, 1).Value = "Показник";
            worksheet.Cell(3, 2).Value = "Значення";
            worksheet.Cell(4, 1).Value = "Кількість коктейлів";
            worksheet.Cell(4, 2).Value = cocktails.Count;
            worksheet.Cell(5, 1).Value = "Кількість категорій";
            worksheet.Cell(5, 2).Value = cocktails.Select(c => c.Category).Where(c => !string.IsNullOrWhiteSpace(c)).Distinct().Count();
            worksheet.Cell(6, 1).Value = "Кількість типів келихів";
            worksheet.Cell(6, 2).Value = cocktails.Select(c => c.GlassType).Where(c => !string.IsNullOrWhiteSpace(c)).Distinct().Count();
            worksheet.Cell(7, 1).Value = "Алкогольних коктейлів";
            worksheet.Cell(7, 2).Value = cocktails.Count(c => c.Alcoholic != null && c.Alcoholic.ToLower().Contains("alcoholic"));

            worksheet.Columns().AdjustToContents();
        }

        private void CreateCategorySheet(XLWorkbook workbook, List<Cocktail> cocktails)
        {
            var worksheet = workbook.Worksheets.Add("Categories");

            worksheet.Cell(1, 1).Value = "Категорія";
            worksheet.Cell(1, 2).Value = "Кількість";

            var categories = cocktails.GroupBy(c => c.Category).Select(g => new
            {
                Category = g.Key,
                Count = g.Count()
            }).OrderByDescending(g => g.Count).ToList();

            int row = 2;

            foreach (var category in categories)
            {
                worksheet.Cell(row, 1).Value = category.Category;
                worksheet.Cell(row, 2).Value = category.Count;
                row++;
            }

            worksheet.Columns().AdjustToContents();
        }

        private void CreateAlcoholicSheet(XLWorkbook workbook, List<Cocktail> cocktails)
        {
            var worksheet = workbook.Worksheets.Add("Alcohol");

            worksheet.Cell(1, 1).Value = "Тип";
            worksheet.Cell(1, 2).Value = "Кількість";

            var alcoholic = cocktails.GroupBy(c => c.Alcoholic).Select(g => new
            {
                Type = g.Key,
                Count = g.Count()
            }).ToList();

            int row = 2;

            foreach (var item in alcoholic)
            {
                worksheet.Cell(row, 1).Value = item.Type;
                worksheet.Cell(row, 2).Value = item.Count;
                row++;
            }

            worksheet.Columns().AdjustToContents();
        }

        private void CreateChartsSheet(XLWorkbook workbook, string categoriesPath, string alcoholicPath, string glassesPath)
        {
            var worksheet = workbook.Worksheets.Add("Charts");

            worksheet.Cell(1, 1).Value = "ГРАФІКИ";

            int currentRow = 3;

            AddChart(worksheet, categoriesPath, "Кількість коктейлів за категоріями", currentRow);

            currentRow += 25;

            AddChart(worksheet, alcoholicPath, "Алкогольні та безалкогольні коктейлі", currentRow);

            currentRow += 25;

            AddChart(worksheet, glassesPath, "Коктейлі за типами келихів", currentRow);
        }

        private void AddChart(IXLWorksheet worksheet, string imagePath, string title, int row)
        {
            worksheet.Cell(row, 1).Value = title;

            if (!File.Exists(imagePath))
            {
                worksheet.Cell(row + 1, 1).Value = "Графік не знайдено: " + imagePath;
                return;
            }

            worksheet.AddPicture(imagePath).MoveTo(worksheet.Cell(row + 1, 1)).Scale(0.6);
        }
    }
}