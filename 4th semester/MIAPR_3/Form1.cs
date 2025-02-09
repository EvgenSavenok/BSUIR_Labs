using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MIAPR_3
{
    public partial class Form1 : Form
    {
        private double[] firstClassPoints, secondClassPoints;
        double mu1 = 0, mu2 = 0;
        double sigma1 = 0, sigma2 = 0;
        double PC1, PC2 = 0;
        double p1 = 0, p2 = 0;
        double falseAlarmError = 0, missingDetectingError = 0, totalClassificationError = 0;
        double x = 0, borderX = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void InitializeMeans()
        {
            mu1 = 0;
            mu2 = 0;
            sigma1 = 0; 
            sigma2 = 0;
            PC1 = 0; 
            PC2 = 0;
            p1 = 0;
            p2 = 0;
            falseAlarmError = 0;
            missingDetectingError = 0; 
            totalClassificationError = 0;
            x = 0; 
            borderX = 0;
        }
        private void fillArrays()
        {
            const int pointsCount = 10000;
            const int offset = 100;
            firstClassPoints = new double[pointsCount];
            secondClassPoints = new double[pointsCount];
            Random rand = new Random();
            for (int i = 0; i < pointsCount; i++)
            {
                firstClassPoints[i] = rand.Next(pictureBox.Width) - offset;
                secondClassPoints[i] = rand.Next(pictureBox.Width) + offset;
            }
        }
        private void CalculateMU()
        {
            for (int i = 0; i < firstClassPoints.Length; i++)
            {
                mu1 += firstClassPoints[i];
                mu2 += secondClassPoints[i];
            }
            mu1 /= firstClassPoints.Length;
            mu2 /= firstClassPoints.Length;
        }
        public void CalculateSigma()
        {
            for (int i = 0; i < firstClassPoints.Length; i++)
            {
                sigma1 += Math.Pow(firstClassPoints[i] - mu1, 2);
                sigma2 += Math.Pow(secondClassPoints[i] - mu2, 2);
            }
            sigma1 = Math.Sqrt(sigma1 / firstClassPoints.Length);
            sigma2 = Math.Sqrt(sigma2 / firstClassPoints.Length);
        }
        private void DrawGraphics(Graphics g, double[] points, double mu, double sigma, Color color, double PC, int scaleMode)
        {
            for (int x = 0; x < points.Length; x++)
            {
                double p = Math.Exp(-0.5 * Math.Pow((x - mu) / sigma, 2)) / (sigma * Math.Sqrt(2 * Math.PI));
                g.FillRectangle(new SolidBrush(color), x, pictureBox.Height - (int)(p * PC * scaleMode), 3, 3);
            }
        }
        private void CheckPC()
        {
            if (PC1 == 0)
            {
                falseAlarmError = 1;
                missingDetectingError = 0;
                totalClassificationError = 1;
            }
            else
            {
                if (PC2 == 0)
                {
                    falseAlarmError = 0;
                    missingDetectingError = 0;
                    totalClassificationError = 0;
                }
                else
                {
                    falseAlarmError /= PC1;
                    missingDetectingError /= PC1;
                }
            }
        }
        private void RecordResults()
        {
            totalClassificationError = falseAlarmError + missingDetectingError;
            fakeAlertTB.Text = falseAlarmError.ToString();
            skipDetectionCB.Text = missingDetectingError.ToString();
            totalErrors.Text = totalClassificationError.ToString();
        }
        private void CalculateErrors()
        {
            const int offset = 150;
            const double EPS = 0.001;
            x = -offset;
            p1 = 1;
            p2 = 0;
            if (PC2 != 0)
                while (p2 < p1)
                {
                    p1 = PC1 * Math.Exp(-0.5 * Math.Pow((x - mu1) / sigma1, 2)) /
                        (sigma1 * Math.Sqrt(2 * Math.PI)); 
                    p2 = PC2 * Math.Exp(-0.5 * Math.Pow((x - mu2) / sigma2, 2)) /
                        (sigma2 * Math.Sqrt(2 * Math.PI));
                    falseAlarmError += p2 * EPS;
                    x += EPS;
                }
            borderX = x;
            while (x < pictureBox.Width + 100)
            {
                p1 = Math.Exp(-0.5 * Math.Pow((x - mu1) / sigma1, 2)) /
                    (sigma1 * Math.Sqrt(2 * Math.PI));
                p2 = Math.Exp(-0.5 * Math.Pow((x - mu2) / sigma2, 2)) /
                    (sigma2 * Math.Sqrt(2 * Math.PI));
                missingDetectingError += p1 * PC1 * EPS;
                x += EPS;
            }
        }
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            const int scaleMode = 150000;
            DrawGraphics(g, firstClassPoints, mu1, sigma1, Color.Red, PC1, scaleMode);
            DrawGraphics(g, secondClassPoints, mu2, sigma2, Color.Blue, PC2, scaleMode);
            Pen pen = new Pen(Color.Green, 3);
            g.DrawLine(pen, (int)borderX, 0, (int)borderX, pictureBox.Height);
            pen.Dispose();
        }
        private void StartCalculations()
        {
            InitializeMeans();
            PC1 = double.Parse(textBox1.Text);
            PC2 = double.Parse(textBox2.Text);
            fillArrays();
            CalculateMU();
            CalculateSigma();
            CalculateErrors();
            CheckPC();
            RecordResults();
            pictureBox.Invalidate();
        }
        private void UpdateTextBoxes(System.Windows.Forms.TrackBar trackBar)
        {
            double value1 = (double)trackBar1.Value / 1000.0;
            double value2 = (double)trackBar2.Value / 1000.0;
            textBox1.Text = value1.ToString("0.000");
            textBox2.Text = value2.ToString("0.000");
            double sum = value1 + value2;
            if (sum > 1)
            {
                if (trackBar == trackBar1)
                    trackBar2.Value = trackBar2.Maximum - trackBar1.Value;
                else
                    trackBar1.Value = trackBar1.Maximum - trackBar2.Value;
                value1 = (double)trackBar1.Value / 1000.0;
                value2 = (double)trackBar2.Value / 1000.0;
                textBox1.Text = value1.ToString("0.000");
                textBox2.Text = value2.ToString("0.000");
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            UpdateTextBoxes(trackBar1);
            StartCalculations();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            UpdateTextBoxes(trackBar2);
            StartCalculations();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.Value = trackBar1.Maximum / 2;
            trackBar2.Value = trackBar2.Maximum / 2;
            textBox1.Text = "0.5";
            textBox2.Text = "0.5";
            StartCalculations();
        }
    }
}
