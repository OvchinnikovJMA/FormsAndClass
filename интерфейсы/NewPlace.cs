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
            var AllPlaces = new Places();
        }
        public Places AllPlaces { get; set; }
        public NewPlace(Places allPlaces)
        {
            InitializeComponent();
            AllPlaces = allPlaces;
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
        }

        Place Place = new Place();
        public void GetNewPlaceReg()
        {
            if (AllPlaces == null)
            {
                AllPlaces = new Places();
                AllPlaces.ListOfPlaces = new List<Place>();
            }   
            Place.Information = new Information();
            Place.Information.Address = new Address();
            Place.Information.Address.Street = new Street();
            Place.Rating = new Rating();
            Place.Name = NameOfPlaceSPM.Text;
            Place.Information.Address.City = EnterCityNewPlaceSpokesman.Text;
            Place.Information.Address.Region = EnterRegionNewPlaceSpokesman.Text;
            Place.Information.Address.Street.Name = EnterNameStreet.Text;
            Place.Information.Address.Street.Number = int.Parse(EnterNumberStreetSPM.Text);
            Place.Information.Discription = EnterDiscription.Text;
            Place.Information.SpokesmanName = EnterNameOfSpokesman.Text;
            Place.RegistrationDate = DateRegisterPicker.Value;
            var rand = new Random();
            Place.Rating.Likes = rand.Next(1, 20);
            Place.Rating.Dislikes = rand.Next(1, 5);
            AllPlaces.ListOfPlaces.Add(Place);
        }
        private void downloadnumber_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Contacts contacts = new Contacts();
            contacts.PhoneNumber = new List<string>();
            Place.Contacts = contacts;
            contacts.PhoneNumber.Add(EnterTelephones.Text);
            EnterTelephones.Clear();
        }

        private void downloadcontact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Contacts contacts = new Contacts();
            contacts.SocialContacts = new List<string>();
            Place.Contacts = contacts;
            contacts.SocialContacts.Add(EnterContacts.Text);
            EnterContacts.Clear();
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
                Image.FromFile(ofd.FileName).Save(stream, ImageFormat.Jpeg) ;
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
