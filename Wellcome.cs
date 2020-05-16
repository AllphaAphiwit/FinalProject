using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Wellcome : Form
    {
        public Wellcome()
        {
            InitializeComponent();
            pro.Value = 0;
            pro.Minimum = 0;
            pro.Maximum = 100;
            this.Opacity = 0.0;
            fadein.Start();
        }

        private void fadein_Tick(object sender, EventArgs e)
        {
            if(this.Opacity < 1)
            {
                this.Opacity += 0.05;  
            }
            pro.Value += 1;
            pro.Text = pro.Value.ToString();
            if (pro.Value == 100)
            {
                fadein.Stop();
                fadeout.Start();
            }
        }

        private void fadeout_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if(this.Opacity == 0)
            {
                fadeout.Stop();
                this.Close();
            }
        }
    }
}
