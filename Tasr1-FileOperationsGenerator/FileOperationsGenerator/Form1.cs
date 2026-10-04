namespace FileOperationsGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                int foldersCount = (int)numFolders.Value;
                int filesCount = (int)numFiles.Value;
                bool readOnly = chkReadOnly.Checked;

                List<string> extensions = new List<string>();

                if (chkTxt.Checked)
                    extensions.Add(".txt");

                if (chkLog.Checked)
                    extensions.Add(".log");

                if (chkDat.Checked)
                    extensions.Add(".dat");

                if (chkCsv.Checked)
                    extensions.Add(".csv");

                if (extensions.Count == 0)
                {
                    lblStatus.Text = "Статус: виберіть хоча б один тип файлу.";
                    return;
                }

                FileGenerator generator = new FileGenerator();

                lblStatus.Text = "Статус: генерація...";

                generator.Generate(foldersCount, filesCount, extensions.ToArray(), readOnly);

                lblStatus.Text = $"Статус: готово! Створено папок: " + $"{generator.FoldersCount}, файлів: " + $"{generator.FilesCount}";
            }
            catch (UnauthorizedAccessException)
            {
                lblStatus.Text = "Статус: недостатньо прав для створення файлів.";
            }
            catch (IOException)
            {
                lblStatus.Text = "Статус: помилка під час роботи з файлами.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Статус: сталася помилка: " + ex.Message;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                FileGenerator generator = new FileGenerator();

                generator.Clear();

                lblStatus.Text = "Статус: тестові файли видалено.";
            }
            catch (UnauthorizedAccessException)
            {
                lblStatus.Text = "Статус: недостатньо прав для видалення файлів.";
            }
            catch (IOException)
            {
                lblStatus.Text = "Статус: помилка під час видалення файлів.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Статус: сталася помилка: " + ex.Message;
            }
        }
    }
}
