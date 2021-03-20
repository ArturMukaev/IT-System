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
    public partial class Director : Form
    {
        public Director()
        {
            InitializeComponent();
        }
        private Departments d1;
        private void redact_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.d1 = new Departments();
            this.d1.Show();
        }
        private Projects_tasks p1;
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.p1 = new Projects_tasks();
            this.p1.Show();
        }
        private Otchet_director o1;
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.o1 = new Otchet_director();
            this.o1.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}
