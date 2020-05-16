using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class PanalWaterCal : UserControl
    {
        public PanalWaterCal()
        {
            InitializeComponent();
            PanelAmount1.Visible = false;
            PanalAmount2.Visible = false;
            comboBox1.Text = "ทั่วไป (ยกเว้นพื้นที่พิเศษ)";
            comboBox2.Text = "ที่อยู่อาศัย และอื่น ๆ";
            comboBox3.Text = "1/2";
            comboBox4.Text = "ที่พักอาศัย";
            comboBox5.Text = "1/2";
            result1.Enter += (s, e) => { result1.Parent.Focus(); };
            service1.Enter += (s, e) => { service1.Parent.Focus(); };
            tax1.Enter += (s, e) => { tax1.Parent.Focus(); };
            allresult1.Enter += (s, e) => { allresult1.Parent.Focus(); };
            result2.Enter += (s, e) => { result2.Parent.Focus(); };
            service2.Enter += (s, e) => { service2.Parent.Focus(); };
            tax2.Enter += (s, e) => { tax2.Parent.Focus(); };
            allresult2.Enter += (s, e) => { allresult2.Parent.Focus(); };
        }
        public double result, sum, plus, CAwater, sumtax, sumall, copy;

        private void Amount_water1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Amount_water2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void backtocal2_Click(object sender, EventArgs e)
        {
            PanalAmount2.Visible = false;
        }

        private void backtocal1_Click(object sender, EventArgs e)
        {
            PanelAmount1.Visible = false;
        }

        public void CalculateWater1(double Awater, int i, double[] unit, double[] price, double more, double service)
        {
            if (Awater >= 0 && Awater <= 3000)
            {
                sumtax = 0; sumall = 0;
                if (CAwater >= 0 && CAwater <= 10) CAwater = 10;
                else if (CAwater >= 11 && CAwater <= 20) CAwater = 20;
                else if (CAwater >= 21 && CAwater <= 30) CAwater = 30;
                else if (CAwater >= 31 && CAwater <= 50) CAwater = 50;
                else if (CAwater >= 51 && CAwater <= 80) CAwater = 80;
                else if (CAwater >= 81 && CAwater <= 100) CAwater = 100;
                else if (CAwater >= 101 && CAwater <= 300) CAwater = 300;
                else if (CAwater >= 301 && CAwater <= 1000) CAwater = 1000;
                else if (CAwater >= 1001 && CAwater <= 2000) CAwater = 2000;
                else if (CAwater >= 2001 && CAwater <= 3000) CAwater = 3000;
                while(i < 10)
                {
                    plus += unit[i];
                    Awater -= unit[i];
                    sum = 0;
                    sum = unit[i] * price[i];
                    result += sum;
                    if (plus == CAwater)
                    {
                        result = result + (Awater * price[i]);
                        break;
                    }
                    i++;
                }
                if((comboBox2.Text == "ราชการ และธุรกิจขนาดเล็ก" || comboBox2.Text == "ราชการ และธุรกิจขนาดเล็ก(รหัส 28 และ 29)") && comboBox1.Text == "ทั่วไป (ยกเว้นพื้นที่พิเศษ)")
                {
                    if(copy >= 0 && copy <= 9) result = 150;
                }
                else if (comboBox2.Text == "ราชการ และธุรกิจขนาดเล็ก" || comboBox2.Text == "ราชการ และธุรกิจขนาดเล็ก(รหัส 28 และ 29)")
                {
                    if (copy >= 0 && copy <= 8) result = 150;
                }
                else if (comboBox2.Text == "รัฐวิสาหกิจ และธุรกิจขนาดใหญ่")
                {
                    if (copy >= 0 && copy <= 9) result = 300;
                }
                result1.Text = result.ToString("#,#.00");
                service1.Text = service.ToString("#,#.00");
                sumtax = (result * 0.07) + (service * 0.07);
                tax1.Text = sumtax.ToString("#,#.00");
                sumall = result + service + sumtax;
                allresult1.Text = sumall.ToString("#,#.00");
            }
            else
            {
                Awater -= 3000;
                while(i < 10)
                {
                    sum = 0;
                    sum = unit[i] * price[i];
                    plus += sum;
                    i++;
                }
                result = (Awater * more) + plus;
                result1.Text = result.ToString("#,#.00");
                service1.Text = service.ToString("#,#.00");
                sumtax = (result * 0.07) + (service * 0.07);
                tax1.Text = sumtax.ToString("#,#.00");
                sumall = result + service + sumtax;
                allresult1.Text = sumall.ToString("#,#.00");
            }
        }

        private void Cal1_Click(object sender, EventArgs e)
        {
            PanelAmount1.Visible = true;
            string[] Pipe_size = { "1/2", "3/4", "1", "1-1/2", "2", "2-1/2", "3", "4", "6", ">6" };
            double[] Service = { 30, 50, 60, 90, 350, 450, 450, 500, 950, 1200 };
            double[] unit = { 10, 10, 10, 20, 30, 20, 200, 700, 1000, 1000 };
            double[] price1_collection1 = { 10.2, 16, 19, 21.2, 21.6, 21.65, 21.7, 21.75, 21.8, 21.85 };
            double[] price1_collection2 = { 16, 19, 20, 21.5, 21.6, 21.65, 21.7, 21.75, 21.8, 21.85 };
            double[] price1_collection3 = { 16, 19, 20, 21.5, 21.6, 29.25, 29.5, 29.75, 29.5, 29.25 };
            double[] price1_collection4 = { 18, 21, 24, 27, 29, 29.25, 29.5, 29.75, 29.5, 29.25 };
            double[] price2_collection1 = { 10.2, 16, 19, 21.2, 24, 26, 30.25, 30.25, 30.25, 30.25 };
            double[] price2_collection2 = { 18, 21, 22, 23, 24, 26, 30.25, 30.25, 30.25, 30.25 };
            double[] price2_collection3 = { 18, 21, 22, 23, 24, 32.5, 33.5, 34.75, 34.75, 34.75 };
            double[] price2_collection4 = { 18.5, 22, 26, 29, 31.5, 32.5, 33.5, 34.75, 34.75, 34.75 };
            double[] price3_collection1 = { 10.2, 16, 19, 21.2, 23, 24, 27.4, 27.5, 27.6, 27.8 };
            double[] price3_collection2 = { 17, 20, 21, 22, 23, 24, 27.4, 27.5, 27.6, 27.8 };
            double[] price3_collection3 = { 17, 20, 21, 22, 23, 31.25, 31.5, 31.75, 32, 32.25 };
            double[] price3_collection4 = { 18.25, 21.5, 25.5, 28.5, 31, 31.25, 31.5, 31.75, 32, 32.25 };
            if(Amount_water1.Text == "")
            {
                Amount_water1.Text = "0";
            }
            double Awater1 = Convert.ToDouble(Amount_water1.Text);
            CAwater = Awater1; int i = 0; int x = 0; result = 0; plus = 0; copy = Awater1;
            if (comboBox1.Text == "ทั่วไป (ยกเว้นพื้นที่พิเศษ)")
            {
                if(comboBox2.Text == "ที่อยู่อาศัย และอื่น ๆ")
                {
                    while(x < 10)
                    {
                        if (comboBox3.Text == Pipe_size[x])
                        {
                            CalculateWater1(Awater1, i, unit, price1_collection1, 21.9, Service[x]);
                        }
                        x++;
                    }
                }
                else if (comboBox2.Text == "ราชการ และธุรกิจขนาดเล็ก")
                {
                    while (x < 10)
                    {
                        if (comboBox3.Text == Pipe_size[x])
                        {
                            CalculateWater1(Awater1, i, unit, price1_collection2, 21.9, Service[x]);
                        }
                        x++;
                    }
                }
                else if (comboBox2.Text == "ราชการ และธุรกิจขนาดเล็ก(รหัส 28 และ 29)")
                {
                    while (x < 10)
                    {
                        if (comboBox3.Text == Pipe_size[x])
                        {
                            CalculateWater1(Awater1, i, unit, price1_collection3, 29, Service[x]);
                        }
                        x++;
                    }
                }
                else if (comboBox2.Text == "รัฐวิสาหกิจ และธุรกิจขนาดใหญ่")
                {
                    while (x < 10)
                    {
                        if (comboBox3.Text == Pipe_size[x])
                        {
                            CalculateWater1(Awater1, i, unit, price1_collection4, 29, Service[x]);
                        }
                        x++;
                    }
                }
            }
            else if (comboBox1.Text == "กปภ.สาขาภูเก็ต เกาะสมุย และเกาะพะงัน")
            {
                if (comboBox2.Text == "ที่อยู่อาศัย และอื่น ๆ")
                {
                    while (x < 10)
                    {
                        if (comboBox3.Text == Pipe_size[x])
                        {
                            CalculateWater1(Awater1, i, unit, price2_collection1, 30.25, Service[x]);
                        }
                        x++;
                    }
                }
                else if (comboBox2.Text == "ราชการ และธุรกิจขนาดเล็ก")
                {
                    while (x < 10)
                    {
                        if (comboBox3.Text == Pipe_size[x])
                        {
                            CalculateWater1(Awater1, i, unit, price2_collection2, 30.25, Service[x]);
                        }
                        x++;
                    }
                }
                else if (comboBox2.Text == "ราชการ และธุรกิจขนาดเล็ก(รหัส 28 และ 29)")
                {
                    while (x < 10)
                    {
                        if (comboBox3.Text == Pipe_size[x])
                        {
                            CalculateWater1(Awater1, i, unit, price2_collection3, 34.75, Service[x]);
                        }
                        x++;
                    }
                }
                else if (comboBox2.Text == "รัฐวิสาหกิจ และธุรกิจขนาดใหญ่")
                {
                    while (x < 10)
                    {
                        if (comboBox3.Text == Pipe_size[x])
                        {
                            CalculateWater1(Awater1, i, unit, price2_collection4, 34.75, Service[x]);
                        }
                        x++;
                    }
                }
            }
            else if (comboBox1.Text == "เอกชนร่วมลงทุน และพื้นที่จังหวัดชลบุรี")
            {
                if (comboBox2.Text == "ที่อยู่อาศัย และอื่น ๆ")
                {
                    while (x < 10)
                    {
                        if (comboBox3.Text == Pipe_size[x])
                        {
                            CalculateWater1(Awater1, i, unit, price3_collection1, 28, Service[x]);
                        }
                        x++;
                    }
                }
                else if (comboBox2.Text == "ราชการ และธุรกิจขนาดเล็ก")
                {
                    while (x < 10)
                    {
                        if (comboBox3.Text == Pipe_size[x])
                        {
                            CalculateWater1(Awater1, i, unit, price3_collection2, 28, Service[x]);
                        }
                        x++;
                    }
                }
                else if (comboBox2.Text == "ราชการ และธุรกิจขนาดเล็ก(รหัส 28 และ 29)")
                {
                    while (x < 10)
                    {
                        if (comboBox3.Text == Pipe_size[x])
                        {
                            CalculateWater1(Awater1, i, unit, price3_collection3, 32.5, Service[x]);
                        }
                        x++;
                    }
                }
                else if (comboBox2.Text == "รัฐวิสาหกิจ และธุรกิจขนาดใหญ่")
                {
                    while (x < 10)
                    {
                        if (comboBox3.Text == Pipe_size[x])
                        {
                            CalculateWater1(Awater1, i, unit, price3_collection4, 32.5, Service[x]);
                        }
                        x++;
                    }
                }
            }
        }

        public void CalculateWater2(double Awater, int i, double[] unit, double[] price, double more, double service)
        {
            if (Awater >= 0 && Awater <= 200)
            {
                sumtax = 0; sumall = 0;
                if (comboBox4.Text == "ที่พักอาศัย")
                {
                    if (CAwater >= 0 && CAwater <= 30) CAwater = 30;
                    else if (CAwater >= 31 && CAwater <= 40) CAwater = 40;
                    else if (CAwater >= 41 && CAwater <= 50) CAwater = 50;
                    else if (CAwater >= 51 && CAwater <= 60) CAwater = 60;
                    else if (CAwater >= 61 && CAwater <= 70) CAwater = 70;
                    else if (CAwater >= 71 && CAwater <= 80) CAwater = 80;
                    else if (CAwater >= 81 && CAwater <= 90) CAwater = 90;
                    else if (CAwater >= 91 && CAwater <= 100) CAwater = 100;
                    else if (CAwater >= 101 && CAwater <= 120) CAwater = 120;
                    else if (CAwater >= 121 && CAwater <= 160) CAwater = 160;
                    else if (CAwater >= 161 && CAwater <= 200) CAwater = 200;
                }
                else
                {
                    if (CAwater >= 0 && CAwater <= 10) CAwater = 10;
                    else if (CAwater >= 11 && CAwater <= 20) CAwater = 20;
                    else if (CAwater >= 21 && CAwater <= 30) CAwater = 30;
                    else if (CAwater >= 31 && CAwater <= 40) CAwater = 40;
                    else if (CAwater >= 41 && CAwater <= 50) CAwater = 50;
                    else if (CAwater >= 51 && CAwater <= 60) CAwater = 60;
                    else if (CAwater >= 61 && CAwater <= 80) CAwater = 80;
                    else if (CAwater >= 81 && CAwater <= 100) CAwater = 100;
                    else if (CAwater >= 101 && CAwater <= 120) CAwater = 120;
                    else if (CAwater >= 121 && CAwater <= 160) CAwater = 160;
                    else if (CAwater >= 161 && CAwater <= 200) CAwater = 200;
                }
                while (i < 11)
                {
                    plus += unit[i];
                    Awater -= unit[i];
                    sum = 0;
                    sum = unit[i] * price[i];
                    result += sum;
                    if (plus == CAwater)
                    {
                        result = result + (Awater * price[i]);
                        break;
                    }
                    i++;
                }
                if (comboBox4.Text == "ธุรกิจ ราชการ รัฐวิสาหกิจ อุตสาหกรรม และอื่น ๆ")
                {
                    if (copy >= 0 && copy <= 9) result = 90;
                }
                result2.Text = result.ToString("#,#.00");
                service2.Text = service.ToString("#,#.00");
                sumtax = (result * 0.07) + (service * 0.07);
                tax2.Text = sumtax.ToString("#,#.00");
                sumall = result + service + sumtax;
                allresult2.Text = sumall.ToString("#,#.00");
            }
            else
            {
                Awater -= 200;
                while (i < 11)
                {
                    sum = 0;
                    sum = unit[i] * price[i];
                    plus += sum;
                    i++;
                }
                result = (Awater * more) + plus;
                result2.Text = result.ToString("#,#.00");
                service2.Text = service.ToString("#,#.00");
                sumtax = (result * 0.07) + (service * 0.07);
                tax2.Text = sumtax.ToString("#,#.00");
                sumall = result + service + sumtax;
                allresult2.Text = sumall.ToString("#,#.00");
            }
        }

        private void Cal2_Click(object sender, EventArgs e)
        {
            PanalAmount2.Visible = true;
            string[] Pipe_size = { "1/2", "3/4", "1", "1-1/2", "2", "3", "4", "6", "8", "12", "16" };
            double[] Service = { 25, 40, 50, 80, 300, 400, 500, 900, 1100, 3500, 5000};
            double[] unit1 = { 30, 10, 10, 10, 10, 10, 10, 10, 20, 40, 40 };
            double[] unit2 = { 10, 10, 10, 10, 10, 10, 20, 20, 20, 40, 40 };
            double[] price1_collection1 = { 8.5, 10.03, 10.35, 10.68, 11, 11.33, 12.5, 12.82, 13.15, 13.47, 13.8 };
            double[] price1_collection2 = { 9.5, 10.7, 10.95, 13.21, 13.54, 13.86, 14.19, 14.51, 14.84, 15.16, 15.49 };
            if (Amount_water2.Text == "")
            {
                Amount_water2.Text = "0";
            }
            double Awater2 = Convert.ToDouble(Amount_water2.Text);
            CAwater = Awater2; int i = 0; int x = 0; result = 0; plus = 0; copy = Awater2;
            if (comboBox4.Text == "ที่พักอาศัย")
            {
                while (x < 11)
                {
                    if (comboBox5.Text == Pipe_size[x])
                    {
                        CalculateWater2(Awater2, i, unit1, price1_collection1, 14.45, Service[x]);
                    }
                    x++;
                }
            }
            else if (comboBox4.Text == "ธุรกิจ ราชการ รัฐวิสาหกิจ อุตสาหกรรม และอื่น ๆ")
            {
                while (x < 11)
                {
                    if (comboBox5.Text == Pipe_size[x])
                    {
                        CalculateWater2(Awater2, i, unit2, price1_collection2, 14.45, Service[x]);
                    }
                    x++;
                }
            }
        }
    }
}
