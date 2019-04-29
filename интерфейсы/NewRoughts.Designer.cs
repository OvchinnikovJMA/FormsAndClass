namespace интерфейсы
{
    partial class NewRoughts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewRoughts));
            this.RouhtsTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.UsersRoughts = new System.Windows.Forms.Button();
            this.SaveNewRought = new System.Windows.Forms.Button();
            this.DeletePlaceRought = new System.Windows.Forms.Button();
            this.AddPlaceRoght = new System.Windows.Forms.Button();
            this.SelectedPlacesRoughts = new System.Windows.Forms.ListBox();
            this.AllPlacesRoughts = new System.Windows.Forms.ListBox();
            this.AllUserRoghts = new System.Windows.Forms.TabPage();
            this.MyRoughtsUser = new System.Windows.Forms.ListBox();
            this.BackToNewRoughts = new System.Windows.Forms.Button();
            this.DeleteRought = new System.Windows.Forms.Button();
            this.RouhtsTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.AllUserRoghts.SuspendLayout();
            this.SuspendLayout();
            // 
            // RouhtsTab
            // 
            this.RouhtsTab.Controls.Add(this.tabPage1);
            this.RouhtsTab.Controls.Add(this.AllUserRoghts);
            this.RouhtsTab.Location = new System.Drawing.Point(0, -22);
            this.RouhtsTab.Name = "RouhtsTab";
            this.RouhtsTab.SelectedIndex = 0;
            this.RouhtsTab.Size = new System.Drawing.Size(804, 393);
            this.RouhtsTab.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.UsersRoughts);
            this.tabPage1.Controls.Add(this.SaveNewRought);
            this.tabPage1.Controls.Add(this.DeletePlaceRought);
            this.tabPage1.Controls.Add(this.AddPlaceRoght);
            this.tabPage1.Controls.Add(this.SelectedPlacesRoughts);
            this.tabPage1.Controls.Add(this.AllPlacesRoughts);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(796, 367);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "NewRoughts";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // UsersRoughts
            // 
            this.UsersRoughts.Location = new System.Drawing.Point(362, 32);
            this.UsersRoughts.Name = "UsersRoughts";
            this.UsersRoughts.Size = new System.Drawing.Size(75, 41);
            this.UsersRoughts.TabIndex = 8;
            this.UsersRoughts.Text = "Мои маршруты";
            this.UsersRoughts.UseVisualStyleBackColor = true;
            this.UsersRoughts.Click += new System.EventHandler(this.UsersRoughts_Click);
            // 
            // SaveNewRought
            // 
            this.SaveNewRought.Location = new System.Drawing.Point(362, 179);
            this.SaveNewRought.Name = "SaveNewRought";
            this.SaveNewRought.Size = new System.Drawing.Size(75, 23);
            this.SaveNewRought.TabIndex = 7;
            this.SaveNewRought.Text = "Сохранить";
            this.SaveNewRought.UseVisualStyleBackColor = true;
            this.SaveNewRought.Click += new System.EventHandler(this.SaveNewRought_Click);
            // 
            // DeletePlaceRought
            // 
            this.DeletePlaceRought.Location = new System.Drawing.Point(362, 304);
            this.DeletePlaceRought.Name = "DeletePlaceRought";
            this.DeletePlaceRought.Size = new System.Drawing.Size(75, 23);
            this.DeletePlaceRought.TabIndex = 6;
            this.DeletePlaceRought.Text = "Убрать";
            this.DeletePlaceRought.UseVisualStyleBackColor = true;
            this.DeletePlaceRought.Click += new System.EventHandler(this.DeletePlaceRought_Click);
            // 
            // AddPlaceRoght
            // 
            this.AddPlaceRoght.Location = new System.Drawing.Point(362, 239);
            this.AddPlaceRoght.Name = "AddPlaceRoght";
            this.AddPlaceRoght.Size = new System.Drawing.Size(75, 23);
            this.AddPlaceRoght.TabIndex = 5;
            this.AddPlaceRoght.Text = "Добавить";
            this.AddPlaceRoght.UseVisualStyleBackColor = true;
            this.AddPlaceRoght.Click += new System.EventHandler(this.AddPlaceRoght_Click);
            // 
            // SelectedPlacesRoughts
            // 
            this.SelectedPlacesRoughts.Dock = System.Windows.Forms.DockStyle.Right;
            this.SelectedPlacesRoughts.FormattingEnabled = true;
            this.SelectedPlacesRoughts.Location = new System.Drawing.Point(445, 3);
            this.SelectedPlacesRoughts.Name = "SelectedPlacesRoughts";
            this.SelectedPlacesRoughts.Size = new System.Drawing.Size(348, 361);
            this.SelectedPlacesRoughts.TabIndex = 4;
            this.SelectedPlacesRoughts.SelectedIndexChanged += new System.EventHandler(this.SelectedPlacesRoughts_SelectedIndexChanged);
            this.SelectedPlacesRoughts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SelectedPlacesRoughts_MouseDoubleClick);
            // 
            // AllPlacesRoughts
            // 
            this.AllPlacesRoughts.Dock = System.Windows.Forms.DockStyle.Left;
            this.AllPlacesRoughts.FormattingEnabled = true;
            this.AllPlacesRoughts.Location = new System.Drawing.Point(3, 3);
            this.AllPlacesRoughts.Name = "AllPlacesRoughts";
            this.AllPlacesRoughts.Size = new System.Drawing.Size(350, 361);
            this.AllPlacesRoughts.TabIndex = 3;
            this.AllPlacesRoughts.SelectedIndexChanged += new System.EventHandler(this.AllPlacesRoughts_SelectedIndexChanged);
            this.AllPlacesRoughts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AllPlacesRoughts_MouseDoubleClick);
            // 
            // AllUserRoghts
            // 
            this.AllUserRoghts.Controls.Add(this.DeleteRought);
            this.AllUserRoghts.Controls.Add(this.BackToNewRoughts);
            this.AllUserRoghts.Controls.Add(this.MyRoughtsUser);
            this.AllUserRoghts.Location = new System.Drawing.Point(4, 22);
            this.AllUserRoghts.Name = "AllUserRoghts";
            this.AllUserRoghts.Padding = new System.Windows.Forms.Padding(3);
            this.AllUserRoghts.Size = new System.Drawing.Size(796, 367);
            this.AllUserRoghts.TabIndex = 1;
            this.AllUserRoghts.Text = "tabPage2";
            this.AllUserRoghts.UseVisualStyleBackColor = true;
            // 
            // MyRoughtsUser
            // 
            this.MyRoughtsUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.MyRoughtsUser.FormattingEnabled = true;
            this.MyRoughtsUser.Location = new System.Drawing.Point(3, 3);
            this.MyRoughtsUser.Name = "MyRoughtsUser";
            this.MyRoughtsUser.Size = new System.Drawing.Size(708, 361);
            this.MyRoughtsUser.TabIndex = 0;
            // 
            // BackToNewRoughts
            // 
            this.BackToNewRoughts.Location = new System.Drawing.Point(715, 218);
            this.BackToNewRoughts.Name = "BackToNewRoughts";
            this.BackToNewRoughts.Size = new System.Drawing.Size(75, 23);
            this.BackToNewRoughts.TabIndex = 1;
            this.BackToNewRoughts.Text = "Назад";
            this.BackToNewRoughts.UseVisualStyleBackColor = true;
            this.BackToNewRoughts.Click += new System.EventHandler(this.BackToNewRoughts_Click);
            // 
            // DeleteRought
            // 
            this.DeleteRought.Location = new System.Drawing.Point(715, 90);
            this.DeleteRought.Name = "DeleteRought";
            this.DeleteRought.Size = new System.Drawing.Size(75, 23);
            this.DeleteRought.TabIndex = 2;
            this.DeleteRought.Text = "Удалить";
            this.DeleteRought.UseVisualStyleBackColor = true;
            this.DeleteRought.Click += new System.EventHandler(this.DeleteRought_Click);
            // 
            // NewRoughts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 371);
            this.Controls.Add(this.RouhtsTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewRoughts";
            this.Text = "2ГИС Путеводитель";
            this.Load += new System.EventHandler(this.NewRoughts_Load);
            this.RouhtsTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.AllUserRoghts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl RouhtsTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button DeletePlaceRought;
        private System.Windows.Forms.Button AddPlaceRoght;
        private System.Windows.Forms.ListBox SelectedPlacesRoughts;
        private System.Windows.Forms.ListBox AllPlacesRoughts;
        private System.Windows.Forms.TabPage AllUserRoghts;
        private System.Windows.Forms.Button SaveNewRought;
        private System.Windows.Forms.ListBox MyRoughtsUser;
        private System.Windows.Forms.Button UsersRoughts;
        private System.Windows.Forms.Button BackToNewRoughts;
        private System.Windows.Forms.Button DeleteRought;
    }
}