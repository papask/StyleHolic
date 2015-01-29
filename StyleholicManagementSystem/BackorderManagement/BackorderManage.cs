using System;
using System.Collections.Generic;
using System.Collections;
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
    public partial class BackorderManage : Form
    {
        public StringFormat strFormat;
        public StringFormat StrFormatComboBox; // Holds content of a Boolean Cell to write by DrawImage
        public String strConnectString = String.Empty;
        public Button CellButton;       // Holds the Contents of Button Cell
        public CheckBox CellCheckBox;   // Holds the Contents of CheckBox Cell 
        public ComboBox CellComboBox;   // Holds the Contents of ComboBox Cell
        public ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        public ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        public ArrayList arrColumnTypes = new ArrayList();  // DataType of Columns
        public int iCellHeight = 0; //Used to get/set the datagridview cell height
        public int iTotalWidth = 0; //
        public int iRow = 0;//Used as counter
        public bool bFirstPage = false; //Used to check whether we are printing first page
        public bool bNewPage = false;// Used to check whether we are printing a new page
        public int iHeaderHeight = 0; //Used for the header height
        
        public String strCurrentCustomer = String.Empty;
        public String strSelectedCustomerId = String.Empty;
        public String strSelectedStyleNo = String.Empty;
        public BackorderManage()
        {
            try
            {
                InitializeComponent();
                SetConfig();
                InitBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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

            cbStoreList.SelectedIndex = 0;
        }

        protected void InitBind()
        {
            dvStyleList.Rows.Clear();
            dvCustomerList.Rows.Clear();
            dvRemainItemList.Rows.Clear();
            dvOrderQtyByDate.Rows.Clear();

            try
            {
                MySqlDataManager dm = new MySqlDataManager(strConnectString);
                DataTable dt = dm.GetStyleListFromStoreID(GetStoreId(), !cbShowAll.Checked);

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dvStyleList.Rows.Add(
                            dt.Rows[i]["VenderName"].ToString(),
                            dt.Rows[i]["StyleNo"].ToString(),
                            dt.Rows[i]["OnSale"].ToString() == "1" ? "Yes" : "No"
                            );
                    }

                    dvStyleList.Rows[0].Cells[0].Selected = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void GetRemainItemList()
        {
            if (!String.IsNullOrEmpty(strSelectedCustomerId))
            {
                MySqlDataManager dm = new MySqlDataManager(strConnectString);

                DataTable dt = dm.GetRemainItemListFromCustomerID(GetStoreId(), strSelectedCustomerId, cbShowAllForRemainItems.Checked);

                dvRemainItemList.Rows.Clear();

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        String strItemStatus = String.Empty;

                        switch (row["IsPacked"].ToString())
                        {
                            case "0":
                                strItemStatus = "N";
                                break;

                            case "1":
                                strItemStatus = "Y";
                                break;

                            case "2":
                                strItemStatus = "Canceled";
                                break;

                            default:
                                strItemStatus = "N";
                                break;
                        }

                        MemoryStream ms = new MemoryStream((byte[])row["StyleImage"]);
                        Image returnImage = Image.FromStream(ms);

                        dvRemainItemList.Rows.Add(returnImage,
                                                    row["VenderName"].ToString(),
                                                    row["StyleNo"].ToString(),
                                                    row["Color"].ToString(),
                                                    row["Quantity"].ToString(),
                                                    strItemStatus,
                                                    row["OrderID"].ToString(),
                                                    Convert.ToDateTime(row["OrderDate"]).ToShortDateString()
                                                    );
                    }

                    dvRemainItemList.Rows[0].Cells[0].Selected = false;
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

        private String GetQuantityFromEstimateDate(String strStyleId, String strColor, String strEstimateDate)
        {
            String strRetVal = String.Empty;
            MySqlDataManager dm = new MySqlDataManager(strConnectString);
            strRetVal = dm.GetDeliveryExpectedQuantityFromEstimateDate(strStyleId, strColor, strEstimateDate);

            return strRetVal;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dvStyleList.Rows.Clear();
            dvCustomerList.Rows.Clear();
            dvRemainItemList.Rows.Clear();
            dvOrderQtyByDate.Rows.Clear();

            try
            {
                MySqlDataManager dm = new MySqlDataManager(strConnectString);
                DataTable dt = dm.GetStyleListFromStoreID(GetStoreId(), !cbShowAll.Checked);

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dvStyleList.Rows.Add(
                            dt.Rows[i]["VenderName"].ToString(),
                            dt.Rows[i]["StyleNo"].ToString(),
                            dt.Rows[i]["OnSale"].ToString() == "1" ? "Yes" : "No"
                            );
                    }

                    dvStyleList.Rows[0].Cells[0].Selected = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dvStyleList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HttpWebRequest myRequest;
            HttpWebResponse myResponse;
            System.Drawing.Bitmap bmp;

            dvRemainQuantityList.Rows.Clear();
            dvCustomerList.Rows.Clear();
            dvRemainItemList.Rows.Clear();
            dvOrderQtyByDate.Rows.Clear();

            if (e.RowIndex > -1 && dvStyleList.Rows[e.RowIndex].Cells[1].Value != null)
            {
                strSelectedStyleNo = dvStyleList.Rows[e.RowIndex].Cells[1].Value.ToString();

                MySqlDataManager dm = new MySqlDataManager(strConnectString);

                StyleInfo si = dm.GetStyleInfoFromStyleID(strSelectedStyleNo);

                lbSeletedStyle.Text = strSelectedStyleNo;

                try
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
                catch (Exception ex)
                { }

                DataTable dtRemainQuantity = dm.GetRemainQuantityByColorFromStyleID(strSelectedStyleNo);

                if (dtRemainQuantity != null && dtRemainQuantity.Rows.Count > 0)
                {
                    foreach (DataRow row in dtRemainQuantity.Rows)
                    {
                        String strEstimateDate = String.Empty;

                        try
                        {
                            strEstimateDate = dm.GetFastEstimateInfoFromStyleID(strSelectedStyleNo, row["Color"].ToString());//Convert.ToDateTime(row["EstimateDate"]).ToShortDateString() + " (qty: " + GetQuantityFromEstimateDate(strSelectedStyleNo, row["Color"].ToString(), Convert.ToDateTime(row["EstimateDate"]).ToShortDateString()) + ")";
                        }
                        catch (Exception ex)
                        { }

                        dvRemainQuantityList.Rows.Add(
                                                row["Color"].ToString(),
                                                row["Quantity"].ToString(),
                                                strEstimateDate
                                                );
                    }

                    dvRemainQuantityList.Rows[0].Cells[0].Selected = false;
                }

                DataTable dtCustomerList = dm.GetCustomerListByStyleID(GetStoreId(), si.StyleNo);

                if (dtCustomerList != null && dtCustomerList.Rows.Count > 0)
                {
                    foreach (DataRow row in dtCustomerList.Rows)
                    {
                        dvCustomerList.Rows.Add(
                                                row["OrderDate"].ToString(),
                                                row["CustomerName"].ToString(),
                                                row["Color"].ToString(),
                                                row["Quantity"].ToString(),
                                                row["CustomerId"].ToString()
                                                );
                    }

                    //dvCustomerList.Rows[0].Cells[0].Selected = false;
                }

                DataTable dtDailyOrderQuantity = dm.GetDailyOrderQuantityFromStyleNo(strSelectedStyleNo);

                if (dtDailyOrderQuantity != null && dtDailyOrderQuantity.Rows.Count > 0)
                {
                    foreach (DataRow row in dtDailyOrderQuantity.Rows)
                    {
                        dvOrderQtyByDate.Rows.Add(
                                                row["OrderDate"].ToString(),
                                                row["Color"].ToString(),
                                                row["TotalQuantity"].ToString()
                                                );
                    }

                    dvOrderQtyByDate.Rows[0].Cells[0].Selected = false;
                }
            }
        }

        private void dvCustomerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && dvCustomerList.Rows[e.RowIndex].Cells[4].Value != null)
            {
                strCurrentCustomer = dvCustomerList.Rows[e.RowIndex].Cells[1].Value.ToString();

                strSelectedCustomerId = dvCustomerList.Rows[e.RowIndex].Cells[4].Value.ToString();
                
                // remain item list
                GetRemainItemList();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            InitBind();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;

            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DefaultPageSettings.Landscape = true;
                printDocument1.DocumentName = strCurrentCustomer;
                printDocument1.Print();
            }
        }

        private void cbShowAllForRemainItems_CheckedChanged(object sender, EventArgs e)
        {
            GetRemainItemList();
        }

        private void dvRemainItemList_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    int currentMouseOverRow = dvRemainItemList.HitTest(e.X, e.Y).RowIndex;
                    cmPacked.Show(dvRemainItemList, new Point(e.X, e.Y));
                }
            }
            catch (Exception ex)
            { }
       }

        private void dvRemainItemList_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    var hti = dvRemainItemList.HitTest(e.X, e.Y);
                    dvRemainItemList.ClearSelection();
                    dvRemainItemList.Rows[hti.RowIndex].Selected = true;
                }
            }
            catch (Exception ex)
            { }
        }

        private void packedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String strSelectedStyleNo = dvRemainItemList.SelectedRows[0].Cells[2].Value.ToString();
                String strSelectedColor = dvRemainItemList.SelectedRows[0].Cells[3].Value.ToString();
                String strSelectedorderNo = dvRemainItemList.SelectedRows[0].Cells[6].Value.ToString();

                // change status to packed
                MySqlDataManager dm = new MySqlDataManager(strConnectString);
                dm.UpdateOrderItemStatus(strSelectedorderNo, strSelectedStyleNo, strSelectedColor, "1");

                GetRemainItemList();
            }
            catch (Exception ex)
            { }
        }

        private void didntPackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String strSelectedStyleNo = dvRemainItemList.SelectedRows[0].Cells[2].Value.ToString();
                String strSelectedColor = dvRemainItemList.SelectedRows[0].Cells[3].Value.ToString();
                String strSelectedorderNo = dvRemainItemList.SelectedRows[0].Cells[6].Value.ToString();

                // change status to didn't packed
                MySqlDataManager dm = new MySqlDataManager(strConnectString);
                dm.UpdateOrderItemStatus(strSelectedorderNo, strSelectedStyleNo, strSelectedColor, "0");

                GetRemainItemList();
            }
            catch (Exception ex)
            { }
        }

        private void canceledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String strSelectedStyleNo = dvRemainItemList.SelectedRows[0].Cells[2].Value.ToString();
                String strSelectedColor = dvRemainItemList.SelectedRows[0].Cells[3].Value.ToString();
                String strSelectedorderNo = dvRemainItemList.SelectedRows[0].Cells[6].Value.ToString();

                // change status to canceled
                MySqlDataManager dm = new MySqlDataManager(strConnectString);
                dm.UpdateOrderItemStatus(strSelectedorderNo, strSelectedStyleNo, strSelectedColor, "2");

                GetRemainItemList();
            }
            catch (Exception ex)
            { }
        }

        private void dvStyleList_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    var hti = dvStyleList.HitTest(e.X, e.Y);
                    dvStyleList.ClearSelection();
                    dvStyleList.Rows[hti.RowIndex].Selected = true;
                }
            }
            catch (Exception ex)
            { }
        }

        private void dvStyleList_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    int currentMouseOverRow = dvStyleList.HitTest(e.X, e.Y).RowIndex;
                    cmStyleStatus.Show(dvStyleList, new Point(e.X, e.Y));
                }
            }
            catch (Exception ex)
            { }
        }

        private void outOfStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String strSelectedStyleNo = dvStyleList.SelectedRows[0].Cells[1].Value.ToString();

                // change status to didn't packed
                MySqlDataManager dm = new MySqlDataManager(strConnectString);
                dm.UpdateStyleStatus(strSelectedStyleNo, "0");
                InitBind();
            }
            catch (Exception ex)
            { }
        }

        private void onSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String strSelectedStyleNo = dvStyleList.SelectedRows[0].Cells[1].Value.ToString();

                // change status to didn't packed
                MySqlDataManager dm = new MySqlDataManager(strConnectString);
                dm.UpdateStyleStatus(strSelectedStyleNo, "1");
                InitBind();
            }
            catch (Exception ex)
            { }
        }

        private void btnSearchStyle_Click(object sender, EventArgs e)
        {
            dvStyleList.Rows.Clear();

            if (!String.IsNullOrEmpty(txtSearchStyle.Text))
            {
                MySqlDataManager dm = new MySqlDataManager(strConnectString);
                DataTable dt = dm.GetStyleListFromSearchType(GetStoreId(), "0", txtSearchStyle.Text); // 0 = style number

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dvStyleList.Rows.Add(
                            dt.Rows[i]["VenderName"].ToString(),
                            dt.Rows[i]["StyleNo"].ToString(),
                            dt.Rows[i]["OnSale"].ToString() == "1" ? "Yes" : "No"
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

        private void dvCustomerList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                strSelectedCustomerId = dvCustomerList.SelectedRows[0].Cells[4].Value.ToString();

                // remain item list
                GetRemainItemList();
            }
            catch (Exception ex)
            { }
        }

        private void dvStyleList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                HttpWebRequest myRequest;
                HttpWebResponse myResponse;
                System.Drawing.Bitmap bmp;

                dvRemainQuantityList.Rows.Clear();
                dvCustomerList.Rows.Clear();
                dvRemainItemList.Rows.Clear();
                dvOrderQtyByDate.Rows.Clear();

                strSelectedStyleNo = dvStyleList.SelectedRows[0].Cells[1].Value.ToString();

                MySqlDataManager dm = new MySqlDataManager(strConnectString);

                StyleInfo si = dm.GetStyleInfoFromStyleID(strSelectedStyleNo);

                lbSeletedStyle.Text = strSelectedStyleNo;

                try
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
                catch (Exception ex)
                { }

                DataTable dtRemainQuantity = dm.GetRemainQuantityByColorFromStyleID(strSelectedStyleNo);

                if (dtRemainQuantity != null && dtRemainQuantity.Rows.Count > 0)
                {
                    foreach (DataRow row in dtRemainQuantity.Rows)
                    {
                        String strEstimateDate = String.Empty;

                        try
                        {
                            strEstimateDate = dm.GetFastEstimateInfoFromStyleID(strSelectedStyleNo, row["Color"].ToString());//Convert.ToDateTime(row["EstimateDate"]).ToShortDateString() + " (qty: " + GetQuantityFromEstimateDate(strSelectedStyleNo, row["Color"].ToString(), Convert.ToDateTime(row["EstimateDate"]).ToShortDateString()) + ")";
                        }
                        catch (Exception ex)
                        { }

                        dvRemainQuantityList.Rows.Add(
                                                row["Color"].ToString(),
                                                row["Quantity"].ToString(),
                                                strEstimateDate
                                                );
                    }

                    dvRemainQuantityList.Rows[0].Cells[0].Selected = false;
                }

                DataTable dtCustomerList = dm.GetCustomerListByStyleID(GetStoreId(), si.StyleNo);

                if (dtCustomerList != null && dtCustomerList.Rows.Count > 0)
                {
                    foreach (DataRow row in dtCustomerList.Rows)
                    {
                        dvCustomerList.Rows.Add(
                                                row["OrderDate"].ToString(),
                                                row["CustomerName"].ToString(),
                                                row["Color"].ToString(),
                                                row["Quantity"].ToString(),
                                                row["CustomerId"].ToString()
                                                );
                    }

                    //dvCustomerList.Rows[0].Cells[0].Selected = false;
                }

                DataTable dtDailyOrderQuantity = dm.GetDailyOrderQuantityFromStyleNo(strSelectedStyleNo);

                if (dtDailyOrderQuantity != null && dtDailyOrderQuantity.Rows.Count > 0)
                {
                    foreach (DataRow row in dtDailyOrderQuantity.Rows)
                    {
                        dvOrderQtyByDate.Rows.Add(
                                                row["OrderDate"].ToString(),
                                                row["Color"].ToString(),
                                                row["TotalQuantity"].ToString()
                                                );
                    }

                    dvOrderQtyByDate.Rows[0].Cells[0].Selected = false;
                }
            }
            catch (Exception ex)
            { }
        }

        #region Print
        
        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                arrColumnTypes.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dvRemainItemList.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dvRemainItemList.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                       (double)iTotalWidth * (double)iTotalWidth *
                                       ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headres
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        arrColumnTypes.Add(GridCol.GetType());
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= dvRemainItemList.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dvRemainItemList.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allo more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString(strCurrentCustomer, new Font(dvRemainItemList.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString(strCurrentCustomer, new Font(dvRemainItemList.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate, new Font(dvRemainItemList.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(dvRemainItemList.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString(strCurrentCustomer, new Font(new Font(dvRemainItemList.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dvRemainItemList.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (!Cel.OwningColumn.Visible) continue;

                            // For the TextBox Column
                            if (((Type)arrColumnTypes[iCount]).Name == "DataGridViewTextBoxColumn" ||
                                ((Type)arrColumnTypes[iCount]).Name == "DataGridViewLinkColumn")
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                        new SolidBrush(Cel.InheritedStyle.ForeColor),
                                        new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                        (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            }
                            // For the Button Column
                            else if (((Type)arrColumnTypes[iCount]).Name == "DataGridViewButtonColumn")
                            {
                                CellButton.Text = Cel.Value.ToString();
                                CellButton.Size = new Size((int)arrColumnWidths[iCount], iCellHeight);
                                Bitmap bmp = new Bitmap(CellButton.Width, CellButton.Height);
                                CellButton.DrawToBitmap(bmp, new Rectangle(0, 0,
                                        bmp.Width, bmp.Height));
                                e.Graphics.DrawImage(bmp, new Point((int)arrColumnLefts[iCount], iTopMargin));
                            }
                            // For the CheckBox Column
                            else if (((Type)arrColumnTypes[iCount]).Name == "DataGridViewCheckBoxColumn")
                            {
                                CellCheckBox.Size = new Size(14, 14);
                                CellCheckBox.Checked = (bool)Cel.Value;
                                Bitmap bmp = new Bitmap((int)arrColumnWidths[iCount], iCellHeight);
                                Graphics tmpGraphics = Graphics.FromImage(bmp);
                                tmpGraphics.FillRectangle(Brushes.White, new Rectangle(0, 0,
                                        bmp.Width, bmp.Height));
                                CellCheckBox.DrawToBitmap(bmp,
                                        new Rectangle((int)((bmp.Width - CellCheckBox.Width) / 2),
                                        (int)((bmp.Height - CellCheckBox.Height) / 2),
                                        CellCheckBox.Width, CellCheckBox.Height));
                                e.Graphics.DrawImage(bmp, new Point((int)arrColumnLefts[iCount], iTopMargin));
                            }
                            // For the ComboBox Column
                            else if (((Type)arrColumnTypes[iCount]).Name == "DataGridViewComboBoxColumn")
                            {
                                CellComboBox.Size = new Size((int)arrColumnWidths[iCount], iCellHeight);
                                Bitmap bmp = new Bitmap(CellComboBox.Width, CellComboBox.Height);
                                CellComboBox.DrawToBitmap(bmp, new Rectangle(0, 0,
                                        bmp.Width, bmp.Height));
                                e.Graphics.DrawImage(bmp, new Point((int)arrColumnLefts[iCount], iTopMargin));
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                        new SolidBrush(Cel.InheritedStyle.ForeColor),
                                        new RectangleF((int)arrColumnLefts[iCount] + 1, iTopMargin, (int)arrColumnWidths[iCount]
                                        - 16, iCellHeight), StrFormatComboBox);
                            }
                            // For the Image Column
                            else if (((Type)arrColumnTypes[iCount]).Name == "DataGridViewImageColumn")
                            {
                                Rectangle CelSize = new Rectangle((int)arrColumnLefts[iCount],
                                        iTopMargin, (int)arrColumnWidths[iCount], iCellHeight);
                                Size ImgSize = ((Image)(Cel.FormattedValue)).Size;
                                e.Graphics.DrawImage((Image)Cel.FormattedValue,
                                        new Rectangle((int)arrColumnLefts[iCount] + (int)((CelSize.Width - 100) / 2),
                                        iTopMargin + (int)((CelSize.Height - 150) / 2),
                                        100, 150));
                                        //((Image)(Cel.FormattedValue)).Width, ((Image)(Cel.FormattedValue)).Height));

                            }

                            // Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                    iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                            iCount++;

                            //if (Cel.Value != null)
                            //{
                            //    e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                            //                new SolidBrush(Cel.InheritedStyle.ForeColor),
                            //                new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                            //                (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            //}
                            ////Drawing Cells Borders 
                            //e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                            //        iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                            //iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }

                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
