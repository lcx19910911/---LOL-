using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OneRoad_TOl
{
    public partial class Form2 : Form
    {
        Form1 f1;
        public Form2(Form1 F1)
        {
            InitializeComponent();
            f1 = F1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            f1.IsTSwindowAlive = true;
            //
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, Screen.PrimaryScreen.Bounds.Height - this.Height - 25);
            //
        }

        public void SetTsMessage(string tsmsg)
        {
            this.listBox1.Items.Add(tsmsg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            f1.IsTSwindowAlive = false;
        }
    }
}
