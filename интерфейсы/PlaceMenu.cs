using DoubleGisGidClasses;
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
    public partial class PlaceMenu : Form
    {
        public PlaceMenu()
        {
            InitializeComponent();
        }
        public Place Place {get; set;}
        private void Form4_Load(object sender, EventArgs e)
        {
            PhotoPlace.Image = Image.FromFile(@"C:\Users\teesh\Desktop\Копия флешки\STORE N GO\Иконки\Харитоновский парк.jpg");
            PhotoPlace.SizeMode = PictureBoxSizeMode.StretchImage;
            LikePicture1Info.Image = Image.FromFile(@"C:\Users\teesh\Desktop\Копия флешки\STORE N GO\Иконки\img_165452.png");
            LikePicture1Info.SizeMode = PictureBoxSizeMode.StretchImage;
            DisLikePicture1Info.Image = Image.FromFile(@"C:\Users\teesh\Desktop\Копия флешки\STORE N GO\Иконки\Dislike.png");
            DisLikePicture1Info.SizeMode = PictureBoxSizeMode.StretchImage;
            CommLikePicture1.Image = Image.FromFile(@"C:\Users\teesh\Desktop\Копия флешки\STORE N GO\Иконки\img_165452.png");
            CommLikePicture1.SizeMode = PictureBoxSizeMode.StretchImage;
            CommDisLikePicture1.Image = Image.FromFile(@"C:\Users\teesh\Desktop\Копия флешки\STORE N GO\Иконки\Dislike.png");
            CommDisLikePicture1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = Image.FromFile(@"C:\Users\teesh\Desktop\Копия флешки\STORE N GO\Иконки\img_165452.png");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Image = Image.FromFile(@"C:\Users\teesh\Desktop\Копия флешки\STORE N GO\Иконки\Dislike.png");
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void CommDisLikePicture1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
