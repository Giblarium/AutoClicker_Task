namespace WinFormsApp1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pathToExcel_textBox = new System.Windows.Forms.TextBox();
            this.pathToExcel = new System.Windows.Forms.Label();
            this.readExcel_button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label_CountAccounts = new System.Windows.Forms.Label();
            this.picture_Chrome = new System.Windows.Forms.PictureBox();
            this.picture_Firefox = new System.Windows.Forms.PictureBox();
            this.picture_Edge = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox_DontSend = new System.Windows.Forms.CheckBox();
            this.checkBox_AuthOnly = new System.Windows.Forms.CheckBox();
            this.label_EdgeStatus = new System.Windows.Forms.Label();
            this.label_FirefoxStatus = new System.Windows.Forms.Label();
            this.label_ChromeStatus = new System.Windows.Forms.Label();
            this.button_PauseAll = new System.Windows.Forms.Button();
            this.button_StartAll = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Chrome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Firefox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Edge)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openExcelToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openExcelToolStripMenuItem
            // 
            this.openExcelToolStripMenuItem.Name = "openExcelToolStripMenuItem";
            this.openExcelToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.openExcelToolStripMenuItem.Text = "Open Excel";
            this.openExcelToolStripMenuItem.Click += new System.EventHandler(this.openExcelToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browsersToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.modeToolStripMenuItem,
            this.pauseToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // browsersToolStripMenuItem
            // 
            this.browsersToolStripMenuItem.Name = "browsersToolStripMenuItem";
            this.browsersToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.browsersToolStripMenuItem.Text = "Browsers";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.pauseToolStripMenuItem.Text = "Pause";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.driversToolStripMenuItem,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // driversToolStripMenuItem
            // 
            this.driversToolStripMenuItem.Name = "driversToolStripMenuItem";
            this.driversToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.driversToolStripMenuItem.Text = "Drivers";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(107, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // pathToExcel_textBox
            // 
            this.pathToExcel_textBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.pathToExcel_textBox.Location = new System.Drawing.Point(101, 27);
            this.pathToExcel_textBox.Name = "pathToExcel_textBox";
            this.pathToExcel_textBox.Size = new System.Drawing.Size(350, 23);
            this.pathToExcel_textBox.TabIndex = 1;
            // 
            // pathToExcel
            // 
            this.pathToExcel.AutoSize = true;
            this.pathToExcel.Location = new System.Drawing.Point(12, 30);
            this.pathToExcel.Name = "pathToExcel";
            this.pathToExcel.Size = new System.Drawing.Size(83, 15);
            this.pathToExcel.TabIndex = 2;
            this.pathToExcel.Text = "Путь к файлу:";
            // 
            // readExcel_button
            // 
            this.readExcel_button.Location = new System.Drawing.Point(489, 27);
            this.readExcel_button.Name = "readExcel_button";
            this.readExcel_button.Size = new System.Drawing.Size(127, 23);
            this.readExcel_button.TabIndex = 3;
            this.readExcel_button.Text = "Прочитать";
            this.readExcel_button.UseVisualStyleBackColor = true;
            this.readExcel_button.Click += new System.EventHandler(this.readExcel_button_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(457, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 56);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(439, 382);
            this.dataGridView1.TabIndex = 4;
            // 
            // label_CountAccounts
            // 
            this.label_CountAccounts.AutoSize = true;
            this.label_CountAccounts.Location = new System.Drawing.Point(622, 31);
            this.label_CountAccounts.Name = "label_CountAccounts";
            this.label_CountAccounts.Size = new System.Drawing.Size(0, 15);
            this.label_CountAccounts.TabIndex = 5;
            // 
            // picture_Chrome
            // 
            this.picture_Chrome.Image = ((System.Drawing.Image)(resources.GetObject("picture_Chrome.Image")));
            this.picture_Chrome.Location = new System.Drawing.Point(7, 44);
            this.picture_Chrome.Name = "picture_Chrome";
            this.picture_Chrome.Size = new System.Drawing.Size(32, 32);
            this.picture_Chrome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_Chrome.TabIndex = 6;
            this.picture_Chrome.TabStop = false;
            this.picture_Chrome.Click += new System.EventHandler(this.picture_Chrome_Click);
            // 
            // picture_Firefox
            // 
            this.picture_Firefox.Image = ((System.Drawing.Image)(resources.GetObject("picture_Firefox.Image")));
            this.picture_Firefox.Location = new System.Drawing.Point(7, 82);
            this.picture_Firefox.Name = "picture_Firefox";
            this.picture_Firefox.Size = new System.Drawing.Size(32, 32);
            this.picture_Firefox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_Firefox.TabIndex = 6;
            this.picture_Firefox.TabStop = false;
            this.picture_Firefox.Click += new System.EventHandler(this.picture_Firefox_Click);
            // 
            // picture_Edge
            // 
            this.picture_Edge.Image = ((System.Drawing.Image)(resources.GetObject("picture_Edge.Image")));
            this.picture_Edge.Location = new System.Drawing.Point(7, 120);
            this.picture_Edge.Name = "picture_Edge";
            this.picture_Edge.Size = new System.Drawing.Size(32, 32);
            this.picture_Edge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_Edge.TabIndex = 6;
            this.picture_Edge.TabStop = false;
            this.picture_Edge.Click += new System.EventHandler(this.picture_Edge_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox_DontSend);
            this.panel1.Controls.Add(this.checkBox_AuthOnly);
            this.panel1.Controls.Add(this.label_EdgeStatus);
            this.panel1.Controls.Add(this.label_FirefoxStatus);
            this.panel1.Controls.Add(this.label_ChromeStatus);
            this.panel1.Controls.Add(this.picture_Chrome);
            this.panel1.Controls.Add(this.button_PauseAll);
            this.panel1.Controls.Add(this.button_StartAll);
            this.panel1.Controls.Add(this.picture_Edge);
            this.panel1.Controls.Add(this.picture_Firefox);
            this.panel1.Location = new System.Drawing.Point(457, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 382);
            this.panel1.TabIndex = 7;
            // 
            // checkBox_DontSend
            // 
            this.checkBox_DontSend.AutoSize = true;
            this.checkBox_DontSend.Location = new System.Drawing.Point(3, 335);
            this.checkBox_DontSend.Name = "checkBox_DontSend";
            this.checkBox_DontSend.Size = new System.Drawing.Size(173, 19);
            this.checkBox_DontSend.TabIndex = 8;
            this.checkBox_DontSend.Text = "Не отправлять сообщения";
            this.checkBox_DontSend.UseVisualStyleBackColor = true;
            // 
            // checkBox_AuthOnly
            // 
            this.checkBox_AuthOnly.AutoSize = true;
            this.checkBox_AuthOnly.Location = new System.Drawing.Point(3, 360);
            this.checkBox_AuthOnly.Name = "checkBox_AuthOnly";
            this.checkBox_AuthOnly.Size = new System.Drawing.Size(137, 19);
            this.checkBox_AuthOnly.TabIndex = 8;
            this.checkBox_AuthOnly.Text = "Только авторизация";
            this.checkBox_AuthOnly.UseVisualStyleBackColor = true;
            // 
            // label_EdgeStatus
            // 
            this.label_EdgeStatus.AutoSize = true;
            this.label_EdgeStatus.Location = new System.Drawing.Point(45, 131);
            this.label_EdgeStatus.Name = "label_EdgeStatus";
            this.label_EdgeStatus.Size = new System.Drawing.Size(65, 15);
            this.label_EdgeStatus.TabIndex = 7;
            this.label_EdgeStatus.Text = "EdgeStatus";
            // 
            // label_FirefoxStatus
            // 
            this.label_FirefoxStatus.AutoSize = true;
            this.label_FirefoxStatus.Location = new System.Drawing.Point(45, 91);
            this.label_FirefoxStatus.Name = "label_FirefoxStatus";
            this.label_FirefoxStatus.Size = new System.Drawing.Size(75, 15);
            this.label_FirefoxStatus.TabIndex = 7;
            this.label_FirefoxStatus.Text = "FirefoxStatus";
            // 
            // label_ChromeStatus
            // 
            this.label_ChromeStatus.AutoSize = true;
            this.label_ChromeStatus.Location = new System.Drawing.Point(45, 51);
            this.label_ChromeStatus.Name = "label_ChromeStatus";
            this.label_ChromeStatus.Size = new System.Drawing.Size(82, 15);
            this.label_ChromeStatus.TabIndex = 7;
            this.label_ChromeStatus.Text = "ChromeStatus";
            // 
            // button_PauseAll
            // 
            this.button_PauseAll.Location = new System.Drawing.Point(198, 7);
            this.button_PauseAll.Name = "button_PauseAll";
            this.button_PauseAll.Size = new System.Drawing.Size(127, 23);
            this.button_PauseAll.TabIndex = 3;
            this.button_PauseAll.Text = "Пауза всё";
            this.button_PauseAll.UseVisualStyleBackColor = true;
            this.button_PauseAll.Click += new System.EventHandler(this.button_PauseAll_Click);
            // 
            // button_StartAll
            // 
            this.button_StartAll.Location = new System.Drawing.Point(7, 7);
            this.button_StartAll.Name = "button_StartAll";
            this.button_StartAll.Size = new System.Drawing.Size(127, 23);
            this.button_StartAll.TabIndex = 3;
            this.button_StartAll.Text = "Стартовать всё";
            this.button_StartAll.UseVisualStyleBackColor = true;
            this.button_StartAll.Click += new System.EventHandler(this.button_StartAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_CountAccounts);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.readExcel_button);
            this.Controls.Add(this.pathToExcel);
            this.Controls.Add(this.pathToExcel_textBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Chrome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Firefox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Edge)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openExcelToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem browsersToolStripMenuItem;
        private ToolStripMenuItem dataToolStripMenuItem;
        private ToolStripMenuItem modeToolStripMenuItem;
        private ToolStripMenuItem pauseToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem driversToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private TextBox pathToExcel_textBox;
        private Label pathToExcel;
        private Button readExcel_button;
        private Button button2;
        private DataGridView dataGridView1;
        private Label label_CountAccounts;
        private PictureBox picture_Chrome;
        private PictureBox picture_Firefox;
        private PictureBox picture_Edge;
        private Panel panel1;
        private Label label_EdgeStatus;
        private Label label_FirefoxStatus;
        private Label label_ChromeStatus;
        private Button button_PauseAll;
        private Button button_StartAll;
        private CheckBox checkBox_DontSend;
        private CheckBox checkBox_AuthOnly;
    }
}