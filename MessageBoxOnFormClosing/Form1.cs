using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageBoxOnFormClosing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            
            // Version 1: easy to modify
            const string message = "Are you sure that you would like to close the form?";
            const string caption = "Form Closing";

            var result = MessageBox.Show(message, caption,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            if (result == DialogResult.No)
                e.Cancel = true;

            // Version 2: short
            //if (MessageBox.Show("Are you sure that you would like to close the form?", "Form Closing",
            //                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //    e.Cancel = true;
        }
    }
}
