using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArturDevOps
{
    public partial class SM_Director : Form
    {
        private Registr r1;
        public SM_Director(Registr _f1)
        {
            this.r1 = _f1;
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private Workers_tasks w1;
        private void Workers_task_Click(object sender, EventArgs e)
        {
            this.Close();
            this.w1 = new Workers_tasks(r1);
            this.w1.Show();
        }

        Point lastPoint;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private Real_srok r2;
        private void Period_Click(object sender, EventArgs e)
        {
            this.Close();
            this.r2 = new Real_srok(r1);
            this.r2.Show();
        }
    }
}
