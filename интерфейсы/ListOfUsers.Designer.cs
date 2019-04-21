namespace интерфейсы
{
    partial class ListOfUsersForm
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
            this.ListboxOfUsers = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ListboxOfUsers
            // 
            this.ListboxOfUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListboxOfUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListboxOfUsers.FormattingEnabled = true;
            this.ListboxOfUsers.ItemHeight = 16;
            this.ListboxOfUsers.Location = new System.Drawing.Point(0, 0);
            this.ListboxOfUsers.Name = "ListboxOfUsers";
            this.ListboxOfUsers.Size = new System.Drawing.Size(484, 361);
            this.ListboxOfUsers.TabIndex = 0;
            // 
            // ListOfUsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.ListboxOfUsers);
            this.Name = "ListOfUsersForm";
            this.Text = "Список пользователей (2ГИС путеводитель)";
            this.Load += new System.EventHandler(this.ListOfUsers_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListboxOfUsers;
    }
}