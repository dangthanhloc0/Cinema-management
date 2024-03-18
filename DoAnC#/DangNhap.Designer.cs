using System.Drawing;

namespace DoAnC_
{
    partial class DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            this.Account = new System.Windows.Forms.LinkLabel();
            this.PassWord = new System.Windows.Forms.LinkLabel();
            this.CheckAccount = new System.Windows.Forms.LinkLabel();
            this.TbAccount = new System.Windows.Forms.TextBox();
            this.TbPassWord = new System.Windows.Forms.TextBox();
            this.ShowErrorAccount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.signupAccout = new System.Windows.Forms.LinkLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Account
            // 
            this.Account.AutoSize = true;
            this.Account.BackColor = System.Drawing.Color.LightPink;
            this.Account.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Account.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Account.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.Account.LinkColor = System.Drawing.Color.Crimson;
            this.Account.Location = new System.Drawing.Point(23, 43);
            this.Account.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Account.Name = "Account";
            this.Account.Size = new System.Drawing.Size(132, 29);
            this.Account.TabIndex = 5;
            this.Account.TabStop = true;
            this.Account.Text = "Tài Khoản";
            // 
            // PassWord
            // 
            this.PassWord.AutoSize = true;
            this.PassWord.BackColor = System.Drawing.Color.LightPink;
            this.PassWord.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassWord.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.PassWord.LinkColor = System.Drawing.Color.Crimson;
            this.PassWord.Location = new System.Drawing.Point(23, 116);
            this.PassWord.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PassWord.Name = "PassWord";
            this.PassWord.Size = new System.Drawing.Size(123, 29);
            this.PassWord.TabIndex = 6;
            this.PassWord.TabStop = true;
            this.PassWord.Text = "Mật khẩu";
            // 
            // CheckAccount
            // 
            this.CheckAccount.ActiveLinkColor = System.Drawing.Color.Red;
            this.CheckAccount.BackColor = System.Drawing.Color.LightPink;
            this.CheckAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CheckAccount.DisabledLinkColor = System.Drawing.Color.Black;
            this.CheckAccount.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckAccount.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CheckAccount.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.CheckAccount.LinkColor = System.Drawing.Color.Crimson;
            this.CheckAccount.Location = new System.Drawing.Point(163, 187);
            this.CheckAccount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CheckAccount.Name = "CheckAccount";
            this.CheckAccount.Size = new System.Drawing.Size(167, 42);
            this.CheckAccount.TabIndex = 8;
            this.CheckAccount.TabStop = true;
            this.CheckAccount.Text = "Đăng Nhập";
            this.CheckAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CheckAccount_LinkClicked);
            // 
            // TbAccount
            // 
            this.TbAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbAccount.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbAccount.ForeColor = System.Drawing.Color.Crimson;
            this.TbAccount.Location = new System.Drawing.Point(225, 42);
            this.TbAccount.Margin = new System.Windows.Forms.Padding(2);
            this.TbAccount.Name = "TbAccount";
            this.TbAccount.Size = new System.Drawing.Size(209, 36);
            this.TbAccount.TabIndex = 10;
            this.TbAccount.TextChanged += new System.EventHandler(this.TbAccount_TextChanged);
            // 
            // TbPassWord
            // 
            this.TbPassWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbPassWord.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPassWord.ForeColor = System.Drawing.Color.Crimson;
            this.TbPassWord.Location = new System.Drawing.Point(163, 113);
            this.TbPassWord.Margin = new System.Windows.Forms.Padding(2);
            this.TbPassWord.Name = "TbPassWord";
            this.TbPassWord.PasswordChar = '*';
            this.TbPassWord.Size = new System.Drawing.Size(271, 36);
            this.TbPassWord.TabIndex = 11;
            this.TbPassWord.TextChanged += new System.EventHandler(this.TbPassWord_TextChanged);
            // 
            // ShowErrorAccount
            // 
            this.ShowErrorAccount.AutoSize = true;
            this.ShowErrorAccount.BackColor = System.Drawing.Color.LightPink;
            this.ShowErrorAccount.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowErrorAccount.ForeColor = System.Drawing.Color.Crimson;
            this.ShowErrorAccount.Location = new System.Drawing.Point(179, 152);
            this.ShowErrorAccount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ShowErrorAccount.Name = "ShowErrorAccount";
            this.ShowErrorAccount.Size = new System.Drawing.Size(59, 23);
            this.ShowErrorAccount.TabIndex = 12;
            this.ShowErrorAccount.Text = "label1";
            this.ShowErrorAccount.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Pink;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 287);
            this.panel1.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightPink;
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.ShowErrorAccount);
            this.groupBox1.Controls.Add(this.PassWord);
            this.groupBox1.Controls.Add(this.Account);
            this.groupBox1.Controls.Add(this.CheckAccount);
            this.groupBox1.Controls.Add(this.TbPassWord);
            this.groupBox1.Controls.Add(this.signupAccout);
            this.groupBox1.Controls.Add(this.TbAccount);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 265);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // signupAccout
            // 
            this.signupAccout.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signupAccout.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.signupAccout.LinkColor = System.Drawing.Color.MediumVioletRed;
            this.signupAccout.Location = new System.Drawing.Point(206, 229);
            this.signupAccout.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.signupAccout.Name = "signupAccout";
            this.signupAccout.Size = new System.Drawing.Size(74, 23);
            this.signupAccout.TabIndex = 9;
            this.signupAccout.TabStop = true;
            this.signupAccout.Text = "Đăng kí";
            this.signupAccout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Crimson;
            this.textBox1.Location = new System.Drawing.Point(163, 42);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(62, 36);
            this.textBox1.TabIndex = 13;
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 287);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DangNhap";
            this.Text = "Đăng Nhập";
            this.Load += new System.EventHandler(this.DangNhap_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.LinkLabel Account;
        private System.Windows.Forms.LinkLabel PassWord;
        private System.Windows.Forms.LinkLabel CheckAccount;
        private System.Windows.Forms.TextBox TbAccount;
        private System.Windows.Forms.TextBox TbPassWord;
        private System.Windows.Forms.Label ShowErrorAccount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.LinkLabel signupAccout;
    }
}

