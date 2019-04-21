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
    public partial class ListOfUsersForm : Form
    {
        public ListOfUsersForm()
        {
            InitializeComponent();
        }
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data source=UsersData.accdb";
        OleDbConnection connection = new OleDbConnection(connectString);
        OleDbCommand commandReader = new OleDbCommand();
        private void ListOfUsers_Load(object sender, EventArgs e)
        {
            commandReader.CommandType = CommandType.Text;
            commandReader.Connection = connection;
            commandReader.CommandText = "SELECT Number, Login, Sex, TypeOfUser FROM UsersData";
            connection.Open();
            OleDbDataReader reader = commandReader.ExecuteReader();
            while (reader.Read())
            {
                ListboxOfUsers.Items.Add(reader[0].ToString() + ". " + reader[1].ToString() + " | " + reader[2].ToString() + " | " + reader[3].ToString() + " |");
            }
            reader.Close();
            connection.Close();
        }
    }
}
