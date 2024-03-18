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
    public partial class FormVe : Form
    {
        Model1 db = new Model1();
        DataService ds = new DataService();
        public FormVe()
        {
            InitializeComponent();
        }

        private void FormVe_Load(object sender, EventArgs e)
        {
            LoadDGV(ds.GetAllVe());
           


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

        private void loadDgv3(List<ChiTietDichVu> chiTietDichVu, int IDVe) {
            dataGridView3.Rows.Clear();
            if(chiTietDichVu != null)
            {
                foreach (var item in chiTietDichVu.Where(p=>p.VeID==IDVe).ToList())
                {
                    int index = dataGridView3.Rows.Add();
                    dataGridView3.Rows[index].Cells[0].Value = item.DichVu.Tên_dịch_vụ;
                    dataGridView3.Rows[index].Cells[1].Value = item.Số_lượng;
                    dataGridView3.Rows[index].Cells[2].Value = (item.Số_lượng * item.DichVu.Giá);

                    // dataGridView1.Rows[index].Cells[4].Value = item.ThongTinVes.;
                }
            }    
          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Exit.Visible = true;
            dataGridView2.Visible = true;
            dataGridView3.Visible = true;
            label1.Text = "Chi tiết vé";

            checkBox1.Visible = checkBox2.Visible ;
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
            label1.Text = "Vé";
            checkBox1.Visible = checkBox2.Visible;
        }
        //private void SreachGridVIew()
        //{
        //    for (int i = 0; i + 1 < dataGridView1.Rows.Count; i++)
        //    {
        //        DateTime dt = DateTime.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
        //        if (dateTimePicker1.Value == dt)
        //        {
        //            dataGridView1.Rows[i].Visible = true;
        //        }
        //        else
        //        {
        //            dataGridView1.Rows[i].Visible = false;
        //        }
        //    }
        //    checkBox1.Checked = false;
        //}



        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //SreachGridVIew();
            checkBox2.Checked = false;
            checkBox1.Checked = false;
        }




      

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DateTime dt = DateTime.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    if (DateTime.Now.Year == dt.Year && DateTime.Now.Month==dt.Month && DateTime.Now.Day==dt.Day)
                    {
                        dataGridView1.Rows[i].Visible = true;
                    }
                    else
                    {
                        dataGridView1.Rows[i].Visible = false;
                    }
                }
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                LoadDGV(ds.GetAllVe());
                checkBox1.Checked = false;
            }

        }


    }
}
