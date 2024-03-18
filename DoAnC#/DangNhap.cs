using BUS;
using DLL.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DoAnC_
{
    public partial class DangNhap : Form
    {
        Model1 db = new Model1();
        DataService ds = new DataService();    
        public DangNhap()
        {
            InitializeComponent();
            textBox1.Text = "+84";
        }




        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form SignUp = new DangKi();         
            SignUp.ShowDialog();
            
        }

        private Boolean CheckLogin()
        {
            TaiKhoan tk = new TaiKhoan();
            tk = ds.FindAccount(TbAccount.Text.Trim());
            if (tk != null)
            {
                if (tk.MatKhau == TbPassWord.Text.Trim())
                {
                    var idUser = tk.TaiKhoannID;
                    if (tk.VaiTroID == 1)
                    {
                        this.Hide();
                        Form Admin = new FormAdmin();
                        Admin.ShowDialog();
                    }
                    else if (tk.VaiTroID == 3)
                    {
                        this.Hide();
                        Form mhc = new manhinhchinh(tk.KhachHangId);
                        mhc.ShowDialog();
                    }
                    else if (tk.VaiTroID == 2)
                    {
                        this.Hide();
                        Form mhc = new manhinhchinh(tk.KhachHangId);
                        mhc.ShowDialog();
                    }

                }
                else
                {
                    ShowErrorAccount.Text = "Mật khẩu không chính xác";
                    ShowErrorAccount.Visible = true;
                }
                return false;
            }
            else
            {
                ShowErrorAccount.Text = "Tài khoản không tồn tại";
                ShowErrorAccount.Visible = true;
            }
            return false;
            /*TaiKhoan tk = new TaiKhoan();
            tk = ds.FindAccount(TbAccount.Text.Trim());
            if (tk != null)
            {

                if (tk.MatKhau == TbPassWord.Text.Trim())
                {
                    var idUser = tk.TaiKhoannID;
                    if (tk.VaiTroID == 1)
                    {                   
                        this.Hide();
                        Form Admin = new FormAdmin();
                        Admin.ShowDialog();
                    }
                    else if (tk.VaiTroID == 3)
                    {
                        this.Hide();
                        Form mhc = new manhinhchinh(tk.KhachHangId);
                        mhc.ShowDialog();
                    }
                    else if(tk.VaiTroID == 2)
                    {
                        this.Hide();
                        Form mhc = new manhinhchinh(tk.KhachHangId);
                        mhc.ShowDialog();
                    }
                }
                else
                {
                    ShowErrorPassWord.Text = "Mật khẩu không chính xác";
                    ShowErrorPassWord.Visible = true;
                }
                return true;
            }
            else
            {
                ShowErrorAccount.Text = "Tài khoản không tồn tại";
                ShowErrorAccount.Visible = true;
            }
            return false;*/
        }
        private void CheckAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbAccount.Text) || string.IsNullOrWhiteSpace(TbPassWord.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /*if (!int.TryParse(TbAccount.Text, out int parsedPhoneNumber))
            {
                MessageBox.Show("Vui lòng nhập Tài khoản là số điện thoại bạn đã đăng ký ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
            CheckLogin();
        }

        private void TbAccount_TextChanged(object sender, EventArgs e)
        {
            ShowErrorAccount.Visible = false;
        }

        private void TbPassWord_TextChanged(object sender, EventArgs e)
        {
            //ShowErrorPassWord.Visible=false;
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
