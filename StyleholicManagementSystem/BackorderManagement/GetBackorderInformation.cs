using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Web;
using System.Net;
using System.IO;
using Styleholic.DataManager;
using System.Drawing.Imaging;

namespace BackorderManagement
{
    public partial class GetBackorderInformation : Form
    {
        public List<VenderInfo> VenderInfo_STYList = new List<VenderInfo>();
        public List<VenderInfo> VenderInfo_RAYList = new List<VenderInfo>();
        public List<VenderInfo> VenderInfo_AMCList = new List<VenderInfo>();
        public String strConnectString = String.Empty;
        public String strCurrentStore = String.Empty;

        public GetBackorderInformation()
        {
            SetConfig();
            InitializeComponent();
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
            wbOrderInfo.Url = new Uri("http://vendoradmin.fashiongo.net/Login.aspx?ReturnUrl=%2f");
            SetConfigValue();
        }

        #region SetConfigValue

        public void SetConfigValue()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Application.StartupPath + "\\BackorderManagement.exe.config");

            XmlNodeList nList = xDoc.GetElementsByTagName("appSettings")[0].ChildNodes;


            XmlNodeList xSTY;
            XmlNodeList xAMC;
            XmlNodeList xRAY;

            foreach (XmlNode xNode in nList)
            {
                if (xNode.Name == "VenderInfo_STY")
                {
                    xSTY = xNode.ChildNodes;

                    for (int i = 0; i < xSTY.Count; i++)
                    {
                        VenderInfo_STYList.Add(new VenderInfo(xSTY[i].Attributes["key"].Value, xSTY[i].Attributes["value"].Value));
                    }
                }

                if (xNode.Name == "VenderInfo_AMC")
                {
                    xAMC = xNode.ChildNodes;

                    for (int i = 0; i < xAMC.Count; i++)
                    {
                        VenderInfo_AMCList.Add(new VenderInfo(xAMC[i].Attributes["key"].Value, xAMC[i].Attributes["value"].Value));
                    }
                }

                if (xNode.Name == "VenderInfo_RAY")
                {
                    xRAY = xNode.ChildNodes;

                    for (int i = 0; i < xRAY.Count; i++)
                    {
                        VenderInfo_RAYList.Add(new VenderInfo(xRAY[i].Attributes["key"].Value, xRAY[i].Attributes["value"].Value));
                    }
                }
            }
        }

        #endregion

        #region GetOrderNumber
        
        private void GetOrderNumber()
        {
            cbPOList.Items.Clear();
            HtmlDocument hDoc = wbOrderInfo.Document;

            if (hDoc != null)
            {
                foreach (HtmlElement item in hDoc.GetElementsByTagName("div"))
                {
                    if (item.Id != null && item.Id == "ctl00_ctl00_ContentPlaceHolder1_cphBody_Order_updPnlOrderUC")
                    {
                        foreach (HtmlElement item_td in item.GetElementsByTagName("a"))
                        {
                            if (item_td.Id != null && item_td.Id.IndexOf("hlOrderDetail") > 0)
                            {
                                cbPOList.Items.Add(item_td.InnerText);
                            }
                        }
                    }
                    else if (item.Id != null && item.Id == "ctl00_ctl00_ContentPlaceHolder1_cphBody_TempOrder_pnlTempOrder")
                    {
                        foreach (HtmlElement item_td in item.GetElementsByTagName("a"))
                        {
                            if (item_td.Id != null && item_td.Id.IndexOf("hlOrderDetail") > 0)
                            {
                                cbPOList.Items.Add(item_td.InnerText);
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region GetOrderInfo

        private void GetOrderInfo()
        {
            string strVenderCode = string.Empty;
            string strVenderName = string.Empty;
            string strStyleName = string.Empty;
            string strColorName = string.Empty;
            string strSizeInfo = string.Empty;
            string strTotalQty = string.Empty;
            string strTotalValue = string.Empty;
            string strOrderNumber = string.Empty;
            string strBillingAddr = string.Empty;
            string strShipment = string.Empty;
            string strImageURL = string.Empty;
            string strCustomerID = string.Empty;
            string strOrderDate = string.Empty;


            HtmlDocument hDoc = wbOrderInfo.Document;

            if (hDoc != null)
            {
                foreach (HtmlElement item in hDoc.GetElementsByTagName("div"))
                {
                    // Order Information
                    // Vender code(first 2 charactor in order number), style, color, size(L/M/S), total, customer(billing address), PO#

                    if (item.Id != null && item.Id == "ctl00_ctl00_ContentPlaceHolder1_cphBody_orderGeneralDetail_updPnlODG")
                    {
                        foreach (HtmlElement item_span in item.GetElementsByTagName("span"))
                        {
                            if (item_span.Id != null)
                            {
                                #region order number

                                if (item_span.Id.IndexOf("lblPONumberText") > 0)
                                {
                                    strOrderNumber = item_span.InnerText;
                                }

                                #endregion

                                #region billing info

                                if (item_span.Id.IndexOf("lblBillCompanyName") > 0)
                                {
                                    strBillingAddr = item_span.InnerText;
                                }

                                //if (item_span.Id.IndexOf("lblBillAddress1") > 0)
                                //{
                                //    strBillingAddr += " " + item_span.InnerText;
                                //}

                                //if (item_span.Id.IndexOf("lblBillAddress2") > 0)
                                //{
                                //    strBillingAddr += " " + item_span.InnerText;
                                //}

                                //if (item_span.Id.IndexOf("lblBillCountry") > 0)
                                //{
                                //    strBillingAddr += " " + item_span.InnerText;
                                //}

                                #endregion

                                #region Shipment

                                if (item_span.Id.IndexOf("lblShipMethod") > 0)
                                {
                                    strShipment = item_span.InnerText;
                                }

                                #endregion

                                #region OrderDate

                                if (item_span.Id.IndexOf("lblOrderDate") > 0)
                                {
                                    strOrderDate = item_span.InnerText;
                                }

                                #endregion

                                #region CustomerID

                                if (item_span.Id.IndexOf("lblViewOrderHistoryDetail") > 0)
                                {
                                    string strTemptag = item_span.OuterHtml;
                                    int nStart = strTemptag.ToLower().IndexOf("rid=") + 4;
                                    int nEnd = strTemptag.ToLower().IndexOf("&");
                                    strCustomerID = strTemptag.Substring(nStart, nEnd - nStart);
                                }

                                #endregion
                                
                            }
                        }
                    }

                    if (item.Id != null && item.Id == "ctl00_ctl00_ContentPlaceHolder1_cphBody_orderItemDetail_updPnl")
                    {
                        foreach (HtmlElement item_orderitem_tr in item.GetElementsByTagName("tr"))
                        {
                            if (item_orderitem_tr.Id != null && item_orderitem_tr.Id == "curItem")
                            {
                                foreach (HtmlElement item_orderitem_img in item_orderitem_tr.GetElementsByTagName("img"))
                                {
                                    if (item_orderitem_img.Id.IndexOf("imgProduct") > 0)
                                    {
                                        string strTempIMGtag = item_orderitem_img.OuterHtml;
                                        int nStart = strTempIMGtag.ToLower().IndexOf("src=\"") + 5;
                                        int nEnd = strTempIMGtag.ToLower().IndexOf(".jpg") + 4;
                                        
                                        strImageURL = strTempIMGtag.Substring(nStart, nEnd - nStart);
                                    }
                                }

                                foreach (HtmlElement item_orderitem_span in item_orderitem_tr.GetElementsByTagName("span"))
                                {
                                    if (item_orderitem_span.Id != null)
                                    {
                                        #region StyleName, Vendercode

                                        // ZSH -> styleholic
                                        // RAY -> ray
                                        // UGF -> american chic

                                        if (item_orderitem_span.Id.IndexOf("lblStyleNo") > 0)
                                        {
                                            string[] arrStyle = item_orderitem_span.InnerText.Split('-');

                                            if (arrStyle != null && arrStyle.Length > 0)
                                            {
                                                strVenderCode = arrStyle[0];

                                                string strModifiedOrderNumber = string.Empty;

                                                if (strOrderNumber == "")
                                                {
                                                    strOrderNumber = cbPOList.SelectedText;
                                                }

                                                if (strOrderNumber.ToLower().StartsWith("temp"))
                                                {
                                                    strModifiedOrderNumber = strOrderNumber.Replace("TEMP-", "");
                                                }
                                                else
                                                {
                                                    strModifiedOrderNumber = strOrderNumber;
                                                }

                                                if (string.IsNullOrEmpty(strModifiedOrderNumber))
                                                {
                                                    strStyleName = item_orderitem_span.InnerText;
                                                }
                                                else
                                                {
                                                    if (strModifiedOrderNumber.StartsWith("ZSH"))
                                                    {
                                                        strCurrentStore = "sh";

                                                        for (int i = 0; i < VenderInfo_STYList.Count; i++)
                                                        {
                                                            if (VenderInfo_STYList[i].VenderCode == arrStyle[0])
                                                            {
                                                                strVenderName = VenderInfo_STYList[i].VenderName;
                                                                break;
                                                            }
                                                        }

                                                        try
                                                        {
                                                            for (int i = 1; i < arrStyle.Length; i++)
                                                            {
                                                                strStyleName += arrStyle[i];

                                                                if (i == 1)
                                                                {
                                                                    if (!IsNumeric(arrStyle[1].Substring(arrStyle[1].Length - 1, 1)))
                                                                        strStyleName += "-";
                                                                }
                                                                else
                                                                {
                                                                    if (i != arrStyle.Length - 1)
                                                                        strStyleName += "-";
                                                                }
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            strStyleName = string.Empty;
                                                        }
                                                    }
                                                    else if (strModifiedOrderNumber.StartsWith("RAY"))
                                                    {
                                                        strCurrentStore = "ray";

                                                        for (int i = 0; i < VenderInfo_RAYList.Count; i++)
                                                        {
                                                            if (VenderInfo_RAYList[i].VenderCode == arrStyle[0])
                                                            {
                                                                strVenderName = VenderInfo_RAYList[i].VenderName;
                                                                break;
                                                            }
                                                        }

                                                        try
                                                        {
                                                            for (int i = 1; i < arrStyle.Length; i++)
                                                            {
                                                                strStyleName += arrStyle[i];

                                                                if (i == 1)
                                                                {
                                                                    if (arrStyle[1].Length >= 2 && !IsNumeric(arrStyle[1].Substring(arrStyle[1].Length - 2, 1)) && !IsNumeric(arrStyle[1].Substring(arrStyle[1].Length - 1, 1)))
                                                                        strStyleName += "-";
                                                                }
                                                                else
                                                                {
                                                                    if (i != arrStyle.Length - 1)
                                                                        strStyleName += "-";
                                                                }
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            strStyleName = string.Empty;
                                                        }
                                                    }
                                                    else if (strModifiedOrderNumber.StartsWith("UGF"))
                                                    {
                                                        strCurrentStore = "ugf";

                                                        for (int i = 0; i < VenderInfo_AMCList.Count; i++)
                                                        {
                                                            if (VenderInfo_AMCList[i].VenderCode == arrStyle[0])
                                                            {
                                                                strVenderName = VenderInfo_AMCList[i].VenderName;
                                                                break;
                                                            }
                                                        }

                                                        try
                                                        {
                                                            for (int i = 1; i < arrStyle.Length; i++)
                                                            {
                                                                if (i != 1)
                                                                    strStyleName += "-";

                                                                if (i == 1)
                                                                {
                                                                    string[] arrUGFStyle = arrStyle[1].Split('Z');

                                                                    for (int j = 0; j < arrUGFStyle.Length; j++)
                                                                    {
                                                                        if (j > 1)
                                                                            strStyleName += "Z";

                                                                        strStyleName += arrUGFStyle[j];
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    strStyleName += arrStyle[i];
                                                                }
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            strStyleName = string.Empty;
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        #endregion

                                        #region ColorName

                                        if (item_orderitem_span.Id.IndexOf("lblColorName") > 0)
                                        {
                                            strColorName = item_orderitem_span.InnerText;
                                        }

                                        #endregion

                                        #region TotalPrice

                                        if (item_orderitem_span.Id.IndexOf("lblTotalPrice") > 0)
                                        {
                                            strTotalValue = item_orderitem_span.InnerText;
                                        }

                                        #endregion

                                        #region Total Qty

                                        if (item_orderitem_span.Id.IndexOf("lblTotalQty") > 0)
                                        {
                                            strTotalQty = item_orderitem_span.InnerText;
                                        }

                                        #endregion
                                    }
                                }

                                #region Get Size Value

                                foreach (HtmlElement item_orderitem_input in item_orderitem_tr.GetElementsByTagName("input"))
                                {
                                    if (item_orderitem_input.Id != null)
                                    {
                                        #region SizeValue

                                        if (item_orderitem_input.Id.IndexOf("tbSize01Count") > 0)
                                        {
                                            if (!string.IsNullOrEmpty(strSizeInfo))
                                                strSizeInfo += " / ";

                                            strSizeInfo = item_orderitem_input.GetAttribute("value");
                                        }

                                        if (item_orderitem_input.Id.IndexOf("tbSize02Count") > 0)
                                        {
                                            if (!string.IsNullOrEmpty(strSizeInfo))
                                                strSizeInfo += " / ";

                                            strSizeInfo += item_orderitem_input.GetAttribute("value");
                                        }

                                        if (item_orderitem_input.Id.IndexOf("tbSize03Count") > 0)
                                        {
                                            if (!string.IsNullOrEmpty(strSizeInfo))
                                                strSizeInfo += " / ";

                                            strSizeInfo += item_orderitem_input.GetAttribute("value");
                                        }

                                        if (item_orderitem_input.Id.IndexOf("tbSize04Count") > 0)
                                        {
                                            if (!string.IsNullOrEmpty(strSizeInfo))
                                                strSizeInfo += " / ";

                                            strSizeInfo += item_orderitem_input.GetAttribute("value");
                                        }

                                        if (item_orderitem_input.Id.IndexOf("tbSize05Count") > 0)
                                        {
                                            if (!string.IsNullOrEmpty(strSizeInfo))
                                                strSizeInfo += " / ";

                                            strSizeInfo += item_orderitem_input.GetAttribute("value");
                                        }

                                        if (item_orderitem_input.Id.IndexOf("tbSize06Count") > 0)
                                        {
                                            if (!string.IsNullOrEmpty(strSizeInfo))
                                                strSizeInfo += " / ";

                                            strSizeInfo += item_orderitem_input.GetAttribute("value");
                                        }

                                        if (item_orderitem_input.Id.IndexOf("tbSize07Count") > 0)
                                        {
                                            if (!string.IsNullOrEmpty(strSizeInfo))
                                                strSizeInfo += " / ";

                                            strSizeInfo += item_orderitem_input.GetAttribute("value");
                                        }

                                        if (item_orderitem_input.Id.IndexOf("tbSize08Count") > 0)
                                        {
                                            if (!string.IsNullOrEmpty(strSizeInfo))
                                                strSizeInfo += " / ";

                                            strSizeInfo += item_orderitem_input.GetAttribute("value");
                                        }

                                        if (item_orderitem_input.Id.IndexOf("tbSize09Count") > 0)
                                        {
                                            if (!string.IsNullOrEmpty(strSizeInfo))
                                                strSizeInfo += " / ";

                                            strSizeInfo += item_orderitem_input.GetAttribute("value");
                                        }

                                        #endregion
                                    }
                                }

                                #endregion

                                MySqlDataManager dm = new MySqlDataManager(strConnectString);
                                if (!dm.ExistOrderInfo(strOrderNumber, strColorName))
                                {//strOrderNumber, strColorName
                                    dgResult.Rows.Add(strVenderCode, strVenderName, strStyleName, strColorName, strSizeInfo, strTotalQty, strTotalValue, strBillingAddr, strShipment, strOrderNumber, strImageURL, strCustomerID);

                                    // Save data to DB
                                    SaveBackOrderInfo(strVenderCode, strVenderName, strStyleName, strColorName, strSizeInfo, strTotalQty, strTotalValue, strBillingAddr, strShipment, strOrderNumber, strOrderDate, strImageURL, strCustomerID);
                                }

                                strVenderCode = string.Empty;
                                strVenderName = string.Empty;
                                strStyleName = string.Empty;
                                strColorName = string.Empty;
                                strSizeInfo = string.Empty;
                                strTotalQty = string.Empty;
                                strImageURL = string.Empty;
                                strTotalValue = string.Empty;
                            }
                        }

                        strBillingAddr = string.Empty;
                        strOrderNumber = string.Empty;
                        strShipment = string.Empty;
                        strCustomerID = string.Empty;
                        strOrderDate = string.Empty;
                    }
                }
            }

            
        }

        #endregion

        #region SaveBackOrderInfo

        public void SaveBackOrderInfo(String strVenderCode, String strVenderName, String strStyleName, String strColorName, String strSizeInfo, String strTotalQty, String strTotalValue, String strBillingAddr, String strShipment, String strOrderNumber, String strOrderDate, String strImageURL, String strCustomerID)
        {
            HttpWebRequest myRequest;
            HttpWebResponse myResponse;
            System.Drawing.Bitmap bmp;
            byte[] imageBytes = null;

            try
            {
                if (wbOrderInfo.Url.ToString().IndexOf("-BO") >= 0)
                {
                    MySqlDataManager dm = new MySqlDataManager(strConnectString);

                    // save customer info (if exist return customer ID)
                    dm.InsertCustomerInfo(strCustomerID, strBillingAddr);

                    // save style info (if exist return style no)

                    if (!String.IsNullOrEmpty(strImageURL))
                    {
                        myRequest = (HttpWebRequest)WebRequest.Create(strImageURL);
                        myRequest.Method = "GET";
                        myResponse = (HttpWebResponse)myRequest.GetResponse();
                        bmp = new System.Drawing.Bitmap(myResponse.GetResponseStream());
                        myResponse.Close();

                        var imageStream = new MemoryStream();
                        using (imageStream)
                        {
                            // Save bitmap in some format.
                            bmp.Save(imageStream, ImageFormat.Jpeg);
                            imageStream.Position = 0;

                            // Do something with the memory stream. For example:
                            imageBytes = imageStream.ToArray();
                            // Save bytes to the database.


                        }
                    }

                    dm.InsertStyleInfo(strCurrentStore, strStyleName, strColorName, strImageURL, imageBytes, strVenderCode, strVenderName);

                    // save order info
                    dm.InsertOrderInfo(strOrderNumber, Convert.ToDateTime(strOrderDate));

                    // save order item info
                    dm.InsertOrderItemInfo(strOrderNumber, strStyleName, strCustomerID, strColorName, Convert.ToInt32(strTotalQty));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        public bool IsNumeric(string strValue)
        {
            bool bRetVal = false;
            int nConvertedVal = -1;

            try
            {
                nConvertedVal = int.Parse(strValue);
            }
            catch (Exception ex)
            { }

            if (nConvertedVal > 0)
                bRetVal = true;
            else
                bRetVal = false;

            return bRetVal;
        }

        private void btnGetOrderNumber_Click(object sender, EventArgs e)
        {
            GetOrderNumber();
        }

        private void wbOrderInfo_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.AbsoluteUri == wbOrderInfo.Url.AbsoluteUri)
            {
                if (e.Url.AbsoluteUri.IndexOf("OrderDetails.aspx") >= 0)
                {
                    GetOrderInfo();
                }
            }
        }

        private void cbPOList_SelectedIndexChanged(object sender, EventArgs e)
        {
            wbOrderInfo.Url = new Uri(wbOrderInfo.Url.Scheme + "://" + wbOrderInfo.Url.Host + "/OrderDetails.aspx?po=" + cbPOList.SelectedItem.ToString());
        }

        private void dgResult_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                for (int i = 0; i < dgResult.Rows.Count; i++)
                {
                    if (dgResult.Rows[i].Selected)
                    {
                        dgResult.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                for (int i = 0; i < dgResult.Rows.Count; i++)
                {
                    dgResult.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }
    }

    public class VenderInfo
    {
        public string VenderCode;
        public string VenderName;

        public VenderInfo(string strVenderCode, string strVenderName)
        {
            VenderCode = strVenderCode;
            VenderName = strVenderName;
        }
    }
}
