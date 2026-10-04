namespace FileOperationsGenerator
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
            label1 = new Label();
            label2 = new Label();
            numFolders = new NumericUpDown();
            label3 = new Label();
            numFiles = new NumericUpDown();
            btnGenerate = new Button();
            lblStatus = new Label();
            chkTxt = new CheckBox();
            chkLog = new CheckBox();
            chkDat = new CheckBox();
            chkCsv = new CheckBox();
            label4 = new Label();
            chkReadOnly = new CheckBox();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)numFolders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numFiles).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(160, 32);
            label1.Name = "label1";
            label1.Size = new Size(450, 37);
            label1.TabIndex = 0;
            label1.Text = "ГЕНЕРАТОР ФАЙЛОВИХ ОПЕРАЦІЙ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 140);
            label2.Name = "label2";
            label2.Size = new Size(119, 20);
            label2.TabIndex = 1;
            label2.Text = "Кількість папок:";
            // 
            // numFolders
            // 
            numFolders.Location = new Point(177, 133);
            numFolders.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numFolders.Name = "numFolders";
            numFolders.Size = new Size(150, 27);
            numFolders.TabIndex = 2;
            numFolders.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 213);
            label3.Name = "label3";
            label3.Size = new Size(167, 20);
            label3.TabIndex = 3;
            label3.Text = "Файлів у кожній папці:";
            // 
            // numFiles
            // 
            numFiles.Location = new Point(226, 209);
            numFiles.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numFiles.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numFiles.Name = "numFiles";
            numFiles.Size = new Size(150, 27);
            numFiles.TabIndex = 4;
            numFiles.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(34, 275);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(167, 29);
            btnGenerate.TabIndex = 5;
            btnGenerate.Text = "Згенерувати файли";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(34, 343);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(136, 20);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Статус: очікування";
            // 
            // chkTxt
            // 
            chkTxt.AutoSize = true;
            chkTxt.Checked = true;
            chkTxt.CheckState = CheckState.Checked;
            chkTxt.Location = new Point(415, 129);
            chkTxt.Name = "chkTxt";
            chkTxt.Size = new Size(56, 24);
            chkTxt.TabIndex = 7;
            chkTxt.Text = "TXT";
            chkTxt.UseVisualStyleBackColor = true;
            // 
            // chkLog
            // 
            chkLog.AutoSize = true;
            chkLog.Checked = true;
            chkLog.CheckState = CheckState.Checked;
            chkLog.Location = new Point(415, 159);
            chkLog.Name = "chkLog";
            chkLog.Size = new Size(58, 24);
            chkLog.TabIndex = 8;
            chkLog.Text = "LOG";
            chkLog.UseVisualStyleBackColor = true;
            // 
            // chkDat
            // 
            chkDat.AutoSize = true;
            chkDat.Checked = true;
            chkDat.CheckState = CheckState.Checked;
            chkDat.Location = new Point(415, 189);
            chkDat.Name = "chkDat";
            chkDat.Size = new Size(59, 24);
            chkDat.TabIndex = 9;
            chkDat.Text = "DAT";
            chkDat.UseVisualStyleBackColor = true;
            // 
            // chkCsv
            // 
            chkCsv.AutoSize = true;
            chkCsv.Checked = true;
            chkCsv.CheckState = CheckState.Checked;
            chkCsv.Location = new Point(415, 219);
            chkCsv.Name = "chkCsv";
            chkCsv.Size = new Size(57, 24);
            chkCsv.TabIndex = 10;
            chkCsv.Text = "CSV";
            chkCsv.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(414, 92);
            label4.Name = "label4";
            label4.Size = new Size(98, 20);
            label4.TabIndex = 11;
            label4.Text = "Типи файлів:";
            // 
            // chkReadOnly
            // 
            chkReadOnly.AutoSize = true;
            chkReadOnly.Location = new Point(416, 255);
            chkReadOnly.Name = "chkReadOnly";
            chkReadOnly.Size = new Size(298, 24);
            chkReadOnly.TabIndex = 12;
            chkReadOnly.Text = "Створювати файли тільки для читання";
            chkReadOnly.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(233, 275);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 13;
            btnClear.Text = "Очистити";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClear);
            Controls.Add(chkReadOnly);
            Controls.Add(label4);
            Controls.Add(chkCsv);
            Controls.Add(chkDat);
            Controls.Add(chkLog);
            Controls.Add(chkTxt);
            Controls.Add(lblStatus);
            Controls.Add(btnGenerate);
            Controls.Add(numFiles);
            Controls.Add(label3);
            Controls.Add(numFolders);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Генератор файлових операцій";
            ((System.ComponentModel.ISupportInitialize)numFolders).EndInit();
            ((System.ComponentModel.ISupportInitialize)numFiles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private NumericUpDown numFolders;
        private Label label3;
        private NumericUpDown numFiles;
        private Button btnGenerate;
        private Label lblStatus;
        private CheckBox chkTxt;
        private CheckBox chkLog;
        private CheckBox chkDat;
        private CheckBox chkCsv;
        private Label label4;
        private CheckBox chkReadOnly;
        private Button btnClear;
    }
}
