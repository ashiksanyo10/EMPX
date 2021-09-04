using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.IO;
using System.Net;

namespace Win32_API
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
    {
        public static int timeout;
        private Label label1;
        private Label lblIdleTime;
		private System.ComponentModel.IContainer components;
        Thread th = null;
        private Label label2;
        private Label lblLastInput;
        double total=0;
        double lastKey;
        private Label label3;
        private TextBox TxtTotal;
        String lastKeyTime;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem idleTimeoutToolStripMenuItem;
        Logger log = null;
		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
           
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.lblIdleTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLastInput = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idleTimeoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Idle time";
            // 
            // lblIdleTime
            // 
            this.lblIdleTime.AutoSize = true;
            this.lblIdleTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdleTime.Location = new System.Drawing.Point(19, 133);
            this.lblIdleTime.Name = "lblIdleTime";
            this.lblIdleTime.Size = new System.Drawing.Size(16, 17);
            this.lblIdleTime.TabIndex = 2;
            this.lblIdleTime.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last input by user";
            // 
            // lblLastInput
            // 
            this.lblLastInput.AutoSize = true;
            this.lblLastInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastInput.Location = new System.Drawing.Point(15, 63);
            this.lblLastInput.Name = "lblLastInput";
            this.lblLastInput.Size = new System.Drawing.Size(0, 17);
            this.lblLastInput.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(251, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Total idle time (secs)";
            // 
            // TxtTotal
            // 
            this.TxtTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.Location = new System.Drawing.Point(257, 54);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.ReadOnly = true;
            this.TxtTotal.Size = new System.Drawing.Size(100, 26);
            this.TxtTotal.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(442, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.idleTimeoutToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // idleTimeoutToolStripMenuItem
            // 
            this.idleTimeoutToolStripMenuItem.Name = "idleTimeoutToolStripMenuItem";
            this.idleTimeoutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.idleTimeoutToolStripMenuItem.Text = "Idle timeout";
            this.idleTimeoutToolStripMenuItem.Click += new System.EventHandler(this.idleTimeoutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(442, 165);
            this.Controls.Add(this.TxtTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblLastInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblIdleTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Idle monitoring";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Tracking());
	    }

		private void Form1_Load(object sender, System.EventArgs e)
		{
			//listBox1.Items.Add(Win32_API.Win32.GetIdleTime().ToString());
            CheckForIllegalCrossThreadCalls = false;
            th = new Thread(new ThreadStart(CheckIdle));
            th.Start();
            lastKey = Win32.GetLastInputTime();
            lastKeyTime = DateTime.Now.ToLongTimeString();
            if (File.Exists("timeout.txt"))
                timeout = int.Parse(File.ReadAllText("timeout.txt"));

            log = new Logger();
		}

        private void CheckIdle()
        {
            while (th.IsAlive)
            {
                long secs = Environment.TickCount - Win32.GetLastInputTime();
                if (secs == 0)
                {
                    int val = int.Parse(lblIdleTime.Text);
                    if (val >= timeout)
                    {
                        log.addLog(GetIP(), val.ToString());
                    }
                    total += val;
                    lblLastInput.Text = DateTime.Now.ToString();
                }
                lblIdleTime.Text = (secs / 1000).ToString();
                TxtTotal.Text = total.ToString();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            th.Abort();
        }

        private void idleTimeoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private string GetIP()
        {
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            return addr[addr.Length - 1].ToString();
        }
	}
}
