using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Application1 = Microsoft.Office.Interop.Excel.Application;

namespace ArturDevOps
{
    public partial class Otchet_director : Form
    {
        public Otchet_director()
        {
            InitializeComponent();
        }
        DB db = new DB();
        private Application1 application;
        private Workbook workBook;
        private Worksheet worksheet;
        private void Otchet_director_Load(object sender, EventArgs e)
        {
            label3.Text = "на " + DateTime.Now.ToString();
            System.Data.DataTable dt = new System.Data.DataTable();
            string command1 = "SELECT * FROM Проекты";
            db.readDatathroughAdapter(command1, dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBox1.Items.Add(dt.Rows[i].ItemArray[1].ToString());
                }
            }
            label7.Text = dt.Rows.Count.ToString();
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
        private Director d1;
        private void exit_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.d1 = new Director();
            this.d1.Show();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            System.Data.DataTable dt1 = new System.Data.DataTable();
            string command2 = "SELECT * FROM Проекты Where Название = '" + comboBox1.SelectedItem.ToString() + "'";
            db.readDatathroughAdapter(command2, dt1);
            int bweh = (int)dt1.Rows[0].ItemArray[0];
            if (dt1.Rows.Count > 0)
            {
                DateTime dat;
                DateTime.TryParseExact(dt1.Rows[0].ItemArray[2].ToString(), "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dat);
                textBox2.Text = dat.ToShortDateString();
            }
            System.Data.DataTable dt2 = new System.Data.DataTable();
            string command1 = "SELECT * FROM Задачи_отделам Where Проект = '" + bweh.ToString() + "'";
            db.readDatathroughAdapter(command1, dt2);
            if (dt2.Rows.Count > 0)
            {
                List<DateTime> dates = new List<DateTime>();
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    DateTime dt;
                    if (DateTime.TryParseExact(dt2.Rows[i].ItemArray[4].ToString(), "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                    {
                        dates.Add(dt);
                    }
                }
                if (dates.Count > 0)
                {
                    DateTime date = dates.Max<DateTime>();
                    textBox1.Text = date.ToShortDateString();
                }
                else
                {
                    textBox1.Text = ("Не определено!");
                }

            }
        }

        private void export_MouseEnter(object sender, EventArgs e)
        {
            export.Location = new System.Drawing.Point(498, 280);
        }

        private void export_MouseLeave(object sender, EventArgs e)
        {
            export.Location = new System.Drawing.Point(498, 295);
        }

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
            worksheet.Range["A6"].Value = "Срок выполнения:";
            worksheet.Range["A8"].Value = "Реальный срок выполнения:";
            worksheet.Range["B2"].Value = DateTime.Now;
            worksheet.Range["B4"].Value = comboBox1.Text;
            worksheet.Range["B6"].Value = textBox1.Text;
            worksheet.Range["B8"].Value = textBox2.Text;
            application.Visible = true;
            TopMost = true;
            string savedFileName = "W"+comboBox1.Text + ".xlsx";
            workBook.SaveAs(Path.Combine(Environment.CurrentDirectory, savedFileName));
        }
    }
}
