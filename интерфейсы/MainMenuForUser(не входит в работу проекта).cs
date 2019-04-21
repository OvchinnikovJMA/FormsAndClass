using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace интерфейсы
{
    public partial class MainMenuForUser : Form
    {
        public MainMenuForUser(string text)
        {
            InitializeComponent();
            LoginEnterUser.Text = text;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            var massive = new PictureBox[] {LikePicture1, LikePicture2, RecomendedLikePicture1,
                RecomendedLikePicture2, DisLikePicture1, DisLikePicture2,
                RecomendedDisLikePicture1, RecomendedDisLikePicture2};
            for (int i = 0; i < 4; i++)
            {
                massive[i].Image = Image.FromFile(@"C:\Users\teesh\Desktop\Копия флешки\STORE N GO\Иконки\img_165452.png");
                massive[i].SizeMode = PictureBoxSizeMode.StretchImage;
            }

            for (int i = 4; i < 8; i++)
            {
                massive[i].Image = Image.FromFile(@"C:\Users\teesh\Desktop\Копия флешки\STORE N GO\Иконки\Dislike.png");
                massive[i].SizeMode = PictureBoxSizeMode.StretchImage;
            }
            Logout.Image = Image.FromFile(@"C:\Users\teesh\Desktop\Копия флешки\STORE N GO\Иконки\Logout.png");
            Logout.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void FirstLine_Click(object sender, EventArgs e)
        {

        }

        private void MyPlaces_Click(object sender, EventArgs e)
        {
            var haritonPark = new PlaceMenu();
            haritonPark.Show();
        }

        private void AboutProgram_Click(object sender, EventArgs e)
        {
            var form = new Form();
            var result = MessageBox.Show("2ГИС путеводитель v. 0.2 alpha\n" + "© 2019 Ovchinnikov JMA", "О приложении 2ГИС путеводитель", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoginEnterUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }
    }
}
