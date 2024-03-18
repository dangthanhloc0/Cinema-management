using BUS;
using DLL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnC_
{
    public partial class trangcanhanF : Form
    {
        int idkh1 = -1;
        DataService ds=new DataService();
        Model1 db=new Model1(); 
        public trangcanhanF( )
        {
            InitializeComponent();
        }
        public trangcanhanF(int idKh)
        {
            InitializeComponent();
            idkh1 = idKh;
            LoadThongTin(ds.FindCustomer(idkh1));
            label1.Text = label2.Text = ds.countVeIdKh(idkh1).ToString();
        }

        public void LoadThongTin(KhachHang kh)
        {
            if(kh.Anh!=null)
            {
                pictureBox1.Image = converterByteToImg(kh.Anh);
            }    
            Name.Text = kh.TenKhachHang.ToString();
            Call.Text = ds.GetPhone(kh.KhachHangId);
            
           
        }

        private Image converterByteToImg(byte[] data)
        {
            var avata = new MemoryStream(data);
            Image img = Image.FromStream(avata);
            return img;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new DoiMatKhau(ds.GetPhone(ds.FindCustomer(idkh1).KhachHangId));
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new FormVeKhachHang(idkh1);
            f.ShowDialog(); 
        }

        private byte[] SaveAvata(PictureBox Pbox)
        {
            MemoryStream mmstr = new MemoryStream();
            if (Pbox != null)
            {
                Pbox.Image.Save(mmstr, Pbox.Image.RawFormat);
                return mmstr.ToArray();
            }
            return null;


        }

     

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPEG Image|*.jpg|All Files|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(dlg.FileName);
                pictureBox1.Image = img;

            }

            try
            {
                KhachHang kh = ds.FindCustomer(idkh1);
                kh.Anh = SaveAvata(pictureBox1);
                ds.Addcustommer(kh);
                MessageBox.Show("Cập nhập thành công");
            }
            catch
            {
                MessageBox.Show("Cập nhập thành công");
            }
        }

        private void trangcannhanF_Load(object sender, EventArgs e)
        {

        }

        private void Name_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
