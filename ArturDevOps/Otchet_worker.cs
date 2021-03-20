using Microsoft.Office.Interop.Excel;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Application1 = Microsoft.Office.Interop.Excel.Application;

namespace ArturDevOps
{
    public partial class Otchet_worker : Form
    {
        private Registr r1;
        private Application1 application;
        private Workbook workBook;
        private Worksheet worksheet;
        public Otchet_worker(Registr _f1)
        {
            this.r1 = _f1;
            InitializeComponent();
        }
        DB db = new DB();
        int proj = 0;

        private void export_Click(object sender, EventArgs e)
        {
            application = new Application1
            {
                DisplayAlerts = false
            };
            workBook = application.Workbooks.Add();
            worksheet = workBook.ActiveSheet as Worksheet;
            worksheet.Range["A2"].Value = "Отчет на:";
            worksheet.Range["A4"].Value = "Проект:";
            worksheet.Range["A6"].Value = "Задача:";
            worksheet.Range["A8"].Value = "Срок выполнения:";
            worksheet.Range["A10"].Value = "Статус:";
            worksheet.Range["B2"].Value = DateTime.Now;
            worksheet.Range["B4"].Value = comboBox1.Text;
            worksheet.Range["B8"].Value = textBox2.Text;
            worksheet.Range["B6"].Value = textBox3.Text;
            worksheet.Range["B10"].Value = comboBox3.Text;
            application.Visible = true;
            TopMost = true;
            string savedFileName = comboBox1.Text+".xlsx";
            workBook.SaveAs(Path.Combine(Environment.CurrentDirectory, savedFileName));
        }


        private void Otchet_worker_Load(object sender, EventArgs e)
        {
            export.Enabled = false;
            save.Enabled = false;
            comboBox3.Enabled = false;
            System.Data.DataTable dt1 = new System.Data.DataTable();
            string command2 = "SELECT * FROM Проекты";
            db.readDatathroughAdapter(command2, dt1);
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    comboBox1.Items.Add(dt1.Rows[i].ItemArray[1].ToString());
                }
            }
            System.Data.DataTable dt3 = new System.Data.DataTable();
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

        System.Drawing.Point lastPoint;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new System.Drawing.Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            string st = comboBox3.Text;
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
                string query = "Update Задачи_сотрудникам Set Статус = '" + status.ToString() + "' Where Проект = '" + proj.ToString() + "' and Сотрудник = '" + this.r1.worker + "'";
                SqlCommand update = new SqlCommand(query);
                int row = db.executeQuery(update);
                if (row == 1)
                {
                    MessageBox.Show("Данные сохранены успешно!");
                }
            }
            else
            {
                MessageBox.Show("Не придумывайте статус сами!");
            }

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

            System.Data.DataTable dt1 = new System.Data.DataTable();
            string command2 = "SELECT * FROM Проекты Where Название = '" + comboBox1.SelectedItem.ToString() + "'";
            db.readDatathroughAdapter(command2, dt1);
            if (dt1.Rows.Count > 0)
            { proj = (int)dt1.Rows[0].ItemArray[0]; }
            System.Data.DataTable dt2 = new System.Data.DataTable();
            string command1 = "SELECT * FROM Задачи_сотрудникам Where Проект = '" + proj.ToString() + "' and Сотрудник = '" + this.r1.worker + "'";
            db.readDatathroughAdapter(command1, dt2);
            if (dt2.Rows.Count > 0)
            {
                export.Enabled = true;
                save.Enabled = true;
                comboBox3.Enabled = true;
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
            else
            {
                export.Enabled = false;
                save.Enabled = false;
                comboBox3.Enabled = false;
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox3.SelectedItem = null;
            }

        }

        private void exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void save_MouseEnter(object sender, EventArgs e)
        {
            save.Location = new System.Drawing.Point(498, 90);
        }

        private void save_MouseLeave(object sender, EventArgs e)
        {
            save.Location = new System.Drawing.Point(498, 105);
        }

        private void export_MouseEnter(object sender, EventArgs e)
        {
            export.Location = new System.Drawing.Point(498, 200);
        }

        private void export_MouseLeave(object sender, EventArgs e)
        {
            export.Location = new System.Drawing.Point(498, 214);
        }


    }
}
