namespace MIAPR_3
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.fakeAlertTB = new System.Windows.Forms.TextBox();
            this.skipDetectionCB = new System.Windows.Forms.TextBox();
            this.totalErrors = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(432, 36);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(734, 470);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Первая вероятность:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Вторая вероятность:";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(19, 84);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(245, 56);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(19, 196);
            this.trackBar2.Maximum = 1000;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(245, 56);
            this.trackBar2.TabIndex = 6;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(297, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Вероятность ложной тревоги:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 347);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(357, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Вероятность пропуска обнаружения:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 432);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(252, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Суммарная вероятность:";
            // 
            // fakeAlertTB
            // 
            this.fakeAlertTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fakeAlertTB.Location = new System.Drawing.Point(19, 302);
            this.fakeAlertTB.Name = "fakeAlertTB";
            this.fakeAlertTB.Size = new System.Drawing.Size(279, 30);
            this.fakeAlertTB.TabIndex = 10;
            // 
            // skipDetectionCB
            // 
            this.skipDetectionCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skipDetectionCB.Location = new System.Drawing.Point(19, 387);
            this.skipDetectionCB.Name = "skipDetectionCB";
            this.skipDetectionCB.Size = new System.Drawing.Size(279, 30);
            this.skipDetectionCB.TabIndex = 11;
            // 
            // totalErrors
            // 
            this.totalErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalErrors.Location = new System.Drawing.Point(19, 476);
            this.totalErrors.Name = "totalErrors";
            this.totalErrors.Size = new System.Drawing.Size(279, 30);
            this.totalErrors.TabIndex = 12;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(313, 84);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 30);
            this.textBox1.TabIndex = 13;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(313, 196);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 30);
            this.textBox2.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 543);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.totalErrors);
            this.Controls.Add(this.skipDetectionCB);
            this.Controls.Add(this.fakeAlertTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "MIAPR_3";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox fakeAlertTB;
        private System.Windows.Forms.TextBox skipDetectionCB;
        private System.Windows.Forms.TextBox totalErrors;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

