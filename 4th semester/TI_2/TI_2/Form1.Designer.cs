namespace TI_2
{
  partial class Form1
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openFileBtn = new System.Windows.Forms.ToolStripMenuItem();
      this.saveCipheredFile = new System.Windows.Forms.ToolStripMenuItem();
      this.saveDecipheredFile = new System.Windows.Forms.ToolStripMenuItem();
      this.clearAllFields = new System.Windows.Forms.ToolStripMenuItem();
      this.startStateTB = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.keyDataGridView = new System.Windows.Forms.DataGridView();
      this.cipherBtn = new System.Windows.Forms.Button();
      this.decipherBtn = new System.Windows.Forms.Button();
      this.getKeyBtn = new System.Windows.Forms.Button();
      this.sourceDataGrid = new System.Windows.Forms.DataGridView();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.label3 = new System.Windows.Forms.Label();
      this.cipherGrid = new System.Windows.Forms.DataGridView();
      this.label4 = new System.Windows.Forms.Label();
      this.menuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.keyDataGridView)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.sourceDataGrid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cipherGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.ToolStripMenuItem, this.clearAllFields });
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(1123, 28);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // ToolStripMenuItem
      // 
      this.ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.openFileBtn, this.saveCipheredFile, this.saveDecipheredFile });
      this.ToolStripMenuItem.Name = "ToolStripMenuItem";
      this.ToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
      this.ToolStripMenuItem.Text = "Файл";
      // 
      // openFileBtn
      // 
      this.openFileBtn.Name = "openFileBtn";
      this.openFileBtn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.openFileBtn.Size = new System.Drawing.Size(322, 24);
      this.openFileBtn.Text = "Открыть";
      this.openFileBtn.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
      // 
      // saveCipheredFile
      // 
      this.saveCipheredFile.Enabled = false;
      this.saveCipheredFile.Name = "saveCipheredFile";
      this.saveCipheredFile.Size = new System.Drawing.Size(322, 24);
      this.saveCipheredFile.Text = " Сохранить зашифрованный файл";
      this.saveCipheredFile.Click += new System.EventHandler(this.saveCipheredFile_Click);
      // 
      // saveDecipheredFile
      // 
      this.saveDecipheredFile.Enabled = false;
      this.saveDecipheredFile.Name = "saveDecipheredFile";
      this.saveDecipheredFile.Size = new System.Drawing.Size(322, 24);
      this.saveDecipheredFile.Text = "Сохранить расшифрованный файл";
      this.saveDecipheredFile.Click += new System.EventHandler(this.saveDecipheredFile_Click);
      // 
      // clearAllFields
      // 
      this.clearAllFields.Name = "clearAllFields";
      this.clearAllFields.Size = new System.Drawing.Size(123, 24);
      this.clearAllFields.Text = "Очистить поля";
      this.clearAllFields.Click += new System.EventHandler(this.ClearAllFields_Click);
      // 
      // startStateTB
      // 
      this.startStateTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.startStateTB.Location = new System.Drawing.Point(43, 80);
      this.startStateTB.MaxLength = 23;
      this.startStateTB.Name = "startStateTB";
      this.startStateTB.Size = new System.Drawing.Size(325, 34);
      this.startStateTB.TabIndex = 1;
      this.startStateTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.startStateTB_KeyPress);
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(43, 44);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(451, 33);
      this.label1.TabIndex = 2;
      this.label1.Text = "Начальное состояние регистра:";
      // 
      // label2
      // 
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(513, 135);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(100, 23);
      this.label2.TabIndex = 3;
      this.label2.Text = "Ключ:";
      // 
      // keyDataGridView
      // 
      this.keyDataGridView.AllowUserToAddRows = false;
      this.keyDataGridView.AllowUserToDeleteRows = false;
      this.keyDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
      this.keyDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
      this.keyDataGridView.BackgroundColor = System.Drawing.Color.White;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.keyDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.keyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.keyDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
      this.keyDataGridView.Location = new System.Drawing.Point(433, 183);
      this.keyDataGridView.Name = "keyDataGridView";
      this.keyDataGridView.ReadOnly = true;
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.keyDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
      this.keyDataGridView.RowTemplate.Height = 24;
      this.keyDataGridView.Size = new System.Drawing.Size(250, 275);
      this.keyDataGridView.TabIndex = 5;
      // 
      // cipherBtn
      // 
      this.cipherBtn.Enabled = false;
      this.cipherBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cipherBtn.Location = new System.Drawing.Point(43, 481);
      this.cipherBtn.Name = "cipherBtn";
      this.cipherBtn.Size = new System.Drawing.Size(253, 55);
      this.cipherBtn.TabIndex = 6;
      this.cipherBtn.Text = "Зашифровать";
      this.cipherBtn.UseVisualStyleBackColor = true;
      this.cipherBtn.Click += new System.EventHandler(this.cipherBtn_Click);
      // 
      // decipherBtn
      // 
      this.decipherBtn.Enabled = false;
      this.decipherBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.decipherBtn.Location = new System.Drawing.Point(815, 481);
      this.decipherBtn.Name = "decipherBtn";
      this.decipherBtn.Size = new System.Drawing.Size(250, 55);
      this.decipherBtn.TabIndex = 7;
      this.decipherBtn.Text = "Дешифровать";
      this.decipherBtn.UseVisualStyleBackColor = true;
      this.decipherBtn.Click += new System.EventHandler(this.decipherBtn_Click);
      // 
      // getKeyBtn
      // 
      this.getKeyBtn.Enabled = false;
      this.getKeyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.getKeyBtn.Location = new System.Drawing.Point(433, 481);
      this.getKeyBtn.Name = "getKeyBtn";
      this.getKeyBtn.Size = new System.Drawing.Size(250, 55);
      this.getKeyBtn.TabIndex = 8;
      this.getKeyBtn.Text = "Получить ключ";
      this.getKeyBtn.UseVisualStyleBackColor = true;
      this.getKeyBtn.Click += new System.EventHandler(this.getKeyBtn_Click);
      // 
      // sourceDataGrid
      // 
      this.sourceDataGrid.AllowUserToAddRows = false;
      this.sourceDataGrid.AllowUserToDeleteRows = false;
      this.sourceDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
      this.sourceDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
      this.sourceDataGrid.BackgroundColor = System.Drawing.Color.White;
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.sourceDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
      this.sourceDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.sourceDataGrid.DefaultCellStyle = dataGridViewCellStyle5;
      this.sourceDataGrid.Location = new System.Drawing.Point(43, 183);
      this.sourceDataGrid.Name = "sourceDataGrid";
      this.sourceDataGrid.ReadOnly = true;
      dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.sourceDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
      this.sourceDataGrid.RowTemplate.Height = 24;
      this.sourceDataGrid.Size = new System.Drawing.Size(253, 275);
      this.sourceDataGrid.TabIndex = 9;
      // 
      // openFileDialog
      // 
      this.openFileDialog.FileName = "openFileDialog";
      // 
      // saveFileDialog
      // 
      this.saveFileDialog.Filter = "All files (*.*)|*.*";
      // 
      // label3
      // 
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(65, 135);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(213, 30);
      this.label3.TabIndex = 10;
      this.label3.Text = "Исходный файл:";
      // 
      // cipherGrid
      // 
      this.cipherGrid.AllowUserToAddRows = false;
      this.cipherGrid.AllowUserToDeleteRows = false;
      this.cipherGrid.AllowUserToResizeRows = false;
      this.cipherGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
      this.cipherGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
      this.cipherGrid.BackgroundColor = System.Drawing.Color.White;
      dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.cipherGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
      this.cipherGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.cipherGrid.DefaultCellStyle = dataGridViewCellStyle8;
      this.cipherGrid.Location = new System.Drawing.Point(815, 183);
      this.cipherGrid.Name = "cipherGrid";
      this.cipherGrid.ReadOnly = true;
      dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.cipherGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
      this.cipherGrid.RowTemplate.Height = 24;
      this.cipherGrid.Size = new System.Drawing.Size(250, 275);
      this.cipherGrid.TabIndex = 11;
      // 
      // label4
      // 
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(798, 135);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(294, 37);
      this.label4.TabIndex = 12;
      this.label4.Text = "Зашифрованный файл:";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1123, 565);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.cipherGrid);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.sourceDataGrid);
      this.Controls.Add(this.getKeyBtn);
      this.Controls.Add(this.decipherBtn);
      this.Controls.Add(this.cipherBtn);
      this.Controls.Add(this.keyDataGridView);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.startStateTB);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "ТИ_2";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.keyDataGridView)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.sourceDataGrid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cipherGrid)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private System.Windows.Forms.ToolStripMenuItem clearAllFields;

    private System.Windows.Forms.ToolStripMenuItem saveDecipheredFile;

    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.DataGridView cipherGrid;

    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.SaveFileDialog saveFileDialog;

    private System.Windows.Forms.DataGridView sourceDataGrid;

    private System.Windows.Forms.Button getKeyBtn;

    private System.Windows.Forms.Button cipherBtn;
    private System.Windows.Forms.Button decipherBtn;

    private System.Windows.Forms.ToolStripMenuItem openFileBtn;

    private System.Windows.Forms.DataGridView keyDataGridView;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.TextBox startStateTB;
    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveCipheredFile;

    #endregion
  }
}

