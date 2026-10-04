using CocktailManager.Data.Providers;
using CocktailManager.Domain.Entities;
using CocktailManager.Data.Reports;
using CocktailManager.Data.Logging;

namespace CocktailManager.UI
{
    public partial class Form1 : Form
    {
        private List<Cocktail> allCocktails = new List<Cocktail>();
        private List<Cocktail> displayedCocktails = new List<Cocktail>();
        private string currentFilePath = "";
        private FileLogger logger = new FileLogger();
        private int currentPage = 1;
        private int pageSize = 10;

        public Form1()
        {
            InitializeComponent();

            cmbSort.Items.Add("За назвою");
            cmbSort.Items.Add("За категорією");
            cmbSort.Items.Add("За типом келиха");
            cmbSort.Items.Add("За алкоголем");

            cmbSort.SelectedIndex = 0;

            UpdateRecentFilesMenu();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Data files|*.csv;*.json;*.xml;*.xlsx";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                OpenFile(dialog.FileName);
            }
        }

        private void OpenFile(string filePath)
        {
            try
            {
                allCocktails = LoadData(filePath);
                currentFilePath = filePath;

                SetDisplayedCocktails(allCocktails);
                LoadCategories();
                UpdateStatusBar("Файл відкрито");
                AddToRecentFiles(filePath);

                logger.Log("Файл відкрито: " + currentFilePath);
            }
            catch (Exception ex)
            {
                ShowOpenFileError(ex);
            }
        }

        private List<Cocktail> LoadData(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();

            if (extension == ".csv")
            {
                CsvDataProvider provider = new CsvDataProvider();
                return provider.Load(filePath);
            }

            if (extension == ".json")
            {
                JsonDataProvider provider = new JsonDataProvider();
                return provider.Load(filePath);
            }

            if (extension == ".xml")
            {
                XmlDataProvider provider = new XmlDataProvider();
                return provider.Load(filePath);
            }

            if (extension == ".xlsx")
            {
                XlsxDataProvider provider = new XlsxDataProvider();
                return provider.Load(filePath);
            }

            throw new Exception("Непідтримуваний формат файлу.");
        }

        private void ShowOpenFileError(Exception ex)
        {
            MessageBox.Show("Не вдалося відкрити файл:\n" + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            logger.Log("Помилка відкриття файлу: " + ex.Message);
        }

        private void ConfigureGrid()
        {
            dgvCocktails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvCocktails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCocktails.MultiSelect = false;
            dgvCocktails.ReadOnly = true;
            dgvCocktails.AllowUserToAddRows = false;

            SetColumnHeader("Id", "ID");
            SetColumnHeader("Name", "Назва");
            SetColumnHeader("Alcoholic", "Алкоголь");
            SetColumnHeader("Category", "Категорія");
            SetColumnHeader("GlassType", "Тип келиха");
            SetColumnHeader("Instructions", "Інструкція");
            SetColumnHeader("DrinkThumbnail", "Зображення");
            SetColumnHeader("Ingredients", "Інгредієнти");
            SetColumnHeader("IngredientMeasures", "Міри інгредієнтів");
            SetColumnHeader("Text", "Текст");
        }

        private void SetColumnHeader(string columnName, string headerText)
        {
            if (dgvCocktails.Columns.Contains(columnName))
                dgvCocktails.Columns[columnName].HeaderText = headerText;
        }

        private void ShowPage()
        {
            int totalPages = GetTotalPages();

            currentPage = Math.Max(1, currentPage);
            currentPage = Math.Min(currentPage, totalPages);

            lblPage.Text = "Сторінка " + currentPage + " з " + totalPages;

            btnPrevious.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;

            List<Cocktail> pageData = displayedCocktails.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            dgvCocktails.DataSource = null;
            dgvCocktails.DataSource = pageData;

            ConfigureGrid();
            UpdateStatistics();
        }

        private int GetTotalPages()
        {
            int totalPages = (int)Math.Ceiling((double)displayedCocktails.Count / pageSize);

            return totalPages == 0 ? 1 : totalPages;
        }

        private void SetDisplayedCocktails(List<Cocktail> cocktails)
        {
            displayedCocktails = cocktails;
            currentPage = 1;

            ShowPage();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage <= 1)
                return;

            currentPage--;
            ShowPage();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage >= GetTotalPages())
                return;

