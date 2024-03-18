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
using System.Windows.Forms;

namespace DoAnC_
{

    public partial class FormDichVU : Form
    {
        Model1 db = new Model1();
        DataService ds = new DataService();
        public FormDichVU()
        {
            InitializeComponent();
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dataGridView1.Columns[3];
            pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadDGV(List<DichVu> DichVu)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in DichVu)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.DichVuID;
                dataGridView1.Rows[index].Cells[1].Value = item.Tên_dịch_vụ;
                dataGridView1.Rows[index].Cells[2].Value = item.Giá;
                dataGridView1.Rows[index].Cells[3].Value = item.Anh;
            }
        }
            
        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                DichVu dv = new DichVu();
                dv.Tên_dịch_vụ = Name.Text;
                dv.Giá = int.Parse(Cost.Text);
                dv.Anh = SaveAvata(pictureBox1);
                ds.AddOrUpdateService(dv);
                MessageBox.Show("Thêm thành công");
                LoadDGV(ds.GetAllDichVu());
            }
            catch
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                DichVu dv = ds.GetAllDichVu().FirstOrDefault(p=> p.DichVuID == int.Parse(id.Text));
                
                //dv = ds.FindService(int.Parse(id.Text));
                dv.Tên_dịch_vụ = Name.Text;
                dv.Giá = int.Parse(Cost.Text.Trim());
               // dv.Anh = SaveAvata(pictureBox1);
                ds.AddOrUpdateService(dv);
                MessageBox.Show("Sửa thành công");
                LoadDGV(ds.GetAllDichVu());
            }
            catch
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = int.Parse(id.Text);
                ds.RemoveServide(Id);
                MessageBox.Show("xóa thành công");
                LoadDGV(ds.GetAllDichVu());
            }
            catch
            {
                MessageBox.Show("xóa thất bại");
            }
        }

        private Image converterByteToImg(byte[] data)
        {
            var avata = new MemoryStream(data);
            Image img = Image.FromStream(avata);
            return img;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            id.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            Name.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            Cost.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            pictureBox1.Image = null;
           
        }

        private void FormDichVu_Load(object sender, EventArgs e)
        {
            LoadDGV(ds.GetAllDichVu());
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

        private byte[] SaveAvata(PictureBox Pbox)
        {
            MemoryStream mmstr = new MemoryStream();
            Pbox.Image.Save(mmstr, Pbox.Image.RawFormat);
            return mmstr.ToArray();
        }

        private void Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cost_TextChanged(object sender, EventArgs e)
        {

        }

        private void id_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
