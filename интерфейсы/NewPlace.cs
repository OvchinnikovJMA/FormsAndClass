using DoubleGisGidClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace интерфейсы
{
    public partial class NewPlace : Form
    {
        public NewPlace()
        {
            InitializeComponent();
        }
        public bool flag = false;
        public StartWindow startWindow = new StartWindow();
        public Places AllPlaces { get; set; }
        public Place Place { get; set; }
        public int index = 0;
        public NewPlace(Places allPlaces, Place place)
        {
            AllPlaces = allPlaces;
            Place = place;
            InitializeComponent();
        }
        private void NewPlace_Load(object sender, EventArgs e)
        {
            RegionNewPlaceSpokesman.Visible = false;
            CityNewPlaceSpokesman.Visible = false;
            EnterRegionNewPlaceSpokesman.Visible = false;
            EnterCityNewPlaceSpokesman.Visible = false;
            StreetNewPlaceSpokesman.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            EnterNumberStreetSPM.Visible = false;
            EnterNameStreet.Visible = false;
            if (Place == null)
                Place = new Place();
            else
            {
                index = AllPlaces.ListOfPlaces.IndexOf(Place);
                ChangePlaceSettings();
            }            
        }

        public void ChangePlaceSettings()
        {
            flag = true;
            NameOfPlaceSPM.Text = Place.Name;
            EnterCityNewPlaceSpokesman.Text = Place.Information.City;
            EnterRegionNewPlaceSpokesman.Text = Place.Information.Region;
            EnterNameStreet.Text = Place.Information.NameOfStreet;
            EnterNumberStreetSPM.Text = Place.Information.NumberOfStreet.ToString();
            EnterDiscription.Text = Place.Information.Discription;
            EnterNameOfSpokesman.Text = Place.Information.SpokesmanName;
            DateRegisterPicker.Value = Place.RegistrationDate;
            for (int i = 0; i < Place.PhoneNumber.Count; i++)
                NumberComboBox.Items.Add(Place.PhoneNumber[i]);
            for (int i = 0; i < Place.SocialContacts.Count; i++)
                ContactsComboBox.Items.Add(Place.SocialContacts[i]);
        }

        public void GetNewPlaceReg()
        {
            if (AllPlaces == null)
            {
                AllPlaces = new Places();
                AllPlaces.ListOfPlaces = new List<Place>();
            }
            if(Place.Name == null)
            {
                Place.Information = new Information();
                var rand = new Random();
                Place.Likes = rand.Next(1, 20).ToString();
                Place.Dislikes = rand.Next(1, 5).ToString();
            }
            Place.Name = NameOfPlaceSPM.Text;
            Place.Information.City = EnterCityNewPlaceSpokesman.Text;
            Place.Information.Region = EnterRegionNewPlaceSpokesman.Text;
            Place.Information.NameOfStreet = EnterNameStreet.Text;
            Place.Information.NumberOfStreet = int.Parse(EnterNumberStreetSPM.Text);
            Place.Information.Discription = EnterDiscription.Text;
            Place.Information.SpokesmanName = EnterNameOfSpokesman.Text;
            Place.RegistrationDate = DateRegisterPicker.Value;
            if (!flag)
                AllPlaces.ListOfPlaces.Add(Place);
            else AllPlaces.ListOfPlaces[index] = Place;
        }
        private void downloadnumber_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Place.PhoneNumber = new List<string>();
            Place.PhoneNumber.Add(NumberComboBox.Text);
            NumberComboBox.Items.Add(NumberComboBox.Text);
            if (Place.PhoneNumber.Count == 0)
                Place.PhoneNumber.Add("Нет номера");
            NumberComboBox.Text = "";
        }

        private void downloadcontact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Place.SocialContacts = new List<string>();
            ContactsComboBox.Items.Add(ContactsComboBox.Text);
            Place.SocialContacts.Add(ContactsComboBox.Text);
            if (Place.SocialContacts.Count == 0)
                Place.SocialContacts.Add("Нет контактов");
            ContactsComboBox.Text = "";
        }

        private void AddressNewPlaceSpokesman_Click(object sender, EventArgs e)
        {
            if (RegionNewPlaceSpokesman.Visible)
                RegionNewPlaceSpokesman.Visible = false;
            else RegionNewPlaceSpokesman.Visible = true;
            if (CityNewPlaceSpokesman.Visible)
                CityNewPlaceSpokesman.Visible = false;
            else CityNewPlaceSpokesman.Visible = true;
            if (EnterRegionNewPlaceSpokesman.Visible)
                EnterRegionNewPlaceSpokesman.Visible = false;
            else EnterRegionNewPlaceSpokesman.Visible = true;
            if (EnterCityNewPlaceSpokesman.Visible)
                EnterCityNewPlaceSpokesman.Visible = false;
            else EnterCityNewPlaceSpokesman.Visible = true;
            if (StreetNewPlaceSpokesman.Visible)
                StreetNewPlaceSpokesman.Visible = false;
            else StreetNewPlaceSpokesman.Visible = true;
        }

        private void StreetNewPlaceSpokesman_Click(object sender, EventArgs e)
        {
            if (label1.Visible)
                label1.Visible = false;
            else label1.Visible = true;
            if (label2.Visible)
                label2.Visible = false;
            else label2.Visible = true;
            if (EnterNumberStreetSPM.Visible)
                EnterNumberStreetSPM.Visible = false;
            else EnterNumberStreetSPM.Visible = true;
            if (EnterNameStreet.Visible)
                EnterNameStreet.Visible = false;
            else EnterNameStreet.Visible = true;
        }

        private void PotoNewPlaceSpokesman_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "Фотография|*.jpg" };
            var dr = ofd.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                var stream = new MemoryStream();
                Image.FromFile(ofd.FileName).Save(stream, ImageFormat.Jpeg);
                Place.MainPhoto = stream.ToArray();
            }
        }

        private void NewPlaceComplete_Click(object sender, EventArgs e)
        {
            GetNewPlaceReg();
            var xs = new XmlSerializer(typeof(Places));
            var file = File.Create("Список мест.places");
            xs.Serialize(file, AllPlaces);
            file.Close();
            Close();
        }
    }
}
