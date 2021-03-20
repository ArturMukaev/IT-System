using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ArturDevOps
{
    public partial class Projects_tasks : Form
    {
        public Projects_tasks()
        {
            InitializeComponent();
        }
        private Director d1;
        DB db = new DB();
        int selected;
        bool added;
        private void exit_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.d1 = new Director();
            this.d1.Show();
        }
        private void Projects_tasks_Load(object sender, EventArgs e)
        {
            added = false;
            DataTable dt = new DataTable();
            string command1 = "SELECT * FROM Проекты";
            db.readDatathroughAdapter(command1, dt);
            if (dt.Rows.Count > 0)
            {
                selected = (int)dt.Rows[0].ItemArray[0];
                textBox1.Text = dt.Rows[0].ItemArray[0].ToString();
                textBox2.Text = dt.Rows[0].ItemArray[1].ToString();
                DateTime dat;
                DateTime.TryParseExact(dt.Rows[0].ItemArray[2].ToString(), "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dat);
                textBox3.Text = dat.ToShortDateString();
                DataTable dt1 = new DataTable();
                string command2 = "SELECT * FROM Отделы";
                db.readDatathroughAdapter(command2, dt1);
                if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        comboBox1.Items.Add(dt1.Rows[i].ItemArray[1].ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("В базе данных нет ни одного проекта!");
            }
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

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            string command = "SELECT * FROM Отделы WHERE Название = '" + comboBox1.SelectedItem.ToString() + "'";
            db.readDatathroughAdapter(command, dt2);
            string depart = dt2.Rows[0].ItemArray[0].ToString();
            DataTable dt3 = new DataTable();
            string command1 = "SELECT * FROM Задачи_отделам WHERE Проект = '" + textBox1.Text + "' and Отдел = '" + depart + "'";
            db.readDatathroughAdapter(command1, dt3);
            if (dt3.Rows.Count > 0)
            {
                textBox4.Text = dt3.Rows[0].ItemArray[2].ToString();
                DateTime dat;
                DateTime.TryParseExact(dt3.Rows[0].ItemArray[3].ToString(), "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dat);
                textBox5.Text = dat.ToShortDateString();
            }
            else
            {
                textBox5.Text = "";
                textBox4.Text = "";
            }

        }
        private void save1_Click(object sender, EventArgs e)
        {
            DateTime dt;
            if (textBox4.Text.Replace(" ", "") == "" || !DateTime.TryParseExact(textBox5.Text.Replace(" ",""), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt) || comboBox1.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Заполните все поля для сохранения и введите дату в формате dd.MM.yyyy!");
            }
            else
            {
                DataTable dt2 = new DataTable();
                string command = "SELECT * FROM Отделы WHERE Название = '" + comboBox1.SelectedItem.ToString() + "'";
                db.readDatathroughAdapter(command, dt2);
                string depart = dt2.Rows[0].ItemArray[0].ToString();
                DataTable dt3 = new DataTable();
                string command1 = "SELECT * FROM Задачи_отделам WHERE Проект = '" + textBox1.Text + "' and Отдел = '" + depart + "'";
                db.readDatathroughAdapter(command1, dt3);
                if (dt3.Rows.Count > 0)
                {
                    string query = "Update Задачи_отделам Set Задача_отделу = '" + textBox4.Text + "', Срок_выполнения_задачи = '" + textBox5.Text + "' Where Проект = '" + textBox1.Text + "' and Отдел = '" + depart + "'";
                    SqlCommand update = new SqlCommand(query);
                    int row = db.executeQuery(update);
                    if (row == 1)
                    {
                        MessageBox.Show("Данные сохранены успешно!");
                    }
                }
                else
                {
                    SqlCommand add1 = new SqlCommand("Insert into Задачи_отделам (Проект,Отдел,Задача_отделу,Срок_выполнения_задачи) values('" + textBox1.Text + "','" + depart + "','" + textBox4.Text + "','" + textBox5.Text + "')");
                    int row = db.executeQuery(add1);
                    if (row == 1)
                    {
                        MessageBox.Show("Данные сохранены успешно!");
                    }
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Вы уверены, что хотите удалить задачу?", "Удалить задачу?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                DataTable dt2 = new DataTable();
                string command = "SELECT * FROM Отделы WHERE Название = '" + comboBox1.SelectedItem.ToString() + "'";
                db.readDatathroughAdapter(command, dt2);
                string depart = dt2.Rows[0].ItemArray[0].ToString();
                string query = "Delete from Задачи_отделам Where Проект = '" + textBox1.Text + "' and Отдел = '" + depart + "'";
                SqlCommand delete1 = new SqlCommand(query);
                int row = db.executeQuery(delete1);
                if (row == 1)
                {
                    MessageBox.Show("Задача успешно удалена!");
                    comboBox1.SelectedItem = null;
                    textBox4.Text = "";
                    textBox5.Text = "";
                }
                else
                {
                    MessageBox.Show("Данной задачи нет в базе данных!");
                }
            }
        }
        private void save_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            string date = textBox3.Text;
            DateTime dt;
            if (name.Replace(" ", "") == "" || !DateTime.TryParseExact(date.Replace(" ", ""), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
            {
                MessageBox.Show("Заполните все поля для сохранения и введите дату в формате dd.MM.yyyy!");
            }
            else
            {
                if (added)
                {
                    SqlCommand add1 = new SqlCommand("Insert into Проекты (Название,Срок_выполнения) values('" + name + "','" + date + "')");
                    int row = db.executeQuery(add1);
                    if (row == 1)
                    {
                        MessageBox.Show("Данные сохранены успешно!");
                        added = false;
                        comboBox1.Enabled = true;
                        save1.Enabled = true;
                        delete.Enabled = true;
                        textBox4.Enabled = true;
                        textBox5.Enabled = true;
                    }
                }
                else
                {
                    string query = "Update Проекты Set Название = '" + name + "', Срок_выполнения = '" + date + "' Where Код_проекта ='" + textBox1.Text + "'";
                    SqlCommand update = new SqlCommand(query);
                    int row = db.executeQuery(update);
                    if (row == 1)
                    {
                        MessageBox.Show("Данные сохранены успешно!");
                    }
                }
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = null;
            textBox4.Text = "";
            textBox5.Text = "";
            added = true;
            comboBox1.Enabled = false;
            save1.Enabled = false;
            delete.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            DataTable dt3 = new DataTable();
            string command1 = "SELECT * FROM Проекты";
            db.readDatathroughAdapter(command1, dt3);
            textBox1.Text = ((int)dt3.Rows[dt3.Rows.Count - 1].ItemArray[0] + 1).ToString();
            textBox2.Text = "";
            textBox3.Text = "";
            selected = (int)dt3.Rows[dt3.Rows.Count - 1].ItemArray[0] + 1;
        }

        private void left_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            selected--;
            string command = "SELECT * FROM Проекты WHERE Код_проекта = '" + selected.ToString() + "'";
            db.readDatathroughAdapter(command, dt1);
            if (dt1.Rows.Count > 0)
            { 
                added = false;
                textBox1.Text = dt1.Rows[0].ItemArray[0].ToString();
                textBox2.Text = dt1.Rows[0].ItemArray[1].ToString();
                DateTime dat;
                DateTime.TryParseExact(dt1.Rows[0].ItemArray[2].ToString(), "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dat);
                textBox3.Text = dat.ToShortDateString();
                comboBox1.Enabled = true;
                save1.Enabled = true;
                delete.Enabled = true;
                comboBox1.SelectedItem = null;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox4.Text = "";
                textBox5.Text = "";
            }
            else
            {
                selected++;
                MessageBox.Show("Переход к указанной записи невозможен, т.к. ее нет!");
            }
        }

        private void right_Click(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            selected++;
            string command = "SELECT * FROM Проекты WHERE Код_проекта = '" + selected.ToString() + "'";
            db.readDatathroughAdapter(command, dt2);
            if (dt2.Rows.Count > 0)
            {
                added = false;
                textBox1.Text = dt2.Rows[0].ItemArray[0].ToString();
                textBox2.Text = dt2.Rows[0].ItemArray[1].ToString();
                DateTime dat;
                DateTime.TryParseExact(dt2.Rows[0].ItemArray[2].ToString(), "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dat);
                textBox3.Text = dat.ToShortDateString();
                comboBox1.Enabled = true;
                save1.Enabled = true;
                delete.Enabled = true;
                comboBox1.SelectedItem = null;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox4.Text = "";
                textBox5.Text = "";
            }
            else
            {
                selected--;
                MessageBox.Show("Переход к указанной записи невозможен, т.к. ее нет!");
            }
        }

        private void left_MouseEnter(object sender, EventArgs e)
        {
            left.Location = new Point(26, 250);
        }

        private void left_MouseLeave(object sender, EventArgs e)
        {
            left.Location = new Point(26, 265);
        }

        private void right_MouseEnter(object sender, EventArgs e)
        {
            right.Location = new Point(96, 250);
        }

        private void right_MouseLeave(object sender, EventArgs e)
        {
            right.Location = new Point(96, 265);
        }

        private void save_MouseEnter(object sender, EventArgs e)
        {
            save.Location = new Point(175, 250);
        }

        private void save_MouseLeave(object sender, EventArgs e)
        {
            save.Location = new Point(175, 265);
        }

        private void add_MouseEnter(object sender, EventArgs e)
        {
            add.Location = new Point(254, 250);
        }

        private void add_MouseLeave(object sender, EventArgs e)
        {
            add.Location = new Point(254, 265);
        }

        private void save1_MouseEnter(object sender, EventArgs e)
        {
            save1.Location = new Point(42, 270);
        }

        private void save1_MouseLeave(object sender, EventArgs e)
        {
            save1.Location = new Point(42, 280);
        }

        private void delete_MouseEnter(object sender, EventArgs e)
        {
            delete.Location = new Point(146, 270);
        }

        private void delete_MouseLeave(object sender, EventArgs e)
        {
            delete.Location = new Point(146, 280);
        }
    }
}
