using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DoAnC_
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private Form currentFormChild;

        private void OpenChildForm(Form ChildForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }

            currentFormChild = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            panel_Body_Form.Controls.Add(ChildForm);
            panel_Body_Form.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FromTaiKhoan());
            label1.Text = btn_user.Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormVe());
            label1.Text = btn_ve.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDichVU());
            label1.Text = btn_DichVu.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormPhim());
            label1.Text = btn_movie.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormLichChieuPhim());
            label1.Text = Btn_LichChieuPhim.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormThongKe());
            label1.Text = Btn_Thongke.Text;
        }
    }
}
