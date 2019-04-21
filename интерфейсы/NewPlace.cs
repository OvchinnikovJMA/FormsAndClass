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
        Places Places = new Places();
        public void GetNewPlaceReg()
        { 
            Place.Name = NameOfPlaceSPM.Text;
            Place.Information.Address.City = EnterCityNewPlaceSpokesman.Text;
            Place.Information.Address.Region = EnterRegionNewPlaceSpokesman.Text;
            Place.Information.Address.Street.Name = EnterNameStreet.Text;
            Place.Information.Address.Street.Number = int.Parse(EnterNumberStreetSPM.Text);
            Place.Information.Discription = DiscriptionNewPlaceSpokesman.Text;
            Place.Information.SpokesmanName = EnterNameOfSpokesman.Text;
            Place.RegistrationDate = DateRegisterPicker.Value;

            Places.ListOfPlaces.Add(Place);
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
            var sfd = new SaveFileDialog() { Filter = "Список Мест|*.places" };

            if (sfd.ShowDialog(this) != DialogResult.OK)
                return;
            var xs = new XmlSerializer(typeof(Places));
            var file = File.Create(sfd.FileName);
            xs.Serialize(file, Places);
            file.Close();
        }
    }
}
