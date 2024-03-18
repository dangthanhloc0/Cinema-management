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
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


using DoAnC_.Properties;
using GroupBox = System.Windows.Forms.GroupBox;

using System.Reflection;

namespace DoAnC_
{
    public partial class manhinhchinh : Form
    {
        Model1 db = new Model1();
        DataService ds=new DataService();
        int idKh=-1;
        List<GroupBox> groups = new List<GroupBox>();   
        public manhinhchinh(int id)
        {
          
            InitializeComponent();
            UnitMovie();
            idKh = id;
            LoginSuccess(idKh);
            btndangky.Visible = false;
            btndangnhap.Visible = false;
            panel2.Visible = true;
            if (ds.FindAccountIDkh(idKh).VaiTroID == 2)
            {
                label1.Visible = true;
            }
        }

        public manhinhchinh()
        {
            InitializeComponent();
            UnitMovie();

            //int index = 64;
            //for (int i = 0; i < 10; i++)
            //{
            //    index++;
            //    int stt = 0;
            //    for (int j = 0; j < 13; j++)
            //    {
            //        stt++;
            //        Ghe g = new Ghe();
            //        g.GheID = ((char)index).ToString();
            //        g.TTGID = 0;
            //        // g.LoaiTrangThaiGhe =
            //        g.PhongChieuID = 3;
            //        if (i < 4)
            //        {
            //            g.LoaiGheID = 1;
            //        }
            //        else
            //        {
            //            g.LoaiGheID = 2;
            //        }
            //    }
            //}


        }

        public void UnitMovie()
        {
            DateTime Today= DateTime.Now;   
            List<ThongtinPhim> ListMovie = ds.GetALLThongTinPhim().Where(p=>p.NgayBatDauChieu<= Today && p.NgayKetThuc> Today).ToList();
            foreach(ThongtinPhim item in ListMovie)
            {
                createGroupMovie(item);
            }
        }

     
        private void LoginSuccess(int id)
        {
            if (id != -1)
            {
                KhachHang User =ds.FindCustomer(id);
                UserName.Text=User.TenKhachHang.ToString();
                UserName.Visible = true;
                if (User.Anh!=null) {
                    pictureBox1.Image = converterByteToImg(User.Anh);
                    pictureBox1.Visible = true;
                }
                btndangky.Visible = false;
                btndangnhap.Visible=false;
              
                
            }
        }


        private Image converterByteToImg(byte[] data)
        {
            var avata = new MemoryStream(data);
            Image img = Image.FromStream(avata);
            return img;
        }    

  


        private void createGroupMovie(ThongtinPhim Movie)
        {
            Button btn = new Button();
            btn.BackgroundImage = converterByteToImg(Movie.anh);
            btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btn.Location = new System.Drawing.Point(30, 24); // Move down by 5 pixels
            btn.Name = Movie.PhimId.ToString();
            btn.Size = new System.Drawing.Size(249, 361);
            btn.TabIndex = 21;
            btn.UseVisualStyleBackColor = true;

            TextBox tb = new TextBox();
            tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            tb.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tb.Location = new System.Drawing.Point(41, 386);
            tb.Name = "textBox1";
            tb.Size = new System.Drawing.Size(203, 23);
            tb.TabIndex = 15;
            tb.Text = Movie.TenPhim;

            tb.TextAlign = HorizontalAlignment.Center; // Center align the text

            TextBox tb1 = new TextBox();
            tb1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            tb1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tb1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            tb1.Location = new System.Drawing.Point(20, 415);
            tb1.Name = "textBox2";
            tb1.Size = new System.Drawing.Size(243, 20);
            tb1.TabIndex = 16;
            tb1.Text = ds.GetTheLoai(Movie);

            tb1.TextAlign = HorizontalAlignment.Center; // Center align the text

            Button btn1 = new Button();
            btn1.BackColor = System.Drawing.Color.HotPink;
            btn1.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn1.ForeColor = System.Drawing.SystemColors.HighlightText;
            btn1.Location = new System.Drawing.Point(95, 439); // Move down by 5 pixels
            btn1.Name = Movie.PhimId.ToString();
            btn1.Size = new System.Drawing.Size(87, 38);
            btn1.TabIndex = 11;
            btn1.Text = "Đặt vé";
            btn1.UseVisualStyleBackColor = false;
            btn1.Click += new EventHandler(Grp_Click);

            GroupBox grb = new GroupBox();
            grb.Controls.Add(btn);
            grb.Controls.Add(btn1);
            grb.Controls.Add(tb1);
            grb.Controls.Add(tb);
            grb.Location = new System.Drawing.Point(20, 31);
            grb.Name = Movie.PhimId.ToString();
            grb.Size = new System.Drawing.Size(298, 493);
            grb.TabIndex = 22;
            grb.TabStop = false;
            groups.Add(grb);

            this.flowLayoutPanelMovies.Controls.Add(grb);
        }

        public void Grp_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Form Movie = new movie1(int.Parse(btn.Name), idKh);
            Movie.ShowDialog();
            
        }



        
        private void btndangnhap_Click(object sender, EventArgs e)
        {
            Form DangNhap = new DangNhap();
            DangNhap.ShowDialog();
        }

        private void btndangky_Click(object sender, EventArgs e)
        {
            Form DangKi = new DangKi();
            DangKi.ShowDialog();
        }


        private void thôngTinCáNhânToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form Nform = new trangcanhanF(idKh);
            Nform.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in groups)
            {
                if(ds.findThongTinPHim(int.Parse(item.Name)).TenPhim.Contains(textBox1.Text)){
                    item.Visible = true;
                }
                else
                {
                    item.Visible = false;   
                }
            }
        }

        private void manhinhchinh_Load(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
