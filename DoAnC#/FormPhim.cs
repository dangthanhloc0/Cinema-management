using BUS;
using DLL.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;


namespace DoAnC_
{
    public partial class FormPhim : Form
    {

        DataService ds = new DataService();
        List<CheckBox> ckB = new List<CheckBox>();
        Model1 db = new Model1();

        public FormPhim()
        {
            InitializeComponent();
            LoadCheckBox();
            //LoaiCb();
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dataGridView1.Columns[5];
            pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void FormPhim_Load(object sender, EventArgs e)
        {
            loadDGV(ds.GetALLThongTinPhim());
        }


        private void loadDGV(List<ThongtinPhim> Ttp)

        {
            dataGridView1.Rows.Clear();
            foreach (var item in Ttp)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.PhimId;
                dataGridView1.Rows[index].Cells[1].Value = item.TenPhim;
                dataGridView1.Rows[index].Cells[2].Value = ds.GetNameTheLoai(item.PhimId);
                dataGridView1.Rows[index].Cells[3].Value = item.NgayBatDauChieu;
                dataGridView1.Rows[index].Cells[4].Value = item.NgayKetThuc;
                dataGridView1.Rows[index].Cells[5].Value = item.anh;
                dataGridView1.Rows[index].Cells[6].Value = item.Thời_lượng;
                dataGridView1.Rows[index].Cells[7].Value = item.Mota;


            }
        }

        private void LoadCheckBox()
        {
            foreach (var item in ds.GetALLTheloaiPhim())
            {
                CheckBox ck = new CheckBox();
                ck.AutoSize = true;
                ck.Location = new System.Drawing.Point(12, 130);
                ck.Name = item.TheLoaiId.ToString();
                ck.Size = new System.Drawing.Size(95, 20);
                ck.TabIndex = 2;
                ck.Text = item.Tên_Thể_loại.ToString();
                ck.UseVisualStyleBackColor = true;

                flowLayoutPanel1.Controls.Add(ck);
                ckB.Add(ck);
            }

        }

        private void add_Click(object sender, EventArgs e)
        {

            using (var transaction = db.Database.BeginTransaction())
                try
                {
                    
                    if (checkEmpty() && timeCheck())
                    {
                        ThongtinPhim Movie = new ThongtinPhim();
                        Movie.TenPhim = Name.Text;
                        Movie.NgayBatDauChieu = dateTimePicker1.Value;
                        Movie.NgayKetThuc = dateTimePicker2.Value;
                        Movie.Thời_lượng = time.Text;
                        Movie.Mota = textBox2.Text;
                        Movie.anh = SaveAvata(pictureBox1);
                        ds.AddOrUpdatePhim(Movie);
                        foreach (var item in ckB)
                        {
                            ChiTIetTheLoaiPhinm ctl = new ChiTIetTheLoaiPhinm();
                           
                            if (item.Checked == true)
                            {
                                ctl.PhimID = Movie.PhimId;
                                ctl.TheLoaiID = int.Parse(item.Name);
                                ds.AddOrUpdateCTTheLoaiPhim(ctl);
                            }

                        }

                        transaction.Commit();
                        loadDGV(ds.GetALLThongTinPhim());
                        //LoaiCb();
                        MessageBox.Show("Lưu phim thành công");

                    }
                }
                catch
                {
                    transaction.Rollback();
                    MessageBox.Show("Lưu thất bại");
                }
        }

        //private void delete_Click(object sender, EventArgs e)
        //{
        //    DialogResult dlg = MessageBox.Show("Bạn có muốn xóa  bộ phim này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        //    if (dlg == DialogResult.OK)
        //    {
        //        using (var transaction = db.Database.BeginTransaction())
        //            try
        //            {
                       
        //                ds.removeMovie(ds.findThongTinPHim(idMovie));
        //                transaction.Commit();
        //                loadDGV(ds.GetALLThongTinPhim());
                       
        //                MessageBox.Show("xóa thành công");
        //            }
        //            catch
        //            {
        //                transaction.Rollback();
        //                MessageBox.Show("Xóa thất bại");
        //            }
        //    }

        //}
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



        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPEG Image|*.jpg|All Files|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(dlg.FileName);
                pictureBox1.Image = img;

            }
        }

        private void thêmDiễnViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Describer_Click(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Visible = false;
            button2.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value < DateTime.Now)
            {
                MessageBox.Show("Thời gian không hợp lệ");
                
            }


        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                MessageBox.Show("Thời gian không hợp lệ");
            }



        }

        private Boolean timeCheck()
        {
            if (dateTimePicker1.Value >  dateTimePicker2.Value) 
            {
                MessageBox.Show("Thời gian không hợp lệ");
                return false;    
            }
            return true;
        }

        private Boolean checkEmpty()
        {
            if (Name.Text == "" || time.Text == "" || pictureBox1 == null)
            {
                MessageBox.Show("không được để trống thông tin");
                return false;
            }
            return true;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
