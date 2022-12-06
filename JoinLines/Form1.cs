using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoinLines
{
    public partial class Form1 : Form
    {
        GraphicsPath path;
        
        Point pointStart, pointEnd;
        Point pointReset = new Point(-1, -1);

        Pen pen;
        
        bool isDrawing;

        public Form1()
        {
            InitializeComponent();

            // Init pen
            pen = new Pen(Color.Red)
            {
                // Set width
                Width = 10,

                // Set Line Join
                LineJoin = LineJoin.Round,
            };

            // Set default value for pointStart and pointEnd;
            pointStart = new Point(pointReset.X, pointReset.Y);
            pointEnd = new Point(pointReset.X, pointReset.Y);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !isDrawing) 
            {
                // Start drawing
                isDrawing = true;

                // Start new path
                path?.Dispose();
                path = new GraphicsPath();
                path.StartFigure();

                // Init start point of current line
                pointStart = e.Location;
            }

            else if (e.Button == MouseButtons.Left && isDrawing)
            {
                // Add current line to path
                path.AddLine(pointStart, pointEnd);

                // Start new line; start point of new line is end point of old line
                pointStart = pointEnd;
            }

            else if (e.Button == MouseButtons.Right && isDrawing)
            {
                // Stop drawing
                isDrawing = false;

                // Reset points
                pointStart.X = pointReset.X;
                pointStart.Y = pointReset.Y;
                pointEnd.X = pointReset.X;
                pointEnd.Y = pointReset.Y;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                pointEnd = e.Location;

                // Call Paint event of pictureBox1
                pictureBox1.Invalidate();
                pictureBox1.Update();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Clear old drawing
            g.Clear(Color.White);

            if (pointStart.X == pointReset.X)
                return;

            // Draw current line
            g.DrawLine(pen, pointStart, pointEnd);

            // Draw path
            g.DrawPath(pen, path);
        }
    }
}
