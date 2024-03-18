
using BUS;
using DLL.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DoAnC_
{
    public partial class FromTaiKhoan : Form
    {

        Model1 db = new Model1();
        DataService ds = new DataService();
        int id = -1;
        public FromTaiKhoan()
        {
            InitializeComponent();
        }

        private void FormTaiKhoan_Load(object sender, EventArgs e)
        {

            role.DataSource = ds.GetAllLoaiTaiKhoan().Where(p => p.VaiTroID != 1).ToList();
            SearchRole.DataSource = ds.GetAllLoaiTaiKhoan().Where(p => p.VaiTroID != 1).ToList();
            SearchRole.Text = "";
            loadDGV(ds.GetAllTaiKhoan().Where(p => p.VaiTroID != 1).ToList());



        }

        private void loadDGV(List<TaiKhoan> listTk)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in listTk)
            {
                int index = dataGridView1.Rows.Add();
                if (item.KhachHang.TenKhachHang != null)
                    dataGridView1.Rows[index].Cells[0].Value = item.KhachHang.TenKhachHang;
                dataGridView1.Rows[index].Cells[1].Value = item.Số_điện_thoại;
                dataGridView1.Rows[index].Cells[2].Value = item.MatKhau;
                dataGridView1.Rows[index].Cells[3].Value = item.LoaiTaiKhoan.LoaiVaiTro;



            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            Name.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            phone.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            password.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            role.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            id = int.Parse(dataGridView1.Rows[index].Cells[4].Value.ToString());

        }

        private void addCusTomer()
        {
            using (var transaction = db.Database.BeginTransaction())
                try
                {
                    KhachHang custommer = new KhachHang();
                    custommer.TenKhachHang = Name.Text;
                    ds.Addcustommer(custommer);

                    TaiKhoan tk = new TaiKhoan(); ;

                    tk.KhachHangId = custommer.KhachHangId;
                    tk.Số_điện_thoại = phone.Text;
                    tk.MatKhau = password.Text.Trim();
                    tk.VaiTroID = ds.GetVaiTroID(role.Text);
                    ds.addAccount(tk);


                    MessageBox.Show("Thêm mới tài khoản thành công");
                    transaction.Commit();
                    loadDGV(ds.GetAllTaiKhoan().Where(p => p.VaiTroID != 1).ToList());
                }
                catch
                {
                    MessageBox.Show("Thêm mới tài khoản thất  bại");
                    transaction.Rollback();
                }
        }

        private void updateCusTomMer()
        {
            if (id == -1)
            {
                MessageBox.Show("Vui lòng chọn 1 tài khoản");
                return;
            }
            using (var transaction = db.Database.BeginTransaction())
                try
                {
                    KhachHang custommer = ds.FindCustomer(id); ;
                   
                    custommer.TenKhachHang = Name.Text;
                    ds.Addcustommer(custommer);

                    TaiKhoan tk= ds.FindAccountID(id); ;               
                    tk.MatKhau = password.Text.Trim();
                    tk.VaiTroID = ds.GetVaiTroID(role.Text);
                    tk.Số_điện_thoại = phone.Text.Trim();
                    
                    ds.addAccount(tk);


                    MessageBox.Show("Sửa tài khoản thành công");
                    transaction.Commit();
                    loadDGV(ds.GetAllTaiKhoan().Where(p => p.VaiTroID != 1).ToList());
                }
                catch
                {
                    MessageBox.Show("Sửa  tài khoản thất  bại");
                    transaction.Rollback();
                }
        }

        private void AU_Click(object sender, EventArgs e)
        {

            if (isEmpty())
            {
                if (IsPhoneNumber())
                    if (checkpassWord())
                    {
                                     
                            updateCusTomMer();
                        

                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isEmpty())
            {
                if (IsPhoneNumber())
                    if (checkpassWord())
                    {
                        {

                        }
                    }
            }
        }




        private Boolean isEmpty()
        {
            if (Name.Text == "" || phone.Text == "" || password.Text == "")
            {
                MessageBox.Show("Không được để trống thông tin");
                return false;
            }
            return true;

        }


        private Boolean IsPhoneNumber()
        {
            Boolean result = Regex.Match(phone.Text.ToString(), @"^(84|0[3|5|7|8|9])+([0-9]{8})\b$").Success;
            if (result == false)
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
                return false;
            }
            return true;
        }

        private Boolean Checkname()
        {
            if (ds.FindNameAgain(Name.Text))
            {
                return true;
            }
            MessageBox.Show("trùng tên");
            return false;
        }

        private Boolean checkpassWord()
        {
            Regex RegexPassWord = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            if (RegexPassWord.IsMatch(password.Text.Trim()))
            {
                return true;
            }
            MessageBox.Show("Mật khẩu không hợp lệ", "Thông báo", MessageBoxButtons.OK);
            return false;
        }



        private void button6_Click(object sender, EventArgs e)
        {

            DialogResult dlgResult = MessageBox.Show("Bạn chắc chắn muốn xóa  tài khoản này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            using (var transaction = db.Database.BeginTransaction())
                if (dlgResult == DialogResult.Yes)
                {
                    try
                    {

                        ds.removeAccount(phone.Text);
                        ds.Removecustommer(Name.Text);


                        transaction.Commit();
                        MessageBox.Show("Xóa tài khoản thành công");
                        loadDGV(ds.GetAllTaiKhoan().Where(p => p.VaiTroID != 1).ToList());

                    }
                    catch
                    {
                        MessageBox.Show("Xóa tài khoản thất bại");
                        transaction.Rollback();
                    }
                }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                ds.KeyLogAndOpen(phone.Text, 4);
                MessageBox.Show("Khóa tài khoản thành công");
                loadDGV(ds.GetAllTaiKhoan().Where(p => p.VaiTroID != 1).ToList());
            }
            catch
            {
                MessageBox.Show("Khóa tài khoản thất bại");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                ds.KeyLogAndOpen(phone.Text, 3);
                MessageBox.Show("Mở tài khoản thành công");
                loadDGV(ds.GetAllTaiKhoan().Where(p => p.VaiTroID != 1).ToList());
            }
            catch
            {
                MessageBox.Show("Mở tài khoản thất bại");
            }
        }
        
        //****
        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[3].Value.ToString().Contains(SearchRole.Text)
                    && dataGridView1.Rows[i].Cells[1].Value.ToString().Contains(SearchPhone.Text))
                {
                    dataGridView1.Rows[i].Visible = true;
                }
                else
                {
                    dataGridView1.Rows[i].Visible = false;
                }
            }

            checkBox1.Checked = false;
        }

        private void SearchRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[3].Value.ToString().Contains(SearchRole.Text))
                {
                    dataGridView1.Rows[i].Visible = true;
                }
                else
                {
                    dataGridView1.Rows[i].Visible = false;
                }
            }
            checkBox1.Checked = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                loadDGV(ds.GetAllTaiKhoan().Where(p => p.VaiTroID != 1).ToList());
                SearchRole.Text = "";
            }
        }

        private void SearchPhone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
