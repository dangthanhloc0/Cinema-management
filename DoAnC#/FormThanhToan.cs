using BUS;
using DLL.Model;
using DoAnC_.Properties;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DoAnC_
{
    public partial class FormThanhToan : Form
    {
        List <Label> listLb = new List <Label> ();
        Model1 db=new Model1 ();    
        DataService ds = new DataService ();

        List<Button> btns=new List<Button> ();
        int idkh;
        LichChieuPhim lcp;
       
        public FormThanhToan()
        {
            InitializeComponent();
           
        }

        public FormThanhToan(List<Button> Lbtns,string totalcost,LichChieuPhim lcpO ,int idkh1)
        {
            InitializeComponent();
            btns = Lbtns;
            lcp = lcpO;
            idkh = idkh1;
            TotalCost.Text=totalcost;
            CreateService();
            label4.Text=btns.Count.ToString();
            if (ds.FindAccountIDkh(idkh).VaiTroID == 2)
            {
                phoneNumber.Visible = true;
                textBox1.Visible = true;
            }
        }

        private Image converterByteToImg(byte[] data)
        {
            var avata = new MemoryStream(data);
            Image img = Image.FromStream(avata);
            return img;
        }

        private void CreateGroup(DichVu dv)
        {
            PictureBox img=new PictureBox();
            img.Location = new System.Drawing.Point(71, 21);
            img.Name = "pictureBox1";
            img.Size = new System.Drawing.Size(200, 100);
            img.TabIndex = 2;
            img.TabStop = false;
            if (dv.Anh != null) { img.Image = converterByteToImg(dv.Anh); }
           


            Label tb = new Label();
            tb.AutoSize = true;
            tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tb.Location = new System.Drawing.Point(300, 30);
            tb.Name = "Name";
            tb.Size = new System.Drawing.Size(50, 42);
            tb.TabIndex = 3;
            tb.Text = dv.Tên_dịch_vụ;


            Label lb3 = new Label();
            lb3.AutoSize = true;
            lb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lb3.Location = new System.Drawing.Point(400, 30);
            lb3.Name = "label2";
            lb3.Size = new System.Drawing.Size(50, 42);
            lb3.TabIndex = 12;
            lb3.Text = dv.Giá.ToString(); ;
            // 
            Button btn = new Button();

           btn.AutoSize = true;
            btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn.Location = new System.Drawing.Point(600, 30);
            btn.Name = dv.DichVuID.ToString();
            btn.Size = new System.Drawing.Size(50, 50);
            btn.TabIndex = 6;
            btn.Text = "ADD";
            btn.UseVisualStyleBackColor = true;
            btn.Click += new EventHandler(btn_add);



            Button btn1 = new Button();
            //this.button3.Image =(resources.GetObject("button3.Image")));
            btn1.Location = new System.Drawing.Point(700, 30);
            btn1.Name = dv.DichVuID.ToString();
            btn1.Size = new System.Drawing.Size(50, 50);
            btn1.TabIndex = 7;
            btn1.UseVisualStyleBackColor = true;
            btn1.Text = "xóa";
            btn1.Click += new EventHandler(btn_delete);
          


            // 
            Label lb2=new Label();
           lb2.AutoSize = true;
            lb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lb2.Location = new System.Drawing.Point(1000, 30);
            lb2.Name = dv.DichVuID.ToString();
            lb2.Size = new System.Drawing.Size(46, 52);
            lb2.TabIndex = 11;
            lb2.Text = "0";
            listLb.Add(lb2);
            lb2.TextChanged += new EventHandler(lb2_textChange);
            

         
            // 
            // 
            GroupBox grb=new GroupBox();
       
            grb.Controls.Add(lb2);
            grb.Controls.Add(lb3);
            grb.Controls.Add(btn);
            grb.Controls.Add(btn1);
            grb.Controls.Add(img);
            grb.Controls.Add(tb);
            grb.Location = new System.Drawing.Point(3, 3);
            grb.Name = "groupBox1";
            grb.Size = new System.Drawing.Size(1435, 100);
            grb.TabIndex = 3;
            grb.TabStop = false;
            grb.Text = "groupBox1";

            flowLayoutPanel1.Controls.Add(grb);
        }

        private void btn_add(object sender, EventArgs e)
        {
           Button btn=sender as Button;
            var lb =listLb.FirstOrDefault(p=>p.Name==btn.Name);
            lb.Text=(int.Parse(lb.Text)+1).ToString();
            TotalCost.Text = (Double.Parse(TotalCost.Text) + ds.FindGia(int.Parse(btn.Name))).ToString();
            
        }
      
        private void btn_delete(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var lb = listLb.FirstOrDefault(p => p.Name == btn.Name);
            if (int.Parse(lb.Text) < 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn  hoặc bằng 0");
                lb.Text = "0";
                return;
            }         
            lb.Text = (int.Parse(lb.Text) - 1).ToString();
            TotalCost.Text = (Double.Parse(TotalCost.Text) - ds.FindGia(int.Parse(btn.Name))).ToString();
          

        }

        private void lb2_textChange(object sender, EventArgs e)
        {
         
    
        }

        public void CreateService()
        {
            foreach(var item in ds.GetAllDichVu())
            {
                CreateGroup(item);
            }
        }
       
        private void button1_Click(object sender, EventArgs e)
        {

            if (ds.FindAccountIDkh(idkh).VaiTroID == 2)
            {
                if(textBox1.Text=="")
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại của khách hàng");
                    return;
                }
                else
                {
                    try
                    {
                        if (ds.FindAccount(textBox1.Text) != null)
                        {
                            idkh = ds.FindAccount(textBox1.Text).KhachHangId;
                        }
                        else
                        {
                            MessageBox.Show("Không tồn tại khách hàng này");
                            return;
                        }
                     
                        
                    }
                    catch
                    {
                     
                    }                 
                }
                 
            }

            DialogResult dlg = MessageBox.Show("Bạn có muốn thanh toán không?", "Thông báo", MessageBoxButtons.YesNo);
            if(dlg== DialogResult.Yes) {
                using (var transaction = db.Database.BeginTransaction())
                    try
                    {
                        Ve v = new Ve();
                        v.Ngày_bán_vé = DateTime.Now;
                        v.Thành_tiền = float.Parse(TotalCost.Text);
                        v.KhachHangId = idkh;
                        ds.AddVe(v);



                        foreach (var iteam in btns)
                        {
                            ThongTinVe ttv = new ThongTinVe();
                            ttv.VeID = v.VeID;
                            ttv.GheID = iteam.Name;
                            ttv.LCPid = lcp.LCPId;
                            ds.AddTtv(ttv);
                            UpdateStatusSeat(iteam);
                        }

                        foreach (var iteam in listLb)
                        {
                            ChiTietDichVu ctdv = new ChiTietDichVu();
                            ctdv.VeID = v.VeID;
                            ctdv.DichVuID = int.Parse(iteam.Name);
                            ctdv.Số_lượng = int.Parse(iteam.Text);
                            ctdv.Thành_tiền = (int.Parse(iteam.Text) * ds.FindGia(int.Parse(iteam.Name)));
                            ds.AddCTDV(ctdv);
                        }


                        transaction.Commit();
                        MessageBox.Show("Thanh toán thành công");
                        this.Close();
                        ////kkgg

                    }
                    catch
                    {
                        transaction.Rollback();
                        MessageBox.Show("Thanh toán thất  bại");
                    }
            }
         
        }
        private void UpdateStatusSeat(Button btn)
        {
            //Ghe ghe = new Ghe();
            ChiTietGhe ctg = db.ChiTietGhes.FirstOrDefault(p => p.GheID == btn.Name && p.LCPID==lcp.LCPId);
            ctg.TTGID = 1;
            ds.AddChiTietGhe(ctg);
        }
    }
}
