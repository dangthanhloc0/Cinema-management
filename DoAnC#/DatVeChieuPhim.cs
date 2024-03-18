
using BUS;
using DLL.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace DoAnC_
{

    public partial class DatVeChieuPhim : Form
    {
        Model1 db = new Model1();
        DataService ds=new DataService();
        int idkh3;
        int idLcp;
        LichChieuPhim lcp;
        List<Button> buttons = new List<Button>();
        public DatVeChieuPhim()
        {
            InitializeComponent();
           
        }

        public DatVeChieuPhim(int IDLCP,int idKh)
        {
            InitializeComponent();
          
            idLcp = IDLCP;
            idkh3 = idKh;
            create();

            lcp = ds.FindLichChieuPhim(idLcp);
            NameRoom.Text = lcp.PhongChieu.Tên_Phòng.ToString();
            PhongChieu pc = db.PhongChieux.FirstOrDefault(p => p.Tên_Phòng == NameRoom.Text);
            totalCost.Text = (double.Parse(totalCost.Text) + pc.loaiPhong.Giá_Thêm).ToString();
        }



        private void create()
        {
            int index = 64;

            for (int i = 0; i < 10; i++)
            {
                index++;
                int stt = 0;

               // List<Ghe> ghe = db.Ghes.ToList();


                for (int j = 0; j < 13; j++)
                {

                    stt++;
                    Button btn = new Button();
                    btn.Name = ((char)index).ToString() + stt.ToString();

                    btn.Text = ((char)index).ToString() + stt.ToString();
                    btn.Size = new Size(40, 30);
                    btn.UseVisualStyleBackColor = true;

                    if (j == 0)
                    {
                        btn.Margin = new System.Windows.Forms.Padding(45, 3, 0, 0);
                    }
                    if (j == 12)
                    {
                        btn.Margin = new System.Windows.Forms.Padding(0, 3, 45, 0);
                    }

                    if (i < 4)
                    {
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderColor = Color.Green;
                        btn.FlatAppearance.BorderSize = 1;
                    }
                    else
                    {
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderColor = Color.OrangeRed;
                        btn.FlatAppearance.BorderSize = 1;
                    }

                    btn.Click += new System.EventHandler(btn_Click);
                    FLP.Controls.Add(btn);


                 //   MessageBox.Show(btn.Name + "  " + idLcp);

                    ChiTietGhe ctg = db.ChiTietGhes.FirstOrDefault(p => p.GheID == btn.Name && p.LCPID == idLcp);
                  
                   //MessageBox.Show(ctg.LCPID.ToString());
                  if (ctg.TTGID == 1)
                    {
                        btn.BackColor = Color.Gray;
                        btn.Enabled = false;
                    }

                }
            }



            int sttVip = 0;
            index++;
            for (int i = 0; i < 15; i++)
            {

                sttVip++;
                Button btn = new Button();
                btn.Name = ((char)index).ToString() + sttVip.ToString();
                btn.Text = ((char)index).ToString() + sttVip.ToString();
                btn.Size = new Size(40, 30);
                btn.UseVisualStyleBackColor = true;
                btn.BackColor = Color.DeepPink;
                btn.Click += new System.EventHandler(btn_Click);
                FLP.Controls.Add(btn);


                ChiTietGhe g = new ChiTietGhe();
                g = db.ChiTietGhes.FirstOrDefault(p => p.GheID == btn.Name && p.LCPID == idLcp);

              if (g.TTGID == 1)
                {
                    btn.BackColor = Color.Gray;
                    btn.Enabled = false;
                }
            }

        }


        private void btn_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            if (btn.BackColor == Color.Red)
            {
                if (btn.Name.Contains("K"))
                    btn.BackColor = Color.DeepPink;
                else
                    btn.BackColor = Color.White;
                buttons.Remove(btn);
            }
            else
            {
                btn.BackColor = Color.Red;
                buttons.Add(btn);
            }

            totalCost.Text = TotalChoose().ToString();
        }

        private float TotalChoose()
        {
            float TotalCost = 0;
            foreach (var iteam in buttons)
            {
                Ghe ghe = new Ghe();
                ghe = db.Ghes.FirstOrDefault(p => p.GheID == iteam.Name);
                TotalCost += ghe.LoaiGhe.Gia;
            }
            return TotalCost;
        }

      



        private void button9_Click(object sender, EventArgs e)
        {

            Form TToan = new FormThanhToan(buttons, totalCost.Text, lcp,idkh3);
            TToan.ShowDialog();
        }
    }
}
