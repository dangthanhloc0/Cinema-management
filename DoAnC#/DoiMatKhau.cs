using BUS;
using DLL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnC_
{
    public partial class DoiMatKhau : Form
    {
        Model1 db = new Model1();
        DataService ds=new DataService();

        string sdt1;
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        public DoiMatKhau(string sdt)
        {
            InitializeComponent();
            sdt1 = sdt;
        }




        // PassWord 1 hoa , 1 thường, 1 kí tự đặc biệt ,8 kí tự,số
        private Boolean checkpassWord(TextBox tb,Label lb)
        {
            Regex RegexPassWord = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            if (RegexPassWord.IsMatch(tb.Text.Trim()))
            {
                return true;
            }
            lb.Text = "Mật khẩu không hợp lệ";
            lb.Visible = true;
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

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(checkpassWord(textBox1,ShowErrorOldPassWord)==true && checkpassWord(TbPassWordSignUp,ShowErrorPassWordSignUp) && CheckPassWordAgain()==true)
            {
                try
                {
                    TaiKhoan tk = ds.FindAccount(sdt1);
                    tk.MatKhau = TbPassWordSignUp.Text;
                    ds.addAccount(tk);
                    MessageBox.Show("Đổi mật khẩu thành công");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Đổi mật khẩu thất bại");
                }
 
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
