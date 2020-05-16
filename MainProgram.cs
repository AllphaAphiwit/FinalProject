using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.IO;

namespace Final_Project
{
    public partial class MainProgram : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public MainProgram()
        {
            InitializeComponent();
            getIm_userid();
            panalslide0.Visible = true;
            panalWaterRate1.Visible = false;
            panalWaterCal1.Visible = false;
            panalHisUse1.Visible = false;
            panalHis1.Visible = false;
            textboxtime.Enter += (s, e) => { textboxtime.Parent.Focus(); };
            textBoxdate.Enter += (s, e) => { textBoxdate.Parent.Focus(); };
            textboxuser.Enter += (s, e) => { textboxuser.Parent.Focus(); };
        }

        private void home_Click(object sender, EventArgs e)
        {
            panalslide0.Visible = true;
            panalslide1.Visible = false;
            panalslide2.Visible = false;
            panalslide3.Visible = false;
            panalslide4.Visible = false;
            panalWaterRate1.Visible = false;
            panalWaterCal1.Visible = false;
            panalHisUse1.Visible = false;
            panalHis1.Visible = false;

        }

        private void water_rate_Click(object sender, EventArgs e)
        {
            panalslide0.Visible = false;
            panalslide1.Visible = true;
            panalslide2.Visible = false;
            panalslide3.Visible = false;
            panalslide4.Visible = false;
            panalWaterRate1.Visible = true;
            panalWaterCal1.Visible = false;
            panalHisUse1.Visible = false;
            panalHis1.Visible = false;
        }

        private void water_cal_Click(object sender, EventArgs e)
        {
            panalslide0.Visible = false;
            panalslide1.Visible = false;
            panalslide2.Visible = true;
            panalslide3.Visible = false;
            panalslide4.Visible = false;
            panalWaterRate1.Visible = false;
            panalWaterCal1.Visible = true;
            panalHisUse1.Visible = false;
            panalHis1.Visible = false;

        }

        private void water_use_Click(object sender, EventArgs e)
        {
            panalslide0.Visible = false;
            panalslide1.Visible = false;
            panalslide2.Visible = false;
            panalslide3.Visible = true;
            panalslide4.Visible = false;
            panalWaterRate1.Visible = false;
            panalWaterCal1.Visible = false;
            panalHisUse1.Visible = true;
            panalHis1.Visible = false;
        }

        private void water_his_Click(object sender, EventArgs e)
        {
            panalslide0.Visible = false;
            panalslide1.Visible = false;
            panalslide2.Visible = false;
            panalslide3.Visible = false;
            panalslide4.Visible = true;
            panalWaterRate1.Visible = false;
            panalWaterCal1.Visible = false;
            panalHisUse1.Visible = false;
            panalHis1.Visible = true;
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private int temp;
        private void maxsi_Click(object sender, EventArgs e)
        {
            temp += 1;
            if(temp % 2 == 0)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }
        
        public void getIm_userid()
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
                byte[] pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                picturebox.Image  = Image.FromStream(picture);
                textboxuser.Text = table.Rows[0]["firstname"].ToString() + "  " + table.Rows[0]["surname"].ToString();
            }
        }

        private void logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            userlogin userlogin = new userlogin();
            userlogin.Show();
        }

        private void editprofile_Click(object sender, EventArgs e)
        {
            this.Hide();
            PanalEdit_Profies panalEdit_Profies = new PanalEdit_Profies();
            panalEdit_Profies.Show();
        }

        private void time_Tick(object sender, EventArgs e)
        {
            textboxtime.Text = DateTime.Now.ToShortTimeString();
            textBoxdate.Text = DateTime.Now.ToLongDateString();
        }

        private void taskbar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panalaccount_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void picturebox_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void textboxuser_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
