using BUS;
using DLL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DoAnC_
{
    public partial class FormVeKhachHang : Form
    {
        Model1 db = new Model1();
        DataService ds = new DataService();

        int idKh;

        public FormVeKhachHang()
        {
            InitializeComponent();
        }

        public FormVeKhachHang(int idkh1)
        {
            InitializeComponent();
            idKh = idkh1;
            LoadDGV(ds.GetAllVe().Where(p => p.KhachHangId == idKh).ToList());
        }

        private void FormVe_Load(object sender, EventArgs e)
        {
                   
        }

        private void LoadDGV2(List<ThongTinVe> TTves, int IDVe)
        {
            dataGridView2.Rows.Clear();

            foreach (var item in ds.GetAllThongtinPve(IDVe))
            {
                int i = dataGridView2.Rows.Add();
                // dataGridView2.Rows[i].Cells[0].Value = item.LichChieuPhim.ThongtinPhim.TenPhim;
                dataGridView2.Rows[i].Cells[0].Value = item.GheID;
                dataGridView2.Rows[i].Cells[1].Value = item.LichChieuPhim.PhongChieu.Tên_Phòng;
                dataGridView2.Rows[i].Cells[2].Value = item.LichChieuPhim.ThongtinPhim.TenPhim;
            }
        }

        private void LoadDGV(List<Ve> ves)
        {
            dataGridView1.Rows.Clear();
            foreach (Ve item in ves)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.KhachHang.TenKhachHang;
                dataGridView1.Rows[index].Cells[1].Value = item.Ngày_bán_vé;
                dataGridView1.Rows[index].Cells[2].Value = item.Thành_tiền;
                dataGridView1.Rows[index].Cells[3].Value = item.VeID;
                // dataGridView1.Rows[index].Cells[4].Value = item.ThongTinVes.;
            }
        }

     

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Exit.Visible = true;
            dataGridView2.Visible = true;
            dataGridView3.Visible = true;
            label1.Text = "Chi tiết vé";
            int index = dataGridView1.CurrentCell.RowIndex;
            int IDve = int.Parse(dataGridView1.Rows[index].Cells[3].Value.ToString());
            LoadDGV2(ds.GetAllTTve(), IDve);
            loadDgv3(ds.GetAllChiTietDichVu(), IDve);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Exit.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
        }

        private void loadDgv3(List<ChiTietDichVu> chiTietDichVu, int IDVe)
        {
            dataGridView3.Rows.Clear();
            if (chiTietDichVu != null)
            {
                foreach (var item in chiTietDichVu.Where(p => p.VeID == IDVe).ToList())
                {
                    int index = dataGridView3.Rows.Add();
                    dataGridView3.Rows[index].Cells[0].Value = item.DichVu.Tên_dịch_vụ;
                    dataGridView3.Rows[index].Cells[1].Value = item.Số_lượng;
                    dataGridView3.Rows[index].Cells[2].Value = (item.Số_lượng * item.DichVu.Giá);

                    // dataGridView1.Rows[index].Cells[4].Value = item.ThongTinVes.;
                }
            }

        }

        private void FormVeKhachHang_Load(object sender, EventArgs e)
        {

        }
    }
}
