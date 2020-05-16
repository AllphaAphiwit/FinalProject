using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace Final_Project
{
    public partial class userlogin : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public userlogin()
        {
            InitializeComponent();
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void signin_Click(object sender, EventArgs e)
        {
            String water_id = textboxwater_id.Text;
            String password = textboxpassword.Text;

            DataBaseUser dataBaseUser = new DataBaseUser();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `water_id` = @wid AND `password` = @pass", dataBaseUser.GetConnection());
            command.Parameters.Add("@wid", MySqlDbType.VarChar).Value = water_id;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MySqlCommand my = new MySqlCommand("INSERT INTO `login_history`(`water_id`, `logintime`) VALUES (@water, @date)", dataBaseUser.GetConnection());
                my.Parameters.Add("@water", MySqlDbType.VarChar).Value = water_id;
                my.Parameters.Add("@date", MySqlDbType.VarChar).Value = DateTime.Now.ToShortTimeString() + "  |  " + DateTime.Now.ToLongDateString();
                dataBaseUser.openConnection();
                my.ExecuteNonQuery();
                dataBaseUser.closeConnection();

                int userid = Convert.ToInt32(table.Rows[0][0].ToString());
                Globals.SetGlobal_userid(userid);
                this.Hide();
                Wellcome wellcome = new Wellcome();
                wellcome.ShowDialog();
                MainProgram mainProgram = new MainProgram();
                mainProgram.Show();
            }
            else
            {
                if (textboxwater_id.Text.Equals("เลขที่ผู้ใช้น้ำ") && !textboxpassword.Text.Equals("รหัสผ่าน"))
                {
                    warning.Visible = true;
                    textwarning.Text = "ชื่อผู้ใช้ไม่ถูกต้อง";
                }
                else if (textboxpassword.Text.Equals("รหัสผ่าน") && !textboxwater_id.Text.Equals("เลขที่ผู้ใช้น้ำ"))
                {
                    warning.Visible = true;
                    textwarning.Text = "รหัสผ่านไม่ถูกต้อง";
                }
                else if (textboxwater_id.Text.Equals("เลขที่ผู้ใช้น้ำ") && textboxpassword.Text.Equals("รหัสผ่าน"))
                {
                    warning.Visible = true;
                    textwarning.Text = "กรุณากรอกเลขที่ผู้ใช้น้ำ และรหัสผ่าน";
                }
                else
                {
                    warning.Visible = true;
                    textwarning.Text = "เลขที่ผู้ใช้น้ำ หรือรหัสผ่านไม่ถูกต้อง";
                }
            }
        }

        private void textboxwater_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textboxwater_id_Enter(object sender, EventArgs e)
        {
            if (textboxwater_id.Text == "เลขที่ผู้ใช้น้ำ")
            {
                textboxwater_id.Text = "";
            }
        }

        private void textboxwater_id_Leave(object sender, EventArgs e)
        {
            if (textboxwater_id.Text == "")
            {
                textboxwater_id.Text = "เลขที่ผู้ใช้น้ำ";
            }
        }

        private void textboxpassword_Enter(object sender, EventArgs e)
        {
            if (textboxpassword.Text == "รหัสผ่าน")
            {
                textboxpassword.UseSystemPasswordChar = true;
                textboxpassword.Text = "";
            }
        }

        private void textboxpassword_Leave(object sender, EventArgs e)
        {
            if (textboxpassword.Text == "")
            {
                textboxpassword.UseSystemPasswordChar = false;
                textboxpassword.Text = "รหัสผ่าน";
            }
        }

        private void intoregister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            register register = new register();
            register.Show();
        }
    }
}
