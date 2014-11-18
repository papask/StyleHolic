using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Net;

namespace BackorderManagement
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            InitBind();
        }

        protected void InitBind()
        {
            listBox1.Items.Add("SW7115");
            listBox1.Items.Add("B6607");
            listBox1.Items.Add("B6612");
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            HttpWebRequest myRequest;
            HttpWebResponse myResponse;
            System.Drawing.Bitmap bmp;

            dvList.Rows.Clear();
            dataGridView1.Rows.Clear();

            switch (listBox1.Text.ToUpper())
            {
                case "SW7115":
                    myRequest = (HttpWebRequest)WebRequest.Create("https://d1cp2g0bs3j72.cloudfront.net/Vendors/0styleholic/ProductImage/list/3618245_0102113_066%20copy.jpg");
                    myRequest.Method = "GET";
                    myResponse = (HttpWebResponse)myRequest.GetResponse();
                    bmp = new System.Drawing.Bitmap(myResponse.GetResponseStream());
                    myResponse.Close();

                    pictureBox1.Image = bmp;
                    dvList.Rows.Add("aaa", "black", "5");
                    dvList.Rows[0].Cells[0].Selected = false;

                    label1.Text = "SW7115";
                    label2.Text = "KATE";
                    break;

                case "B6607":
                    myRequest = (HttpWebRequest)WebRequest.Create("https://d1cp2g0bs3j72.cloudfront.net/Vendors/0styleholic/ProductImage/list/674d361a-dea9-4055-9431-e6ca8b30df2b.jpg");
                    myRequest.Method = "GET";
                    myResponse = (HttpWebResponse)myRequest.GetResponse();
                    bmp = new System.Drawing.Bitmap(myResponse.GetResponseStream());
                    myResponse.Close();

                    pictureBox1.Image = bmp;
                    dvList.Rows.Add("bbb", "black", "5");
                    dvList.Rows[0].Cells[0].Selected = false;

                    label1.Text = "B6607";
                    label2.Text = "22nd";
                    break;

                case "B6612":
                    myRequest = (HttpWebRequest)WebRequest.Create("https://d1cp2g0bs3j72.cloudfront.net/Vendors/0styleholic/ProductImage/list/3643501_3643501-0102914C-338copy.jpg");
                    myRequest.Method = "GET";
                    myResponse = (HttpWebResponse)myRequest.GetResponse();
                    bmp = new System.Drawing.Bitmap(myResponse.GetResponseStream());
                    myResponse.Close();

                    pictureBox1.Image = bmp;
                    dvList.Rows.Add("ccc", "black", "5");
                    dvList.Rows[0].Cells[0].Selected = false;

                    label1.Text = "B6612";
                    label2.Text = "22nd";
                    break;

                default:
                    break;
            }
        }

        private void dvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows.Clear();

            dataGridView1.Rows.Add("ET0812", "white", "4");
            dataGridView1.Rows.Add("ET0813", "red", "4");
            dataGridView1.Rows.Add("ET0814", "blue", "4");
            dataGridView1.Rows.Add("ET0815", "black", "4");

            dataGridView1.Rows[0].Cells[0].Selected = false;
        }
    }
}
