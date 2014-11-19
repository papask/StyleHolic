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
            dvStyleList.Rows.Add("KATE", "SW7115");
            dvStyleList.Rows.Add("22nd", "B6607");
            dvStyleList.Rows.Add("22nd", "B6612");

            dvStyleList.Rows[0].Cells[0].Selected = false;
        }

        private void dvStyleList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HttpWebRequest myRequest;
            HttpWebResponse myResponse;
            System.Drawing.Bitmap bmp;

            dvCustomerList.Rows.Clear();
            dvRemainItemList.Rows.Clear();

            if (e.RowIndex > -1 && dvStyleList.Rows[e.RowIndex].Cells[1].Value != null)
            {
                String strSelectedStyleNo = dvStyleList.Rows[e.RowIndex].Cells[1].Value.ToString();

                switch (strSelectedStyleNo.ToUpper())
                {
                    case "SW7115":
                        myRequest = (HttpWebRequest)WebRequest.Create("https://d1cp2g0bs3j72.cloudfront.net/Vendors/0styleholic/ProductImage/list/3618245_0102113_066%20copy.jpg");
                        myRequest.Method = "GET";
                        myResponse = (HttpWebResponse)myRequest.GetResponse();
                        bmp = new System.Drawing.Bitmap(myResponse.GetResponseStream());
                        myResponse.Close();

                        pictureBox1.Image = bmp;
                        dvCustomerList.Rows.Add("UGFCFC4ACE35-BO", "aaa", "black", "5");
                        dvCustomerList.Rows.Add("UGFCFC4ACE35-BO", "asa", "red", "5");
                        dvCustomerList.Rows.Add("UGFCFC4ACE35-BO", "ada", "black", "3");
                        dvCustomerList.Rows[0].Cells[0].Selected = false;
                        break;

                    case "B6607":
                        myRequest = (HttpWebRequest)WebRequest.Create("https://d1cp2g0bs3j72.cloudfront.net/Vendors/0styleholic/ProductImage/list/674d361a-dea9-4055-9431-e6ca8b30df2b.jpg");
                        myRequest.Method = "GET";
                        myResponse = (HttpWebResponse)myRequest.GetResponse();
                        bmp = new System.Drawing.Bitmap(myResponse.GetResponseStream());
                        myResponse.Close();

                        pictureBox1.Image = bmp;
                        dvCustomerList.Rows.Add("RAYD007259A1-BO", "bbb", "black", "5");
                        dvCustomerList.Rows.Add("RAYD007259A1-BO", "bcb", "white", "2");
                        dvCustomerList.Rows.Add("RAYD007259A1-BO", "bdb", "yellow", "5");
                        dvCustomerList.Rows[0].Cells[0].Selected = false;
                        break;

                    case "B6612":
                        myRequest = (HttpWebRequest)WebRequest.Create("https://d1cp2g0bs3j72.cloudfront.net/Vendors/0styleholic/ProductImage/list/3643501_3643501-0102914C-338copy.jpg");
                        myRequest.Method = "GET";
                        myResponse = (HttpWebResponse)myRequest.GetResponse();
                        bmp = new System.Drawing.Bitmap(myResponse.GetResponseStream());
                        myResponse.Close();

                        pictureBox1.Image = bmp;
                        dvCustomerList.Rows.Add("RAYD007259A1-BO", "ccc", "black", "5");
                        dvCustomerList.Rows[0].Cells[0].Selected = false;
                        break;

                    default:
                        break;
                }
            }
        }

        private void dvCustomerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && dvCustomerList.Rows[e.RowIndex].Cells[1].Value != null)
            {
                HttpWebRequest myRequest;
                HttpWebResponse myResponse;
                System.Drawing.Bitmap bmp;

                myRequest = (HttpWebRequest)WebRequest.Create("https://d1cp2g0bs3j72.cloudfront.net/Vendors/0styleholic/ProductImage/list/674d361a-dea9-4055-9431-e6ca8b30df2b.jpg");
                myRequest.Method = "GET";
                myResponse = (HttpWebResponse)myRequest.GetResponse();
                bmp = new System.Drawing.Bitmap(myResponse.GetResponseStream());
                myResponse.Close();

                dvRemainItemList.Rows.Clear();

                dvRemainItemList.Rows.Add(bmp, "RAYD007259A1-BO", "ET0812", "white", "4", "Y", "KATE", "2014-05-05");
                dvRemainItemList.Rows.Add(bmp, "RAYD007259A1-BO", "ET0813", "red", "4", "N", "22nd", "2014-05-05");
                dvRemainItemList.Rows.Add(bmp, "RAYD007259A1-BO", "ET0814", "blue", "4", "N", "KATE", "2014-05-05");
                dvRemainItemList.Rows.Add(bmp, "RAYD007259A1-BO", "ET0815", "black", "4", "Y", "23rd", "2014-05-05");

                dvRemainItemList.Rows[0].Cells[0].Selected = false;
            }
        }
    }
}
