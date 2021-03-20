using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ArturDevOps
{
    public partial class Departments : Form
    {
        public Departments()
        {
            InitializeComponent();
        }
        private Director d1;
        DB db = new DB();
        DataTable dt = new DataTable();
        private void exit_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.d1 = new Director();
            this.d1.Show();
        }
        int selected;
        bool added;
        private void Departments_Load(object sender, EventArgs e)
        {
            string command1 = "SELECT * FROM Отделы";
            added = false;
            db.readDatathroughAdapter(command1, dt);
            if (dt.Rows.Count > 0)
            {
                selected = (int)dt.Rows[0].ItemArray[0];
                textBox1.Text = dt.Rows[0].ItemArray[0].ToString();
                textBox2.Text = dt.Rows[0].ItemArray[1].ToString();
                textBox3.Text = dt.Rows[0].ItemArray[2].ToString();
            }
            else
            {
                MessageBox.Show("В базе данных нет ни одного отдела!");
            }
        }
        private void save_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            string descr = textBox3.Text;
            if (name.Replace(" ", "") == "")
            {
                MessageBox.Show("Заполните название проекта для сохранения!");
            }
            else
            {
                if (added)
                {
                    SqlCommand add1 = new SqlCommand("Insert into Отделы (Название,Краткое_описание) values('" + name + "','" + descr + "')");
                    int row = db.executeQuery(add1);
                    if (row == 1)
                    {
                        MessageBox.Show("Данные сохранены успешно!");
                    }
                    delete.Enabled = true;
                }
                else
                {
                    string query = "Update Отделы Set Название = '" + name + "', Краткое_описание = '" + descr + "' Where Код_отдела ='" + textBox1.Text + "'";
                    SqlCommand update = new SqlCommand(query);
                    int row = db.executeQuery(update);
                    if (row == 1)
                    {
                        MessageBox.Show("Данные сохранены успешно!");
                    }
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Вы уверены, что хотите удалить отдел " + textBox2.Text+ "?","Удалить отдел?",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if(dialog == DialogResult.Yes)
            {
                string query = "Delete from Отделы Where Код_отдела = '"+textBox2.Text+"'";
                SqlCommand delete1 = new SqlCommand(query);
                int row = db.executeQuery(delete1);
                if (row == 1)
                {
                    MessageBox.Show("Отдел успешно удален!");
                    string command1 = "SELECT * FROM Отделы";
                    db.readDatathroughAdapter(command1, dt);
                    if (dt.Rows.Count > 0)
                    {
                        selected = (int)dt.Rows[0].ItemArray[0];
                        textBox1.Text = dt.Rows[0].ItemArray[0].ToString();
                        textBox2.Text = dt.Rows[0].ItemArray[1].ToString();
                        textBox3.Text = dt.Rows[0].ItemArray[2].ToString();
                    }
                    else
                    {
                        MessageBox.Show("В базе данных нет ни одного отдела!");
                    }
                }
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            delete.Enabled = false;
            added = true;
            DataTable dt3 = new DataTable();
            string command1 = "SELECT * FROM Отделы";
            db.readDatathroughAdapter(command1, dt3);
            textBox1.Text = ((int)dt3.Rows[dt3.Rows.Count - 1].ItemArray[0] + 1).ToString();
            textBox2.Text = "";
            textBox3.Text = "";
            selected = (int)dt3.Rows[dt3.Rows.Count - 1].ItemArray[0] + 1;
        }

        private void left_Click(object sender, EventArgs e)
        {
            added = false;
            int reserve = selected;
            DataTable dt4 = new DataTable();
            string command6 = "SELECT * FROM Отделы";
            db.readDatathroughAdapter(command6, dt4);
            DataTable dt1 = new DataTable();
            if (dt4.Rows.Count > 0)
            {
                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    selected--;
                    string command = "SELECT * FROM Отделы WHERE Код_отдела = '" + selected.ToString() + "'";
                    db.readDatathroughAdapter(command, dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        break;
                    }
                }
            }
            if (dt1.Rows.Count > 0)
            {
                textBox1.Text = dt1.Rows[0].ItemArray[0].ToString();
                textBox2.Text = dt1.Rows[0].ItemArray[1].ToString();
                textBox3.Text = dt1.Rows[0].ItemArray[2].ToString();
                delete.Enabled = true;
            }
            else
            {
                selected=reserve;
                MessageBox.Show("Переход к указанной записи невозможен, т.к. ее нет!");
            }
        }

        private void right_Click(object sender, EventArgs e)
        {
            added = false;
            int reserve = selected;
            DataTable dt4 = new DataTable();
            string command6 = "SELECT * FROM Отделы";
            db.readDatathroughAdapter(command6, dt4);
            DataTable dt2 = new DataTable();
            if (dt4.Rows.Count > 0)
            {
                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    selected++;
                    string command = "SELECT * FROM Отделы WHERE Код_отдела = '" + selected.ToString() + "'";
                    db.readDatathroughAdapter(command, dt2);
                    if (dt2.Rows.Count > 0)
                    {
                        break;
                    }
                }
            }
            
            if (dt2.Rows.Count > 0)
            {
                textBox1.Text = dt2.Rows[0].ItemArray[0].ToString();
                textBox2.Text = dt2.Rows[0].ItemArray[1].ToString();
                textBox3.Text = dt2.Rows[0].ItemArray[2].ToString();
                delete.Enabled = true;
            }
            else
            {
                selected=reserve;
                MessageBox.Show("Переход к указанной записи невозможен, т.к. ее нет!");
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

        private void save_MouseEnter(object sender, EventArgs e)
        {
            save.Location = new Point(407, 215);
        }

        private void save_MouseLeave(object sender, EventArgs e)
        {
            save.Location = new Point(407, 230);
        }

        private void delete_MouseEnter(object sender, EventArgs e)
        {
            delete.Location = new Point(477, 215);
        }
        private void delete_MouseLeave(object sender, EventArgs e)
        {
            delete.Location = new Point(477, 230);
        }

        private void add_MouseEnter(object sender, EventArgs e)
        {
            add.Location = new Point(546, 215);
        }

        private void add_MouseLeave(object sender, EventArgs e)
        {
            add.Location = new Point(546, 230);
        }

        private void left_MouseEnter(object sender, EventArgs e)
        {
            left.Location = new Point(437, 272);
        }

        private void left_MouseLeave(object sender, EventArgs e)
        {
            left.Location = new Point(437, 287);
        }

        private void right_MouseEnter(object sender, EventArgs e)
        {
            right.Location = new Point(508, 272);
        }

        private void right_MouseLeave(object sender, EventArgs e)
        {
            right.Location = new Point(508, 287);
        }
    }
}
