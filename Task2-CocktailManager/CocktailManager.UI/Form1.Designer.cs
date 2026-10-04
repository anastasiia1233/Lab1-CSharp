namespace CocktailManager.UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnOpenFile = new Button();
            dgvCocktails = new DataGridView();
            lblRows = new Label();
            lblColumns = new Label();
            lblMissing = new Label();
            txtSearch = new TextBox();
            txtName = new TextBox();
            txtGlassType = new TextBox();
            txtAlcoholic = new TextBox();
            txtCategory = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnAdd = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnExport = new Button();
            txtIngredients = new TextBox();
            label5 = new Label();
            txtInstructions = new TextBox();
            txtIngredientMeasures = new TextBox();
            jfjkfd = new Label();
            label7 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            lblPage = new Label();
            btnNext = new Button();
            btnPrevious = new Button();
            btnDataInfo = new Button();
            final = new StatusStrip();
            lblFilePath = new ToolStripStatusLabel();
            lblRecordCount = new ToolStripStatusLabel();
            lblOperationTime = new ToolStripStatusLabel();
            btnStatistics = new Button();
            btnResetFilter = new Button();
            btnFilter = new Button();
            cmbCategory = new ComboBox();
            btnSort = new Button();
            cmbSort = new ComboBox();
            btnDocxReport = new Button();
            btnXlsxReport = new Button();
            tabPage2 = new TabPage();
            btnSaveCharts = new Button();
            btnUpdateCharts = new Button();
            formsPlotGlass = new ScottPlot.WinForms.FormsPlot();
            formsPlotAlcoholic = new ScottPlot.WinForms.FormsPlot();
            formsPlotCategory = new ScottPlot.WinForms.FormsPlot();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            toolStripMenuItem6 = new ToolStripMenuItem();
            toolStripMenuItem8 = new ToolStripMenuItem();
            toolStripMenuItemRecentFiles = new ToolStripMenuItem();
            toolStripMenuItemOpenLast = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem9 = new ToolStripMenuItem();
            toolStripMenuItem10 = new ToolStripMenuItem();
            toolStripMenuItem11 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripMenuItem12 = new ToolStripMenuItem();
            toolStripMenuItem13 = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvCocktails).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            final.SuspendLayout();
            tabPage2.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnOpenFile
            // 
            btnOpenFile.ForeColor = SystemColors.MenuHighlight;
            btnOpenFile.Location = new Point(6, 23);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(134, 29);
            btnOpenFile.TabIndex = 0;
            btnOpenFile.Text = "Відкрити файл";
            btnOpenFile.UseVisualStyleBackColor = true;
            btnOpenFile.Click += btnOpenFile_Click;
            // 
            // dgvCocktails
            // 
            dgvCocktails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCocktails.Location = new Point(3, 78);
            dgvCocktails.Name = "dgvCocktails";
            dgvCocktails.RowHeadersWidth = 51;
            dgvCocktails.Size = new Size(1171, 225);
            dgvCocktails.TabIndex = 1;
            dgvCocktails.CellClick += dgvCocktails_CellClick;
            // 
            // lblRows
            // 
            lblRows.AutoSize = true;
            lblRows.Location = new Point(17, 55);
            lblRows.Name = "lblRows";
            lblRows.Size = new Size(67, 20);
            lblRows.TabIndex = 2;
            lblRows.Text = "Рядків: 0";
            // 
            // lblColumns
            // 
            lblColumns.AutoSize = true;
            lblColumns.Location = new Point(117, 55);
            lblColumns.Name = "lblColumns";
            lblColumns.Size = new Size(84, 20);
            lblColumns.TabIndex = 3;
            lblColumns.Text = "Колонок: 0";
            // 
            // lblMissing
            // 
            lblMissing.AutoSize = true;
            lblMissing.Location = new Point(245, 55);
            lblMissing.Name = "lblMissing";
            lblMissing.Size = new Size(175, 20);
            lblMissing.TabIndex = 4;
            lblMissing.Text = "Пропущених значень: 0";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(257, 22);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(153, 27);
            txtSearch.TabIndex = 5;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // txtName
            // 
            txtName.Location = new Point(17, 331);
            txtName.Name = "txtName";
            txtName.Size = new Size(255, 27);
            txtName.TabIndex = 8;
            // 
            // txtGlassType
            // 
            txtGlassType.Location = new Point(911, 331);
            txtGlassType.Name = "txtGlassType";
            txtGlassType.Size = new Size(255, 27);
            txtGlassType.TabIndex = 9;
            // 
            // txtAlcoholic
            // 
            txtAlcoholic.Location = new Point(610, 331);
            txtAlcoholic.Name = "txtAlcoholic";
            txtAlcoholic.Size = new Size(255, 27);
            txtAlcoholic.TabIndex = 10;
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(313, 331);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(255, 27);
            txtCategory.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 306);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 12;
            label1.Text = "Назва:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(313, 306);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 13;
            label2.Text = "Категорія:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(911, 308);
            label3.Name = "label3";
            label3.Size = new Size(89, 20);
            label3.TabIndex = 14;
            label3.Text = "Тип келиха:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(612, 308);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 15;
            label4.Text = "Алкоголь:";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(23, 443);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(146, 29);
            btnAdd.TabIndex = 16;
            btnAdd.Text = "Додати";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(354, 443);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(146, 29);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Видалити";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(190, 443);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(146, 29);
            btnEdit.TabIndex = 18;
            btnEdit.Text = "Редагувати";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(146, 22);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(105, 29);
            btnExport.TabIndex = 19;
            btnExport.Text = "Експорт";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // txtIngredients
            // 
            txtIngredients.Location = new Point(17, 399);
            txtIngredients.Multiline = true;
            txtIngredients.Name = "txtIngredients";
            txtIngredients.Size = new Size(255, 27);
            txtIngredients.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 376);
            label5.Name = "label5";
            label5.Size = new Size(88, 20);
            label5.TabIndex = 21;
            label5.Text = "Інгредієнти";
            // 
            // txtInstructions
            // 
            txtInstructions.Location = new Point(614, 399);
            txtInstructions.Multiline = true;
            txtInstructions.Name = "txtInstructions";
            txtInstructions.Size = new Size(552, 27);
            txtInstructions.TabIndex = 22;
            // 
            // txtIngredientMeasures
            // 
            txtIngredientMeasures.Location = new Point(313, 399);
            txtIngredientMeasures.Multiline = true;
            txtIngredientMeasures.Name = "txtIngredientMeasures";
            txtIngredientMeasures.Size = new Size(255, 27);
            txtIngredientMeasures.TabIndex = 23;
            // 
            // jfjkfd
            // 
            jfjkfd.AutoSize = true;
            jfjkfd.Location = new Point(610, 376);
            jfjkfd.Name = "jfjkfd";
            jfjkfd.Size = new Size(79, 20);
            jfjkfd.TabIndex = 24;
            jfjkfd.Text = "Інструкція";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(313, 376);
            label7.Name = "label7";
            label7.Size = new Size(130, 20);
            label7.TabIndex = 25;
            label7.Text = "Міри інгредієнтів";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(0, 31);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1182, 584);
            tabControl1.TabIndex = 26;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(lblPage);
            tabPage1.Controls.Add(btnNext);
            tabPage1.Controls.Add(btnPrevious);
            tabPage1.Controls.Add(btnDataInfo);
            tabPage1.Controls.Add(final);
            tabPage1.Controls.Add(btnStatistics);
            tabPage1.Controls.Add(btnResetFilter);
            tabPage1.Controls.Add(btnFilter);
            tabPage1.Controls.Add(cmbCategory);
            tabPage1.Controls.Add(btnSort);
            tabPage1.Controls.Add(cmbSort);
            tabPage1.Controls.Add(btnDocxReport);
            tabPage1.Controls.Add(btnXlsxReport);
            tabPage1.Controls.Add(dgvCocktails);
            tabPage1.Controls.Add(btnEdit);
            tabPage1.Controls.Add(jfjkfd);
            tabPage1.Controls.Add(btnDelete);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(btnOpenFile);
            tabPage1.Controls.Add(txtAlcoholic);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(lblRows);
            tabPage1.Controls.Add(txtIngredientMeasures);
            tabPage1.Controls.Add(lblColumns);
            tabPage1.Controls.Add(txtInstructions);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(lblMissing);
            tabPage1.Controls.Add(txtIngredients);
            tabPage1.Controls.Add(txtSearch);
            tabPage1.Controls.Add(btnExport);
            tabPage1.Controls.Add(txtName);
            tabPage1.Controls.Add(txtCategory);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(btnAdd);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(txtGlassType);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1174, 551);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Дані";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblPage
            // 
            lblPage.AutoSize = true;
            lblPage.Location = new Point(175, 488);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(105, 20);
            lblPage.TabIndex = 38;
            lblPage.Text = "Сторінка 1 з 1";
            // 
            // btnNext
            // 
            btnNext.Location = new Point(298, 484);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(94, 29);
            btnNext.TabIndex = 37;
            btnNext.Text = "Далі";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(75, 484);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(94, 29);
            btnPrevious.TabIndex = 36;
            btnPrevious.Text = "Назад";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnDataInfo
            // 
            btnDataInfo.Location = new Point(434, 484);
            btnDataInfo.Name = "btnDataInfo";
            btnDataInfo.Size = new Size(167, 29);
            btnDataInfo.TabIndex = 35;
            btnDataInfo.Text = "Інформація про дані";
            btnDataInfo.UseVisualStyleBackColor = true;
            btnDataInfo.Click += btnDataInfo_Click;
            // 
            // final
            // 
            final.ImageScalingSize = new Size(20, 20);
            final.Items.AddRange(new ToolStripItem[] { lblFilePath, lblRecordCount, lblOperationTime });
            final.Location = new Point(3, 522);
            final.Name = "final";
            final.Size = new Size(1168, 26);
            final.TabIndex = 34;
            final.Text = "ТЕСТ";
            // 
            // lblFilePath
            // 
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(48, 20);
            lblFilePath.Text = "Файл:";
            // 
            // lblRecordCount
            // 
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new Size(65, 20);
            lblRecordCount.Text = "Записів:";
            // 
            // lblOperationTime
            // 
            lblOperationTime.Name = "lblOperationTime";
            lblOperationTime.Size = new Size(78, 20);
            lblOperationTime.Text = "Операція:";
            // 
            // btnStatistics
            // 
            btnStatistics.Location = new Point(950, 444);
            btnStatistics.Name = "btnStatistics";
            btnStatistics.Size = new Size(216, 29);
            btnStatistics.TabIndex = 33;
            btnStatistics.Text = "Статистика категорій";
            btnStatistics.UseVisualStyleBackColor = true;
            btnStatistics.Click += btnStatistics_Click;
            // 
            // btnResetFilter
            // 
            btnResetFilter.Location = new Point(950, 484);
            btnResetFilter.Name = "btnResetFilter";
            btnResetFilter.Size = new Size(216, 29);
            btnResetFilter.TabIndex = 32;
            btnResetFilter.Text = "Скинути фільтр";
            btnResetFilter.UseVisualStyleBackColor = true;
            btnResetFilter.Click += btnResetFilter_Click;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(817, 484);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(108, 29);
            btnFilter.TabIndex = 31;
            btnFilter.Text = "Фільтрувати";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(730, 443);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(195, 28);
            cmbCategory.TabIndex = 30;
            // 
            // btnSort
            // 
            btnSort.Location = new Point(620, 484);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(94, 29);
            btnSort.TabIndex = 29;
            btnSort.Text = "Сортувати";
            btnSort.UseVisualStyleBackColor = true;
            btnSort.Click += btnSort_Click;
            // 
            // cmbSort
            // 
            cmbSort.FormattingEnabled = true;
            cmbSort.Location = new Point(515, 444);
            cmbSort.Name = "cmbSort";
            cmbSort.Size = new Size(199, 28);
            cmbSort.TabIndex = 28;
            // 
            // btnDocxReport
            // 
            btnDocxReport.Location = new Point(799, 23);
            btnDocxReport.Name = "btnDocxReport";
            btnDocxReport.Size = new Size(168, 29);
            btnDocxReport.TabIndex = 27;
            btnDocxReport.Text = "Створити DOCX-звіт";
            btnDocxReport.UseVisualStyleBackColor = true;
            btnDocxReport.Click += btnDocxReport_Click;
            // 
            // btnXlsxReport
            // 
            btnXlsxReport.Location = new Point(982, 23);
            btnXlsxReport.Name = "btnXlsxReport";
            btnXlsxReport.Size = new Size(163, 29);
            btnXlsxReport.TabIndex = 26;
            btnXlsxReport.Text = "Створити XLSX-звіт";
            btnXlsxReport.UseVisualStyleBackColor = true;
            btnXlsxReport.Click += btnXlsxReport_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnSaveCharts);
            tabPage2.Controls.Add(btnUpdateCharts);
            tabPage2.Controls.Add(formsPlotGlass);
            tabPage2.Controls.Add(formsPlotAlcoholic);
            tabPage2.Controls.Add(formsPlotCategory);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1174, 551);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Графіки";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSaveCharts
            // 
            btnSaveCharts.Location = new Point(821, 405);
            btnSaveCharts.Name = "btnSaveCharts";
            btnSaveCharts.Size = new Size(173, 29);
            btnSaveCharts.TabIndex = 4;
            btnSaveCharts.Text = "Зберегти графіки PNG";
            btnSaveCharts.UseVisualStyleBackColor = true;
            btnSaveCharts.Click += btnSaveCharts_Click;
            // 
            // btnUpdateCharts
            // 
            btnUpdateCharts.Location = new Point(821, 361);
            btnUpdateCharts.Name = "btnUpdateCharts";
            btnUpdateCharts.Size = new Size(173, 29);
            btnUpdateCharts.TabIndex = 3;
            btnUpdateCharts.Text = "Оновити графіки";
            btnUpdateCharts.UseVisualStyleBackColor = true;
            btnUpdateCharts.Click += btnUpdateCharts_Click;
            // 
            // formsPlotGlass
            // 
            formsPlotGlass.Location = new Point(644, 6);
            formsPlotGlass.Name = "formsPlotGlass";
            formsPlotGlass.Size = new Size(522, 272);
            formsPlotGlass.TabIndex = 2;
            // 
            // formsPlotAlcoholic
            // 
            formsPlotAlcoholic.Location = new Point(9, 281);
            formsPlotAlcoholic.Name = "formsPlotAlcoholic";
            formsPlotAlcoholic.Size = new Size(631, 248);
            formsPlotAlcoholic.TabIndex = 1;
            // 
            // formsPlotCategory
            // 
            formsPlotCategory.Location = new Point(9, 6);
            formsPlotCategory.Name = "formsPlotCategory";
            formsPlotCategory.Size = new Size(631, 269);
            formsPlotCategory.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2, toolStripMenuItem4 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1182, 28);
            menuStrip1.TabIndex = 27;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem5, toolStripMenuItem6, toolStripMenuItem8, toolStripMenuItemRecentFiles });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(59, 24);
            toolStripMenuItem1.Text = "Файл";
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(196, 26);
            toolStripMenuItem5.Text = "Відкрити";
            toolStripMenuItem5.Click += toolStripMenuItem5_Click;
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new Size(196, 26);
            toolStripMenuItem6.Text = "Зберегти як";
            toolStripMenuItem6.Click += toolStripMenuItem6_Click;
            // 
            // toolStripMenuItem8
            // 
            toolStripMenuItem8.Name = "toolStripMenuItem8";
            toolStripMenuItem8.Size = new Size(196, 26);
            toolStripMenuItem8.Text = "Вихід";
            toolStripMenuItem8.Click += toolStripMenuItem8_Click;
            // 
            // toolStripMenuItemRecentFiles
            // 
            toolStripMenuItemRecentFiles.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItemOpenLast });
            toolStripMenuItemRecentFiles.Name = "toolStripMenuItemRecentFiles";
            toolStripMenuItemRecentFiles.Size = new Size(196, 26);
            toolStripMenuItemRecentFiles.Text = "Недавні файли";
            // 
            // toolStripMenuItemOpenLast
            // 
            toolStripMenuItemOpenLast.Name = "toolStripMenuItemOpenLast";
            toolStripMenuItemOpenLast.Size = new Size(257, 26);
            toolStripMenuItemOpenLast.Text = "Відкрити останній файл";
            toolStripMenuItemOpenLast.Click += toolStripMenuItemOpenLast_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem9, toolStripMenuItem10, toolStripMenuItem11 });
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(58, 24);
            toolStripMenuItem2.Text = "Звіти";
            // 
            // toolStripMenuItem9
            // 
            toolStripMenuItem9.Name = "toolStripMenuItem9";
            toolStripMenuItem9.Size = new Size(212, 26);
            toolStripMenuItem9.Text = "XLSX-звіт";
            toolStripMenuItem9.Click += toolStripMenuItem9_Click;
            // 
            // toolStripMenuItem10
            // 
            toolStripMenuItem10.Name = "toolStripMenuItem10";
            toolStripMenuItem10.Size = new Size(212, 26);
            toolStripMenuItem10.Text = "DOCX-звіт";
            toolStripMenuItem10.Click += toolStripMenuItem10_Click;
            // 
            // toolStripMenuItem11
            // 
            toolStripMenuItem11.Name = "toolStripMenuItem11";
            toolStripMenuItem11.Size = new Size(212, 26);
            toolStripMenuItem11.Text = "Зберегти графіки";
            toolStripMenuItem11.Click += toolStripMenuItem11_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem12, toolStripMenuItem13 });
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(94, 24);
            toolStripMenuItem4.Text = "Допомога";
            // 
            // toolStripMenuItem12
            // 
            toolStripMenuItem12.Name = "toolStripMenuItem12";
            toolStripMenuItem12.Size = new Size(193, 26);
            toolStripMenuItem12.Text = "Про програму";
            toolStripMenuItem12.Click += toolStripMenuItem12_Click;
            // 
            // toolStripMenuItem13
            // 
            toolStripMenuItem13.Name = "toolStripMenuItem13";
            toolStripMenuItem13.Size = new Size(193, 26);
            toolStripMenuItem13.Text = "Довідка";
            toolStripMenuItem13.Click += toolStripMenuItem13_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 608);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            Name = "Form1";
            Text = "CocktailManager";
            ((System.ComponentModel.ISupportInitialize)dgvCocktails).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            final.ResumeLayout(false);
            final.PerformLayout();
            tabPage2.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOpenFile;
        private DataGridView dgvCocktails;
        private Label lblRows;
        private Label lblColumns;
        private Label lblMissing;
        private TextBox txtSearch;
        private TextBox txtName;
        private TextBox txtGlassType;
        private TextBox txtAlcoholic;
        private TextBox txtCategory;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnExport;
        private TextBox txtIngredients;
        private Label label5;
        private TextBox txtInstructions;
        private TextBox txtIngredientMeasures;
        private Label jfjkfd;
        private Label label7;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btnUpdateCharts;
        private ScottPlot.WinForms.FormsPlot formsPlotGlass;
        private ScottPlot.WinForms.FormsPlot formsPlotAlcoholic;
        private ScottPlot.WinForms.FormsPlot formsPlotCategory;
        private Button btnSaveCharts;
        private Button btnXlsxReport;
        private Button btnDocxReport;
        private Button btnSort;
        private ComboBox cmbSort;
        private Button btnResetFilter;
        private Button btnFilter;
        private ComboBox cmbCategory;
        private Button btnStatistics;
        private StatusStrip final;
        private ToolStripStatusLabel lblFilePath;
        private ToolStripStatusLabel lblRecordCount;
        private ToolStripStatusLabel lblOperationTime;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripMenuItem toolStripMenuItem10;
        private ToolStripMenuItem toolStripMenuItem11;
        private ToolStripMenuItem toolStripMenuItem12;
        private ToolStripMenuItem toolStripMenuItem13;
        private Button btnDataInfo;
        private ToolStripMenuItem toolStripMenuItemRecentFiles;
        private ToolStripMenuItem toolStripMenuItemOpenLast;
        private Label lblPage;
        private Button btnNext;
        private Button btnPrevious;
    }
}
