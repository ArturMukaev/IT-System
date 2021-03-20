namespace ArturDevOps
{
    partial class SM_Director
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.Period = new System.Windows.Forms.Button();
            this.Workers_task = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel1.Controls.Add(this.Period);
            this.panel1.Controls.Add(this.Workers_task);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.exit);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(565, 360);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // Period
            // 
            this.Period.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Period.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.Period.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.Period.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Period.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Period.Location = new System.Drawing.Point(338, 172);
            this.Period.Name = "Period";
            this.Period.Size = new System.Drawing.Size(167, 100);
            this.Period.TabIndex = 6;
            this.Period.Text = "Установление реального срока задач";
            this.Period.UseVisualStyleBackColor = false;
            this.Period.Click += new System.EventHandler(this.Period_Click);
            // 
            // Workers_task
            // 
            this.Workers_task.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Workers_task.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.Workers_task.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.Workers_task.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Workers_task.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Workers_task.Location = new System.Drawing.Point(76, 172);
            this.Workers_task.Name = "Workers_task";
            this.Workers_task.Size = new System.Drawing.Size(150, 100);
            this.Workers_task.TabIndex = 5;
            this.Workers_task.Text = "Работа с задачами сотрудников";
            this.Workers_task.UseVisualStyleBackColor = false;
            this.Workers_task.Click += new System.EventHandler(this.Workers_task_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(213, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 53);
            this.label1.TabIndex = 3;
            this.label1.Text = "Меню";
            // 
            // exit
            // 
            this.exit.FlatAppearance.BorderSize = 0;
            this.exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit.Location = new System.Drawing.Point(490, 0);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 35);
            this.exit.TabIndex = 2;
            this.exit.Text = "Выход";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // SM_Director
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 360);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SM_Director";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SM_Director";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Period;
        private System.Windows.Forms.Button Workers_task;
    }
}