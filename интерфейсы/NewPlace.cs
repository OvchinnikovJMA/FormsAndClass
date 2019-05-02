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
            //if (Place.Contacts.SocialContacts == null)
            //    Place.Contacts.SocialContacts = new Contacts;
            flag = true;
            NameOfPlaceSPM.Text = Place.Name;
            EnterCityNewPlaceSpokesman.Text = Place.Information.Address.City;
            EnterRegionNewPlaceSpokesman.Text = Place.Information.Address.Region;
            EnterNameStreet.Text = Place.Information.Address.Street.Name;
            EnterNumberStreetSPM.Text = Place.Information.Address.Street.Number.ToString();
            EnterDiscription.Text = Place.Information.Discription;
            EnterNameOfSpokesman.Text = Place.Information.SpokesmanName;
            DateRegisterPicker.Value = Place.RegistrationDate;
            for (int i = 0; i < Place.Contacts.PhoneNumber.Count; i++)
                NumberComboBox.Items.Add(Place.Contacts.PhoneNumber[i]);
            for (int i = 0; i < Place.Contacts.SocialContacts.Count; i++)
                ContactsComboBox.Items.Add(Place.Contacts.SocialContacts[i]);

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
                Place.Information.Address = new Address();
                Place.Information.Address.Street = new Street();
                Place.Rating = new Rating();
                var rand = new Random();
                Place.Rating.Likes = rand.Next(1, 20);
                Place.Rating.Dislikes = rand.Next(1, 5);
            }
            Place.Name = NameOfPlaceSPM.Text;
            Place.Information.Address.City = EnterCityNewPlaceSpokesman.Text;
            Place.Information.Address.Region = EnterRegionNewPlaceSpokesman.Text;
            Place.Information.Address.Street.Name = EnterNameStreet.Text;
            Place.Information.Address.Street.Number = int.Parse(EnterNumberStreetSPM.Text);
            Place.Information.Discription = EnterDiscription.Text;
            Place.Information.SpokesmanName = EnterNameOfSpokesman.Text;
            Place.RegistrationDate = DateRegisterPicker.Value;
            if (!flag)
                AllPlaces.ListOfPlaces.Add(Place);
            else AllPlaces.ListOfPlaces[index] = Place;
        }
        private void downloadnumber_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Contacts contacts = new Contacts();
            contacts.PhoneNumber = new List<string>();
            Place.Contacts = contacts;
            contacts.PhoneNumber.Add(NumberComboBox.Text);
            NumberComboBox.Items.Add(NumberComboBox.Text);
            if (contacts.PhoneNumber.Count == 0)
                contacts.PhoneNumber.Add("Нет номера");
            NumberComboBox.Text = "";
        }

        private void downloadcontact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Contacts contacts = new Contacts();
            contacts.SocialContacts = new List<string>();
            Place.Contacts = contacts;
            ContactsComboBox.Items.Add(ContactsComboBox.Text);
            contacts.SocialContacts.Add(ContactsComboBox.Text);
            if (contacts.SocialContacts.Count == 0)
                contacts.SocialContacts.Add("Нет контактов");
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
