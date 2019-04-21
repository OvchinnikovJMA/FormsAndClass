namespace интерфейсы
{
    partial class RegistrationForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RegistrationLogin = new System.Windows.Forms.TextBox();
            this.RegistrationPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.User = new System.Windows.Forms.RadioButton();
            this.SpokesmanOfPlace = new System.Windows.Forms.RadioButton();
            this.Admin = new System.Windows.Forms.RadioButton();
            this.WomanGender = new System.Windows.Forms.RadioButton();
            this.ManGender = new System.Windows.Forms.RadioButton();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AnotherGender = new System.Windows.Forms.RadioButton();
            this.RegistrationButton = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(107, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Регистрация";
            // 
            // RegistrationLogin
            // 
            this.RegistrationLogin.AccessibleDescription = "ипаи";
            this.RegistrationLogin.ForeColor = System.Drawing.SystemColors.WindowText;
            this.RegistrationLogin.Location = new System.Drawing.Point(85, 114);
            this.RegistrationLogin.Name = "RegistrationLogin";
            this.RegistrationLogin.Size = new System.Drawing.Size(270, 20);
            this.RegistrationLogin.TabIndex = 2;
            this.toolTip1.SetToolTip(this.RegistrationLogin, "Только латинские или русские символы");
            this.RegistrationLogin.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // RegistrationPassword
            // 
            this.RegistrationPassword.Location = new System.Drawing.Point(85, 149);
            this.RegistrationPassword.Name = "RegistrationPassword";
            this.RegistrationPassword.Size = new System.Drawing.Size(270, 20);
            this.RegistrationPassword.TabIndex = 3;
            this.RegistrationPassword.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Пароль";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(10, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 40);
            this.label4.TabIndex = 8;
            this.label4.Text = "Зарегестрироваться\r\n          в качестве:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Пол";
            // 
            // User
            // 
            this.User.AutoSize = true;
            this.User.Location = new System.Drawing.Point(187, 239);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(149, 17);
            this.User.TabIndex = 10;
            this.User.TabStop = true;
            this.User.Text = "Обычного пользователя";
            this.User.UseVisualStyleBackColor = true;
            this.User.CheckedChanged += new System.EventHandler(this.User_CheckedChanged);
            // 
            // SpokesmanOfPlace
            // 
            this.SpokesmanOfPlace.AutoSize = true;
            this.SpokesmanOfPlace.Location = new System.Drawing.Point(187, 262);
            this.SpokesmanOfPlace.Name = "SpokesmanOfPlace";
            this.SpokesmanOfPlace.Size = new System.Drawing.Size(169, 17);
            this.SpokesmanOfPlace.TabIndex = 11;
            this.SpokesmanOfPlace.TabStop = true;
            this.SpokesmanOfPlace.Text = "Представителя мест города";
            this.SpokesmanOfPlace.UseVisualStyleBackColor = true;
            this.SpokesmanOfPlace.CheckedChanged += new System.EventHandler(this.SpokesmanOfPlace_CheckedChanged);
            // 
            // Admin
            // 
            this.Admin.AutoSize = true;
            this.Admin.Location = new System.Drawing.Point(187, 285);
            this.Admin.Name = "Admin";
            this.Admin.Size = new System.Drawing.Size(175, 17);
            this.Admin.TabIndex = 12;
            this.Admin.TabStop = true;
            this.Admin.Text = "Администратора приложения";
            this.Admin.UseVisualStyleBackColor = true;
            this.Admin.CheckedChanged += new System.EventHandler(this.Admin_CheckedChanged);
            // 
            // WomanGender
            // 
            this.WomanGender.AutoSize = true;
            this.WomanGender.Location = new System.Drawing.Point(6, 19);
            this.WomanGender.Name = "WomanGender";
            this.WomanGender.Size = new System.Drawing.Size(72, 17);
            this.WomanGender.TabIndex = 13;
            this.WomanGender.TabStop = true;
            this.WomanGender.Text = "Женский";
            this.WomanGender.UseVisualStyleBackColor = true;
            this.WomanGender.CheckedChanged += new System.EventHandler(this.WomanGender_CheckedChanged);
            // 
            // ManGender
            // 
            this.ManGender.AutoSize = true;
            this.ManGender.Location = new System.Drawing.Point(6, 41);
            this.ManGender.Name = "ManGender";
            this.ManGender.Size = new System.Drawing.Size(71, 17);
            this.ManGender.TabIndex = 14;
            this.ManGender.TabStop = true;
            this.ManGender.Text = "Мужской";
            this.ManGender.UseVisualStyleBackColor = true;
            this.ManGender.CheckedChanged += new System.EventHandler(this.ManGender_CheckedChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(153, 18);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(144, 20);
            this.textBox3.TabIndex = 16;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AnotherGender);
            this.groupBox1.Controls.Add(this.ManGender);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.WomanGender);
            this.groupBox1.Location = new System.Drawing.Point(58, 175);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 64);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // AnotherGender
            // 
            this.AnotherGender.AutoSize = true;
            this.AnotherGender.Location = new System.Drawing.Point(85, 20);
            this.AnotherGender.Name = "AnotherGender";
            this.AnotherGender.Size = new System.Drawing.Size(62, 17);
            this.AnotherGender.TabIndex = 17;
            this.AnotherGender.TabStop = true;
            this.AnotherGender.Text = "Другой";
            this.AnotherGender.UseVisualStyleBackColor = true;
            this.AnotherGender.CheckedChanged += new System.EventHandler(this.AnotherGender_CheckedChanged);
            // 
            // RegistrationButton
            // 
            this.RegistrationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistrationButton.Location = new System.Drawing.Point(27, 313);
            this.RegistrationButton.Name = "RegistrationButton";
            this.RegistrationButton.Size = new System.Drawing.Size(178, 36);
            this.RegistrationButton.TabIndex = 19;
            this.RegistrationButton.Text = "Зарегистрироваться";
            this.RegistrationButton.UseVisualStyleBackColor = true;
            this.RegistrationButton.Click += new System.EventHandler(this.RegestrationButton_Click);
            // 
            // Cancel
            // 
            this.Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Cancel.Location = new System.Drawing.Point(238, 313);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(98, 36);
            this.Cancel.TabIndex = 20;
            this.Cancel.Text = "Отмена";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.RegistrationButton);
            this.Controls.Add(this.Admin);
            this.Controls.Add(this.SpokesmanOfPlace);
            this.Controls.Add(this.User);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RegistrationPassword);
            this.Controls.Add(this.RegistrationLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistrationForm";
            this.Text = "2ГИС путеводитель";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegistrationForm_FormClosing);
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton User;
        private System.Windows.Forms.RadioButton SpokesmanOfPlace;
        private System.Windows.Forms.RadioButton Admin;
        private System.Windows.Forms.RadioButton WomanGender;
        private System.Windows.Forms.RadioButton ManGender;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton AnotherGender;
        private System.Windows.Forms.Button RegistrationButton;
        private System.Windows.Forms.Button Cancel;
        public System.Windows.Forms.TextBox RegistrationLogin;
        public System.Windows.Forms.TextBox RegistrationPassword;
    }
}