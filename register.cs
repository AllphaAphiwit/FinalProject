using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Final_Project
{
    public partial class register : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public register()
        {
            InitializeComponent();
        }

        private void name_Enter(object sender, EventArgs e)
        {
            if (name.Text == "ชื่อ" || name.Text == "    ชื่อ")
            {
                warning1.Visible = false;
                name.ForeColor = Color.Gray;
                name.Text = "";
                lineShape1.BorderColor = Color.DarkGray;
            }
        }

        private void name_Leave(object sender, EventArgs e)
        {
            if (name.Text == "")
            {
                name.Text = "ชื่อ";
            }
        }

        private void surname_Enter(object sender, EventArgs e)
        {
            if (surname.Text == "นามสกุล" || surname.Text == "    นามสกุล")
            {
                warning2.Visible = false;
                surname.ForeColor = Color.Gray;
                surname.Text = "";
                lineShape6.BorderColor = Color.DarkGray;
            }
        }

        private void surname_Leave(object sender, EventArgs e)
        {
            if (surname.Text == "")
            {
                surname.Text = "นามสกุล";
            }
        }

        private void email_Enter(object sender, EventArgs e)
        {
            if (email.Text == "อีเมล์" || email.Text == "    อีเมล์")
            {
                warning3.Visible = false;
                email.ForeColor = Color.Gray;
                email.Text = "";
                lineShape2.BorderColor = Color.DarkGray;
            }
        }

        private void email_Leave(object sender, EventArgs e)
        {
            if (email.Text == "")
            {
                email.Text = "อีเมล์";
            }
        }

        private void number_Enter(object sender, EventArgs e)
        {
            if (number.Text == "เลขที่ผู้ใช้น้ำ 11 หลัก" || number.Text == "    เลขที่ผู้ใช้น้ำ 11 หลัก")
            {
                warning4.Visible = false;
                number.ForeColor = Color.Gray;
                number.Text = "";
                lineShape3.BorderColor = Color.DarkGray;
            }
        }

        private void number_Leave(object sender, EventArgs e)
        {
            if (number.Text == "")
            {
                number.Text = "เลขที่ผู้ใช้น้ำ 11 หลัก";
            }
        }

        private void number_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if(number.Text.Length == 11)
            {
                number.ForeColor = Color.Gray;
                lineShape3.BorderColor = Color.DarkGray;
            }
        }

        private void pass_Enter(object sender, EventArgs e)
        {
            if (pass.Text == "รหัสผ่าน" || pass.Text == "    รหัสผ่าน")
            {
                warning5.Visible = false;
                pass.ForeColor = Color.Gray;
                pass.Text = "";
                pass.UseSystemPasswordChar = true;
                lineShape4.BorderColor = Color.DarkGray;
            }
        }

        private void pass_Leave(object sender, EventArgs e)
        {
            if (pass.Text == "")
            {
                pass.Text = "รหัสผ่าน";
                pass.UseSystemPasswordChar = false;
            }
        }

        private void conpass_Enter(object sender, EventArgs e)
        {
            if (conpass.Text == "ยืนยันรหัสผ่าน" || conpass.Text == "    ยืนยันรหัสผ่าน")
            {
                warning6.Visible = false;
                conpass.ForeColor = Color.Gray;
                conpass.Text = "";
                conpass.UseSystemPasswordChar = true;
                lineShape5.BorderColor = Color.DarkGray;
            }
        }

        private void conpass_Leave(object sender, EventArgs e)
        {
            if (conpass.Text == "")
            {
                conpass.Text = "ยืนยันรหัสผ่าน";
                conpass.UseSystemPasswordChar = false;
            }
        }

        private void backtologin_Click(object sender, EventArgs e)
        {
            pictureBoxuser.Image = Image.FromFile(@"C:\Users\HP\Desktop\c#\FinalReferent\profile.png");
            MemoryStream picture = new MemoryStream();
            pictureBoxuser.Image.Save(picture, pictureBoxuser.Image.RawFormat);
            DataBaseUser dataBaseUser = new DataBaseUser();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`water_id`, `firstname`, `surname`, `email`, `password`, `picture`) VALUES (@wid, @fname, @sname, @email, @pass, @pic)", dataBaseUser.GetConnection());
            command.Parameters.Add("@wid", MySqlDbType.VarChar).Value = number.Text;
            command.Parameters.Add("@fname", MySqlDbType.VarChar).Value = name.Text;
            command.Parameters.Add("@sname", MySqlDbType.VarChar).Value = surname.Text;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass.Text;
            command.Parameters.Add("@pic", MySqlDbType.Blob).Value = picture.ToArray();
            dataBaseUser.openConnection();
            if(!checktextboxvalues())
            {
                if(pass.Text.Equals(conpass.Text))
                {
                    if (checkwater_id())
                    {
                        if (checkwater_id())
                        {
                            warning.Visible = true;
                            textwarning.ForeColor = Color.FromArgb(235, 73, 93);
                            textwarning.Text = "รหัสผู้ใช้น้ำมีอยู่แล้ว โปรดลองใหม่";
                        }
                    }
                    else
                    {
                        if (command.ExecuteNonQuery() == 1)
                        {
                            warning.Visible = false;
                            warning0.Visible = true;
                            textwarning.ForeColor = Color.FromArgb(0, 154, 159);
                            textwarning.Text = "สร้างบัญชีผู้ใช้สำเร็จ";
                        }
                    }
                }
                else
                {
                    warning.Visible = true;
                    textwarning.Text = "รหัสผ่านไม่ถูกต้อง";
                }
            }
            else
            {
                if(name.Text.Equals("ชื่อ"))
                {
                    name.Text = "    ชื่อ";
                    warning1.Visible = true;
                    name.ForeColor = Color.FromArgb(235, 73, 93);
                    lineShape1.BorderColor = Color.FromArgb(235, 73, 93);
                }
                if(surname.Text.Equals("นามสกุล"))
                {
                    surname.Text = "    นามสกุล";
                    warning2.Visible = true;
                    surname.ForeColor = Color.FromArgb(235, 73, 93);
                    lineShape6.BorderColor = Color.FromArgb(235, 73, 93);
                }
                if (email.Text.Equals("อีเมล์"))
                {
                    email.Text = "    อีเมล์";
                    warning3.Visible = true;
                    email.ForeColor = Color.FromArgb(235, 73, 93);
                    lineShape2.BorderColor = Color.FromArgb(235, 73, 93);
                }
                if (number.Text.Equals("เลขที่ผู้ใช้น้ำ 11 หลัก") || number.Text.Length < 11)
                {
                    number.Text = "    เลขที่ผู้ใช้น้ำ 11 หลัก";
                    warning4.Visible = true;
                    number.ForeColor = Color.FromArgb(235, 73, 93);
                    lineShape3.BorderColor = Color.FromArgb(235, 73, 93);
                }
                if (pass.Text.Equals("รหัสผ่าน"))
                {
                    pass.Text = "    รหัสผ่าน";
                    warning5.Visible = true;
                    pass.ForeColor = Color.FromArgb(235, 73, 93);
                    lineShape4.BorderColor = Color.FromArgb(235, 73, 93);
                }
                if (conpass.Text.Equals("ยืนยันรหัสผ่าน"))
                {
                    conpass.Text = "    ยืนยันรหัสผ่าน";
                    warning6.Visible = true;
                    conpass.ForeColor = Color.FromArgb(235, 73, 93);
                    lineShape5.BorderColor = Color.FromArgb(235, 73, 93);
                }
            }
            dataBaseUser.closeConnection();
        }

        public Boolean checkwater_id()
        {
            DataBaseUser dataBaseUser = new DataBaseUser();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `water_id` = @wid", dataBaseUser.GetConnection());
            command.Parameters.Add("@wid", MySqlDbType.VarChar).Value = number.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean checktextboxvalues()
        {
            if(name.Text.Equals("ชื่อ") || surname.Text.Equals("นามสกุล") || email.Text.Equals("อีเมล์") || number.Text.Equals("เลขที่ผู้ใช้น้ำ 11 หลัก")
                || pass.Text.Equals("รหัสผ่าน") || conpass.Text.Equals("ยืนยันรหัสผ่าน") || number.Text.Length < 11
                || name.Text.Equals("    ชื่อ") || surname.Text.Equals("    นามสกุล") || email.Text.Equals("    อีเมล์") || number.Text.Equals("    เลขที่ผู้ใช้น้ำ 11 หลัก")
                || pass.Text.Equals("    รหัสผ่าน") || conpass.Text.Equals("    ยืนยันรหัสผ่าน"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void intouserlogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            userlogin userlogin = new userlogin();
            userlogin.Show();
        }

        public DataTable GetUserEdit(Int64 id)
        {
            DataBaseUser dataBaseUser = new DataBaseUser();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `user_id` = @id", dataBaseUser.GetConnection());
            command.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        private void register_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
