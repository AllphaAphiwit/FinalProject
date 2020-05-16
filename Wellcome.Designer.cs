namespace Final_Project
{
    partial class Wellcome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pro = new CircularProgressBar.CircularProgressBar();
            this.fadein = new System.Windows.Forms.Timer(this.components);
            this.fadeout = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pro
            // 
            this.pro.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.pro.AnimationSpeed = 500;
            this.pro.BackColor = System.Drawing.Color.Transparent;
            this.pro.Font = new System.Drawing.Font("Quark", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pro.ForeColor = System.Drawing.Color.White;
            this.pro.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(81)))), ((int)(((byte)(154)))));
            this.pro.InnerMargin = 2;
            this.pro.InnerWidth = -1;
            this.pro.Location = new System.Drawing.Point(605, 141);
            this.pro.Margin = new System.Windows.Forms.Padding(2);
            this.pro.MarqueeAnimationSpeed = 2000;
            this.pro.Name = "pro";
            this.pro.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(81)))), ((int)(((byte)(154)))));
            this.pro.OuterMargin = -25;
            this.pro.OuterWidth = 26;
            this.pro.ProgressColor = System.Drawing.Color.White;
            this.pro.ProgressWidth = 45;
            this.pro.SecondaryFont = new System.Drawing.Font("Quark", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pro.Size = new System.Drawing.Size(328, 317);
            this.pro.StartAngle = 270;
            this.pro.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pro.SubscriptColor = System.Drawing.Color.White;
            this.pro.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.pro.SubscriptText = "";
            this.pro.SuperscriptColor = System.Drawing.Color.White;
            this.pro.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.pro.SuperscriptText = "";
            this.pro.TabIndex = 0;
            this.pro.Text = "0";
            this.pro.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.pro.Value = 68;
            // 
            // fadein
            // 
            this.fadein.Interval = 30;
            this.fadein.Tick += new System.EventHandler(this.fadein_Tick);
            // 
            // fadeout
            // 
            this.fadeout.Interval = 30;
            this.fadeout.Tick += new System.EventHandler(this.fadeout_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Quark", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(591, 546);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 85);
            this.label1.TabIndex = 1;
            this.label1.Text = "กำลังเข้าสู่ระบบ...";
            // 
            // Wellcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(81)))), ((int)(((byte)(154)))));
            this.ClientSize = new System.Drawing.Size(1500, 790);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Wellcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wellcome";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CircularProgressBar.CircularProgressBar pro;
        private System.Windows.Forms.Timer fadein;
        private System.Windows.Forms.Timer fadeout;
        private System.Windows.Forms.Label label1;
    }
}