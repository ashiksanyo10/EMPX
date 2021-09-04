using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Win32_API
{
    public partial class Tracking : Form
    {
        public Tracking()
        {
            InitializeComponent();
        }

        private void idleTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.MdiParent = this;
            frm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void processManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            
        }
 
    }
}
