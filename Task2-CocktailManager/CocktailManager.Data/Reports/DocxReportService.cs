
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using CocktailManager.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CocktailManager.Data.Reports
{
    public class DocxReportService
    {
        public void CreateReport(string filePath, List<Cocktail> cocktails, string categoryChartPath, string alcoholicChartPath, string glassChartPath)
        {
            using (WordprocessingDocument document = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = document.AddMainDocumentPart();

                mainPart.Document = new Document();

                Body body = new Body();

                AddTitle(body);
                AddDatasetDescription(body, cocktails);
                AddStatistics(body, cocktails);

                AddChart(mainPart, body, categoryChartPath, "Кількість коктейлів за категоріями");
                AddChart(mainPart, body, alcoholicChartPath, "Алкогольні та безалкогольні коктейлі");
                AddChart(mainPart, body, glassChartPath, "Найпоширеніші типи келихів");

                mainPart.Document.Append(body);
                mainPart.Document.Save();
            }
        }

        private void AddTitle(Body body)
        {
            Paragraph paragraph = new Paragraph();
            ParagraphProperties properties = new ParagraphProperties();

            Justification justification = new Justification
            {
                Val = JustificationValues.Center
            };

            properties.Append(justification);
            paragraph.Append(properties);

            Run run = new Run();
            RunProperties runProperties = new RunProperties();

            runProperties.Append(new Bold());

            FontSize fontSize = new FontSize
            {
                Val = "32"
            };

            runProperties.Append(fontSize);
            run.Append(runProperties);
            run.Append(new Text("Звіт про набір даних коктейлів"));
            paragraph.Append(run);
            body.Append(paragraph);

            body.Append(new Paragraph(new Run(new Text("Лабораторна робота №1"))));
            body.Append(new Paragraph(new Run(new Text("Студентка: Толпегіна Анастасія Юріївна"))));
            body.Append(new Paragraph(new Run(new Text("Група: КН-22"))));
            body.Append(new Paragraph(new Run(new Text("Варіант: 27"))));
        }

        private void AddDatasetDescription(Body body, List<Cocktail> cocktails)
        {
            body.Append(new Paragraph(new Run(new Text("Опис набору даних"))));
            body.Append(new Paragraph(new Run(new Text("Набір даних містить інформацію " + "про коктейлі, їх категорії, " + "типи келихів, інгредієнти " + "та інструкції приготування."))));
            body.Append(new Paragraph(new Run(new Text("Кількість записів у наборі: " + cocktails.Count))));
        }

        private void AddStatistics(Body body, List<Cocktail> cocktails)
        {
            int categories = cocktails.Select(c => c.Category).Where(c => !string.IsNullOrWhiteSpace(c)).Distinct().Count();
            int glasses = cocktails.Select(c => c.GlassType).Where(c => !string.IsNullOrWhiteSpace(c)).Distinct().Count();
            int alcoholic = cocktails.Count(c => c.Alcoholic != null && c.Alcoholic.ToLower().Contains("alcoholic"));

            body.Append(new Paragraph(new Run(new Text("Основні показники"))));

            Table table = new Table();
            TableRow header = new TableRow();

            header.Append(CreateCell("Показник"));
            header.Append(CreateCell("Значення"));

            table.Append(header);

            AddTableRow(table, "Кількість коктейлів", cocktails.Count.ToString());
            AddTableRow(table, "Кількість категорій", categories.ToString());
            AddTableRow(table, "Кількість типів келихів", glasses.ToString());
            AddTableRow(table, "Алкогольних коктейлів", alcoholic.ToString());

            body.Append(table);
        }

        private void AddTableRow(Table table, string name, string value)
        {
            TableRow row = new TableRow();

            row.Append(CreateCell(name));
            row.Append(CreateCell(value));

            table.Append(row);
        }

        private TableCell CreateCell(string text)
        {
            TableCell cell = new TableCell();

            cell.Append(new Paragraph(new Run(new Text(text))));

            return cell;
        }

        private void AddChart(MainDocumentPart mainPart, Body body, string imagePath, string title)
        {
            if (!System.IO.File.Exists(imagePath))
                return;

            body.Append(new Paragraph(new Run(new Text(title))));

            ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Png);

            using (var stream = System.IO.File.OpenRead(imagePath))
            {
                imagePart.FeedData(stream);
            }

            string relationshipId = mainPart.GetIdOfPart(imagePart);

            body.Append(CreateImageParagraph(relationshipId));
        }

        private Paragraph CreateImageParagraph(string relationshipId)
        {
            var drawing = new DocumentFormat.OpenXml.Wordprocessing.Drawing(
                new DocumentFormat.OpenXml.Drawing.Wordprocessing.Inline(
                    new DocumentFormat.OpenXml.Drawing.Wordprocessing.Extent
                    {
                        Cx = 7000000,
                        Cy = 4000000
                    },
                    new DocumentFormat.OpenXml.Drawing.Wordprocessing.DocProperties
                    {
                        Id = 1,
                        Name = "Chart"
                    },
                    new DocumentFormat.OpenXml.Drawing.Graphic(
                        new DocumentFormat.OpenXml.Drawing.GraphicData(
                            new DocumentFormat.OpenXml.Drawing.Pictures.Picture(
                                new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureProperties(
                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualDrawingProperties
                                    {
                                        Id = 0,
                                        Name = "Chart"
                                    },
                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureDrawingProperties()),
                                new DocumentFormat.OpenXml.Drawing.Pictures.BlipFill(
                                    new DocumentFormat.OpenXml.Drawing.Blip
                                    {
                                        Embed = relationshipId
                                    },
                                    new DocumentFormat.OpenXml.Drawing.Stretch(
                                        new DocumentFormat.OpenXml.Drawing.FillRectangle())),
                                new DocumentFormat.OpenXml.Drawing.Pictures.ShapeProperties(
                                    new DocumentFormat.OpenXml.Drawing.Transform2D(
                                        new DocumentFormat.OpenXml.Drawing.Offset
                                        {
                                            X = 0,
                                            Y = 0
                                        },
                                        new DocumentFormat.OpenXml.Drawing.Extents
                                        {
                                            Cx = 7000000,
                                            Cy = 4000000
                                        }),
                                    new DocumentFormat.OpenXml.Drawing.PresetGeometry
                                    {
                                        Preset = DocumentFormat.OpenXml.Drawing.ShapeTypeValues.Rectangle
                                    })))
                        {
                            Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture"
                        })));

            Paragraph paragraph = new Paragraph();

            paragraph.Append(new Run(drawing));

            return paragraph;
        }
    }
}
