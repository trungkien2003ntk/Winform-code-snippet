using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#region snippet
// ----------------------------------------------       SNIPPET       ----------------------------------------------
//namespace Smooth_Painting
//{
//    public partial class Form1 : Form
//    {
//        public Form1()
//        {
//            InitializeComponent();

//            // Enable Double Buffered on panel1
//            EnableDoubleBuffered(panel1);
//            
//            // Enable Double Buffered on pictureBox1
//            EnableDoubleBuffered(pictureBox1);
//        }

//        private void EnableDoubleBuffered<T>(T control)
//        {
//            typeof(T).InvokeMember("DoubleBuffered",
//                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
//                null, control, new object[] { true });
//        }

//        private void panel1_Paint(object sender, PaintEventArgs e)
//        {
//            Graphics g = e.Graphics;

//            // Do some drawing action by using g
//        }

//        private void pictureBox1_Paint(object sender, PaintEventArgs e)
//        {
//            Graphics g = e.Graphics;

//            // Do some drawing action by using g
//        }


//        /// <summary>
//        ///     Call this function whenever you want to repaint your control (trigger the Paint event)
//        /// </summary>
//        /// <param name="control">Control to be repainted</param>
//        private void UpdatePanel(Control control)
//        {
//            control.Invalidate();
//            control.Update();
//        }
//    }
//}
#endregion snippet


#region Example
// ----------------------------------------------       EXAMPLE       ----------------------------------------------

namespace Smooth_Painting
{
    public partial class Form1 : Form
    {
        private int squareX1 = 0, 
                    squareY1 = 0,
                    squareEdge1 = 200;

        private int squareX2 = 0, 
                    squareY2 = 0,
                    squareEdge2 = 200;

        public Form1()
        {
            InitializeComponent();

            /*  Notes:
             *      To see the difference, comment/uncomment the Enable DoubleBuffered Function below
             *      
             *      P/s : PictureBox have a better performance in drawing things than panel
             */

            EnableDoubleBuffered(panel1);

            EnableDoubleBuffered(pictureBox1);
        } 

        private void EnableDoubleBuffered<T>(T control)
        {
            typeof(T).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
        }

        
        #region Panel
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            DrawSquare1(g, panel1);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Update location of square1
                squareX1 = e.X - squareEdge1 / 2;
                squareY1 = e.Y - squareEdge1 / 2;

                // Repaint square1 with new location
                UpdateControl(panel1);
            }
        }
        #endregion Panel



        #region PictureBox
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            DrawSquare2(g, pictureBox1);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Update location of square2
                squareX2 = e.X - squareEdge1 / 2;
                squareY2 = e.Y - squareEdge1 / 2;

                // Repaint square2 with new location
                UpdateControl(pictureBox1);
            }
        }
        #endregion PictureBox



        private void DrawSquare1(Graphics g, Control ctrl)
        {
            Rectangle square = new Rectangle(squareX1, squareY1, squareEdge1, squareEdge1);
            Brush brush = new SolidBrush(Color.Red);

            // Clear old drawing
            g.Clear(ctrl.BackColor);

            // Draw new
            g.FillRectangle(brush, square);
        }

        private void DrawSquare2(Graphics g, Control ctrl)
        {
            Rectangle square = new Rectangle(squareX2, squareY2, squareEdge2, squareEdge2);
            Brush brush = new SolidBrush(Color.Yellow);

            // Clear old drawing
            g.Clear(ctrl.BackColor);
            
            // Draw new
            g.FillRectangle(brush, square);
        }


        /// <summary>
        ///     Call this function whenever you want to repaint your control (trigger the Paint event)
        /// </summary>
        /// <param name="control">Control to be repainted</param>
        private void UpdateControl(Control control)
        {
            control.Invalidate();
            control.Update();
        }
    }
}
#endregion Example
