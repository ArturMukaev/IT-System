
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ArturDevOps
{
    public partial class Registr : Form
    {
        DB db = new DB();
        DataTable dt = new DataTable();
        public Registr()
        {
            InitializeComponent();
        }
        private Director d1;
        private SM_Director d2;
        private Otchet_worker o1;
        private HR_Form h1;
        public int worker;
        public int dep;
        private void EnterB_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;

            string command1 = "SELECT * FROM Сотрудники WHERE Логин = '" + login + "' AND Пароль = '" + password + "'";
            db.readDatathroughAdapter(command1, dt);
            if (textBox1.Text.Replace(" ","") == "" || textBox2.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Заполните все поля для входа!");
            }
            else
            {
                if (dt.Rows.Count > 0)
                {
                    switch ((int)dt.Rows[0].ItemArray[9])
                    {
                        case 1:
                            {
                                this.Hide();
                                this.d2 = new SM_Director(this);
                                this.d2.Show();
                                dep = (int)dt.Rows[0].ItemArray[1];
                                break;
                            }
                        case 2:
                            {
                                this.Hide();
                                this.o1 = new Otchet_worker(this);
                                this.o1.Show();
                                worker = (int)dt.Rows[0].ItemArray[0];
                                break;
                            }
                        case 3:
                            {
                                this.Hide();
                                this.d1 = new Director();
                                this.d1.Show();
                                break;
                            }
                        case 4:
                            {
                                this.Hide();
                                this.h1 = new HR_Form();
                                this.h1.Show();
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }

                }
                else
                {
                    MessageBox.Show("Введите правильные логин и пароль!");
                }
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        Point lastPoint;
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

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
