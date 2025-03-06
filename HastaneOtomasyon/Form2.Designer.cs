namespace HastaneOtomasyon
{
    partial class Form2
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
            button1 = new Button();
            dataGridView1 = new DataGridView();
            hasta_id = new DataGridViewTextBoxColumn();
            ad = new DataGridViewTextBoxColumn();
            soyad = new DataGridViewTextBoxColumn();
            tc_no = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            textBox1 = new TextBox();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(484, 120);
            button1.Name = "button1";
            button1.Size = new Size(75, 50);
            button1.TabIndex = 2;
            button1.Text = "reçete yaz";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { hasta_id, ad, soyad, tc_no });
            dataGridView1.Location = new Point(44, 120);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(423, 274);
            dataGridView1.TabIndex = 7;
            // 
            // hasta_id
            // 
            hasta_id.Frozen = true;
            hasta_id.HeaderText = "id";
            hasta_id.Name = "hasta_id";
            hasta_id.Width = 30;
            // 
            // ad
            // 
            ad.Frozen = true;
            ad.HeaderText = "hasta ad";
            ad.Name = "ad";
            // 
            // soyad
            // 
            soyad.Frozen = true;
            soyad.HeaderText = "soyad";
            soyad.Name = "soyad";
            // 
            // tc_no
            // 
            tc_no.Frozen = true;
            tc_no.HeaderText = "tc no";
            tc_no.Name = "tc_no";
            tc_no.Width = 150;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 22);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 8;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(102, 22);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 9;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(179, 22);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 10;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 63);
            label4.Name = "label4";
            label4.Size = new Size(71, 15);
            label4.TabIndex = 11;
            label4.Text = "hasta arama";
            // 
            // button2
            // 
            button2.Location = new Point(484, 176);
            button2.Name = "button2";
            button2.Size = new Size(75, 50);
            button2.TabIndex = 12;
            button2.Text = "hasta bilgi";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(484, 232);
            button3.Name = "button3";
            button3.Size = new Size(75, 50);
            button3.TabIndex = 13;
            button3.Text = "randevu ver";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(484, 288);
            button4.Name = "button4";
            button4.Size = new Size(75, 50);
            button4.TabIndex = 14;
            button4.Text = "hasta ekle";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(42, 81);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 15;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // button5
            // 
            button5.Location = new Point(484, 344);
            button5.Name = "button5";
            button5.Size = new Size(75, 50);
            button5.TabIndex = 16;
            button5.Text = "Tanı yaz";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(599, 478);
            Controls.Add(button5);
            Controls.Add(textBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Name = "Form2";
            Text = "Ana Sayfa";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button2;
        private Button button3;
        private Button button4;
        private DataGridViewTextBoxColumn hasta_id;
        private DataGridViewTextBoxColumn ad;
        private DataGridViewTextBoxColumn soyad;
        private DataGridViewTextBoxColumn tc_no;
        private TextBox textBox1;
        private Button button5;
    }
}