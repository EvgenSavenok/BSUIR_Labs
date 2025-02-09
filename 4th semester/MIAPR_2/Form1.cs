using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MIAPR_2
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private List<Point> points = null;
        private List<Point> cores = null;
        private List<List<Point>> classes;
        private List<double> maxDistances = new List<double>();
        int step = 0;
        private int kMeansIteration = 0;
        private int kMeansMaxIterations = 30;
        private int kMeansK = 0;
        bool isKMeansStarted = false;
        private List<Point> kMeansCentroids = new List<Point>();
        private List<List<Point>> kMeansClusters = new List<List<Point>>();
        public Form1()
        {
            InitializeComponent();
        }
        private Point FindNextCore()
        {
            double maxDistance = 0;
            Point nextCore = Point.Empty;
            foreach (Point point in points)
            {
                double minDistance = double.MaxValue;
                foreach (Point core in cores)
                {
                    double distance = GetDistance(point, core);
                    if (distance < minDistance)
                        minDistance = distance;
                }
                if (minDistance > maxDistance)
                {
                    maxDistance = minDistance;
                    nextCore = point;
                }
            }
            cores.Add(nextCore);
            return nextCore;
        }
        private double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
        private void GenerateRandomPoints(int count)
        {
            points.Clear();
            for (int i = 0; i < count; i++)
            {
                points.Add(new Point(random.Next(0, pictureBox1.Width), random.Next(0, pictureBox1.Height)));
            }
        }
        private void AssignPointsToClasses()
        {
            classes = new List<List<Point>>();
            foreach (Point core in cores)
            {
                classes.Add(new List<Point>());
            }
            foreach (Point point in points)
            {
                double minDistance = double.MaxValue;
                int closestCoreIndex = -1;
                for (int i = 0; i < cores.Count; i++)
                {
                    double distance = GetDistance(point, cores[i]);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestCoreIndex = i;
                    }
                }
                classes[closestCoreIndex].Add(point);
            }
        }
        private Color GetRandomColor()
        {
            Random rnd = new Random();
            return Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (points != null)
            {
                for (int i = 0; i < classes.Count; i++)
                {
                    Brush brush = new SolidBrush(GetRandomColor());
                    foreach (Point point in classes[i])
                    {
                        e.Graphics.FillEllipse(brush, point.X - 2, point.Y - 2, 4, 4);
                    }
                }
            }
            if (cores != null)
            {
                foreach (Point core in cores)
                {
                    e.Graphics.FillEllipse(Brushes.Red, core.X - 6, core.Y - 6, 12, 12);
                }
            }
            if (kMeansClusters != null)
            {
                for (int i = 0; i < kMeansClusters.Count; i++)
                {
                    Brush brush = new SolidBrush(GetRandomColor());
                    foreach (Point point in kMeansClusters[i])
                    {
                        e.Graphics.FillEllipse(brush, point.X - 2, point.Y - 2, 4, 4);
                    }
                }
            }
        }
        private void CalculateMaxDistances()
        {
            maxDistances.Clear();
            foreach (List<Point> classPoints in classes)
            {
                double maxDistance = 0;
                foreach (Point point in classPoints)
                {
                    foreach (Point core in cores)
                    {
                        double distance = GetDistance(point, core);
                        if (distance > maxDistance)
                        {
                            maxDistance = distance;
                        }
                    }
                }
                maxDistances.Add(maxDistance);
            }
        }
        private double CalculateAverageDistanceBetweenCores()
        {
            double totalDistance = 0;
            int coreCount = cores.Count;
            for (int i = 0; i < coreCount; i++)
            {
                for (int j = i + 1; j < coreCount; j++)
                {
                    totalDistance += GetDistance(cores[i], cores[j]);
                }
            }
            return totalDistance / coreCount; 
        }
        private void InitializeKMeans()
        {
            kMeansCentroids.Clear();
            kMeansK = cores.Count;
            for (int i = 0; i < kMeansK; i++)
            {
                kMeansCentroids.Add(cores[i]); 
            }
        }
        private void RunKMeans()
        {
            classes = new List<List<Point>>();
            if (kMeansIteration < kMeansMaxIterations)
            {
                kMeansClusters.Clear();
                InitializeKMeans(); 
                for (int i = 0; i < kMeansK; i++)
                {
                    kMeansClusters.Add(new List<Point>());
                }
                foreach (Point point in points)
                {
                    int closestCentroidIndex = FindClosestCentroidIndex(point);
                    kMeansClusters[closestCentroidIndex].Add(point);
                }
                for (int i = 0; i < kMeansK; i++)
                {
                    if (kMeansClusters[i].Count > 0)
                    {
                        int sumX = 0, sumY = 0;
                        foreach (Point point in kMeansClusters[i])
                        {
                            sumX += point.X;
                            sumY += point.Y;
                        }
                        cores[i] = new Point(sumX / kMeansClusters[i].Count, sumY / kMeansClusters[i].Count); // Обновляем координаты ядра
                    }
                }
                kMeansIteration++;
            }
            else
            {
                timer1.Stop();
            }
        }
        private int FindClosestCentroidIndex(Point point)
        {
            double minDistance = double.MaxValue;
            int closestCentroidIndex = -1;
            for (int i = 0; i < kMeansK; i++)
            {
                double distance = GetDistance(point, kMeansCentroids[i]);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestCentroidIndex = i;
                }
            }
            return closestCentroidIndex;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (step == 0)
            {
                points = new List<Point>();
                cores = new List<Point>();
                classes = new List<List<Point>>();
                maxDistances = new List<double>();
                int numOfPoints = Int32.Parse(textBox1.Text);
                GenerateRandomPoints(numOfPoints);
                Point firstCore = points[random.Next(points.Count)];
                cores.Add(firstCore);
                pictureBox1.Invalidate();
                step++;
            }
            else
            {
                if (!isKMeansStarted)
                {
                    Point nextCore = FindNextCore();
                    AssignPointsToClasses();
                    CalculateMaxDistances();
                    double maxMaxDistance = maxDistances.Max();
                    double averageDistance = CalculateAverageDistanceBetweenCores();

                    if (maxMaxDistance > averageDistance / 2)
                    {
                        step++;
                        pictureBox1.Invalidate();
                    }
                    else
                    {
                        isKMeansStarted = true;
                    }
                }
                else
                {
                    step++;
                    timer1.Interval = 100;
                    RunKMeans();                  
                    pictureBox1.Invalidate();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}