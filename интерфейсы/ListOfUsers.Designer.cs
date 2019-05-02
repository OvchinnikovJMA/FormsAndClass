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
            this.ListOfUsersData = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ListOfUsersData
            // 
            this.ListOfUsersData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListOfUsersData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListOfUsersData.FormattingEnabled = true;
            this.ListOfUsersData.ItemHeight = 16;
            this.ListOfUsersData.Location = new System.Drawing.Point(0, 0);
            this.ListOfUsersData.Name = "ListOfUsersData";
            this.ListOfUsersData.ScrollAlwaysVisible = true;
            this.ListOfUsersData.Size = new System.Drawing.Size(594, 361);
            this.ListOfUsersData.TabIndex = 0;
            // 
            // ListOfUsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 361);
            this.Controls.Add(this.ListOfUsersData);
            this.Name = "ListOfUsersForm";
            this.Text = "Список пользователей (2ГИС путеводитель)";
            this.Load += new System.EventHandler(this.ListOfUsers_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListOfUsersData;
    }
}