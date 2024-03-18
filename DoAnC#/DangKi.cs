using BUS;
using DLL.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnC_
{
    public partial class DangKi : Form
    {
        Model1 db = new Model1();
        DataService ds=new DataService();

        public DangKi()
        {
            InitializeComponent();
            
        }

        private Boolean checkEmpty()
        {
            if (TbAccountSignUp.Text.Trim() == "" || TbPassWordSignUp.Text.Trim() == "" || tbPassWordAgain.Text.Trim() == "")
                return false;
            return true;
        }

        public bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^(84|0[3|5|7|8|9])+([0-9]{8})\b$").Success;
        }
        private Boolean CheckAccount()
        {
            var PhoneNumber = TbAccountSignUp.Text.Trim();
            //try
            //{                          
            //    int result = int.Parse(PhoneNumber);                                                                  
            //}catch 
            //{
            //    ShowErrorAccount.Text = "Số điện thoại không hợp lệ";
            //}
            Model1 db = new Model1();
            var tk = db.TaiKhoans.FirstOrDefault(p => p.Số_điện_thoại.ToString() == TbAccountSignUp.Text.Trim());
            if (tk == null)
            {
                if (IsPhoneNumber(PhoneNumber))
                {
                    return true;
                }
            }

            else
            {
                ShowErrorAccountSignUp.Text = "số điện  thoại đã tồn tại";
                ShowErrorAccountSignUp.Visible = true;
                return false;
            }

            ShowErrorAccountSignUp.Text = "Số điện thoại không hợp lệ";
            ShowErrorAccountSignUp.Visible = true;
            return false;
        }

        // PassWord 1 hoa , 1 thường, 1 kí tự đặc biệt ,8 kí tự,số
        private Boolean checkpassWord()
        {
            Regex RegexPassWord = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            if (RegexPassWord.IsMatch(TbPassWordSignUp.Text.Trim()))
            {
                return true;
            }
            ShowErrorPassWordSignUp.Text = "Mật khẩu không hợp lệ";
            ShowErrorPassWordSignUp.Visible = true;
            return false;
        }

        private Boolean CheckPassWordAgain()
        {

            if (tbPassWordAgain.Text.Trim() != TbPassWordSignUp.Text.Trim())
            {
                ShowErrorPasswordAgain.Text = "Mật khẩu không trùng khớp";
                ShowErrorPasswordAgain.Visible = true;
                return false;
            }
            return true;
        }

        private Boolean CheckName()
        {
            if(!ds.FindNameAgain(NameUser.Text.Trim()))
            {
                ShowErrorName.Text = "Tên tài khoản đã tồn tại";
                ShowErrorName.Visible = true;
                return false;
            }
            return true;
        }

        private Boolean CheckSignUp()
        {
            var Empty = checkEmpty();
            var Account = CheckAccount();
            var PassWord = checkpassWord();
            var PassWordAgain = CheckPassWordAgain();
            var Name = CheckName();
            if (!Empty)
            {
                MessageBox.Show("Không được  để trống thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (Account == true && PassWord == true && PassWordAgain == true && Name==true) 
                {
                    return true;
                }
            }

            return false;
        }

        private void CheckAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CheckSignUp())
            {
                
                MessageBox.Show("Đăng kí thật bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (var transaction = db.Database.BeginTransaction())
                    try
                    {

                        KhachHang kh=new KhachHang();
                        kh.TenKhachHang = NameUser.Text;
                        ds.Addcustommer(kh);


                        TaiKhoan tk = new TaiKhoan();
                        tk.Số_điện_thoại = TbAccountSignUp.Text;
                        tk.MatKhau = TbPassWordSignUp.Text.Trim();
                        tk.VaiTroID = 3;
                        tk.KhachHangId = kh.KhachHangId;
                        ds.addAccount( tk );
                        transaction.Commit();
                        MessageBox.Show("Đăng kí thành công,mời bạn đăng nhập. ");
                        this.Hide();/*Close();
                        Form dangnhap = new DangNhap();
                        dangnhap.ShowDialog();*/
                    }
                    catch
                    {
                        transaction.Rollback();
                        MessageBox.Show("Đăng kí thất bại");
                    }

            }
        }

        private void TbAccountSignUp_TextChanged(object sender, EventArgs e)
        {
            ShowErrorAccountSignUp.Text = "";
        }

        private void TbPassWordSignUp_TextChanged(object sender, EventArgs e)
        {
            ShowErrorPassWordSignUp.Text = "";
        }

        private void tbPassWordAgain_TextChanged(object sender, EventArgs e)
        {
            ShowErrorPasswordAgain.Text = "";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form f = new DangNhap();
            f.ShowDialog();
           
        }

        private void NameUser_TextChanged(object sender, EventArgs e)
        {
            ShowErrorName.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DangKi_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
