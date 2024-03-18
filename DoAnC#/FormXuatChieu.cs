using BUS;
using DLL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace DoAnC_
{
    public partial class FormXuatChieu : Form
    {

        ThongtinPhim movie1 = new ThongtinPhim();
        DataService ds = new DataService();
        int idkh2;
        int i = 0;
       
        public FormXuatChieu()
        {
            InitializeComponent();
        }

        public FormXuatChieu(ThongtinPhim movie,int idkh)
        {
       
            InitializeComponent();
            pictureBox1.Image = converterByteToImg(movie.anh);
            movie1 = movie;
            idkh2 = idkh;
            label1.Text = movie1.TenPhim;
            LoadTimeXuatChieu();
        }

        private Image converterByteToImg(byte[] data)
        {
            var avata = new MemoryStream(data);
            Image img = Image.FromStream(avata);
            return img;
        }

        public string getTime(string time)
        {
            string result = "";
           for(int i = 0; i < time.Length; i++) {
                result += time[i];
                if (i == 10)
                    break;
            }
            return result;

        }
        private void crateGrb(LichChieuPhim lcp)
        {

       

            Button btn =new Button();
            btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn.Location = new System.Drawing.Point(51, 21);
            btn.Name =lcp.LCPId.ToString();
            btn .Size = new System.Drawing.Size(216, 110);
            btn.TabIndex = 0;
            btn.Text =lcp.PhongChieu.Tên_Phòng;
            btn.UseVisualStyleBackColor = true;
            btn.Click += new EventHandler(btn_click);
            // 
            // label2
            // 
            Label lb2= new Label(); 
            lb2.AutoSize = true;
            lb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lb2.Location = new System.Drawing.Point(46, 148);
            lb2.Name = "label2";
            lb2.Size = new System.Drawing.Size(26, 29);
            lb2.TabIndex = 1;
            lb2.Text =lcp.Thời_gian_bắt_đầu_chiếu;
            lb2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            Label lb3 = new Label();
            lb3.AutoSize = true;
            lb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lb3.Location = new System.Drawing.Point(169, 190);
            lb3.Name = "label3";
            lb3.Size = new System.Drawing.Size(125, 29);
            lb3.TabIndex = 2;

            lb3.Text = getTime(lcp.NgayChieu.ToString());
            // 
            // label4
            // 
            Label lb4 = new Label();
           lb4.AutoSize = true;
            lb4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lb4.Location = new System.Drawing.Point(241, 148);
            lb4.Name = "label4";
            lb4.Size = new System.Drawing.Size(26, 29);
            lb4.TabIndex = 3;
            lb4.Text = lcp.Thời_gian_kết_thúc_chiếu;
            // 
            // label5
            // 
            Label lb5 = new Label();
            lb5.AutoSize = true;
            lb5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lb5.Location = new System.Drawing.Point(124, 148);
            lb5.Name = "label5";
            lb5.Size = new System.Drawing.Size(57, 29);
            lb5.TabIndex = 4;
            lb5.Text = "Đến";
            lb5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            Label lb6 = new Label();
            lb6.AutoSize = true;
            lb6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lb6.Location = new System.Drawing.Point(24, 233);
            lb6.Name = "label6";
            lb6.Size = new System.Drawing.Size(149, 29);
            lb6.TabIndex = 5;
            lb6.Text = "Tổng số ghế";
            // 
            // label7
            // 
            Label lb7 = new Label();
            lb7.AutoSize = true;
            lb7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lb7.Location = new System.Drawing.Point(210, 233);
            lb7.Name = "label7";
            lb7.Size = new System.Drawing.Size(59, 29);
            lb7.TabIndex = 6;
            lb7.Text = ds.CountChar(lcp.LCPId)+"/145";
            // 
            // label8
            // 
            Label lb8 = new Label();
            lb8.AutoSize = true;
            lb8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lb8.Location = new System.Drawing.Point(24, 190);
            lb8.Name = "label8";
            lb8.Size = new System.Drawing.Size(139, 29);
            lb8.TabIndex = 7;
            lb8.Text = "Ngày chiếu ";
            lb8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            i++;

            GroupBox grp = new GroupBox();
            grp.Controls.Add(lb2);
            grp.Controls.Add(lb3);
            grp.Controls.Add(lb4);
            grp.Controls.Add(lb5);
            grp.Controls.Add(lb6);
            grp.Controls.Add(lb7);
            grp.Controls.Add(lb8);
            grp.Controls.Add(btn);
            grp.Location = new System.Drawing.Point(3, 3);
            grp.Name = "groupBox1";
            grp.Size = new System.Drawing.Size(325, 281);
            grp.TabIndex = 0;
            grp.TabStop = false;
            grp.Text ="Xuất "+i.ToString();
            
            // 

            flowLayoutPanel1.Controls.Add(grp);
        }

        private void btn_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
           // MessageBox.Show(btn.Name);
            Form DatVe = new DatVeChieuPhim(int.Parse(btn.Name), idkh2);
            DatVe.ShowDialog();
        }

        private void LoadTimeXuatChieu()
        {
            DateTime Today = DateTime.Now;
            List<LichChieuPhim> ListLichChieuPhim = ds.GetLichChieuPhim(movie1.PhimId); 
            foreach(var item in ListLichChieuPhim)
            {
                crateGrb(item);
            }
           
        
        }

    
    }
}
