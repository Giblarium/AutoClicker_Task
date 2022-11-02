namespace net6
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_ReadExcelBook = new System.Windows.Forms.Button();
            this.textBox_PathExcelBook = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_ReadExcelBook
            // 
            this.button_ReadExcelBook.Location = new System.Drawing.Point(682, 12);
            this.button_ReadExcelBook.Name = "button_ReadExcelBook";
            this.button_ReadExcelBook.Size = new System.Drawing.Size(122, 23);
            this.button_ReadExcelBook.TabIndex = 0;
            this.button_ReadExcelBook.Text = "Прочитать";
            this.button_ReadExcelBook.UseVisualStyleBackColor = true;
            // 
            // textBox_PathExcelBook
            // 
            this.textBox_PathExcelBook.Location = new System.Drawing.Point(131, 12);
            this.textBox_PathExcelBook.Name = "textBox_PathExcelBook";
            this.textBox_PathExcelBook.Size = new System.Drawing.Size(545, 23);
            this.textBox_PathExcelBook.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Путь к файлу Excel:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Login});
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(789, 475);
            this.dataGridView1.TabIndex = 3;
            // 
            // Login
            // 
            this.Login.HeaderText = "Login";
            this.Login.Name = "Login";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 528);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_PathExcelBook);
            this.Controls.Add(this.button_ReadExcelBook);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button_ReadExcelBook;
        private TextBox textBox_PathExcelBook;
        private Label label1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Login;
    }
}