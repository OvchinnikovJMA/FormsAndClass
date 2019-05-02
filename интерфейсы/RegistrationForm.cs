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
using DoubleGisGidClasses;

namespace интерфейсы
{

    public partial class RegistrationForm : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data source=UsersData.accdb";
        public User user = new User();
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            textBox3.Visible = false;
            RegistrationButton.Enabled = false;

        }

        private void AnotherGender_CheckedChanged(object sender, EventArgs e)
        {
            if (AnotherGender.Checked == true)
            {
                textBox3.Visible = true;
            }
            else
            {
                textBox3.Visible = false;
            }
            RegistrationButton.Enabled = RegistrationLogin.Text.Length > 0 && RegistrationPassword.Text.Length > 0
               && (WomanGender.Checked || ManGender.Checked || AnotherGender.Checked)
               && (User.Checked || SpokesmanOfPlace.Checked || Admin.Checked);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            RegistrationButton.Enabled = RegistrationLogin.Text.Length > 0 && RegistrationPassword.Text.Length > 0
               && (WomanGender.Checked || ManGender.Checked || AnotherGender.Checked)
               && (User.Checked || SpokesmanOfPlace.Checked || Admin.Checked);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            RegistrationButton.Enabled = RegistrationLogin.Text.Length > 0 && RegistrationPassword.Text.Length > 0
               && (WomanGender.Checked || ManGender.Checked || AnotherGender.Checked)
               && (User.Checked || SpokesmanOfPlace.Checked || Admin.Checked); ;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void WomanGender_CheckedChanged(object sender, EventArgs e)
        {
            RegistrationButton.Enabled = RegistrationLogin.Text.Length > 0 && RegistrationPassword.Text.Length > 0
                && (WomanGender.Checked || ManGender.Checked || AnotherGender.Checked)
                && (User.Checked || SpokesmanOfPlace.Checked || Admin.Checked);
        }

        private void RegestrationButton_Click(object sender, EventArgs e)
        {
            user.TypeOfUser = new TypeOfUser();
            user.GenderType = new GenderType();
            user.Login = RegistrationLogin.Text.ToString();
            user.Password = Hash.encrypt(RegistrationPassword.Text.ToString());
            if (WomanGender.Checked)
                user.GenderType.CurrentTypeOfGender = "Женщина";
            else if (ManGender.Checked)
                user.GenderType.CurrentTypeOfGender = "Мужчина";
            else user.GenderType.CurrentTypeOfGender = "Другой";
            if (User.Checked)
                user.TypeOfUser.CurrentTypeOfUser = "Пользователь";
            else if (SpokesmanOfPlace.Checked)
                user.TypeOfUser.CurrentTypeOfUser = "Представитель";
            else user.TypeOfUser.CurrentTypeOfUser = "Админиcтратор";
            OleDbConnection connection = new OleDbConnection(connectString);
            OleDbCommand commandInsert = new OleDbCommand();
            commandInsert.CommandType = CommandType.Text;
            commandInsert.Connection = connection;
            commandInsert.CommandText = "INSERT into UsersData (Login, EnterCode, Sex, TypeOfUser) VALUES ('" + user.Login + "', '" + user.Password + "', '" + user.GenderType.CurrentTypeOfGender.ToString() + "', '" + user.TypeOfUser.CurrentTypeOfUser.ToString() + "')";
            connection.Open();
            commandInsert.ExecuteNonQuery();
            connection.Close();
            Close();
        }

        private void ManGender_CheckedChanged(object sender, EventArgs e)
        {
            RegistrationButton.Enabled = RegistrationLogin.Text.Length > 0 && RegistrationPassword.Text.Length > 0
               && (WomanGender.Checked || ManGender.Checked || AnotherGender.Checked)
               && (User.Checked || SpokesmanOfPlace.Checked || Admin.Checked);
        }

        private void User_CheckedChanged(object sender, EventArgs e)
        {
            RegistrationButton.Enabled = RegistrationLogin.Text.Length > 0 && RegistrationPassword.Text.Length > 0
               && (WomanGender.Checked || ManGender.Checked || AnotherGender.Checked)
               && (User.Checked || SpokesmanOfPlace.Checked || Admin.Checked);
        }

        private void SpokesmanOfPlace_CheckedChanged(object sender, EventArgs e)
        {
            RegistrationButton.Enabled = RegistrationLogin.Text.Length > 0 && RegistrationPassword.Text.Length > 0
               && (WomanGender.Checked || ManGender.Checked || AnotherGender.Checked)
               && (User.Checked || SpokesmanOfPlace.Checked || Admin.Checked);
        }

        private void Admin_CheckedChanged(object sender, EventArgs e)
        {
            RegistrationButton.Enabled = RegistrationLogin.Text.Length > 0 && RegistrationPassword.Text.Length > 0
               && (WomanGender.Checked || ManGender.Checked || AnotherGender.Checked)
               && (User.Checked || SpokesmanOfPlace.Checked || Admin.Checked);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}