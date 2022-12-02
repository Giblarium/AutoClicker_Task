namespace Tweaker
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.openServicePause = new System.Windows.Forms.TextBox();
            this.waitTreatmentPause = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.openMenuPause = new System.Windows.Forms.TextBox();
            this.sendMessagePause = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.loginPause = new System.Windows.Forms.TextBox();
            this.loadServicePause = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.loadAppPause = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.useAPI = new System.Windows.Forms.CheckBox();
            this.countTry = new System.Windows.Forms.TextBox();
            this.currentMonth = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.deleteData = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.authOnly = new System.Windows.Forms.CheckBox();
            this.sendMessage = new System.Windows.Forms.CheckBox();
            this.save = new System.Windows.Forms.Button();
            this.open = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.openServicePause);
            this.groupBox1.Controls.Add(this.waitTreatmentPause);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.openMenuPause);
            this.groupBox1.Controls.Add(this.sendMessagePause);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.loginPause);
            this.groupBox1.Controls.Add(this.loadServicePause);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.loadAppPause);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 225);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Паузы (милисекунды)";
            // 
            // openServicePause
            // 
            this.openServicePause.Location = new System.Drawing.Point(202, 106);
            this.openServicePause.Name = "openServicePause";
            this.openServicePause.Size = new System.Drawing.Size(100, 23);
            this.openServicePause.TabIndex = 1;
            this.openServicePause.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.loadAppPause_KeyPress);
            // 
            // waitTreatmentPause
            // 
            this.waitTreatmentPause.Location = new System.Drawing.Point(202, 192);
            this.waitTreatmentPause.Name = "waitTreatmentPause";
            this.waitTreatmentPause.Size = new System.Drawing.Size(100, 23);
            this.waitTreatmentPause.TabIndex = 1;
            this.waitTreatmentPause.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.loadAppPause_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ожидание загрузки списка ЛП:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ожидание назначения спеца:";
            // 
            // openMenuPause
            // 
            this.openMenuPause.Location = new System.Drawing.Point(202, 77);
            this.openMenuPause.Name = "openMenuPause";
            this.openMenuPause.Size = new System.Drawing.Size(100, 23);
            this.openMenuPause.TabIndex = 1;
            this.openMenuPause.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.loadAppPause_KeyPress);
            // 
            // sendMessagePause
            // 
            this.sendMessagePause.Location = new System.Drawing.Point(202, 163);
            this.sendMessagePause.Name = "sendMessagePause";
            this.sendMessagePause.Size = new System.Drawing.Size(100, 23);
            this.sendMessagePause.TabIndex = 1;
            this.sendMessagePause.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.loadAppPause_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ожидание загрузки меню:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ожидание отправки сообщения:";
            // 
            // loginPause
            // 
            this.loginPause.Location = new System.Drawing.Point(202, 48);
            this.loginPause.Name = "loginPause";
            this.loginPause.Size = new System.Drawing.Size(100, 23);
            this.loginPause.TabIndex = 1;
            this.loginPause.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.loadAppPause_KeyPress);
            // 
            // loadServicePause
            // 
            this.loadServicePause.Location = new System.Drawing.Point(202, 134);
            this.loadServicePause.Name = "loadServicePause";
            this.loadServicePause.Size = new System.Drawing.Size(100, 23);
            this.loadServicePause.TabIndex = 1;
            this.loadServicePause.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.loadAppPause_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ожидание авторизации:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ожидание загрузки ЛП:";
            // 
            // loadAppPause
            // 
            this.loadAppPause.Location = new System.Drawing.Point(202, 19);
            this.loadAppPause.Name = "loadAppPause";
            this.loadAppPause.Size = new System.Drawing.Size(100, 23);
            this.loadAppPause.TabIndex = 1;
            this.loadAppPause.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.loadAppPause_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ожидание загрузки приложения:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.useAPI);
            this.groupBox2.Controls.Add(this.countTry);
            this.groupBox2.Controls.Add(this.currentMonth);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.deleteData);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.authOnly);
            this.groupBox2.Controls.Add(this.sendMessage);
            this.groupBox2.Location = new System.Drawing.Point(333, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 225);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Настройки";
            // 
            // useAPI
            // 
            this.useAPI.AutoSize = true;
            this.useAPI.Location = new System.Drawing.Point(12, 97);
            this.useAPI.Name = "useAPI";
            this.useAPI.Size = new System.Drawing.Size(124, 19);
            this.useAPI.TabIndex = 0;
            this.useAPI.Text = "Использовать API";
            this.useAPI.UseVisualStyleBackColor = true;
            // 
            // countTry
            // 
            this.countTry.Location = new System.Drawing.Point(110, 148);
            this.countTry.Name = "countTry";
            this.countTry.Size = new System.Drawing.Size(100, 23);
            this.countTry.TabIndex = 1;
            this.countTry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.loadAppPause_KeyPress);
            // 
            // currentMonth
            // 
            this.currentMonth.Location = new System.Drawing.Point(110, 119);
            this.currentMonth.Name = "currentMonth";
            this.currentMonth.Size = new System.Drawing.Size(100, 23);
            this.currentMonth.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Попытки:";
            // 
            // deleteData
            // 
            this.deleteData.AutoSize = true;
            this.deleteData.Location = new System.Drawing.Point(12, 72);
            this.deleteData.Name = "deleteData";
            this.deleteData.Size = new System.Drawing.Size(190, 19);
            this.deleteData.TabIndex = 0;
            this.deleteData.Text = "Удалять Data.json при запуске";
            this.deleteData.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Текущий месяц:";
            // 
            // authOnly
            // 
            this.authOnly.AutoSize = true;
            this.authOnly.Location = new System.Drawing.Point(12, 47);
            this.authOnly.Name = "authOnly";
            this.authOnly.Size = new System.Drawing.Size(138, 19);
            this.authOnly.TabIndex = 0;
            this.authOnly.Text = "Только авторизации";
            this.authOnly.UseVisualStyleBackColor = true;
            // 
            // sendMessage
            // 
            this.sendMessage.AutoSize = true;
            this.sendMessage.Location = new System.Drawing.Point(12, 26);
            this.sendMessage.Name = "sendMessage";
            this.sendMessage.Size = new System.Drawing.Size(157, 19);
            this.sendMessage.TabIndex = 0;
            this.sendMessage.Text = "Отправлять сообщения";
            this.sendMessage.UseVisualStyleBackColor = true;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(500, 244);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 2;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(419, 244);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(75, 23);
            this.open.TabIndex = 3;
            this.open.Text = "Открыть";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 282);
            this.Controls.Add(this.open);
            this.Controls.Add(this.save);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Настройка AutoClicker";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private TextBox openServicePause;
        private TextBox waitTreatmentPause;
        private Label label4;
        private Label label7;
        private TextBox openMenuPause;
        private TextBox sendMessagePause;
        private Label label3;
        private Label label6;
        private TextBox loginPause;
        private TextBox loadServicePause;
        private Label label2;
        private Label label5;
        private TextBox loadAppPause;
        private Label label1;
        private GroupBox groupBox2;
        private CheckBox useAPI;
        private TextBox countTry;
        private TextBox currentMonth;
        private Label label9;
        private CheckBox deleteData;
        private Label label8;
        private CheckBox authOnly;
        private CheckBox sendMessage;
        private Button save;
        private Button open;
    }
}