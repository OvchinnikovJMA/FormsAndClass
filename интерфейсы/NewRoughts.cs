using DoubleGisGidClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace интерфейсы
{
    public partial class NewRoughts : Form
    {
        public User userForRought { get; set; }
        public Places AllPlaces { get; set; }
        public StartWindow startwindow = new StartWindow();
        CurrentUserLog CurrentUserLog;
        private XmlSerializer xs = new XmlSerializer(typeof(List<Rought>));
        public int index = 0;
        LOG LOG;
        private string[] FilesRoughts;
        private string path = @"C:\Users\teesh\source\repos\интерфейсы2\интерфейсы\bin\Debug";
        public NewRoughts()
        {
            InitializeComponent();
            CurrentUserLog = new CurrentUserLog();
            LOG = new LOG(CurrentUserLog);
        }

        private void NewRoughts_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < AllPlaces.ListOfPlaces.Count; i++)
            {
                var Place = AllPlaces.ListOfPlaces[i];
                AllPlacesRoughts.Items.Add(Place);
            }
            CurrentUserLog.currentLogin = userForRought.Login;
            CurrentUserLog.currentPassword = userForRought.Password;
            FilesRoughts = Directory.GetFiles(path, "*.roughts");
            if (FilesRoughts != null && FilesRoughts.Length > index)
            {
                var file = File.OpenRead("Маршруты пользователей.roughts");
                var OldUserRoughts = (List<Rought>)xs.Deserialize(file);
                file.Close();
                for (int i = 0; i < OldUserRoughts.Count; i++)
                {
                    MyRoughtsUser.Items.Add(OldUserRoughts[i]);
                }
            }
        }

        private void AllPlacesRoughts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            startwindow.GetPlaceMenu(AllPlacesRoughts, e);
        }

        private void SelectedPlacesRoughts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            startwindow.GetPlaceMenu(SelectedPlacesRoughts, e);
        }

        private void AddPlaceRoght_Click(object sender, EventArgs e)
        {
            LOG.DoLog(AddPlaceRoght.Name);
            if (AllPlacesRoughts.SelectedItem is Place)
            {
                SelectedPlacesRoughts.Items.Add(AllPlacesRoughts.SelectedItem);
            }
        }

        private void DeletePlaceRought_Click(object sender, EventArgs e)
        {
            LOG.DoLog(DeletePlaceRought.Name);
            if (SelectedPlacesRoughts.SelectedItem is Place)
            {
                SelectedPlacesRoughts.Items.Remove(SelectedPlacesRoughts.SelectedItem);
            }
        }

        private void AllPlacesRoughts_SelectedIndexChanged(object sender, EventArgs e)
        {
            LOG.DoLog(AllPlacesRoughts.Name);
            AddPlaceRoght.Enabled = AllPlacesRoughts.SelectedItem is Place;
        }

        private void SelectedPlacesRoughts_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeletePlaceRought.Enabled = SelectedPlacesRoughts.SelectedItem is Place;
        }

        private void SaveNewRought_Click(object sender, EventArgs e)
        {
            LOG.DoLog(SaveNewRought.Name);
            var rought = new Rought();
            userForRought.Roughts = new List<Rought>();
            rought.MyRought = new List<Place>();
            var place = new Place();
            for (int i = 0; i < SelectedPlacesRoughts.Items.Count; i++)
            {
                place = (Place)SelectedPlacesRoughts.Items[i];
                rought.MyRought.Add(place);
            }
            userForRought.Roughts.Add(rought);
            for(int i = 0; i < userForRought.Roughts.Count; i++)
            {
                MyRoughtsUser.Items.Add(userForRought.Roughts[i]);
            }
            var file = File.Create("Маршруты пользователей.roughts");
            xs.Serialize(file, userForRought.Roughts);
            file.Close();
            Close();
        }

        private void UsersRoughts_Click(object sender, EventArgs e)
        {
            LOG.DoLog(UsersRoughts.Name);
            index += 1;
            RouhtsTab.SelectedIndex = index;
            index = 0;
        }

        private void BackToNewRoughts_Click(object sender, EventArgs e)
        {
            LOG.DoLog(BackToNewRoughts.Name);
            RouhtsTab.SelectedIndex = index;
        }

        private void DeleteRought_Click(object sender, EventArgs e)
        {
            LOG.DoLog(DeleteRought.Name);
            if (MyRoughtsUser.SelectedItem is Rought)
            {
                MyRoughtsUser.Items.Remove(MyRoughtsUser.SelectedItem);
            }
        }
    }
}
