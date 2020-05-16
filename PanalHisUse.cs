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

namespace Final_Project
{
    public partial class PanalHisUse : UserControl
    {
        MySqlConnection sqlConnection = new MySqlConnection("server = localhost;port = 3306;username = root;password =;database = data_user");
        public string thename;

        public PanalHisUse()
        {
            InitializeComponent();
        }

        private void PanalHisUse_Load(object sender, EventArgs e)
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
                thename = "" + table.Rows[0]["water_id"] + "";
            }
            searchData(thename);
        }

        public void searchData(string Value)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT `water_date`, `water_use`, `water_price`, `water_service`, `water_tax`, `water_result` FROM datause_water WHERE CONCAT(water_id) LIKE '%" + Value + "%'", sqlConnection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            GridView1.DataSource = table;
            GridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridView1.AllowUserToAddRows = false;
        }
    }
}
