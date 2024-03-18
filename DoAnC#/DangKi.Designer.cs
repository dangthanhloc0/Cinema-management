namespace DoAnC_
{
    partial class DangKi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangKi));
            this.Account = new System.Windows.Forms.LinkLabel();
            this.PassWord = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.SignUp = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.TbAccountSignUp = new System.Windows.Forms.TextBox();
            this.TbPassWordSignUp = new System.Windows.Forms.TextBox();
            this.ShowErrorAccountSignUp = new System.Windows.Forms.Label();
            this.ShowErrorPassWordSignUp = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.tbPassWordAgain = new System.Windows.Forms.TextBox();
            this.ShowErrorPasswordAgain = new System.Windows.Forms.Label();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.NameUser = new System.Windows.Forms.TextBox();
            this.ShowErrorName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Account
            // 
            this.Account.AutoSize = true;
            this.Account.BackColor = System.Drawing.Color.LightPink;
            this.Account.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Account.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.Account.LinkColor = System.Drawing.Color.Crimson;
            this.Account.Location = new System.Drawing.Point(9, 101);
            this.Account.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Account.Name = "Account";
            this.Account.Size = new System.Drawing.Size(170, 33);
            this.Account.TabIndex = 5;
            this.Account.TabStop = true;
            this.Account.Text = "Số điện thoại";
            // 
            // PassWord
            // 
            this.PassWord.AutoSize = true;
            this.PassWord.BackColor = System.Drawing.Color.LightPink;
            this.PassWord.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassWord.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.PassWord.LinkColor = System.Drawing.Color.Crimson;
            this.PassWord.Location = new System.Drawing.Point(9, 183);
            this.PassWord.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PassWord.Name = "PassWord";
            this.PassWord.Size = new System.Drawing.Size(124, 33);
            this.PassWord.TabIndex = 6;
            this.PassWord.TabStop = true;
            this.PassWord.Text = "Mật khẩu";
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.BackColor = System.Drawing.Color.LightPink;
            this.linkLabel3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel3.LinkColor = System.Drawing.Color.MediumVioletRed;
            this.linkLabel3.Location = new System.Drawing.Point(268, 358);
            this.linkLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(99, 23);
            this.linkLabel3.TabIndex = 7;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Trang Chủ";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // SignUp
            // 
            this.SignUp.AutoSize = true;
            this.SignUp.BackColor = System.Drawing.Color.LightPink;
            this.SignUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SignUp.DisabledLinkColor = System.Drawing.Color.Black;
            this.SignUp.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignUp.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.SignUp.LinkColor = System.Drawing.Color.Crimson;
            this.SignUp.Location = new System.Drawing.Point(188, 317);
            this.SignUp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SignUp.Name = "SignUp";
            this.SignUp.Size = new System.Drawing.Size(141, 41);
            this.SignUp.TabIndex = 8;
            this.SignUp.TabStop = true;
            this.SignUp.Text = "Đăng kí";
            this.SignUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CheckAccount_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.MediumVioletRed;
            this.linkLabel1.Location = new System.Drawing.Point(134, 358);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(106, 23);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Đăng Nhập";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // TbAccountSignUp
            // 
            this.TbAccountSignUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbAccountSignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbAccountSignUp.Location = new System.Drawing.Point(214, 97);
            this.TbAccountSignUp.Margin = new System.Windows.Forms.Padding(2);
            this.TbAccountSignUp.Name = "TbAccountSignUp";
            this.TbAccountSignUp.Size = new System.Drawing.Size(284, 37);
            this.TbAccountSignUp.TabIndex = 10;
            this.TbAccountSignUp.TextChanged += new System.EventHandler(this.TbAccountSignUp_TextChanged);
            // 
            // TbPassWordSignUp
            // 
            this.TbPassWordSignUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbPassWordSignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPassWordSignUp.Location = new System.Drawing.Point(215, 179);
            this.TbPassWordSignUp.Margin = new System.Windows.Forms.Padding(2);
            this.TbPassWordSignUp.Name = "TbPassWordSignUp";
            this.TbPassWordSignUp.PasswordChar = '*';
            this.TbPassWordSignUp.Size = new System.Drawing.Size(284, 37);
            this.TbPassWordSignUp.TabIndex = 11;
            this.TbPassWordSignUp.TextChanged += new System.EventHandler(this.TbPassWordSignUp_TextChanged);
            // 
            // ShowErrorAccountSignUp
            // 
            this.ShowErrorAccountSignUp.AutoSize = true;
            this.ShowErrorAccountSignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowErrorAccountSignUp.Location = new System.Drawing.Point(219, 136);
            this.ShowErrorAccountSignUp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ShowErrorAccountSignUp.Name = "ShowErrorAccountSignUp";
            this.ShowErrorAccountSignUp.Size = new System.Drawing.Size(60, 24);
            this.ShowErrorAccountSignUp.TabIndex = 12;
            this.ShowErrorAccountSignUp.Text = "label1";
            this.ShowErrorAccountSignUp.Visible = false;
            // 
            // ShowErrorPassWordSignUp
            // 
            this.ShowErrorPassWordSignUp.AutoSize = true;
            this.ShowErrorPassWordSignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowErrorPassWordSignUp.Location = new System.Drawing.Point(219, 218);
            this.ShowErrorPassWordSignUp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ShowErrorPassWordSignUp.Name = "ShowErrorPassWordSignUp";
            this.ShowErrorPassWordSignUp.Size = new System.Drawing.Size(60, 24);
            this.ShowErrorPassWordSignUp.TabIndex = 13;
            this.ShowErrorPassWordSignUp.Text = "label1";
            this.ShowErrorPassWordSignUp.Visible = false;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.LightPink;
            this.linkLabel2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel2.LinkColor = System.Drawing.Color.Crimson;
            this.linkLabel2.Location = new System.Drawing.Point(10, 259);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(207, 29);
            this.linkLabel2.TabIndex = 14;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Nhập lại mật khẩu";
            // 
            // tbPassWordAgain
            // 
            this.tbPassWordAgain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPassWordAgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassWordAgain.Location = new System.Drawing.Point(215, 251);
            this.tbPassWordAgain.Margin = new System.Windows.Forms.Padding(2);
            this.tbPassWordAgain.Name = "tbPassWordAgain";
            this.tbPassWordAgain.PasswordChar = '*';
            this.tbPassWordAgain.Size = new System.Drawing.Size(284, 37);
            this.tbPassWordAgain.TabIndex = 15;
            this.tbPassWordAgain.TextChanged += new System.EventHandler(this.tbPassWordAgain_TextChanged);
            // 
            // ShowErrorPasswordAgain
            // 
            this.ShowErrorPasswordAgain.AutoSize = true;
            this.ShowErrorPasswordAgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowErrorPasswordAgain.Location = new System.Drawing.Point(219, 288);
            this.ShowErrorPasswordAgain.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ShowErrorPasswordAgain.Name = "ShowErrorPasswordAgain";
            this.ShowErrorPasswordAgain.Size = new System.Drawing.Size(60, 24);
            this.ShowErrorPasswordAgain.TabIndex = 16;
            this.ShowErrorPasswordAgain.Text = "label1";
            this.ShowErrorPasswordAgain.Visible = false;
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.BackColor = System.Drawing.Color.LightPink;
            this.linkLabel4.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel4.ForeColor = System.Drawing.Color.LightPink;
            this.linkLabel4.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel4.LinkColor = System.Drawing.Color.Crimson;
            this.linkLabel4.Location = new System.Drawing.Point(9, 28);
            this.linkLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(180, 33);
            this.linkLabel4.TabIndex = 19;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Tên tài Khoản";
            // 
            // NameUser
            // 
            this.NameUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameUser.Location = new System.Drawing.Point(214, 24);
            this.NameUser.Margin = new System.Windows.Forms.Padding(2);
            this.NameUser.Name = "NameUser";
            this.NameUser.Size = new System.Drawing.Size(284, 37);
            this.NameUser.TabIndex = 20;
            this.NameUser.TextChanged += new System.EventHandler(this.NameUser_TextChanged);
            // 
            // ShowErrorName
            // 
            this.ShowErrorName.AutoSize = true;
            this.ShowErrorName.BackColor = System.Drawing.Color.LightPink;
            this.ShowErrorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowErrorName.Location = new System.Drawing.Point(233, 81);
            this.ShowErrorName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ShowErrorName.Name = "ShowErrorName";
            this.ShowErrorName.Size = new System.Drawing.Size(60, 24);
            this.ShowErrorName.TabIndex = 21;
            this.ShowErrorName.Text = "label1";
            this.ShowErrorName.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Pink;
            this.panel1.Controls.Add(this.ShowErrorName);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.Crimson;
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(543, 430);
            this.panel1.TabIndex = 22;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightPink;
            this.groupBox1.Controls.Add(this.tbPassWordAgain);
            this.groupBox1.Controls.Add(this.ShowErrorPasswordAgain);
            this.groupBox1.Controls.Add(this.linkLabel3);
            this.groupBox1.Controls.Add(this.Account);
            this.groupBox1.Controls.Add(this.linkLabel2);
            this.groupBox1.Controls.Add(this.linkLabel4);
            this.groupBox1.Controls.Add(this.PassWord);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.SignUp);
            this.groupBox1.Controls.Add(this.NameUser);
            this.groupBox1.Controls.Add(this.TbPassWordSignUp);
            this.groupBox1.Controls.Add(this.ShowErrorPassWordSignUp);
            this.groupBox1.Controls.Add(this.TbAccountSignUp);
            this.groupBox1.Controls.Add(this.ShowErrorAccountSignUp);
            this.groupBox1.Location = new System.Drawing.Point(14, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(518, 398);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // DangKi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(545, 430);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DangKi";
            this.Text = "Đăng Ký";
            this.Load += new System.EventHandler(this.DangKi_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.LinkLabel Account;
        private System.Windows.Forms.LinkLabel PassWord;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel SignUp;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox TbAccountSignUp;
        private System.Windows.Forms.TextBox TbPassWordSignUp;
        private System.Windows.Forms.Label ShowErrorAccountSignUp;
        private System.Windows.Forms.Label ShowErrorPassWordSignUp;
        #region Windows Form Designer generated code



        #endregion

        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.TextBox tbPassWordAgain;
        private System.Windows.Forms.Label ShowErrorPasswordAgain;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.TextBox NameUser;
        private System.Windows.Forms.Label ShowErrorName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}