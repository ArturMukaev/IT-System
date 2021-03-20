using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ArturDevOps
{
    public partial class Real_srok : Form
    {
        private Registr r1;
        public Real_srok(Registr _f1)
        {
            this.r1 = _f1;
            InitializeComponent();
        }
        DB db = new DB();

        private void Real_srok_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Пример: 01.01.2021";
            textBox1.ForeColor = Color.Gray;
            DataTable dt1 = new DataTable();
            string command2 = "SELECT * FROM Проекты";
            db.readDatathroughAdapter(command2, dt1);
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    comboBox1.Items.Add(dt1.Rows[i].ItemArray[1].ToString());
                }
            }
        }

        private SM_Director s1;
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.s1 = new SM_Director(r1);
            this.s1.Show();
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

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            string command = "SELECT * FROM Проекты WHERE Название = '" + comboBox1.SelectedItem.ToString() + "'";
            db.readDatathroughAdapter(command, dt2);
            string depart = dt2.Rows[0].ItemArray[0].ToString();
            DataTable dt3 = new DataTable();
            string command1 = "SELECT * FROM Задачи_отделам WHERE Проект = '" + depart + "' and Отдел = '" + this.r1.dep + "'";
            db.readDatathroughAdapter(command1, dt3);
            if (dt3.Rows.Count > 0)
            {
                textBox3.Text = dt3.Rows[0].ItemArray[2].ToString();
                DateTime dat;
                DateTime.TryParseExact(dt3.Rows[0].ItemArray[3].ToString(), "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dat);
                textBox2.Text = dat.ToShortDateString();
                DateTime date;
                if (DateTime.TryParseExact(dt3.Rows[0].ItemArray[4].ToString(), "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    textBox1.Text = date.ToShortDateString();
                }
                else
                {
                    textBox1.Text = "Пример: 01.01.2021";
                }

            }
            else
            {
                textBox3.Text = "";
                textBox2.Text = "";
                textBox1.Text = "Пример: 01.01.2021";
                textBox1.ForeColor = Color.Gray;
                MessageBox.Show("Вашему отделу еще нет задачи по данному проекту!");
                comboBox1.SelectedItem = null;
            }
        }
        private void save_Click(object sender, EventArgs e)
        {
            DateTime dt;
            if (textBox3.Text.Replace(" ", "") == "" || !DateTime.TryParseExact(textBox1.Text.Replace(" ", ""), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt) || comboBox1.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Заполните все поля для сохранения и введите дату в формате dd.MM.yyyy!");
            }
            else
            {
                DataTable dt2 = new DataTable();
                string command = "SELECT * FROM Проекты WHERE Название = '" + comboBox1.SelectedItem.ToString() + "'";
                db.readDatathroughAdapter(command, dt2);
                string depart = dt2.Rows[0].ItemArray[0].ToString();
                DataTable dt3 = new DataTable();
                string command1 = "SELECT * FROM Задачи_отделам WHERE Проект = '" + depart + "' and Отдел = '" + this.r1.dep + "'";
                db.readDatathroughAdapter(command1, dt3);
                string query = "Update Задачи_отделам Set Реальный_срок = '" + textBox1.Text + "' WHERE Проект = '" + depart + "' and Отдел = '" + this.r1.dep + "'";
                SqlCommand update = new SqlCommand(query);
                int row = db.executeQuery(update);
                if (row == 1)
                {
                    MessageBox.Show("Данные сохранены успешно!");
                }
            }
        }
        private void save_MouseEnter(object sender, EventArgs e)
        {
            save.Location = new Point(498, 172);
        }

        private void save_MouseLeave(object sender, EventArgs e)
        {
            save.Location = new Point(498, 187);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }
    }
}
