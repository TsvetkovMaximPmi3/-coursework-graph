namespace Viewer
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SetkaN = new System.Windows.Forms.TextBox();
            this.Tochki = new System.Windows.Forms.TextBox();
            this.SetkaM = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.f1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.f2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.f3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // SetkaN
            // 
            this.SetkaN.Location = new System.Drawing.Point(725, 38);
            this.SetkaN.Name = "SetkaN";
            this.SetkaN.Size = new System.Drawing.Size(50, 20);
            this.SetkaN.TabIndex = 0;
            this.SetkaN.Text = "5";
            // 
            // Tochki
            // 
            this.Tochki.Location = new System.Drawing.Point(725, 12);
            this.Tochki.Name = "Tochki";
            this.Tochki.Size = new System.Drawing.Size(50, 20);
            this.Tochki.TabIndex = 1;
            this.Tochki.Text = "25";
            this.Tochki.TextChanged += new System.EventHandler(this.q_TextChanged);
            // 
            // SetkaM
            // 
            this.SetkaM.Location = new System.Drawing.Point(725, 64);
            this.SetkaM.Name = "SetkaM";
            this.SetkaM.Size = new System.Drawing.Size(50, 20);
            this.SetkaM.TabIndex = 2;
            this.SetkaM.Text = "5";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(781, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 20);
            this.button1.TabIndex = 3;
            this.button1.Text = "Редактировать сетку";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(781, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Начертить точки";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(781, 64);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(159, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Результат";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.f1,
            this.f2,
            this.f3});
            this.dataGridView1.Location = new System.Drawing.Point(725, 134);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(349, 150);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // f1
            // 
            this.f1.HeaderText = "f1";
            this.f1.Name = "f1";
            // 
            // f2
            // 
            this.f2.HeaderText = "f2";
            this.f2.Name = "f2";
            // 
            // f3
            // 
            this.f3.HeaderText = "общее отклонение";
            this.f3.Name = "f3";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(725, 91);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(50, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "0.6";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(400, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 556);
            this.panel1.TabIndex = 8;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 869);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SetkaM);
            this.Controls.Add(this.Tochki);
            this.Controls.Add(this.SetkaN);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SetkaN;
        private System.Windows.Forms.TextBox Tochki;
        private System.Windows.Forms.TextBox SetkaM;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn f1;
        private System.Windows.Forms.DataGridViewTextBoxColumn f2;
        private System.Windows.Forms.DataGridViewTextBoxColumn f3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
    }
}

