namespace TI_1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.inputKeyTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuStripFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutDeveloper = new System.Windows.Forms.ToolStripMenuItem();
            this.InputKeyLabel = new System.Windows.Forms.Label();
            this.encryptBtn = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.textBox = new System.Windows.Forms.TextBox();
            this.decipherBtn = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputKeyTextBox
            // 
            this.inputKeyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputKeyTextBox.Location = new System.Drawing.Point(239, 63);
            this.inputKeyTextBox.Name = "inputKeyTextBox";
            this.inputKeyTextBox.ShortcutsEnabled = false;
            this.inputKeyTextBox.Size = new System.Drawing.Size(142, 30);
            this.inputKeyTextBox.TabIndex = 0;
            this.inputKeyTextBox.TextChanged += new System.EventHandler(this.inputKeyTextBox_TextChanged);
            this.inputKeyTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputKeyTextBox_KeyDown_1);
            this.inputKeyTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputKeyTextBox_KeyPress);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripFiles,
            this.AboutDeveloper});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(649, 28);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // MenuStripFiles
            // 
            this.MenuStripFiles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFile,
            this.SaveFile});
            this.MenuStripFiles.Name = "MenuStripFiles";
            this.MenuStripFiles.Size = new System.Drawing.Size(59, 24);
            this.MenuStripFiles.Text = "Файл";
            // 
            // OpenFile
            // 
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenFile.Size = new System.Drawing.Size(216, 26);
            this.OpenFile.Text = "Открыть";
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // SaveFile
            // 
            this.SaveFile.Enabled = false;
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveFile.Size = new System.Drawing.Size(216, 26);
            this.SaveFile.Text = "Сохранить";
            this.SaveFile.Click += new System.EventHandler(this.SaveFile_Click);
            // 
            // AboutDeveloper
            // 
            this.AboutDeveloper.Name = "AboutDeveloper";
            this.AboutDeveloper.Size = new System.Drawing.Size(135, 24);
            this.AboutDeveloper.Text = "О разработчике";
            this.AboutDeveloper.Click += new System.EventHandler(this.AboutDeveloper_Click);
            // 
            // InputKeyLabel
            // 
            this.InputKeyLabel.AutoSize = true;
            this.InputKeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputKeyLabel.Location = new System.Drawing.Point(27, 63);
            this.InputKeyLabel.Name = "InputKeyLabel";
            this.InputKeyLabel.Size = new System.Drawing.Size(206, 32);
            this.InputKeyLabel.TabIndex = 3;
            this.InputKeyLabel.Text = "Введите ключ:";
            // 
            // encryptBtn
            // 
            this.encryptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encryptBtn.Location = new System.Drawing.Point(42, 260);
            this.encryptBtn.Name = "encryptBtn";
            this.encryptBtn.Size = new System.Drawing.Size(222, 53);
            this.encryptBtn.TabIndex = 4;
            this.encryptBtn.Text = "Зашифровать";
            this.encryptBtn.UseVisualStyleBackColor = true;
            this.encryptBtn.Click += new System.EventHandler(this.inputKeyBtn_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            // 
            // textBox
            // 
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new System.Drawing.Point(42, 119);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ShortcutsEnabled = false;
            this.textBox.Size = new System.Drawing.Size(339, 122);
            this.textBox.TabIndex = 5;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // decipherBtn
            // 
            this.decipherBtn.Enabled = false;
            this.decipherBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decipherBtn.Location = new System.Drawing.Point(42, 339);
            this.decipherBtn.Name = "decipherBtn";
            this.decipherBtn.Size = new System.Drawing.Size(222, 53);
            this.decipherBtn.TabIndex = 6;
            this.decipherBtn.Text = "Расшифровать";
            this.decipherBtn.UseVisualStyleBackColor = true;
            this.decipherBtn.Click += new System.EventHandler(this.decipherBtn_Click);
            // 
            // comboBox
            // 
            this.comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "Метод децимаций",
            "Шифр Вижинера"});
            this.comboBox.Location = new System.Drawing.Point(421, 124);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(200, 28);
            this.comboBox.TabIndex = 7;
            this.comboBox.Click += new System.EventHandler(this.comboBox_Click);
            this.comboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(416, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "Выберите способ ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(416, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 29);
            this.label2.TabIndex = 9;
            this.label2.Text = "шифрования:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 421);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.decipherBtn);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.encryptBtn);
            this.Controls.Add(this.InputKeyLabel);
            this.Controls.Add(this.inputKeyTextBox);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "ТИ лаб. 1, вар. 6";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputKeyTextBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuStripFiles;
        private System.Windows.Forms.ToolStripMenuItem OpenFile;
        private System.Windows.Forms.ToolStripMenuItem SaveFile;
        private System.Windows.Forms.ToolStripMenuItem AboutDeveloper;
        private System.Windows.Forms.Label InputKeyLabel;
        private System.Windows.Forms.Button encryptBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button decipherBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

