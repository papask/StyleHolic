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
using Styleholic.DataManager;
using System.IO;
using System.Xml;
using System.Configuration;

namespace BackorderManagement
{
    public partial class StyleManage : Form
    {
        public String strConnectString = String.Empty;
        public String strSelectedStyleNo = String.Empty;

        public String strSelectedOrderId = String.Empty;
        public String strSelectedColor = String.Empty;
        
        public StyleManage()
        {
            InitializeComponent();

            SetConfig();
            InitBind();
        }

        protected void SetConfig()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Application.StartupPath + "\\BackorderManagement.exe.config");

            XmlNodeList nList = xDoc.GetElementsByTagName("appSettings")[0].ChildNodes;

            foreach (XmlNode xNode in nList)
            {
                try
                {
                    if (xNode.Attributes["key"].Value == "ConnectString")
                    {
                        strConnectString = xNode.Attributes["value"].Value;//"Server=localhost; database=styleholic; UID=root; password=dubu8790";
                    }
                }
                catch (Exception ex)
                { }
            }


        }

        public void InitBind()
        {
            cbSearchType.SelectedIndex = 0;
            cbStoreList.SelectedIndex = 0;
        }

        public void GetEstimateDateList()
        {
            if (!String.IsNullOrEmpty(strSelectedStyleNo))
            {
                dvEstimateList.Rows.Clear();

                MySqlDataManager dm = new MySqlDataManager(strConnectString);
                DataTable dt = dm.GetEstimateDateListFromStyleNo(strSelectedStyleNo);

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dvEstimateList.Rows.Add(
                            dt.Rows[i]["Color"].ToString(),
                            Convert.ToDateTime(dt.Rows[i]["EstimateDate"]).ToString("yyyy-MM-dd"),
                            dt.Rows[i]["Quantity"].ToString(),
                           dt.Rows[i]["Delivered"].ToString()
                            );
                    }

                    dvEstimateList.Rows[0].Cells[0].Selected = false;
                }
            }
        }

        public void GetRemainQuantityList()
        {
            if (!String.IsNullOrEmpty(strSelectedStyleNo))
            {
                dvColorList.Rows.Clear();
                cbColorList.Items.Clear();

                MySqlDataManager dm = new MySqlDataManager(strConnectString);
                DataTable dt = dm.GetRemainQuantityByCustomerFromStyleID(GetStoreId(), strSelectedStyleNo);
                DataTable dt2 = dm.GetRemainQuantityByColorFromStyleID(strSelectedStyleNo);

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dvColorList.Rows.Add(
                            dt.Rows[i]["CustomerName"].ToString(),
                            dt.Rows[i]["Color"].ToString(),
                            dt.Rows[i]["Quantity"].ToString(),
                            dt.Rows[i]["Orderid"].ToString()
                            );
                    }

                    dvColorList.Rows[0].Cells[0].Selected = false;
                }

                if (dt2 != null && dt2.Rows.Count > 0)
                {
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        cbColorList.Items.Add(dt2.Rows[i]["Color"].ToString());
                    }

                    cbColorList.SelectedIndex = 0;
                }
            }
        }

        private String GetStoreId()
        {
            String strRetVal = "sh";

            if (cbStoreList.SelectedIndex == 0)
                strRetVal = "sh";
            else if (cbStoreList.SelectedIndex == 1)
                strRetVal = "ugf";
            else
                strRetVal = "ray";

            return strRetVal;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dvStyleList.Rows.Clear();

            if (!String.IsNullOrEmpty(cbSearchType.Text) && !String.IsNullOrEmpty(txtSearch.Text))
            {
                MySqlDataManager dm = new MySqlDataManager(strConnectString);
                DataTable dt = dm.GetStyleListFromSearchType(GetStoreId(), cbSearchType.SelectedIndex.ToString(), txtSearch.Text);

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dvStyleList.Rows.Add(
                            dt.Rows[i]["StyleNo"].ToString()
                            );
                    }

                    dvStyleList.Rows[0].Cells[0].Selected = false;
                }
            }
            else
            {
                MessageBox.Show("Type search value.");
            }
        }

        private void dvStyleList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HttpWebRequest myRequest;
            HttpWebResponse myResponse;
            System.Drawing.Bitmap bmp;

            txtCustomerName.ReadOnly = true;
            txtCustomerName.Text = "";
            txtColorName.ReadOnly = true;
            txtColorName.Text = "";
            txtQuantity.ReadOnly = true;
            txtQuantity.Text = "";

            if (e.RowIndex > -1 && dvStyleList.Rows[e.RowIndex].Cells[0].Value != null)
            {
                strSelectedStyleNo = dvStyleList.Rows[e.RowIndex].Cells[0].Value.ToString();

                MySqlDataManager dm = new MySqlDataManager(strConnectString);

                StyleInfo si = dm.GetStyleInfoFromStyleID(strSelectedStyleNo);

                if (si.StyleImage != null)
                {
                    MemoryStream ms = new MemoryStream(si.StyleImage);
                    Image returnImage = Image.FromStream(ms);

                    if (returnImage != null)
                    {
                        pictureBox1.Image = returnImage;
                    }
                    else
                    {
                        myRequest = (HttpWebRequest)WebRequest.Create(si.ImageUrl);
                        myRequest.Method = "GET";
                        myResponse = (HttpWebResponse)myRequest.GetResponse();
                        bmp = new System.Drawing.Bitmap(myResponse.GetResponseStream());
                        myResponse.Close();

                        pictureBox1.Image = bmp;
                    }
                }
                else
                {
                    pictureBox1.Image = null;
                }

                txtStyleNo.Text = si.StyleNo;
                txtVenderCode.Text = si.VenderCode;
                txtVenderName.Text = si.VenderName;
                cbOnSale.Checked = si.OnSale;

                // bind remain quantity list
                GetRemainQuantityList();

                // bind estimate date
                GetEstimateDateList();
            }
        }

        private void dvColorList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && dvColorList.Rows[e.RowIndex].Cells[0].Value != null)
            {
                //txtCustomerName.ReadOnly = false;
                //txtColorName.ReadOnly = false;
                txtQuantity.ReadOnly = false;

                txtCustomerName.Text = dvColorList.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtColorName.Text = dvColorList.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtQuantity.Text = dvColorList.Rows[e.RowIndex].Cells[2].Value.ToString();

                strSelectedOrderId = dvColorList.Rows[e.RowIndex].Cells[3].Value.ToString();
                strSelectedColor = dvColorList.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(strSelectedStyleNo))
            {
                MySqlDataManager dm = new MySqlDataManager(strConnectString);

                if (!txtQuantity.ReadOnly)
                {
                    // update quantity
                    dm.UpdateOrderItemQuantity(strSelectedOrderId, strSelectedStyleNo, strSelectedColor, txtQuantity.Value.ToString());
                }

                // update style info
                dm.UpdateStyleInfo(strSelectedStyleNo, txtVenderCode.Text, txtVenderName.Text, cbOnSale.Checked ? "1" : "0");

                MessageBox.Show("Saved");
            }
        }

        private void btnAddEstimateDate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(strSelectedStyleNo))
            {
                DialogResult dr = MessageBox.Show("Do you want to add new date?", "", MessageBoxButtons.OKCancel);

                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    MySqlDataManager dm = new MySqlDataManager(strConnectString);
                    dm.InsertEstimateDateInfo(strSelectedStyleNo, cbColorList.SelectedItem.ToString(), Convert.ToInt32(txtEstimateQuantity.Value), Convert.ToDateTime(dpEstimateDate.Value.ToShortDateString()));

                    GetEstimateDateList();
                }
            }
            else
            {
                MessageBox.Show("Please select any style.");
            }
        }

        private void dvEstimateList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = dvEstimateList.HitTest(e.X, e.Y).RowIndex;
                cmEstimate.Show(dvEstimateList, new Point(e.X, e.Y));
            }
        }

        private void dvEstimateList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dvEstimateList.HitTest(e.X, e.Y);
                dvEstimateList.ClearSelection();
                dvEstimateList.Rows[hti.RowIndex].Selected = true;
            }
        }

        private void deliveredToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlDataManager dm = new MySqlDataManager(strConnectString);

            String strColor = dvEstimateList.SelectedRows[0].Cells[0].Value.ToString();
            String strDate = dvEstimateList.SelectedRows[0].Cells[1].Value.ToString();

            dm.UpdateDeleveryStatus(strSelectedStyleNo, strColor, strDate);

            // bind estimate date
            GetEstimateDateList();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlDataManager dm = new MySqlDataManager(strConnectString);

            String strColor = dvEstimateList.SelectedRows[0].Cells[0].Value.ToString();
            String strDate = dvEstimateList.SelectedRows[0].Cells[1].Value.ToString();

            dm.DeleteDeliveryEstimateDateInfo(strSelectedStyleNo, strColor, strDate);
            
            // bind estimate date
            GetEstimateDateList();
        }

        private void dvStyleList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                strSelectedStyleNo = dvStyleList.SelectedRows[0].Cells[0].Value.ToString();

                HttpWebRequest myRequest;
                HttpWebResponse myResponse;
                System.Drawing.Bitmap bmp;

                txtCustomerName.ReadOnly = true;
                txtCustomerName.Text = "";
                txtColorName.ReadOnly = true;
                txtColorName.Text = "";
                txtQuantity.ReadOnly = true;
                txtQuantity.Text = "";



                MySqlDataManager dm = new MySqlDataManager(strConnectString);

                StyleInfo si = dm.GetStyleInfoFromStyleID(strSelectedStyleNo);

                MemoryStream ms = new MemoryStream(si.StyleImage);
                Image returnImage = Image.FromStream(ms);

                if (returnImage != null)
                {
                    pictureBox1.Image = returnImage;
                }
                else
                {
                    myRequest = (HttpWebRequest)WebRequest.Create(si.ImageUrl);
                    myRequest.Method = "GET";
                    myResponse = (HttpWebResponse)myRequest.GetResponse();
                    bmp = new System.Drawing.Bitmap(myResponse.GetResponseStream());
                    myResponse.Close();

                    pictureBox1.Image = bmp;
                }

                txtStyleNo.Text = si.StyleNo;
                txtVenderCode.Text = si.VenderCode;
                txtVenderName.Text = si.VenderName;
                cbOnSale.Checked = si.OnSale;

                // bind remain quantity list
                GetRemainQuantityList();

                // bind estimate date
                GetEstimateDateList();
            }
            catch (Exception ex)
            { }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dvStyleList.Rows.Clear();

                if (!String.IsNullOrEmpty(cbSearchType.Text) && !String.IsNullOrEmpty(txtSearch.Text))
                {
                    MySqlDataManager dm = new MySqlDataManager(strConnectString);
                    DataTable dt = dm.GetStyleListFromSearchType(GetStoreId(), cbSearchType.SelectedIndex.ToString(), txtSearch.Text);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dvStyleList.Rows.Add(
                                dt.Rows[i]["StyleNo"].ToString()
                                );
                        }

                        dvStyleList.Rows[0].Cells[0].Selected = false;
                    }
                }
                else
                {
                    MessageBox.Show("Type search value.");
                }
            }
        }
    }
}
