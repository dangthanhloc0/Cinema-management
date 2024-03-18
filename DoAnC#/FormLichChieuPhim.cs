using BUS;
using DLL.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Internal;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DoAnC_
{
    public partial class FormLichChieuPhim : Form
    {
        Model1 db = new Model1();
        DataService ds = new DataService();
        public FormLichChieuPhim()
        {
            InitializeComponent();
        }



        private void FormLichChieuPhim_Load(object sender, EventArgs e)
        {
            LoadCb();
            LoadDGV();
            //loadCbIDLCp();
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dataGridView2.Columns[5];
            pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void LoadDGV()
        {
            dataGridView1.Rows.Clear();
            foreach (var item in ds.GetAllLichChieuPhim())
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.LCPId;
                dataGridView1.Rows[index].Cells[1].Value = item.ThongtinPhim.TenPhim;
                dataGridView1.Rows[index].Cells[2].Value = item.Thời_gian_bắt_đầu_chiếu;
                dataGridView1.Rows[index].Cells[3].Value = item.Thời_gian_kết_thúc_chiếu;
                dataGridView1.Rows[index].Cells[4].Value = item.PhongChieu.Tên_Phòng;
                dataGridView1.Rows[index].Cells[5].Value = item.NgayChieu;
            }
        }

        private void LoadCb()
        {

            Combobox2.DataSource = ds.getALlPhongChieu();
        }

        //private void loadCbIDLCp()
        //{
        //    Combobox2.DataSource = ds.GetAllLichChieuPhim();
        //}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadDGV1(ds.GetALLThongTinPhim());
            dataGridView2.Visible = true;
        }

        private void loadDGV1(List<ThongtinPhim> Ttp)

        {
            dataGridView2.Rows.Clear();
            foreach (var item in Ttp)
            {
                if(item.NgayBatDauChieu<=DateTime.Now && DateTime.Now<=item.NgayKetThuc)
                {
                    int index = dataGridView2.Rows.Add();
                    dataGridView2.Rows[index].Cells[0].Value = item.PhimId;
                    dataGridView2.Rows[index].Cells[1].Value = item.TenPhim;
                    dataGridView2.Rows[index].Cells[2].Value = ds.GetNameTheLoai(item.PhimId);
                    dataGridView2.Rows[index].Cells[3].Value = item.NgayBatDauChieu;
                    dataGridView2.Rows[index].Cells[4].Value = item.NgayKetThuc;
                    dataGridView2.Rows[index].Cells[5].Value = item.anh;
                    dataGridView2.Rows[index].Cells[6].Value = item.Thời_lượng;
                    dataGridView2.Rows[index].Cells[7].Value = item.Mota;
                }
          


            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView2.CurrentCell.RowIndex;
            IdPhim.Text = dataGridView2.Rows[index].Cells[0].Value.ToString();
            NaneMovie.Text = dataGridView2.Rows[index].Cells[1].Value.ToString();
            dataGridView2.Visible = false;
        }

        private void CreateGhe(int id)
        {
            foreach(var item in ds.getAllGhe())
            {
                ChiTietGhe ctg=new ChiTietGhe();
                ctg.LCPID = id;
                ctg.GheID = item.GheID;
                ctg.TTGID =0 ;
                ds.AddChiTietGhe(ctg);  
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (checkEmpty())
            {

                if (CheckTime)
                {
                    {

                        try
                        {

                            LichChieuPhim lcp = new LichChieuPhim();
                            lcp.PhimId = int.Parse(IdPhim.Text);
                            lcp.Thời_gian_bắt_đầu_chiếu = TimeStart.Text;
                            lcp.Thời_gian_kết_thúc_chiếu = TimeFinish.Text;
                            lcp.PhongChieuID = ds.GetIdPhong(Combobox2.Text);
                            lcp.NgayChieu = dateTimePicker1.Value;
                            ds.addorUpdateLichChieuPhim(lcp);

                            CreateGhe(lcp.LCPId);
                            MessageBox.Show("Lưu thành công");



                            LoadDGV();
                            //  loadCbIDLCp();
                        }
                        catch
                        {
                            MessageBox.Show("Lưu thất bại");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần chỉnh sửa thời gian chiếu");
                }
            } 
           
          

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                LichChieuPhim lcp =ds.FindLichChieuPhim(int.Parse(textBox1.Text));
               
                lcp.Thời_gian_bắt_đầu_chiếu = TimeStart.Text;
                lcp.Thời_gian_kết_thúc_chiếu = TimeFinish.Text;
                lcp.PhongChieuID = ds.GetIdPhong(Combobox2.Text);
                lcp.NgayChieu = dateTimePicker1.Value;
                ds.addorUpdateLichChieuPhim(lcp);
                //  ds.removeLichChieuPhim(int.Parse(Combobox2.Text));
                MessageBox.Show("sửa thành công");
                textBox1.Text = "";
                LoadDGV();
                
            }
            catch
            {
                MessageBox.Show("Vui lòng click chọn bộ phim cần sửa");
            }
        }

        private Boolean checkEmpty()
        {
            if (NaneMovie.Text == "" || TimeFinish.Text == "" || TimeStart.Text == "")
            {
                MessageBox.Show("Không được để trống thông tin");
                return false;
            }
            return true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            NaneMovie.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            Combobox2.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
            TimeStart.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            TimeFinish.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            textBox1.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            IdPhim.Text = ds.FindLichChieuPhim(int.Parse(textBox1.Text)).ThongtinPhim.PhimId.ToString();
        }

        Boolean CheckTime =true;
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {        
                if(IdPhim.Text!="")
                {
                    ThongtinPhim ttv = ds.findThongTinPHim(int.Parse(IdPhim.Text));
                    if (dateTimePicker1.Value < DateTime.Now || dateTimePicker1.Value < ttv.NgayBatDauChieu || dateTimePicker1.Value > ttv.NgayKetThuc)
                    {

                        CheckTime = false;
                        MessageBox.Show("Thời gian không hợp lệ");
                      
                    }
                    else
                    {
                        CheckTime = true;
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần phải chọn phim trước");               
                }
               

                
            }
            catch
            {
             
              
              
              
            }
         
        }
    }
}
