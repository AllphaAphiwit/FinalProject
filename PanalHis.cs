using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace Final_Project
{
    public partial class PanalHis : UserControl
    {
        MySqlConnection sqlConnection = new MySqlConnection("server = localhost;port = 3306;username = root;password =;database = data_user");
        public string thename;
        public PanalHis()
        {
            InitializeComponent();
        }

        private void PanalHis_Load(object sender, EventArgs e)
        {
            DataBaseUser dataBaseUser = new DataBaseUser();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `user_id` = @id", dataBaseUser.GetConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Globals.Global_userid;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                thename = ""+table.Rows[0]["water_id"]+"";
            }
            searchData(thename); 
        }
       
        public void searchData(string Value)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT login_history.water_id,users.firstname,users.surname,login_history.logintime FROM login_history,users WHERE users.water_id = login_history.water_id AND login_history.water_id LIKE '%"+Value+"%'", sqlConnection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            GridView1.DataSource = table;
            GridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridView1.AllowUserToAddRows = false;
        }
    }
}
