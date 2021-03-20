namespace ArturDevOps
{
    partial class Departments
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
            this.exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.delete = new System.Windows.Forms.PictureBox();
            this.add = new System.Windows.Forms.PictureBox();
            this.save = new System.Windows.Forms.PictureBox();
            this.right = new System.Windows.Forms.PictureBox();
            this.left = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.add)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.save)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.left)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.GreenYellow;
            this.panel1.Controls.Add(this.delete);
            this.panel1.Controls.Add(this.add);
            this.panel1.Controls.Add(this.save);
            this.panel1.Controls.Add(this.right);
            this.panel1.Controls.Add(this.left);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.exit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.GreenYellow;
            this.exit.FlatAppearance.BorderSize = 0;
            this.exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit.Location = new System.Drawing.Point(719, 0);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(81, 32);
            this.exit.TabIndex = 2;
            this.exit.Text = "Назад";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(219, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 41);
            this.label1.TabIndex = 3;
            this.label1.Text = "Управление отделами";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(29, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 39);
            this.label2.TabIndex = 4;
            this.label2.Text = "Код отдела:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(29, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 39);
            this.label3.TabIndex = 5;
            this.label3.Text = "Название:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(29, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 83);
            this.label4.TabIndex = 6;
            this.label4.Text = "Краткое описание:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(225, 142);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(44, 40);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(225, 225);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(259, 40);
            this.textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(226, 315);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(259, 99);
            this.textBox3.TabIndex = 9;
            // 
            // delete
            // 
            this.delete.Image = global::ArturDevOps.Properties.Resources.delete;
            this.delete.Location = new System.Drawing.Point(636, 284);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(60, 50);
            this.delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.delete.TabIndex = 14;
            this.delete.TabStop = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            this.delete.MouseEnter += new System.EventHandler(this.delete_MouseEnter);
            this.delete.MouseLeave += new System.EventHandler(this.delete_MouseLeave);
            // 
            // add
            // 
            this.add.Image = global::ArturDevOps.Properties.Resources.add;
            this.add.Location = new System.Drawing.Point(728, 284);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(60, 50);
            this.add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.add.TabIndex = 13;
            this.add.TabStop = false;
            this.add.Click += new System.EventHandler(this.add_Click);
            this.add.MouseEnter += new System.EventHandler(this.add_MouseEnter);
            this.add.MouseLeave += new System.EventHandler(this.add_MouseLeave);
            // 
            // save
            // 
            this.save.Image = global::ArturDevOps.Properties.Resources.save;
            this.save.Location = new System.Drawing.Point(543, 284);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(60, 50);
            this.save.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.save.TabIndex = 12;
            this.save.TabStop = false;
            this.save.Click += new System.EventHandler(this.save_Click);
            this.save.MouseEnter += new System.EventHandler(this.save_MouseEnter);
            this.save.MouseLeave += new System.EventHandler(this.save_MouseLeave);
            // 
            // right
            // 
            this.right.Image = global::ArturDevOps.Properties.Resources.right;
            this.right.Location = new System.Drawing.Point(678, 354);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(60, 60);
            this.right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.right.TabIndex = 11;
            this.right.TabStop = false;
            this.right.Click += new System.EventHandler(this.right_Click);
            this.right.MouseEnter += new System.EventHandler(this.right_MouseEnter);
            this.right.MouseLeave += new System.EventHandler(this.right_MouseLeave);
            // 
            // left
            // 
            this.left.BackColor = System.Drawing.Color.GreenYellow;
            this.left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.left.Image = global::ArturDevOps.Properties.Resources.left;
            this.left.Location = new System.Drawing.Point(584, 354);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(60, 60);
            this.left.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.left.TabIndex = 10;
            this.left.TabStop = false;
            this.left.Click += new System.EventHandler(this.left_Click);
            this.left.MouseEnter += new System.EventHandler(this.left_MouseEnter);
            this.left.MouseLeave += new System.EventHandler(this.left_MouseLeave);
            // 
            // Departments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Departments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Departments";
            this.Load += new System.EventHandler(this.Departments_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.add)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.save)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.left)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox left;
        private System.Windows.Forms.PictureBox right;
        private System.Windows.Forms.PictureBox delete;
        private System.Windows.Forms.PictureBox add;
        private System.Windows.Forms.PictureBox save;
    }
}