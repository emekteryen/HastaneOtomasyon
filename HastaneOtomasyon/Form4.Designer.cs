namespace HastaneOtomasyon
{
    partial class Form4
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
            button2 = new Button();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            ilac_id2 = new DataGridViewTextBoxColumn();
            ilac_ad2 = new DataGridViewTextBoxColumn();
            ilac_adet2 = new DataGridViewTextBoxColumn();
            dataGridView2 = new DataGridView();
            ilac_id = new DataGridViewTextBoxColumn();
            ilac_ad = new DataGridViewTextBoxColumn();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(552, 54);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Kaydet";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 23);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(238, 23);
            textBox1.TabIndex = 4;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ilac_id2, ilac_ad2, ilac_adet2 });
            dataGridView1.Location = new Point(273, 83);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(354, 333);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // ilac_id2
            // 
            ilac_id2.Frozen = true;
            ilac_id2.HeaderText = "ilaç id";
            ilac_id2.Name = "ilac_id2";
            // 
            // ilac_ad2
            // 
            ilac_ad2.Frozen = true;
            ilac_ad2.HeaderText = "ilaç adı";
            ilac_ad2.Name = "ilac_ad2";
            // 
            // ilac_adet2
            // 
            ilac_adet2.Frozen = true;
            ilac_adet2.HeaderText = "ilaç adedi";
            ilac_adet2.Name = "ilac_adet2";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { ilac_id, ilac_ad });
            dataGridView2.Location = new Point(12, 83);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(238, 333);
            dataGridView2.TabIndex = 8;
            dataGridView2.CellClick += dataGridView2_CellClick;
            // 
            // ilac_id
            // 
            ilac_id.Frozen = true;
            ilac_id.HeaderText = "İlaç id";
            ilac_id.Name = "ilac_id";
            // 
            // ilac_ad
            // 
            ilac_ad.Frozen = true;
            ilac_ad.HeaderText = "İlaç Adı";
            ilac_ad.Name = "ilac_ad";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 55);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 9;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(685, 450);
            Controls.Add(comboBox1);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Name = "Form4";
            Text = "İlaç Yaz";
            Load += Form4_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button2;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn ilac_id2;
        private DataGridViewTextBoxColumn ilac_ad2;
        private DataGridViewTextBoxColumn ilac_adet2;
        private DataGridViewTextBoxColumn ilac_id;
        private DataGridViewTextBoxColumn ilac_ad;
        private ComboBox comboBox1;
    }
}