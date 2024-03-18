using BUS;
using DLL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace DoAnC_
{
    public partial class FormThongKe : Form
    {
        Model1 db=new Model1 ();    
        DataService ds=new DataService ();
        public FormThongKe()
        {
            InitializeComponent();
        
        }

        private void FormThongKe_Load(object sender, EventArgs e)
        {
            ListtotalCost = LoadDoanhThu(ListtotalCost);
            LoadChartBDT();
            LoadChartBDC();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                ChartBDC.Visible = true;
           
            }
            else
            {
                ChartBDC.Visible = false;   
            }
        }

        private double TotalRevenue(List<Ve> list,int i)
        {
            double total = 0;
            if(list.Count>0)
            {                
                foreach (Ve ve in list)
                {
                    DateTime dt = DateTime.Parse(ve.Ngày_bán_vé.ToString());
                    if (dt.Month == i && dt.Year==DateTime.Now.Year)
                    {
                        total += ve.Thành_tiền;
                    }
                }
            }    
           
            return total;
        }


        List<double> ListtotalCost = new List<double> ();
        public List<double> LoadDoanhThu(List<double> ls)
        {
            for (int i = 0; i < 12; i++)
            {
                double result = TotalRevenue(ds.GetAllVe(), i + 1);
                ls.Add(result);
            }

            return ls;
        }

        private void LoadChartBDC()
        {
            for (int i = 0; i < 12; i++)
            {
                double result = TotalRevenue(ds.GetAllVe(), i + 1);
                ChartBDC.Series["ChartBDC"].Points.Add(result);
                ChartBDC.Series["ChartBDC"].Points[i].Label= result.ToString();
                ChartBDC.Series["ChartBDC"].Points[i].Color =Color.Blue;
                ChartBDC.Series["ChartBDC"].Points[i].AxisLabel = (i+1).ToString();
               

            }
            int indexMin = ListtotalCost.IndexOf(ListtotalCost.Min());
            int indexMax= ListtotalCost.IndexOf(ListtotalCost.Max());
            ChartBDC.Series["ChartBDC"].Points[indexMin].Color = Color.Yellow;
            ChartBDC.Series["ChartBDC"].Points[indexMax].Color = Color.Red;
        }
        

        private void LoadChartBDT()
        {
            Random random = new Random();
            int index = 0;
            for (int i = 0; i < 12; i++)
            {
               
                double result = TotalRevenue(ds.GetAllVe(), i + 1);
                if (result != 0)
                {
                    chart1.Series["ChartBDC"].Points.Add(result);
                  
                    chart1.Series["ChartBDC"].Points[index].Label = "Tháng " + (i + 1).ToString() + "  " + result.ToString();
                    chart1.Series["ChartBDC"].Points[index].Color = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
                    //  chart1.Series["ChartBDC"].Points[i].AxisLabel = "Tháng";
                    index++;
                }



            }
        }
         




        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                chart1.Visible = true;
                
            }
            else
            {
                chart1.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                label1.Visible = true;
              label1.Text= ListtotalCost.Sum().ToString();

            }
            else
            {
                label1.Visible = false;
                label1.Text = "0";
            }
        }
    }
}
