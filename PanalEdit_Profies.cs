using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Final_Project
{
    public partial class PanalEdit_Profies : Form
    {
        string temp;
        public PanalEdit_Profies()
        {
            InitializeComponent();
            warning.Visible = false;
        }
        register Register = new register();

        private void PanalEdit_Profies_Load(object sender, EventArgs e)
        {
            DataTable table = Register.GetUserEdit(Globals.Global_userid);
            temp = table.Rows[0][1].ToString();
            name.Text = table.Rows[0][2].ToString();
            surname.Text = table.Rows[0][3].ToString();
            email.Text = table.Rows[0][4].ToString();
            pass.Text = table.Rows[0][5].ToString();
            byte[] pic = (byte[])table.Rows[0]["picture"];
            MemoryStream picture = new MemoryStream(pic);
            picturebox.Image = Image.FromStream(picture);

            DataBaseUser dataBaseUser = new DataBaseUser();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM database_userwater WHERE CONCAT(water_id) LIKE '%" +temp+ "%'", dataBaseUser.GetConnection());
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            textboxwaterid.Text = dataTable.Rows[0][0].ToString();
            textboxname.Text = dataTable.Rows[0][1].ToString();
            textboxsurname.Text = dataTable.Rows[0][2].ToString();
            textboxadress.Text = dataTable.Rows[0][3].ToString();
            textboxphone.Text = dataTable.Rows[0][4].ToString();
            textboxplace.Text = dataTable.Rows[0][5].ToString();
        }

        private void edit_pic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picturebox.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void backtomain_Click(object sender, EventArgs e)
        {
            if(!checktextboxvalues1())
            {
                if (UserUpdate())
                {
                    this.Hide();
                    MainProgram mainProgram = new MainProgram();
                    mainProgram.Show();
                }
                else
                {
                    warning.Visible = true;
                    textwarning.Text = "มีข้อผิดพลาดเกิดขึ้นบันทึกไม่สำเร็จ";
                }
            }
            else
            {
                warning.Visible = true;
                textwarning.Text = "กรุณากรอกข้อมูลให้ครบ";
            }
        }

        public Boolean UserUpdate()
        {
            DataBaseUser dataBaseUser = new DataBaseUser();
            MemoryStream picture = new MemoryStream();
            picturebox.Image.Save(picture, picturebox.Image.RawFormat);
            MySqlCommand command = new MySqlCommand("UPDATE `users` SET `firstname`= @fname,`surname`= @sname,`email`= @email,`password`= @pass,`picture`= @pic WHERE `user_id`=@id", dataBaseUser.GetConnection());
            MySqlCommand my = new MySqlCommand("SET GLOBAL max_allowed_packet=1024*1024*1024",dataBaseUser.GetConnection());
            command.Parameters.Add("@fname", MySqlDbType.VarChar).Value = name.Text;
            command.Parameters.Add("@sname", MySqlDbType.VarChar).Value = surname.Text;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass.Text;
            command.Parameters.Add("@pic", MySqlDbType.LongBlob).Value = picture.ToArray();
            command.Parameters.Add("@id", MySqlDbType.Int64).Value = Globals.Global_userid;
            dataBaseUser.openConnection();
            my.ExecuteNonQuery();
            if (command.ExecuteNonQuery() == 1)
            {
                dataBaseUser.closeConnection();
                return true;
            }
            else
            {
                dataBaseUser.closeConnection();
                return false;
            }
        }

        public Boolean checktextboxvalues1()
        {
            if (name.Text.Equals("") || surname.Text.Equals("") || email.Text.Equals("") || pass.Text.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean DatabaseUserUpdate()
        {
            DataBaseUser dataBaseUser = new DataBaseUser();
            MySqlCommand command = new MySqlCommand("UPDATE `database_userwater` SET `firstname`= @fname,`surname`= @sname,`address`= @add,`phone`= @phone,`location`= @loc WHERE `water_id`=@id", dataBaseUser.GetConnection());
            command.Parameters.Add("@fname", MySqlDbType.VarChar).Value = textboxname.Text;
            command.Parameters.Add("@sname", MySqlDbType.VarChar).Value = textboxsurname.Text;
            command.Parameters.Add("@add", MySqlDbType.VarChar).Value = textboxadress.Text;
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = textboxphone.Text;
            command.Parameters.Add("@loc", MySqlDbType.VarChar).Value = textboxplace.Text;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = textboxwaterid.Text;
            dataBaseUser.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                dataBaseUser.closeConnection();
                return true;
            }
            else
            {
                dataBaseUser.closeConnection();
                return false;
            }
        }

        public Boolean checktextboxvalues2()
        {
            if (textboxname.Text.Equals("") || textboxsurname.Text.Equals("") || textboxwaterid.Text.Equals("") || textboxadress.Text.Equals("") 
                || textboxphone.Text.Equals("") || textboxplace.Text.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void backtomain0_Click(object sender, EventArgs e)
        {
            if (!checktextboxvalues2())
            {
                if (DatabaseUserUpdate())
                {
                    this.Hide();
                    MainProgram mainProgram = new MainProgram();
                    mainProgram.Show();
                }
                else
                {
                    warning0.Visible = true;
                    textwarning0.Text = "มีข้อผิดพลาดเกิดขึ้นบันทึกไม่สำเร็จ";
                }
            }
            else
            {
                warning0.Visible = true;
                textwarning0.Text = "กรุณากรอกข้อมูลให้ครบ";
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pass.UseSystemPasswordChar = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pass.UseSystemPasswordChar = false;
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainProgram mainProgram = new MainProgram();
            mainProgram.Show();
        }

        private void mini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
