using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ArturDevOps
{
    public partial class HR_Form : Form
    {
        public HR_Form()
        {
            InitializeComponent();
        }
        DB db = new DB();
        int selected;
        bool added;

        private void HR_Form_Load(object sender, EventArgs e)
        {
            added = false;
            DataTable dt = new DataTable();
            string command1 = "SELECT * FROM Сотрудники";
            db.readDatathroughAdapter(command1, dt);
            if (dt.Rows.Count > 0)
            {
                selected = (int)dt.Rows[0].ItemArray[0];
                textBox1.Text = dt.Rows[0].ItemArray[0].ToString();
                textBox2.Text = dt.Rows[0].ItemArray[2].ToString();
                textBox3.Text = dt.Rows[0].ItemArray[3].ToString();
                textBox4.Text = dt.Rows[0].ItemArray[4].ToString();
                DateTime dat;
                DateTime.TryParseExact(dt.Rows[0].ItemArray[5].ToString(), "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dat);
                textBox5.Text = dat.ToShortDateString();
                textBox6.Text = dt.Rows[0].ItemArray[6].ToString();
                textBox7.Text = dt.Rows[0].ItemArray[7].ToString();
                textBox8.Text = dt.Rows[0].ItemArray[10].ToString();
                textBox9.Text = dt.Rows[0].ItemArray[11].ToString();
                DataTable dt1 = new DataTable();
                string command2 = "SELECT * FROM Отделы";
                db.readDatathroughAdapter(command2, dt1);
                if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        comboBox2.Items.Add(dt1.Rows[i].ItemArray[1].ToString());
                        if (dt.Rows[0].ItemArray[1].ToString() == dt1.Rows[i].ItemArray[0].ToString())
                        {
                            comboBox2.Enabled = false;
                            comboBox2.Text = dt1.Rows[i].ItemArray[1].ToString();
                            break;
                        }
                        else
                        {
                            comboBox2.Enabled = false;
                        }
                    }
                }
                DataTable dt2 = new DataTable();
                string command3 = "SELECT * FROM Пол";
                db.readDatathroughAdapter(command3, dt2);
                if (dt2.Rows.Count > 0)
                {
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        comboBox1.Items.Add(dt2.Rows[i].ItemArray[1].ToString());
                        if (dt.Rows[0].ItemArray[8].ToString() == dt2.Rows[i].ItemArray[0].ToString())
                        {
                            comboBox1.Text = dt2.Rows[i].ItemArray[1].ToString();
                        }
                    }
                }
                DataTable dt3 = new DataTable();
                string command4 = "SELECT * FROM Роли";
                db.readDatathroughAdapter(command4, dt3);
                if (dt3.Rows.Count > 0)
                {
                    for (int i = 0; i < dt3.Rows.Count; i++)
                    {
                        comboBox3.Items.Add(dt3.Rows[i].ItemArray[1].ToString());
                        if (dt.Rows[0].ItemArray[9].ToString() == dt3.Rows[i].ItemArray[0].ToString())
                        {
                            comboBox3.Text = dt3.Rows[i].ItemArray[1].ToString();
                        }
                    }
                }
            }
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

        private void left_Click(object sender, EventArgs e)
        {
            int reserve = selected;
            DataTable dt4 = new DataTable();
            string command6 = "SELECT * FROM Сотрудники";
            db.readDatathroughAdapter(command6, dt4);
            DataTable dt = new DataTable();
            if (dt4.Rows.Count > 0)
            {
                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    selected--;
                    string command = "SELECT * FROM Сотрудники WHERE Код_сотрудника = '" + selected.ToString() + "'";
                    db.readDatathroughAdapter(command, dt);
                    if (dt.Rows.Count > 0)
                    {
                        break;
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                delete.Enabled = true;
                added = false;
                textBox1.Text = dt.Rows[0].ItemArray[0].ToString();
                textBox2.Text = dt.Rows[0].ItemArray[2].ToString();
                textBox3.Text = dt.Rows[0].ItemArray[3].ToString();
                textBox4.Text = dt.Rows[0].ItemArray[4].ToString();
                DateTime dat;
                DateTime.TryParseExact(dt.Rows[0].ItemArray[5].ToString(), "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dat);
                textBox5.Text = dat.ToShortDateString();
                textBox6.Text = dt.Rows[0].ItemArray[6].ToString();
                textBox7.Text = dt.Rows[0].ItemArray[7].ToString();
                textBox8.Text = dt.Rows[0].ItemArray[10].ToString();
                textBox9.Text = dt.Rows[0].ItemArray[11].ToString();
                DataTable dt1 = new DataTable();
                string command2 = "SELECT * FROM Отделы";
                db.readDatathroughAdapter(command2, dt1);
                if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        if (dt.Rows[0].ItemArray[1].ToString() == dt1.Rows[i].ItemArray[0].ToString())
                        {
                            comboBox2.Enabled = false;
                            comboBox2.Text = dt1.Rows[i].ItemArray[1].ToString();
                            break;
                        }
                        else
                        {
                            comboBox2.SelectedItem = null;
                            comboBox2.Enabled = false;
                        }
                    }
                }
                DataTable dt2 = new DataTable();
                string command3 = "SELECT * FROM Пол";
                db.readDatathroughAdapter(command3, dt2);
                if (dt2.Rows.Count > 0)
                {
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        if (dt.Rows[0].ItemArray[8].ToString() == dt2.Rows[i].ItemArray[0].ToString())
                        {
                            comboBox1.Text = dt2.Rows[i].ItemArray[1].ToString();
                        }
                    }
                }
                DataTable dt3 = new DataTable();
                string command4 = "SELECT * FROM Роли";
                db.readDatathroughAdapter(command4, dt3);
                if (dt3.Rows.Count > 0)
                {
                    for (int i = 0; i < dt3.Rows.Count; i++)
                    {
                        if (dt.Rows[0].ItemArray[9].ToString() == dt3.Rows[i].ItemArray[0].ToString())
                        {
                            comboBox3.Text = dt3.Rows[i].ItemArray[1].ToString();
                        }
                    }
                }
            }
            else
            {
                selected = reserve;
                MessageBox.Show("Переход к указанной записи невозможен, т.к. ее нет!");
            }
        }

        private void right_Click(object sender, EventArgs e)
        {
            int reserve = selected;
            DataTable dt4 = new DataTable();
            string command6 = "SELECT * FROM Сотрудники";
            db.readDatathroughAdapter(command6, dt4);
            DataTable dt = new DataTable();
            if (dt4.Rows.Count > 0)
            {
                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    selected++;
                    string command = "SELECT * FROM Сотрудники WHERE Код_сотрудника = '" + selected.ToString() + "'";
                    db.readDatathroughAdapter(command, dt);
                    if (dt.Rows.Count > 0)
                    {
                        break;
                    }
                }
            }

            if (dt.Rows.Count > 0)
            {
                delete.Enabled = true;
                added = false;
                textBox1.Text = dt.Rows[0].ItemArray[0].ToString();
                textBox2.Text = dt.Rows[0].ItemArray[2].ToString();
                textBox3.Text = dt.Rows[0].ItemArray[3].ToString();
                textBox4.Text = dt.Rows[0].ItemArray[4].ToString();
                DateTime dat;
                DateTime.TryParseExact(dt.Rows[0].ItemArray[5].ToString(), "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dat);
                textBox5.Text = dat.ToShortDateString();
                textBox6.Text = dt.Rows[0].ItemArray[6].ToString();
                textBox7.Text = dt.Rows[0].ItemArray[7].ToString();
                textBox8.Text = dt.Rows[0].ItemArray[10].ToString();
                textBox9.Text = dt.Rows[0].ItemArray[11].ToString();
                DataTable dt1 = new DataTable();
                string command2 = "SELECT * FROM Отделы";
                db.readDatathroughAdapter(command2, dt1);
                if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        if (dt.Rows[0].ItemArray[1].ToString() == dt1.Rows[i].ItemArray[0].ToString())
                        {
                            comboBox2.Enabled = false;
                            comboBox2.Text = dt1.Rows[i].ItemArray[1].ToString();
                            break;
                        }
                        else
                        {
                            comboBox2.SelectedItem = null;
                            comboBox2.Enabled = false;
                        }
                    }
                }
                DataTable dt2 = new DataTable();
                string command3 = "SELECT * FROM Пол";
                db.readDatathroughAdapter(command3, dt2);
                if (dt2.Rows.Count > 0)
                {
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        if (dt.Rows[0].ItemArray[8].ToString() == dt2.Rows[i].ItemArray[0].ToString())
                        {
                            comboBox1.Text = dt2.Rows[i].ItemArray[1].ToString();
                        }
                    }
                }
                DataTable dt3 = new DataTable();
                string command4 = "SELECT * FROM Роли";
                db.readDatathroughAdapter(command4, dt3);
                if (dt3.Rows.Count > 0)
                {
                    for (int i = 0; i < dt3.Rows.Count; i++)
                    {
                        if (dt.Rows[0].ItemArray[9].ToString() == dt3.Rows[i].ItemArray[0].ToString())
                        {
                            comboBox3.Text = dt3.Rows[i].ItemArray[1].ToString();
                        }
                    }
                }
            }
            else
            {
                selected=reserve;
                MessageBox.Show("Переход к указанной записи невозможен, т.к. ее нет!");
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            string name2 = textBox2.Text;
            string name = textBox3.Text;
            string name3 = textBox4.Text;
            string date = textBox5.Text;
            string phone = textBox6.Text;
            string mail = textBox7.Text;
            string login = textBox8.Text;
            string password = textBox9.Text;
            int pol = 0;
            int dep = 0;
            int roll = 0;
            DataTable dt2 = new DataTable();
            string command3 = "SELECT * FROM Пол";
            db.readDatathroughAdapter(command3, dt2);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                if (comboBox1.SelectedItem.ToString() == dt2.Rows[i].ItemArray[1].ToString())
                {
                    pol = (int)dt2.Rows[i].ItemArray[0];
                    break;
                }
            }
            if (comboBox2.SelectedItem != null)
            {
                DataTable dt1 = new DataTable();
                string command2 = "SELECT * FROM Отделы";
                db.readDatathroughAdapter(command2, dt1);
                if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        if (comboBox2.SelectedItem.ToString() == dt1.Rows[i].ItemArray[1].ToString())
                        {
                            dep = (int)dt1.Rows[i].ItemArray[0];
                            break;
                        }
                    }
                }
            }
            DataTable dt3 = new DataTable();
            string command4 = "SELECT * FROM Роли";
            db.readDatathroughAdapter(command4, dt3);
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                if (comboBox3.SelectedItem.ToString() == dt3.Rows[i].ItemArray[1].ToString())
                {
                    roll = (int)dt3.Rows[i].ItemArray[0];
                    break;
                }
            }
            DateTime dt;
            if (name.Replace(" ", "") == "" || name2.Replace(" ", "") == "" || name3.Replace(" ", "") == "" || phone.Replace(" ", "") == "" || mail.Replace(" ", "") == "" || login.Replace(" ", "") == "" || password.Replace(" ", "") == "" || comboBox1.SelectedItem == null || comboBox3.SelectedItem == null || !DateTime.TryParseExact(date.Replace(" ", ""), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
            {
                MessageBox.Show("Заполните все поля для сохранения и введите дату в формате dd.MM.yyyy!");
            }
            else
            {
                if (added)
                {
                    int row;
                    if (comboBox2.SelectedItem == null)
                    {
                        SqlCommand add1 = new SqlCommand("Insert into Сотрудники (Фамилия,Имя,Отчество,Дата_рождения,Телефон,Почта,Пол,Роль,Логин,Пароль) values('" + name2 + "','" + name + "','" + name3 + "','" + date + "','" + phone + "','" + mail + "','" + pol.ToString() + "','" + roll.ToString() + "','" + login + "','" + password + "')");
                        row = db.executeQuery(add1);
                    }
                    else
                    {
                        SqlCommand add2 = new SqlCommand("Insert into Сотрудники (Отдел,Фамилия,Имя,Отчество,Дата_рождения,Телефон,Почта,Пол,Роль,Логин,Пароль) values('" + dep.ToString() + "','" + name2 + "','" + name + "','" + name3 + "','" + date + "','" + phone + "','" + mail + "','" + pol.ToString() + "','" + roll.ToString() + "','" + login + "','" + password + "')");
                        row = db.executeQuery(add2);
                    }

                    if (row == 1)
                    {
                        MessageBox.Show("Данные сохранены успешно!");
                        added = false;
                        delete.Enabled = true;
                    }
                }
                else
                {
                    int row;
                    if (comboBox2.SelectedItem == null)
                    {
                        SqlCommand update = new SqlCommand("Update Сотрудники Set Фамилия = '" + name2 + "', Имя = '" + name + "', Отчество = '" + name3 + "', Дата_рождения = '" + date + "', Телефон = '" + phone + "', Почта = '" + mail + "', Пол = '" + pol.ToString() + "', Роль = '" + roll.ToString() + "', Логин = '" + login + "', Пароль = '" + password + "' Where Код_сотрудника ='" + textBox1.Text + "'");
                        row = db.executeQuery(update);
                    }
                    else
                    {
                        SqlCommand update1 = new SqlCommand("Update Сотрудники Set Отдел = '" + dep.ToString() + "', Фамилия = '" + name2 + "', Имя = '" + name + "', Отчество = '" + name3 + "', Дата_рождения = '" + date + "', Телефон = '" + phone + "', Почта = '" + mail + "', Пол = '" + pol.ToString() + "', Роль = '" + roll.ToString() + "', Логин = '" + login + "', Пароль = '" + password + "' Where Код_сотрудника ='" + textBox1.Text + "'");
                        row = db.executeQuery(update1);
                    }

                    if (row == 1)
                    {
                        MessageBox.Show("Данные сохранены успешно!");
                    }
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Вы уверены, что хотите удалить сотрудника?", "Удалить сотрудника?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                string query = "Delete from Сотрудники Where Код_сотрудника = '" + textBox1.Text + "'";
                SqlCommand delete1 = new SqlCommand(query);
                int row = db.executeQuery(delete1);
                if (row == 1)
                {
                    MessageBox.Show("Сотрудник успешно удален!");
                    DataTable dt = new DataTable();
                    string command = "SELECT * FROM Сотрудники";
                    db.readDatathroughAdapter(command, dt);
                    if (dt.Rows.Count > 0)
                    {
                        selected = (int)dt.Rows[0].ItemArray[0];
                        textBox1.Text = dt.Rows[0].ItemArray[0].ToString();
                        textBox2.Text = dt.Rows[0].ItemArray[2].ToString();
                        textBox3.Text = dt.Rows[0].ItemArray[3].ToString();
                        textBox4.Text = dt.Rows[0].ItemArray[4].ToString();
                        DateTime dat;
                        DateTime.TryParseExact(dt.Rows[0].ItemArray[5].ToString(), "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dat);
                        textBox5.Text = dat.ToShortDateString();
                        textBox6.Text = dt.Rows[0].ItemArray[6].ToString();
                        textBox7.Text = dt.Rows[0].ItemArray[7].ToString();
                        textBox8.Text = dt.Rows[0].ItemArray[10].ToString();
                        textBox9.Text = dt.Rows[0].ItemArray[11].ToString();
                        DataTable dt1 = new DataTable();
                        string command2 = "SELECT * FROM Отделы";
                        db.readDatathroughAdapter(command2, dt1);
                        if (dt1.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt1.Rows.Count; i++)
                            {
                                if (dt.Rows[0].ItemArray[1].ToString() == dt1.Rows[i].ItemArray[0].ToString())
                                {
                                    comboBox2.Enabled = false;
                                    comboBox2.Text = dt1.Rows[i].ItemArray[1].ToString();
                                    break;
                                }
                                else
                                {
                                    comboBox2.SelectedItem = null;
                                    comboBox2.Enabled = false;
                                }
                            }
                        }
                        DataTable dt2 = new DataTable();
                        string command3 = "SELECT * FROM Пол";
                        db.readDatathroughAdapter(command3, dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt2.Rows.Count; i++)
                            {
                                if (dt.Rows[0].ItemArray[8].ToString() == dt2.Rows[i].ItemArray[0].ToString())
                                {
                                    comboBox1.Text = dt2.Rows[i].ItemArray[1].ToString();
                                }
                            }
                        }
                        DataTable dt3 = new DataTable();
                        string command4 = "SELECT * FROM Роли";
                        db.readDatathroughAdapter(command4, dt3);
                        if (dt3.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt3.Rows.Count; i++)
                            {
                                if (dt.Rows[0].ItemArray[9].ToString() == dt3.Rows[i].ItemArray[0].ToString())
                                {
                                    comboBox3.Text = dt3.Rows[i].ItemArray[1].ToString();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            added = true;
            delete.Enabled = false;
            DataTable dt3 = new DataTable();
            string command1 = "SELECT * FROM Сотрудники";
            db.readDatathroughAdapter(command1, dt3);
            textBox1.Text = ((int)dt3.Rows[dt3.Rows.Count - 1].ItemArray[0] + 1).ToString();
            textBox2.Text = "";
            textBox3.Text = "";
            selected = (int)dt3.Rows[dt3.Rows.Count - 1].ItemArray[0] + 1;
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            comboBox1.SelectedItem = null;
            comboBox2.Enabled = true;
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
        }

        private void left_MouseEnter(object sender, EventArgs e)
        {
            left.Location = new Point(58, 624);
        }

        private void left_MouseLeave(object sender, EventArgs e)
        {
            left.Location = new Point(58, 634);
        }

        private void right_MouseEnter(object sender, EventArgs e)
        {
            right.Location = new Point(135, 624);
        }

        private void right_MouseLeave(object sender, EventArgs e)
        {
            right.Location = new Point(135, 634);
        }

        private void save_MouseEnter(object sender, EventArgs e)
        {
            save.Location = new Point(264, 624);
        }

        private void save_MouseLeave(object sender, EventArgs e)
        {
            save.Location = new Point(264, 634);
        }

        private void add_MouseEnter(object sender, EventArgs e)
        {
            add.Location = new Point(412, 624);
        }

        private void add_MouseLeave(object sender, EventArgs e)
        {
            add.Location = new Point(412, 634);
        }

        private void delete_MouseEnter(object sender, EventArgs e)
        {
            delete.Location = new Point(339, 624);
        }

        private void delete_MouseLeave(object sender, EventArgs e)
        {
            delete.Location = new Point(339, 634);
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem.ToString().Replace(" ", "") == "Директор" || comboBox3.SelectedItem.ToString().Replace(" ", "") == "Специалист_по_найму")
            {
                comboBox2.SelectedItem = null;
                comboBox2.Enabled = false;
            }
            else
            {
                comboBox2.Enabled = true;
            }
        }
    }
}
