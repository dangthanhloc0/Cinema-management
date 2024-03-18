using BUS;
using DLL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Internal;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnC_
{
    public partial class movie1 : Form
    {

        ThongtinPhim movie=new ThongtinPhim();
        DataService ds=new DataService();
        int idkh1;
        int idPhim1;
        public movie1()
        {
            InitializeComponent();
        }

        public movie1(int idPhim, int idkh)
        {
            InitializeComponent();
            movie = ds.findThongTinPHim(idPhim);
            pictureBox1.Image = converterByteToImg(movie.anh);
            richTextBox1.Text = movie.Mota;
            textBox1.Text = movie.TenPhim;
            textBox3.Text = "Thời lượng" + movie.Thời_lượng;
            textBox2.Text = ds.GetNameTheLoai(idPhim);
            idkh1 = idkh;
           
        }

        private Image converterByteToImg(byte[] data)
        {
            var avata = new MemoryStream(data);
            Image img = Image.FromStream(avata);
            return img;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (idkh1 == -1)
            {
               DialogResult dlg= MessageBox.Show("Bạn cần đăng nhập trước", "Thông báo", MessageBoxButtons.YesNo);
                if(dlg == DialogResult.Yes)
                {
                    Form Login = new DangNhap();
                    Login.ShowDialog(); 
                }
            }
            else
            {
                if (ds.GetLichChieuPhim(movie.PhimId).Count<=0)
                {
                    MessageBox.Show("Hiện tại nhà  sản xuất chưa có lịch chiếu phim");
                   
                }
                else
                {
                    Form xuatChieu = new FormXuatChieu(movie, idkh1);
                    xuatChieu.ShowDialog();

                }
            
            }
         
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
