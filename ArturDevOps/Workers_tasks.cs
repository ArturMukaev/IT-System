using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ArturDevOps
{
    public partial class Workers_tasks : Form
    {
        private Registr r1;
        public Workers_tasks(Registr _f1)
        {
            this.r1 = _f1;
            InitializeComponent();
        }
        DB db = new DB();
        int proj = 0;
        int worker;

        private void Workers_tasks_Load(object sender, EventArgs e)
        {
            comboBox3.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            delete.Enabled = false;
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
            DataTable dt2 = new DataTable();
            string command1 = "SELECT * FROM Сотрудники Where Роль = '2' and Отдел = '" + this.r1.dep + "'";
            db.readDatathroughAdapter(command1, dt2);
            if (dt2.Rows.Count > 0)
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    string[] arr = { dt2.Rows[i].ItemArray[2].ToString().Replace(" ", ""), dt2.Rows[i].ItemArray[3].ToString().Replace(" ", ""), dt2.Rows[i].ItemArray[4].ToString().Replace(" ", "") };
                    string all = string.Join("_", arr);
                    comboBox2.Items.Add(all);
                }
            }
            DataTable dt3 = new DataTable();
            string command3 = "SELECT * FROM Статусы";
            db.readDatathroughAdapter(command3, dt3);
            if (dt3.Rows.Count > 0)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    comboBox3.Items.Add(dt3.Rows[i].ItemArray[1].ToString().Replace(" ", ""));
                }
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
        private SM_Director s1;
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.s1 = new SM_Director(r1);
            this.s1.Show();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            textBox2.Text = "";
            textBox3.Text = "";
            delete.Enabled = false;
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Сначало выберите проект!");
                comboBox2.SelectedItem = null;
            }
            else
            {
                comboBox3.SelectedItem = null; ;
                textBox2.Text = "";
                textBox3.Text = "";
                DataTable dt1 = new DataTable();
                string command2 = "SELECT * FROM Проекты Where Название = '" + comboBox1.Text + "'";
                db.readDatathroughAdapter(command2, dt1);
                if (dt1.Rows.Count > 0)
                { proj = (int)dt1.Rows[0].ItemArray[0]; }
                comboBox3.Enabled = true;
                delete.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                string[] mass = comboBox2.SelectedItem.ToString().Split('_');
                string secname = mass[0];
                string name = mass[1];
                string thirdname = mass[2];
                DataTable dt3 = new DataTable();
                string command3 = "SELECT * FROM Сотрудники Where Роль = '2' and Отдел = '" + this.r1.dep + "' and Фамилия = '" + secname + "' and Имя = '" + name + "' and Отчество = '" + thirdname + "'";
                db.readDatathroughAdapter(command3, dt3);
                if (dt3.Rows.Count > 0)
                {
                    worker = (int)dt3.Rows[0].ItemArray[0];
                }
                DataTable dt2 = new DataTable();
                string command1 = "SELECT * FROM Задачи_сотрудникам Where Проект = '" + proj.ToString() + "' and Сотрудник = '" + worker.ToString() + "'";
                db.readDatathroughAdapter(command1, dt2);
                if (dt2.Rows.Count > 0)
                {
                    DateTime dat;
                    DateTime.TryParseExact(dt2.Rows[0].ItemArray[3].ToString(), "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dat);
                    textBox2.Text = dat.ToShortDateString();
                    textBox3.Text = dt2.Rows[0].ItemArray[2].ToString();
                    switch ((int)dt2.Rows[0].ItemArray[4])
                    {
                        case 1:
                            {
                                comboBox3.Text = "В_очереди";
                                break;
                            }
                        case 2:
                            {
                                comboBox3.Text = "Выполняется";
                                break;
                            }
                        case 3:
                            {
                                comboBox3.Text = "Выполнена";
                                break;
                            }
                    }
                }
            }
        }
        private void save_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            string date = textBox2.Text;
            string st = comboBox3.Text;
            DateTime dt;
            if (name.Replace(" ", "") == "" || !DateTime.TryParseExact(date.Replace(" ", ""), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt) || st.Replace(" ", "") == "")
            {
                MessageBox.Show("Заполните все поля для сохранения и введите дату в формате dd.MM.yyyy!");
            }
            else
            {
                int status;
                switch (st)
                {
                    case "В_очереди":
                        {
                            status = 1;
                            break;
                        }
                    case "Выполняется":
                        {
                            status = 2;
                            break;
                        }
                    case "Выполнена":
                        {
                            status = 3;
                            break;
                        }
                    default: status = 0; break;
                }
                if (status != 0)
                {
                    DataTable dt2 = new DataTable();
                    string command1 = "SELECT * FROM Задачи_сотрудникам Where Проект = '" + proj.ToString() + "' and Сотрудник = '" + worker.ToString() + "'";
                    db.readDatathroughAdapter(command1, dt2);
                    if (dt2.Rows.Count > 0)
                    {
                        string query = "Update Задачи_сотрудникам Set Задача = '" + name + "', Срок_выполнения = '" + date + "', Статус = '" + status.ToString() + "' Where Проект = '" + proj.ToString() + "' and Сотрудник = '" + worker.ToString() + "'";
                        SqlCommand update = new SqlCommand(query);
                        int row = db.executeQuery(update);
                        if (row == 1)
                        {
                            MessageBox.Show("Данные сохранены успешно!");
                        }
                    }
                    else
                    {
                        SqlCommand add1 = new SqlCommand("Insert into Задачи_сотрудникам (Проект,Сотрудник,Задача,Срок_выполнения,Статус) values('" + proj.ToString() + "','" + worker.ToString() + "','" + name + "','" + date + "','" + status.ToString() + "')");
                        int row = db.executeQuery(add1);
                        if (row == 1)
                        {
                            MessageBox.Show("Данные сохранены успешно!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Не придумывайте статус сами!");
                }

            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Вы уверены, что хотите удалить задачу?", "Удалить задачу?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                DataTable dt2 = new DataTable();
                string command1 = "SELECT * FROM Задачи_сотрудникам Where Проект = '" + proj.ToString() + "' and Сотрудник = '" + worker.ToString() + "'";
                db.readDatathroughAdapter(command1, dt2);
                if (dt2.Rows.Count > 0)
                {
                    string query = "Delete from Задачи_сотрудникам Where Проект = '" + proj.ToString() + "' and Сотрудник = '" + worker.ToString() + "'";
                    SqlCommand delete1 = new SqlCommand(query);
                    int row = db.executeQuery(delete1);
                    if (row == 1)
                    {
                        MessageBox.Show("Задача успешно удалена!");
                        comboBox1.SelectedItem = null;
                        comboBox2.SelectedItem = null;
                        comboBox3.SelectedItem = null;
                        textBox3.Text = "";
                        textBox2.Text = "";
                        delete.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Задачи для удаления еще нет в базе!");
                }
            }
        }

        private void save_MouseEnter(object sender, EventArgs e)
        {
            save.Location = new Point(498, 90);
        }

        private void save_MouseLeave(object sender, EventArgs e)
        {
            save.Location = new Point(498, 105);
        }

        private void delete_MouseEnter(object sender, EventArgs e)
        {
            delete.Location = new Point(498, 172);
        }

        private void delete_MouseLeave(object sender, EventArgs e)
        {
            delete.Location = new Point(498, 187);
        }
    }
}
