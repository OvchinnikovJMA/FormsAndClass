using DoubleGisGidClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace интерфейсы
{
    public partial class StartWindow : Form
    {
        CurrentUserLog CurrentUserLog;
        LOG LOG;
        OleDbConnection connection = new OleDbConnection(connectString);
        OleDbCommand commandReader = new OleDbCommand();
        public StartWindow()
        {
            InitializeComponent();
            CurrentUserLog = new CurrentUserLog();
            LOG = new LOG(CurrentUserLog);
        }
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data source=UsersData.accdb";
        public int index = 0;
        public bool flag = true;
        public string typeOfUser = null;
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
                            typeOfUser = reader[1].ToString();
                    }
                    reader.Close();
                    connection.Close();
                    LOG.DoLog(Enter.Name);
                    if (typeOfUser == "Представитель")
                    {
                        LoginSpokesMan.Text = LoginStartMenu.Text;
                        index += 5;
                        ProgramTab.SelectedIndex = index;
                        index = 0;
                    }
                    else if (typeOfUser.Equals("Администратор"))
                    {
                        LoginAdmin.Text = LoginStartMenu.Text;
                        index += 6;
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
                }
            }
            flag = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void о_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var massive = new PictureBox[] {LikePictureVisited1, LikePictureVisited2, LikePictureStart1,
                LikePictureStart2, RecomendedLikePicture1, RecomendedLikePicture2,
                DisLikePictureVisited1, DisLikePictureVisited2,DisLikePictureStart1, DisLikePictureStart2,
                RecomendedDisLikePicture1, RecomendedDisLikePicture2};
            for (int i = 0; i < 6; i++)
            {
                massive[i].Image = Image.FromFile(@"C:\Users\teesh\Desktop\Копия флешки\STORE N GO\Иконки\img_165452.png");
                massive[i].SizeMode = PictureBoxSizeMode.StretchImage;
            }

            for (int i = 6; i < 12; i++)
            {
                massive[i].Image = Image.FromFile(@"C:\Users\teesh\Desktop\Копия флешки\STORE N GO\Иконки\Dislike.png");
                massive[i].SizeMode = PictureBoxSizeMode.StretchImage;
            }
            Logout.Image = Image.FromFile(@"C:\Users\teesh\Desktop\Копия флешки\STORE N GO\Иконки\Logout.png");
            Logout.SizeMode = PictureBoxSizeMode.StretchImage;
            LogoutSpokesman.Image = Image.FromFile(@"C:\Users\teesh\Desktop\Копия флешки\STORE N GO\Иконки\Logout.png");
            LogoutSpokesman.SizeMode = PictureBoxSizeMode.StretchImage;
            LogoutAdmin.Image = Image.FromFile(@"C:\Users\teesh\Desktop\Копия флешки\STORE N GO\Иконки\Logout.png");
            LogoutAdmin.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void TableOfBestPlaces_Paint(object sender, PaintEventArgs e)
        {
            
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
            ListOfPlacesUser.Items.Clear();
        }
        public void GetRatingMenu()
        {
            index += 4;
            ProgramTab.SelectedIndex = index;
            index = 0;
            PlacesForRating.Items.Clear();
            string connectPlaceData = "Provider=Microsoft.ACE.OLEDB.12.0;Data source=PlacesData.accdb";
            OleDbConnection connection = new OleDbConnection(connectPlaceData);
            OleDbCommand commandReader = new OleDbCommand();
            commandReader.CommandType = CommandType.Text;
            commandReader.Connection = connection;
            commandReader.CommandText = "SELECT Номер, Имя, Лайки, Дизлайки FROM PlacesData ORDER BY Номер";
            connection.Open();
            OleDbDataReader reader = commandReader.ExecuteReader();
            while (reader.Read())
            {
                PlacesForRating.Items.Add(reader[0].ToString() + ".  " + reader[1].ToString() + ";  " + reader[2].ToString() + " лайка;  " + reader[3].ToString() + " дизлайка|");
            }
            reader.Close();
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
            if(ActiveUser.Text == "Войдите в систему")
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
            index += 3;
            ProgramTab.SelectedIndex = index;
            index = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(typeOfUser == "Администратор")
            {
                LOG.DoLog(FromPlacesToMain3.Name);
                index += 6;
                ProgramTab.SelectedIndex = index;
                index = 0;
            }
            else if(typeOfUser == "Представитель")
            {
                LOG.DoLog(FromPlacesToMain3.Name);
                index +=5;
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

        private void FromPlacesToMain2_Click(object sender, EventArgs e)
        {
            LOG.DoLog(FromPlacesToMain2.Name);
            index++;
            ProgramTab.SelectedIndex = index;
            index = 0;
        }

        private void FromPlacesToMain_Click(object sender, EventArgs e)
        {
            if (typeOfUser == "Представитель")
            {
                LOG.DoLog(FromPlacesToMain.Name);
                index += 5;
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
            var MenuNewPlace = new NewPlace();
            MenuNewPlace.Show();


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
            var result = MessageBox.Show("2ГИС путеводитель v. 0.2 alpha\n" + "© 2019 Ovchinnikov JMA", "О приложении 2ГИС путеводитель", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RatingAdmin_Click(object sender, EventArgs e)
        {
            LOG.DoLog(RatingAdmin.Name);
            GetRatingMenu();
        }

        private void ListOfPlacesUser_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = ListOfPlacesUser.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                var item = (Place)ListOfPlacesUser.Items[index];
                var pm = new PlaceMenu() { Place = item };
                pm.Show();
            }
        }

        private void LogoutAdmin_Click(object sender, EventArgs e)
        {
            LOG.DoLog(Logout.Name);
            ProgramTab.SelectedIndex = index;
        }

        private void ListOfUsers_Click(object sender, EventArgs e)
        {
            var listOfUsers = new ListOfUsersForm();
            listOfUsers.Show();
        }
    }
}