            currentPage++;
            ShowPage();
        }

        private void UpdateStatistics()
        {
            int rows = dgvCocktails.Rows.Count;
            int columns = dgvCocktails.Columns.Count;
            int missing = CountMissingValues();

            lblRows.Text = "Рядків: " + rows;
            lblColumns.Text = "Колонок: " + columns;
            lblMissing.Text = "Пропущених значень: " + missing;
        }

        private int CountMissingValues()
        {
            int missing = 0;

            foreach (DataGridViewRow row in dgvCocktails.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        missing++;
                    }
                }
            }

            return missing;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            IEnumerable<Cocktail> result = allCocktails;

            result = FilterByCategory(result);
            result = FilterBySearchText(result);

            SetDisplayedCocktails(result.ToList());
        }

        private IEnumerable<Cocktail> FilterByCategory(IEnumerable<Cocktail> cocktails)
        {
            if (cmbCategory.SelectedIndex <= 0)
                return cocktails;

            string category = cmbCategory.SelectedItem.ToString();

            return cocktails.Where(c => c.Category != null && c.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        }

        private IEnumerable<Cocktail> FilterBySearchText(IEnumerable<Cocktail> cocktails)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
                return cocktails;

            return cocktails.Where(c => c.Id.ToString().Contains(searchText) || (c.Name ?? "").ToLower().Contains(searchText) || (c.Alcoholic ?? "").ToLower().Contains(searchText) || (c.Category ?? "").ToLower().Contains(searchText) || (c.GlassType ?? "").ToLower().Contains(searchText) || (c.Instructions ?? "").ToLower().Contains(searchText) || (c.Ingredients ?? "").ToLower().Contains(searchText) || (c.Text ?? "").ToLower().Contains(searchText));
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (allCocktails.Count == 0)
            {
                MessageBox.Show("Спочатку відкрийте файл.");

                return;
            }

            txtSearch_TextChanged(null, null);
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            cmbCategory.SelectedIndex = 0;
            txtSearch.Clear();

            SetDisplayedCocktails(allCocktails);
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Усі категорії");

            List<string> categories = allCocktails.Select(c => c.Category).Where(c => !string.IsNullOrWhiteSpace(c)).Distinct().OrderBy(c => c).ToList();

            foreach (string category in categories)
                cmbCategory.Items.Add(category);

            cmbCategory.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateAddData())
                return;

            Cocktail cocktail = CreateCocktailFromFields();

            allCocktails.Add(cocktail);

            if (!SaveCurrentFile())
            {
                allCocktails.Remove(cocktail);
                return;
            }

            logger.Log("Додано коктейль: " + cocktail.Name);

            SetDisplayedCocktails(allCocktails);
            LoadCategories();
            ClearCocktailFields();

            MessageBox.Show("Коктейль успішно додано.");
        }

        private bool ValidateAddData()
        {
            if (!ValidateRequiredFields())
                return false;

            if (string.IsNullOrWhiteSpace(currentFilePath))
            {
                MessageBox.Show("Спочатку відкрийте файл.");

                return false;
            }

            string name = txtName.Text.Trim();

            bool alreadyExists = allCocktails.Any(c => c.Name != null && c.Name.Trim().Equals(name, StringComparison.OrdinalIgnoreCase));

            if (alreadyExists)
            {
                MessageBox.Show("Коктейль з такою назвою вже існує.");

                txtName.Focus();
                return false;
            }

            return true;
        }

        private bool ValidateRequiredFields()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введіть назву коктейлю.");

                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Введіть категорію коктейлю.");

                txtCategory.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAlcoholic.Text))
            {
                MessageBox.Show("Введіть інформацію про алкоголь.");

                txtAlcoholic.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtGlassType.Text))
            {
                MessageBox.Show("Введіть тип келиха.");

                txtGlassType.Focus();
                return false;
            }

            return true;
        }

        private Cocktail CreateCocktailFromFields()
        {
            int newId = 1;

            if (allCocktails.Count > 0)
                newId = allCocktails.Max(c => c.Id) + 1;

            return new Cocktail
            {
                Id = newId,
                Name = txtName.Text.Trim(),
                Category = txtCategory.Text.Trim(),
                Alcoholic = txtAlcoholic.Text.Trim(),
                GlassType = txtGlassType.Text.Trim(),
                Instructions = txtInstructions.Text.Trim(),
                DrinkThumbnail = "",
                Ingredients = txtIngredients.Text.Trim(),
                IngredientMeasures = txtIngredientMeasures.Text.Trim(),
                Text = ""
            };
        }

        private void ClearCocktailFields()
        {
            txtName.Clear();
            txtCategory.Clear();
            txtAlcoholic.Clear();
            txtGlassType.Clear();
            txtIngredients.Clear();
            txtIngredientMeasures.Clear();
            txtInstructions.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Cocktail selectedCocktail = GetSelectedCocktail();

            if (selectedCocktail == null)
                return;

            if (string.IsNullOrWhiteSpace(currentFilePath))
            {
                MessageBox.Show("Спочатку відкрийте файл.");

                return;
            }

            DialogResult result = MessageBox.Show("Видалити вибраний коктейль?", "Підтвердження", MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes)
                return;

            DeleteCocktail(selectedCocktail);
        }

        private Cocktail GetSelectedCocktail()
        {
            if (dgvCocktails.CurrentRow == null)
            {
                MessageBox.Show("Виберіть коктейль.");

                return null;
            }

            Cocktail selectedCocktail = dgvCocktails.CurrentRow.DataBoundItem as Cocktail;

            if (selectedCocktail == null)
            {
                MessageBox.Show("Не вдалося визначити вибраний коктейль.");
            }

            return selectedCocktail;
        }

        private void DeleteCocktail(Cocktail selectedCocktail)
        {
            int index = allCocktails.IndexOf(selectedCocktail);

            allCocktails.Remove(selectedCocktail);

            if (!SaveCurrentFile())
            {
                allCocktails.Insert(index, selectedCocktail);

                return;
            }

            logger.Log("Видалено коктейль: " + selectedCocktail.Name);

            SetDisplayedCocktails(allCocktails);
            LoadCategories();

            MessageBox.Show("Коктейль успішно видалено.");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Cocktail selectedCocktail = GetSelectedCocktail();

            if (selectedCocktail == null)
                return;

            if (string.IsNullOrWhiteSpace(currentFilePath))
            {
                MessageBox.Show("Спочатку відкрийте файл.");

                return;
            }

            if (!ValidateRequiredFields())
                return;

            if (IsDuplicateName(selectedCocktail.Id, txtName.Text.Trim()))
            {
                MessageBox.Show("Коктейль з такою назвою вже існує.");

                return;
            }

            EditCocktail(selectedCocktail);
        }

        private bool IsDuplicateName(int selectedId, string name)
        {
            return allCocktails.Any(c => c.Id != selectedId && c.Name != null && c.Name.Trim().Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        private void EditCocktail(Cocktail selectedCocktail)
        {
            Cocktail oldCocktail = CopyCocktail(selectedCocktail);

            UpdateCocktailFields(selectedCocktail);

            if (!SaveCurrentFile())
            {
                RestoreCocktail(selectedCocktail, oldCocktail);

                return;
            }

            logger.Log("Змінено коктейль: " + selectedCocktail.Name);

            SetDisplayedCocktails(allCocktails);
            LoadCategories();

            MessageBox.Show("Коктейль успішно змінено.");
        }

        private Cocktail CopyCocktail(Cocktail cocktail)
        {
            return new Cocktail
            {
                Id = cocktail.Id,
                Name = cocktail.Name,
                Category = cocktail.Category,
                Alcoholic = cocktail.Alcoholic,
                GlassType = cocktail.GlassType,
                Instructions = cocktail.Instructions,
                DrinkThumbnail = cocktail.DrinkThumbnail,
                Ingredients = cocktail.Ingredients,
                IngredientMeasures = cocktail.IngredientMeasures,
                Text = cocktail.Text
            };
        }

        private void UpdateCocktailFields(Cocktail cocktail)
        {
            cocktail.Name = txtName.Text.Trim();
            cocktail.Category = txtCategory.Text.Trim();
            cocktail.Alcoholic = txtAlcoholic.Text.Trim();
            cocktail.GlassType = txtGlassType.Text.Trim();
            cocktail.Ingredients = txtIngredients.Text.Trim();
            cocktail.IngredientMeasures = txtIngredientMeasures.Text.Trim();
            cocktail.Instructions = txtInstructions.Text.Trim();
        }

        private void RestoreCocktail(Cocktail target, Cocktail source)
        {
            target.Name = source.Name;
            target.Category = source.Category;
            target.Alcoholic = source.Alcoholic;
            target.GlassType = source.GlassType;
            target.Instructions = source.Instructions;
            target.DrinkThumbnail = source.DrinkThumbnail;
            target.Ingredients = source.Ingredients;
            target.IngredientMeasures = source.IngredientMeasures;
            target.Text = source.Text;
        }

        private void dgvCocktails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            Cocktail selectedCocktail = dgvCocktails.Rows[e.RowIndex].DataBoundItem as Cocktail;

            if (selectedCocktail == null)
                return;

            txtName.Text = selectedCocktail.Name;
            txtCategory.Text = selectedCocktail.Category;
            txtAlcoholic.Text = selectedCocktail.Alcoholic;
            txtGlassType.Text = selectedCocktail.GlassType;
            txtIngredients.Text = selectedCocktail.Ingredients;
            txtIngredientMeasures.Text = selectedCocktail.IngredientMeasures;
            txtInstructions.Text = selectedCocktail.Instructions;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (allCocktails.Count == 0)
            {
                MessageBox.Show("Немає даних для експорту.");

                return;
            }

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSV files|*.csv|" + "JSON files|*.json|" + "XML files|*.xml|" + "Excel files|*.xlsx";
                dialog.Title = "Експорт даних";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                ExportData(dialog.FileName);
            }
        }

        private void ExportData(string filePath)
        {
            try
            {
                SaveDataByExtension(filePath, allCocktails);

                logger.Log("Файл експортовано: " + filePath);

                MessageBox.Show("Дані успішно експортовано.", "Експорт", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                logger.Log("Помилка експорту: " + ex.Message);

                MessageBox.Show("Не вдалося експортувати дані.\n\n" + "Причина: " + ex.Message, "Помилка експорту", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveDataByExtension(string filePath, List<Cocktail> cocktails)
        {
            string extension = Path.GetExtension(filePath).ToLower();

            if (extension == ".csv")
            {
                CsvDataProvider provider = new CsvDataProvider();

                provider.Save(filePath, cocktails);
                return;
            }

            if (extension == ".json")
            {
                JsonDataProvider provider = new JsonDataProvider();

                provider.Save(filePath, cocktails);
                return;
            }

            if (extension == ".xml")
            {
                XmlDataProvider provider = new XmlDataProvider();

                provider.Save(filePath, cocktails);
                return;
            }

            if (extension == ".xlsx")
            {
                XlsxDataProvider provider = new XlsxDataProvider();

                provider.Save(filePath, cocktails);
                return;
            }

            throw new Exception("Непідтримуваний формат файлу.");
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (allCocktails.Count == 0)
            {
                MessageBox.Show("Спочатку відкрийте файл.");

                return;
            }

            List<Cocktail> sortedCocktails = GetSortedCocktails();

            SetDisplayedCocktails(sortedCocktails);
        }

        private List<Cocktail> GetSortedCocktails()
        {
            if (cmbSort.SelectedIndex == 0)
            {
                return allCocktails.OrderBy(c => c.Name).ToList();
            }

            if (cmbSort.SelectedIndex == 1)
            {
                return allCocktails.OrderBy(c => c.Category).ToList();
            }

            if (cmbSort.SelectedIndex == 2)
            {
                return allCocktails.OrderBy(c => c.GlassType).ToList();
            }

            return allCocktails.OrderBy(c => c.Alcoholic).ToList();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            if (allCocktails.Count == 0)
            {
                MessageBox.Show("Спочатку відкрийте файл.");

                return;
            }

            var statistics = allCocktails.GroupBy(c => c.Category).Select(g => new
            {
                Category = g.Key,
                Count = g.Count()
            }).OrderByDescending(g => g.Count).ToList();

            ShowCategoryStatistics(statistics);
        }

        private void ShowCategoryStatistics(IEnumerable<dynamic> statistics)
        {
            string result = "Статистика за категоріями:\n\n";

            foreach (var item in statistics)
            {
                result += item.Category + ": " + item.Count + "\n";
            }

            MessageBox.Show(result);
        }

        private void btnUpdateCharts_Click(object sender, EventArgs e)
        {
            SetDisplayedCocktails(allCocktails);
            UpdateCharts();
        }

        private void UpdateCharts()
        {
            if (allCocktails.Count == 0)
                return;

            UpdateCategoryChart();
            UpdateAlcoholicChart();
            UpdateGlassChart();
        }

        private void UpdateCategoryChart()
        {
            var categories = allCocktails.GroupBy(c => c.Category).Select(g => new
            {
                Name = g.Key,
                Count = g.Count()
            }).ToList();

            UpdateChart(formsPlotCategory, categories.Select(c => (double)c.Count).ToArray(), categories.Select(c => c.Name).ToArray(), "Кількість коктейлів за категоріями");
        }

        private void UpdateAlcoholicChart()
        {
            var alcoholic = allCocktails.GroupBy(c => c.Alcoholic).Select(g => new
            {
                Name = g.Key,
                Count = g.Count()
            }).ToList();

            UpdateChart(formsPlotAlcoholic, alcoholic.Select(c => (double)c.Count).ToArray(), alcoholic.Select(c => c.Name).ToArray(), "Алкогольні та безалкогольні коктейлі");
        }

        private void UpdateGlassChart()
        {
            var glasses = allCocktails.GroupBy(c => c.GlassType).Select(g => new
            {
                Name = g.Key,
                Count = g.Count()
            }).OrderByDescending(g => g.Count).Take(10).ToList();

            UpdateChart(formsPlotGlass, glasses.Select(c => (double)c.Count).ToArray(), glasses.Select(c => c.Name).ToArray(), "Найпоширеніші типи келихів");
        }

        private void UpdateChart(ScottPlot.WinForms.FormsPlot plot, double[] values, string[] labels, string title)
        {
            plot.Plot.Clear();

            var bars = plot.Plot.Add.Bars(values);

            for (int i = 0; i < bars.Bars.Count; i++)
                bars.Bars[i].Label = labels[i];

            plot.Plot.Title(title);
            plot.Plot.Axes.Margins(0.05, 0);
            plot.Refresh();
        }

        private void btnSaveCharts_Click(object sender, EventArgs e)
        {
            if (allCocktails.Count == 0)
            {
                MessageBox.Show("Немає даних для збереження графіків.");

                return;
            }

            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Виберіть папку для збереження графіків";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                SaveCharts(dialog.SelectedPath);

                MessageBox.Show("Графіки успішно збережено у PNG.");
            }
        }

        private void SaveCharts(string folder)
        {
            formsPlotCategory.Plot.SavePng(Path.Combine(folder, "categories.png"), 800, 500);
            formsPlotAlcoholic.Plot.SavePng(Path.Combine(folder, "alcoholic.png"), 800, 500);
            formsPlotGlass.Plot.SavePng(Path.Combine(folder, "glasses.png"), 800, 500);
        }

        private void btnXlsxReport_Click(object sender, EventArgs e)
        {
            if (allCocktails.Count == 0)
            {
                MessageBox.Show("Немає даних для створення звіту.");

                return;
            }

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Excel files|*.xlsx";
                dialog.Title = "Зберегти XLSX-звіт";
                dialog.FileName = "CocktailReport.xlsx";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                CreateXlsxReport(dialog.FileName);
            }
        }

        private void CreateXlsxReport(string filePath)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Оберіть папку з PNG-графіками";

                if (folderDialog.ShowDialog() != DialogResult.OK)
                    return;

                string folder = folderDialog.SelectedPath;
                string categoriesPath = Path.Combine(folder, "categories.png");
                string alcoholicPath = Path.Combine(folder, "alcoholic.png");
                string glassesPath = Path.Combine(folder, "glasses.png");

                try
                {
                    XlsxReportService service = new XlsxReportService();

                    service.CreateReport(filePath, allCocktails, categoriesPath, alcoholicPath, glassesPath);

                    MessageBox.Show("XLSX-звіт успішно створено.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка створення звіту: " + ex.Message);
                }
            }
        }

        private void btnDocxReport_Click(object sender, EventArgs e)
        {
            if (allCocktails.Count == 0)
            {
                MessageBox.Show("Немає даних для створення звіту.");

                return;
            }

            string folder = SelectChartsFolder();

            if (folder == null)
                return;

            if (!AreChartsAvailable(folder))
                return;

            string filePath = SelectDocxFile();

            if (filePath == null)
                return;

            CreateDocxReport(filePath, folder);
        }

        private string SelectChartsFolder()
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Виберіть папку, де знаходяться PNG-графіки";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return null;

                return dialog.SelectedPath;
            }
        }

        private bool AreChartsAvailable(string folder)
        {
            string categoryChart = Path.Combine(folder, "categories.png");
            string alcoholicChart = Path.Combine(folder, "alcoholic.png");
            string glassChart = Path.Combine(folder, "glasses.png");

            if (File.Exists(categoryChart) && File.Exists(alcoholicChart) && File.Exists(glassChart))
            {
                return true;
            }

            MessageBox.Show("У вибраній папці повинні знаходитися:\n" + "categories.png\n" + "alcoholic.png\n" + "glasses.png");

            return false;
        }

        private string SelectDocxFile()
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Word files|*.docx";
                dialog.Title = "Зберегти DOCX-звіт";
                dialog.FileName = "CocktailReport.docx";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return null;

                return dialog.FileName;
            }
        }

        private void CreateDocxReport(string filePath, string folder)
        {
            try
            {
                DocxReportService service = new DocxReportService();

                service.CreateReport(filePath, allCocktails, Path.Combine(folder, "categories.png"), Path.Combine(folder, "alcoholic.png"), Path.Combine(folder, "glasses.png"));

                MessageBox.Show("DOCX-звіт успішно створено.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка створення DOCX-звіту:\n" + ex.Message);
            }
        }

        private bool IsFileLocked(string filePath)
        {
            if (!File.Exists(filePath))
                return false;

            try
            {
                using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                }

                return false;
            }
            catch (IOException)
            {
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }

        private bool SaveCurrentFile()
        {
            if (string.IsNullOrEmpty(currentFilePath))
                return false;

            if (IsFileLocked(currentFilePath))
                return ShowLockedFileMessage();

            try
            {
                SaveDataByExtension(currentFilePath, allCocktails);

                logger.Log("Файл збережено: " + currentFilePath);

                return true;
            }
            catch (Exception ex)
            {
                ShowSaveError(ex);
                return false;
            }
        }

        private bool ShowLockedFileMessage()
        {
            MessageBox.Show("Файл відкритий в іншій програмі. " + "Закрийте файл і повторіть операцію.", "Файл заблокований", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            logger.Log("Файл заблокований: " + currentFilePath);

            return false;
        }

        private void ShowSaveError(Exception ex)
        {
            logger.Log("Помилка збереження файлу: " + ex.Message);

            MessageBox.Show("Не вдалося зберегти файл.\n\n" + "Можливо, файл відкритий в іншій програмі " + "або недоступний для запису.\n\n" + "Причина: " + ex.Message, "Помилка збереження", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void UpdateStatusBar(string operation)
        {
            lblFilePath.Text = "Файл: " + currentFilePath;
            lblRecordCount.Text = "Записів: " + allCocktails.Count;
            lblOperationTime.Text = "Операція: " + operation + " | " + DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnDataInfo_Click(object sender, EventArgs e)
        {
            if (allCocktails.Count == 0)
            {
                MessageBox.Show("Спочатку відкрийте файл.");

                return;
            }

            string result = BuildDataInfo();

            MessageBox.Show(result, "Інформація про дані", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string BuildDataInfo()
        {
            int previewCount = Math.Min(10, allCocktails.Count);

            string result = "Інформація про дані\n\n" + "Кількість рядків: " + allCocktails.Count + "\n" + "Кількість колонок: " + dgvCocktails.Columns.Count + "\n\n" + "Перші " + previewCount + " записів:\n\n";

            for (int i = 0; i < previewCount; i++)
            {
                Cocktail cocktail = allCocktails[i];

                result += (i + 1) + ". " + cocktail.Name + " | " + cocktail.Category + " | " + cocktail.Alcoholic + "\n";
            }

            return result + GetFieldTypes();
        }

        private string GetFieldTypes()
        {
            return "\nТипи полів:\n" + "Id → Int32\n" + "Name → String\n" + "Alcoholic → String\n" + "Category → String\n" + "GlassType → String\n" + "Instructions → String\n" + "DrinkThumbnail → String\n" + "Ingredients → String\n" + "IngredientMeasures → String\n" + "Text → String\n";
        }

        private void AddToRecentFiles(string filePath)
        {
            List<string> recentFiles = GetRecentFiles();

            recentFiles.Remove(filePath);
            recentFiles.Insert(0, filePath);

            if (recentFiles.Count > 10)
                recentFiles.RemoveAt(10);

            Properties.Settings.Default.RecentFiles = string.Join(Environment.NewLine, recentFiles);
            Properties.Settings.Default.Save();

            UpdateRecentFilesMenu();
        }

        private List<string> GetRecentFiles()
        {
            string value = Properties.Settings.Default.RecentFiles;

            if (string.IsNullOrWhiteSpace(value))
                return new List<string>();

            return value.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        private void UpdateRecentFilesMenu()
        {
            toolStripMenuItemRecentFiles.DropDownItems.Clear();

            List<string> recentFiles = GetRecentFiles();

            if (recentFiles.Count == 0)
            {
                ToolStripMenuItem emptyItem = new ToolStripMenuItem("Немає недавніх файлів");

                emptyItem.Enabled = false;

                toolStripMenuItemRecentFiles.DropDownItems.Add(emptyItem);

                return;
            }

            foreach (string filePath in recentFiles)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(filePath);

                item.Click += RecentFile_Click;

                toolStripMenuItemRecentFiles.DropDownItems.Add(item);
            }
        }

        private void RecentFile_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            if (item == null)
                return;

            string filePath = item.Text;

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Файл більше не існує:\n" + filePath, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            OpenFile(filePath);
        }

        private void OpenLastFile()
        {
            List<string> recentFiles = GetRecentFiles();

            if (recentFiles.Count == 0)
            {
                MessageBox.Show("Недавніх файлів немає.");

                return;
            }

            string filePath = recentFiles[0];

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Останній файл більше не існує:\n" + filePath, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            OpenFile(filePath);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            btnOpenFile_Click(sender, e);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            btnExport_Click(sender, e);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            btnXlsxReport_Click(sender, e);
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            btnDocxReport_Click(sender, e);
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            btnSaveCharts_Click(sender, e);
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Відкрийте файл через меню «Файл → Відкрити» " + "або кнопку «Відкрити файл».\n\n" + "Для пошуку використовуйте поле пошуку.\n" + "Для фільтрації виберіть категорію.\n" + "Для додавання, редагування та видалення " + "використовуйте відповідні кнопки.\n" + "Звіти та графіки доступні в меню «Звіти».", "Довідка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cocktail Manager\n\n" + "Програма для роботи з даними про коктейлі.\n" + "Підтримуються формати CSV, JSON, XML та XLSX.", "Про програму", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripMenuItemOpenLast_Click(object sender, EventArgs e)
        {
            OpenLastFile();
        }
    }
}
