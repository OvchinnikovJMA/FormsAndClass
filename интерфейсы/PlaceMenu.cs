﻿using DoubleGisGidClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace интерфейсы
{
    public partial class PlaceMenu : Form
    {
        public int number;
        public bool flag = false, flag2 = false, flag3 = false;
        public PlaceMenu()
        {
            InitializeComponent();
        }
        public PlaceMenu(User user)
        {
            userForplace = user;
            InitializeComponent();
        }
        public User userForplace { get; set; }
        public Place Place {get; set;}
        public Information Information = new Information();
        public readonly Label addressText = new Label();
        public readonly Label contactsText = new Label();
        private void Form4_Load(object sender, EventArgs e)
        {
            var ms = new MemoryStream(Place.MainPhoto);
            PhotoPlace.Image = Image.FromStream(ms);
            PhotoPlace.SizeMode = PictureBoxSizeMode.StretchImage;
            NameOfPlace.Text = Place.Name;
            InfoLikeNumber.Text = Place.Likes.ToString();
            InfoDisLikeNumber.Text = Place.Dislikes.ToString();
            InformationPlaceInfo.Text = Place.Information.Discription;
            LikePicture1Info.Image = Image.FromFile(@"C:\Users\teesh\Desktop\Копия флешки\STORE N GO\Иконки\img_165452.png");
            LikePicture1Info.SizeMode = PictureBoxSizeMode.StretchImage;
            DisLikePicture1Info.Image = Image.FromFile(@"C:\Users\teesh\Desktop\Копия флешки\STORE N GO\Иконки\Dislike.png");
            DisLikePicture1Info.SizeMode = PictureBoxSizeMode.StretchImage;
            GetAddress();
            GetContacts();
        }
        public void GetAddress()
        {
            splitContainer1.Panel2.Controls.Add(addressText);
            addressText.Location = new Point(15, InformationPlaceInfo.Location.Y + InformationPlaceInfo.Height + 10);
            addressText.Width = 448;
            addressText.Text = $"г.{Place.Information.City}, Улица: {Place.Information.NameOfStreet}, Номер: {Place.Information.NumberOfStreet}";
        }
        public void GetContacts()
        {
            splitContainer1.Panel2.Controls.Add(contactsText);
            contactsText.Location = new Point(15, addressText.Height + addressText.Location.Y + 10);
            contactsText.Width = 448;
            contactsText.AutoSize = true;
            contactsText.Text = $" Номер телефона: ";
            for (int i = 0; i < Place.PhoneNumber.Count; i++)
            {
                contactsText.Text += $"{Place.PhoneNumber[i]} ";
            }
            contactsText.Text += $"\n Контакты: ";
            for (int i = 0; i < Place.SocialContacts.Count; i++)
            {
                contactsText.Text += $"{Place.SocialContacts[i]} ";
            }           
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

        private void LikePicture1Info_Click(object sender, EventArgs e)
        {
            
        }
        private void DisLikePicture1Info_Click(object sender, EventArgs e)
        {
            
        }
    }
}
