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
    public partial class StartWindow : Form
    {
        CurrentUserLog CurrentUserLog;
        LOG LOG;
        OleDbConnection connection = new OleDbConnection(connectString);
        OleDbCommand commandReader = new OleDbCommand();
        public User user = new User();
        public XmlSerializer xs = new XmlSerializer(typeof(Places));
        public Places DataOfAllPlaces = new Places();
        public StartWindow()
        {
            InitializeComponent();
            CurrentUserLog = new CurrentUserLog();
            LOG = new LOG(CurrentUserLog);
        }
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data source=UsersData.accdb", path = @"C:\Users\teesh\source\repos\интерфейсы2\интерфейсы\bin\Debug";
        public int index = 0;
        public bool flag = true;
        public string[] Files;
        private void Enter_Click(object sender, EventArgs e)
        {
            while (flag)
            {
                commandReader.CommandType = CommandType.Text;
                commandReader.Connection = connection;
                commandReader.CommandText = "SELECT Login, EnterCode FROM UsersData";
                connection.Open();
                OleDbDataReader reader = commandReader.ExecuteReader();
                while (reader.Read())
                {
                    var successfulLogin = reader[0].ToString();
                    var successfulPassword = reader[1].ToString();
                    if (successfulLogin == LoginStartMenu.Text && successfulPassword == PasswordStartMenu.Text.ToString())
                    {
                        flag = false;
                        break;
                    }
                }
                reader.Close();
                connection.Close();
                if (flag && LoginStartMenu.Text.Length != 0)
                {
                    MessageBox.Show("Неверный логин или пароль", "2ГИС путеводитель", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                if (LoginStartMenu.Text.Length == 0)
                    flag = false;
            }
            if (flag == false)
            {
                CurrentUserLog.currentLogin = LoginStartMenu.Text;
                CurrentUserLog.currentPassword = PasswordStartMenu.Text;
                user.Login = CurrentUserLog.currentLogin;
                user.TypeOfUser = new TypeOfUser();
                if (LoginStartMenu.Text.Length != 0)
                {
                    commandReader.CommandType = CommandType.Text;
                    commandReader.Connection = connection;
                    commandReader.CommandText = "SELECT Login, TypeOfUser FROM UsersData";
                    connection.Open();
                    OleDbDataReader reader = commandReader.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader[0].ToString() == CurrentUserLog.currentLogin)
                            user.TypeOfUser.CurrentTypeOfUser = reader[1].ToString();
                    }
                    reader.Close();
                    connection.Close();
                    LOG.DoLog(Enter.Name);
                    if (user.TypeOfUser.CurrentTypeOfUser == "Представитель")
                    {
                        LoginSpokesMan.Text = LoginStartMenu.Text;
                        index += 4;
                        ProgramTab.SelectedIndex = index;
                        index = 0;
                    }
                    else if (user.TypeOfUser.CurrentTypeOfUser.Equals("Администратор"))
                    {
                        LoginAdmin.Text = LoginStartMenu.Text;
                        index += 5;
                        ProgramTab.SelectedIndex = index;
                        index = 0;
                    }
                    else
                    {
                        ActiveUser.Text = LoginStartMenu.Text;
                        index++;
                        ProgramTab.SelectedIndex = index;
                        index = 0;
                    }

                }
                else
                {
                    ActiveUser.Text = "Войдите в систему";
                    index++;
                    ProgramTab.SelectedIndex = index;
                    index = 0;
                    MyPlaces.Enabled = false;
                    MyRouteUser.Enabled = false;
                }
            }
            flag = true;
            if (Files != null && Files.Length > index && user.TypeOfUser.CurrentTypeOfUser == "Представитель")
            {
                for (int i = 0; i < DataOfAllPlaces.ListOfPlaces.Count; i++)
                {
                    var place = DataOfAllPlaces.ListOfPlaces[i];
                    if (place.Information.SpokesmanName == LoginSpokesMan.Text)
                    {
                        ListOfPlacesUser.Items.Add(place);
                    }
                }
            }
            if (Files != null && Files.Length > index && user.TypeOfUser.CurrentTypeOfUser == "Пользователь")
            {
                for (int i = 0; i < DataOfAllPlaces.ListOfPlaces.Count; i++)
                {
                    var place = DataOfAllPlaces.ListOfPlaces[i];
                    ListOfPlacesUser.Items.Add(place);
                    RecomPlacesUser.Items.Add(place);
                    VisitedPlacesUser.Items.Add(place);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void о_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var logouts = new PictureBox[] { Logout, LogoutSpokesman, LogoutAdmin };
            for (int i = 0; i < logouts.Length; i++)
            {
                logouts[i].Image = Image.FromFile(@"C:\Users\teesh\Desktop\Копия флешки\STORE N GO\Иконки\Logout.png");
                logouts[i].SizeMode = PictureBoxSizeMode.StretchImage;
            }
            Files = Directory.GetFiles(path, "*.places");
            if (Files != null && Files.Length > index)
            {
                var file = File.OpenRead("Список мест.places");
                DataOfAllPlaces = (Places)xs.Deserialize(file);
                file.Close();
                for (int i = 0; i < DataOfAllPlaces.ListOfPlaces.Count; i++)
                {
                    var place = DataOfAllPlaces.ListOfPlaces[i];
                    BestPlaceLastWeek.Items.Add(place);
                    PlacesForRating.Items.Add(place);
                }
            }

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AboutProgram_Click(object sender, EventArgs e)
        {
            LOG.DoLog(AboutProgram.Name);
            var form = new Form();
            var result = MessageBox.Show("2ГИС путеводитель v. 0.2 alpha\n" + "© 2019 Ovchinnikov JMA", "О приложении 2ГИС путеводитель", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MyPlaces_Click(object sender, EventArgs e)
        {
            LOG.DoLog(MyPlaces.Name);
            index += 2;
            ProgramTab.SelectedIndex = index;
            index = 0;
        }
        public void GetRatingMenu()
        {
            index += 3;
            ProgramTab.SelectedIndex = index;
            index = 0;

        }
        private void RatingUser_Click(object sender, EventArgs e)
        {
            LOG.DoLog(RatingUser.Name);
            GetRatingMenu();
        }

        private void Menu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void ActiveUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ActiveUser.Text == "Войдите в систему")
                ProgramTab.SelectedIndex = index;
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            LOG.DoLog(Logout.Name);
            ProgramTab.SelectedIndex = index;
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LOG.DoLog(DoRegistration.Name);
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
        }

        private void MyRouteUser_Click(object sender, EventArgs e)
        {
            LOG.DoLog(MyRouteUser.Name);
            var newRought = new NewRoughts() { AllPlaces = DataOfAllPlaces, userForRought = user };
            newRought.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (user.TypeOfUser.CurrentTypeOfUser == "Администратор")
            {
                LOG.DoLog(FromPlacesToMain3.Name);
                index += 5;
                ProgramTab.SelectedIndex = index;
                index = 0;
            }
            else if (user.TypeOfUser.CurrentTypeOfUser == "Представитель")
            {
                LOG.DoLog(FromPlacesToMain3.Name);
                index += 4;
                ProgramTab.SelectedIndex = index;
                index = 0;
            }
            else
            {
                LOG.DoLog(FromPlacesToMain3.Name);
                index++;
                ProgramTab.SelectedIndex = index;
                index = 0;
            }
        }

        private void FromPlacesToMain_Click(object sender, EventArgs e)
        {
            if (user.TypeOfUser.CurrentTypeOfUser == "Представитель")
            {
                LOG.DoLog(FromPlacesToMain.Name);
                index += 4;
                ProgramTab.SelectedIndex = index;
                index = 0;
            }
            else
            {
                LOG.DoLog(FromPlacesToMain.Name);
                index++;
                ProgramTab.SelectedIndex = index;
                index = 0;
            }
        }

        private void ListOfRoutes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NewPlaceSpokesman_Click(object sender, EventArgs e)
        {
            if (Files.Count() == 0)
            {
                var MenuNewPlace = new NewPlace();
                MenuNewPlace.Show();
            }
            else
            {
                var MenuNewPlace = new NewPlace() { AllPlaces = DataOfAllPlaces };
                MenuNewPlace.Show();
            }
        }

        private void RatingSpokesman_Click(object sender, EventArgs e)
        {
            LOG.DoLog(RatingSpokesman.Name);
            GetRatingMenu();
        }

        private void InfSpokesman_Click(object sender, EventArgs e)
        {
            LOG.DoLog(InfSpokesman.Name);
            var form = new Form();
            var result = MessageBox.Show("2ГИС путеводитель v. 0.6 alpha\n" + "© 2019 Ovchinnikov JMA", "О приложении 2ГИС путеводитель", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RatingAdmin_Click(object sender, EventArgs e)
        {
            GetRatingMenu();
        }

        private void ListOfPlacesUser_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GetPlaceMenu(ListOfPlacesUser, e);
        }

        private void LogoutAdmin_Click(object sender, EventArgs e)
        {
            ProgramTab.SelectedIndex = index;
            LoginStartMenu.Clear();
            PasswordStartMenu.Clear();
        }

        private void PlaceOfSpokesman_Click(object sender, EventArgs e)
        {
            LOG.DoLog(PlaceOfSpokesman.Name);
            index = 2;
            ProgramTab.SelectedIndex = index;
            index = 0;
        }

        private void LoginAdmin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void AddPlaceAdmin_Click(object sender, EventArgs e)
        {
            if (Files.Count() == 0)
            {
                var MenuNewPlace = new NewPlace();
                MenuNewPlace.Show();
            }
            else
            {
                var MenuNewPlace = new NewPlace() { AllPlaces = DataOfAllPlaces };
                MenuNewPlace.Show();
            }
        }

        private void LogoutSpokesman_Click(object sender, EventArgs e)
        {
            LOG.DoLog(LogoutSpokesman.Name);
            ProgramTab.SelectedIndex = index;
            LoginStartMenu.Clear();
            PasswordStartMenu.Clear();
        }
        public void GetPlaceMenu(ListBox listbox, MouseEventArgs e)
        {
            int index = listbox.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                var item = (Place)listbox.Items[index];
                if(ActiveUser.Text != "Войдите в систему")
                {
                    var pm = new PlaceMenu(user) { Place = item };
                    pm.Show();
                }
                else
                {
                    var pm = new PlaceMenu() { Place = item };
                    pm.Show();
                }
            }
        }
        private void BestPlaceLastWeek_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GetPlaceMenu(BestPlaceLastWeek, e);
        }

        private void RecomPlacesUser_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GetPlaceMenu(RecomPlacesUser, e);
        }

        private void VisitedPlacesUser_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GetPlaceMenu(VisitedPlacesUser, e);
        }

        private void PlacesForRating_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GetPlaceMenu(PlacesForRating, e);
        }

        private void ListOfUsers_Click(object sender, EventArgs e)
        {
            var listOfUsers = new ListOfUsersForm();
            listOfUsers.Show();
        }
    }
}