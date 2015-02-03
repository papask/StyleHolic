using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace Styleholic.DataManager
{
    public class MySqlDataManager
    {
        private MySqlConnection Connection = null;

        public MySqlDataManager()
        {
            string StrCon = string.Format("Server=localhost; database={0}; UID=root; password=dubu8790", "styleholic");
            Connection = new MySqlConnection(StrCon);
            Connection.Open();
        }

        public MySqlDataManager(String strConnectString)
        {
            string StrCon = strConnectString;
            Connection = new MySqlConnection(StrCon);
            Connection.Open();
        }

        public bool ExistOrderInfo(String strOrderID, String strStyleNo, String strColor, String strCustomerID)
        {
            bool bRetVal = false;

            DataTable dt = new DataTable();
            string query = "Select * from orderiteminfo where OrderId = '" + strOrderID + "' AND StyleNo = '" + strStyleNo + "' AND color = '" + strColor + "' AND CustomerId = '" + strCustomerID + "';";
            MySqlCommand cmd = new MySqlCommand(query, Connection);
            MySqlDataReader dr = cmd.ExecuteReader();

            dt.Load(dr);

            if (dt != null && dt.Rows.Count > 0)
            {
                bRetVal = true;
            }

            return bRetVal;
        }

        public DataTable GetStyleListFromStoreID(String strStoreID, bool bIsOnlyExist)
        {
            DataTable dt = new DataTable();
            string query = "SELECT	a.StyleNo, a.VenderName, a.OnSale	" +
                        " FROM (Select *, fnGetRemainOrderCount(StyleNo) AS RemainOrderCount from styleinfo) a " +
                        " INNER JOIN orderiteminfo b ON a.styleNo = b.StyleNo" +
                        " INNER JOIN orderinfo c ON b.orderId = c.OrderId" +
                        " where c.storeid = '" + strStoreID + "'";
                        
            if (bIsOnlyExist)
                query += " AND RemainOrderCount > 0 AND OnSale = '1'";

            query += " GROUP BY a.StyleNo, a.VenderName, a.OnSale	";
            query += " ORDER BY a.VenderName ASC";
            
            MySqlCommand cmd = new MySqlCommand(query, Connection);
            MySqlDataReader dr = cmd.ExecuteReader();

            dt.Load(dr);

            return dt;
        }

        public StyleInfo GetStyleInfoFromStyleID(String strStyleID)
        {
            StyleInfo si = new StyleInfo();

            DataTable dt = new DataTable();
            string query = "Select * from styleinfo where styleno = '" + strStyleID + "'";
            MySqlCommand cmd = new MySqlCommand(query, Connection);
            MySqlDataReader dr = cmd.ExecuteReader();

            dt.Load(dr);

            if (dt != null && dt.Rows.Count > 0)
            {
                si.StoreId = dt.Rows[0]["storeid"].ToString();
                si.StyleNo = dt.Rows[0]["styleno"].ToString();
                try
                {
                    si.ImageUrl = dt.Rows[0]["imageurl"].ToString();
                }
                catch (Exception ex)
                {
                    si.ImageUrl = String.Empty;
                }

                try
                {
                    si.StyleImage = (byte[])dt.Rows[0]["StyleImage"];
                }
                catch (Exception ex)
                {
                    si.StyleImage = null;
                }
                si.VenderCode = dt.Rows[0]["vender"].ToString();
                si.VenderName = dt.Rows[0]["vendername"].ToString();
                si.Created = Convert.ToDateTime(dt.Rows[0]["created"]);
                si.LastModified = Convert.ToDateTime(dt.Rows[0]["LastModified"]);

                if (dt.Rows[0]["OnSale"].ToString() == "1")
                    si.OnSale = true;
                else
                    si.OnSale = false;
            }

            return si;
        }

        public DataTable GetCustomerListByStyleID(String strStoreID, String strStyleNo)
        {
            DataTable dt = new DataTable();
            string query = "SELECT	a.CustomerName, d.OrderDate, b.*"
                        +" FROM	customerinfo a"
			            + " INNER JOIN orderiteminfo b ON a.CustomerId = b.CustomerId"
                        + " INNER JOIN styleinfo c ON b.StyleNo = c.StyleNo"
                        + " INNER JOIN orderinfo d ON b.OrderId = d.OrderId"
                        + " WHERE	b.StyleNo = '" + strStyleNo + "'"
                        + " AND d.StoreId = '" + strStoreID + "'"
                        + " ORDER BY d.OrderDate ASC;";

            MySqlCommand cmd = new MySqlCommand(query, Connection);
            MySqlDataReader dr = cmd.ExecuteReader();

            dt.Load(dr);

            return dt;

            //DataTable dt = new DataTable();
            //using (MySqlCommand command = new MySqlCommand())
            //{
            //    command.Connection = Connection;
            //    command.CommandText = "CALL spGetCustomerListByStyleId(?styleId);";
            //    MySqlParameter paramStyleID = new MySqlParameter("?styleId", MySqlDbType.VarChar, 45);
            //    paramStyleID.Value = strStyleID;

            //    MySqlDataAdapter da = new MySqlDataAdapter(command);
            //    da.Fill(dt);
            //}

            //return dt;
        }

        public DataTable GetRemainQuantityByColorFromStyleID(String strStyleNo)
        {
            DataTable dt = new DataTable();
            string query = "SELECT	Color, SUM(Quantity) AS Quantity"
                            + " FROM	orderiteminfo"
                            + " WHERE StyleNo = '" + strStyleNo + "'"
                            + " GROUP BY Color;";

            MySqlCommand cmd = new MySqlCommand(query, Connection);
            MySqlDataReader dr = cmd.ExecuteReader();

            dt.Load(dr);

            return dt;
        }

        public String GetFastEstimateInfoFromStyleID(String strStyleNo, String strColor)
        {
            String strRetVal = String.Empty;
            DataTable dt = new DataTable();
            string query = "SELECT EstimateDate, Quantity"
                            + " FROM	estimatedateinfo"
                            + " WHERE StyleNo = '" + strStyleNo + "'"
                            + " AND Color = '" + strColor + "'"
                            + " AND (Delivered IS NULL OR Delivered = 'N')"
                            + " ORDER BY EstimateDate ASC;";

            MySqlCommand cmd = new MySqlCommand(query, Connection);
            MySqlDataReader dr = cmd.ExecuteReader();

            dt.Load(dr);

            if (dt != null && dt.Rows.Count > 0)
            {
                strRetVal = Convert.ToDateTime(dt.Rows[0]["EstimateDate"]).ToShortDateString() + " (qty: " + dt.Rows[0]["Quantity"].ToString() + ")";
            }

            return strRetVal;
        }

        public String GetDeliveryExpectedQuantityFromEstimateDate(String strStyleNo, String strColor, String strEstimateDate)
        {
            String strRetVal = String.Empty;

            DataTable dt = new DataTable();
            string query = "SELECT	*"
                            + " FROM estimatedateinfo "
                            + " WHERE StyleNo = '" + strStyleNo + "'"
                            + " AND Color = '" + strColor + "'"
                            + " AND EstimateDate = '" + strEstimateDate + "'";

            MySqlCommand cmd = new MySqlCommand(query, Connection);
            MySqlDataReader dr = cmd.ExecuteReader();

            dt.Load(dr);

            if (dt != null && dt.Rows.Count > 0)
            {
                strRetVal = dt.Rows[0]["Quantity"].ToString();
            }
            return strRetVal;
        } 

        public DataTable GetRemainQuantityByCustomerFromStyleID(String strStoreID, String strStyleNo)
        {
            DataTable dt = new DataTable();
            string query = "SELECT	a.Color, a.Quantity, b.CustomerName, c.OrderId"
                            + " FROM	orderiteminfo a"
                            + " INNER JOIN customerinfo b ON a.customerId = b.customerId"
                            + " INNER JOIN orderinfo c ON a.OrderId = c.OrderId" 
                            + " WHERE a.StyleNo = '" + strStyleNo + "'"
                            + " AND c.StoreId = '" + strStoreID + "'"
                            + " AND (a.Ispacked IS NULL OR a.Ispacked = '0')"
                            + " GROUP BY a.Color, a.Quantity, b.CustomerName, c.OrderId"
                            + " ORDER BY b.CustomerName ASC;";

            MySqlCommand cmd = new MySqlCommand(query, Connection);
            MySqlDataReader dr = cmd.ExecuteReader();

            dt.Load(dr);

            return dt;
        }

        public DataTable GetRemainItemListFromCustomerID(String strStoreID, String strCustomerID, bool bIsShowAll)
        {
            DataTable dt = new DataTable();
            string query = "SELECT	b.*, d.StyleImage, d.ImageUrl, d.Vender, d.VenderName, c.OrderDate, a.CustomerName"
                            + " FROM	customerinfo a"
                            + " INNER JOIN orderiteminfo b ON a.CustomerId = b.CustomerId"
                            + " INNER JOIN orderinfo c ON b.OrderId = c.OrderId"
                            + " INNER JOIN styleinfo d ON b.styleNo = d.StyleNo"
                            + " WHERE c.StoreId = '" + strStoreID + "'";

            if (bIsShowAll)
                query += " AND	a.CustomerId = '" + strCustomerID + "';";
            else
                query += " AND	a.CustomerId = '" + strCustomerID + "' AND ispacked = '0';";

            MySqlCommand cmd = new MySqlCommand(query, Connection);
            MySqlDataReader dr = cmd.ExecuteReader();

            dt.Load(dr);

            return dt;
        }

        public DataTable GetStyleListFromSearchType(String strStoreType, String strSearchType, String strSearchValue)
        {
            DataTable dt = new DataTable();
            string query = "SELECT	a.StyleNo, a.Vendername, a.OnSale"
                            + " FROM	styleinfo a"
                            + " INNER JOIN orderiteminfo b ON a.StyleNo = b.StyleNo"
                            + " INNER JOIN customerinfo c ON b.CustomerId = c.CustomerId"
                            + " INNER JOIN orderinfo d ON b.OrderId = d.orderId"
                            + " WHERE d.StoreId = '" + strStoreType + "'";
            switch (strSearchType)
            {
                case "0":
                    query += " AND a.StyleNo like '%" + strSearchValue + "%'";
                    break;

                case "1":
                    query += " AND a.VenderName like '%" + strSearchValue + "%'";
                    break;

                case "2":
                    query += " AND c.CustomerName like '%" + strSearchValue + "%'";
                    break;

                default:
                    break;
            }

            query += " GROUP BY a.StyleNo";
            query += " ORDER BY a.StyleNo ASC;";

            MySqlCommand cmd = new MySqlCommand(query, Connection);
            MySqlDataReader dr = cmd.ExecuteReader();

            dt.Load(dr);

            return dt;
        }

        public DataTable GetEstimateDateListFromStyleNo(String strStyleNo)
        {
            DataTable dt = new DataTable();
            string query = "SELECT	*"
                            + " FROM	estimatedateinfo"
                            + " WHERE StyleNo = '" + strStyleNo + "'"
                            + " ORDER BY EstimateDate ASC;";

            MySqlCommand cmd = new MySqlCommand(query, Connection);
            MySqlDataReader dr = cmd.ExecuteReader();

            dt.Load(dr);

            return dt;
        }

        public DataTable GetDailyOrderQuantityFromStyleNo(String strStyleNo)
        {
            DataTable dt = new DataTable();
            string query = "SELECT	OrderDate, Color, SUM(Quantity) AS TotalQuantity"
                            + " FROM"
                            + " ("
                            + " SELECT	a.Color, a.Quantity, DATE_FORMAT(b.OrderDate, '%Y-%m-%d') AS OrderDate"
                            + " FROM	orderiteminfo a"
                            + " INNER JOIN orderinfo b ON a.OrderId = b.OrderId"
                            + " WHERE StyleNo = '" + strStyleNo + "'"
                            + " AND a.IsPacked != '2'"
                            + " )a"
                            + " GROUP BY Color, OrderDate"
                            + " ORDER BY OrderDate ASC, Color ASC;";

            MySqlCommand cmd = new MySqlCommand(query, Connection);
            MySqlDataReader dr = cmd.ExecuteReader();

            dt.Load(dr);

            return dt;
        }

        public String InsertCustomerInfo(String strCustomerID, String strCustomerName)
        {
            using (MySqlCommand command = new MySqlCommand())
            {
                command.Connection = Connection;
                command.CommandText = "CALL spInsertCustomer(?customerId, ?customerName);";
                MySqlParameter paramCustomerID = new MySqlParameter("?customerId", MySqlDbType.VarChar, 100);
                MySqlParameter paramCustomerName = new MySqlParameter("?customerName", MySqlDbType.VarChar, 200);
                //MySqlParameter fileContentParameter = new MySqlParameter("?rawData", MySqlDbType.Blob, rawData.Length);

                paramCustomerID.Value = strCustomerID;
                paramCustomerName.Value = strCustomerName;

                command.Parameters.Add(paramCustomerID);
                command.Parameters.Add(paramCustomerName);

                command.ExecuteNonQuery();

            }

            return strCustomerID;
        }

        public String InsertStyleInfo(String strStoreID, String strStyleNo, String strColorName, String strImageURL, byte[] arrImage, String strVender, String strVenderName)
        {
            using (MySqlCommand command = new MySqlCommand())
            {
                command.Connection = Connection;
                command.CommandText = "CALL spInsertStyleInfo(?StoreId, ?StyleNo, ?ColorName, ?ImageUrl, ?styleImage, ?Vender, ?VenderName);";
                MySqlParameter paramStoreID = new MySqlParameter("?StoreId", MySqlDbType.VarChar, 45);
                MySqlParameter paramStyleNo = new MySqlParameter("?StyleNo", MySqlDbType.VarChar, 200);
                MySqlParameter paramColorName = new MySqlParameter("?ColorName", MySqlDbType.VarChar, 100);
                MySqlParameter paramImageURL = new MySqlParameter("?ImageUrl", MySqlDbType.VarChar, 1000);
                MySqlParameter paramImage = new MySqlParameter("?styleImage", MySqlDbType.LongBlob, arrImage == null ? 0 : arrImage.Length);
                MySqlParameter paramVender = new MySqlParameter("?Vender", MySqlDbType.VarChar, 50);
                MySqlParameter paramVenderName = new MySqlParameter("?VenderName", MySqlDbType.VarChar, 100);

                paramStoreID.Value = strStoreID;
                paramStyleNo.Value = strStyleNo;
                paramColorName.Value = strColorName;
                paramImageURL.Value = strImageURL;
                paramImage.Value = arrImage;
                paramVender.Value = strVender;
                paramVenderName.Value = strVenderName;

                command.Parameters.Add(paramStoreID);
                command.Parameters.Add(paramStyleNo);
                command.Parameters.Add(paramColorName);
                command.Parameters.Add(paramImageURL);
                command.Parameters.Add(paramImage);
                command.Parameters.Add(paramVender);
                command.Parameters.Add(paramVenderName);

                command.ExecuteNonQuery();

            }
            return strStyleNo;
        }

        public String InsertOrderInfo(String strOrderID, DateTime OrderDate)
        {
            using (MySqlCommand command = new MySqlCommand())
            {
                command.Connection = Connection;
                command.CommandText = "CALL spInsertOrder(?orderID, ?OrderDate);";
                MySqlParameter paramOrderID = new MySqlParameter("?orderID", MySqlDbType.VarChar, 45);
                MySqlParameter paramOrderDate = new MySqlParameter("?OrderDate", MySqlDbType.Datetime);

                paramOrderID.Value = strOrderID;
                paramOrderDate.Value = OrderDate;

                command.Parameters.Add(paramOrderID);
                command.Parameters.Add(paramOrderDate);

                command.ExecuteNonQuery();

            }

            return strOrderID;
        }

        public void InsertOrderItemInfo(String strOrderID, String strStyleNo, String strCustomerID, String strColor, int nQuantity)
        {
            using (MySqlCommand command = new MySqlCommand())
            {
                command.Connection = Connection;
                command.CommandText = "CALL spInsertOrderItem(?orderID, ?StyleNo, ?CustomerID, ?Color, ?Quantity);";
                MySqlParameter paramOrderID = new MySqlParameter("?orderID", MySqlDbType.VarChar, 45);
                MySqlParameter paramStyleNo = new MySqlParameter("?StyleNo", MySqlDbType.VarChar, 200);
                MySqlParameter paramCustomerID = new MySqlParameter("?CustomerID", MySqlDbType.VarChar, 45);
                MySqlParameter paramColor = new MySqlParameter("?Color", MySqlDbType.VarChar, 100);
                MySqlParameter paramQuantity = new MySqlParameter("?Quantity", MySqlDbType.Int32, 11);

                paramOrderID.Value = strOrderID;
                paramStyleNo.Value = strStyleNo;
                paramCustomerID.Value = strCustomerID;
                paramColor.Value = strColor;
                paramQuantity.Value = nQuantity;

                command.Parameters.Add(paramOrderID);
                command.Parameters.Add(paramStyleNo);
                command.Parameters.Add(paramCustomerID);
                command.Parameters.Add(paramColor);
                command.Parameters.Add(paramQuantity);

                command.ExecuteNonQuery();

            }
        }

        public void InsertEstimateDateInfo(String strStyleNo, String strColor, int nQuantity, DateTime EstimateDate)
        {
            using (MySqlCommand command = new MySqlCommand())
            {
                command.Connection = Connection;
                command.CommandText = "CALL spInsertEstimateDate(?styleNo, ?color, ?quantity, ?estimateDate);";
                MySqlParameter paramStyleNo = new MySqlParameter("?styleNo", MySqlDbType.VarChar, 200);
                MySqlParameter paramColor = new MySqlParameter("?color", MySqlDbType.VarChar, 100);
                MySqlParameter paramQuantity = new MySqlParameter("?quantity", MySqlDbType.Int32);
                MySqlParameter paramEstimateDate = new MySqlParameter("?estimateDate", MySqlDbType.Datetime);

                paramStyleNo.Value = strStyleNo;
                paramColor.Value = strColor;
                paramQuantity.Value = nQuantity;
                paramEstimateDate.Value = EstimateDate;

                command.Parameters.Add(paramStyleNo);
                command.Parameters.Add(paramColor);
                command.Parameters.Add(paramQuantity);
                command.Parameters.Add(paramEstimateDate);

                command.ExecuteNonQuery();

            }
        }

        public void UpdateStyleInfo(String strStyleNo, String strVenderCode, String strVenderName, String strOnSale)
        {
            DataTable dt = new DataTable();
            string query = "UPDATE	styleinfo"
                            + " SET		Vender = '" + strVenderCode + "'"
                            + " , Vendername = '" + strVenderName + "'"
                            + " , OnSale = '" + strOnSale + "'"
                            + " WHERE	StyleNo = '" + strStyleNo + "';";

            MySqlCommand cmd = new MySqlCommand(query, Connection);
            cmd.ExecuteNonQuery();
        }

        public void UpdateStyleStatus(String strStyleNo, String strOnSale)
        {
            DataTable dt = new DataTable();
            string query = "UPDATE	styleinfo"
                            + " SET		OnSale = '" + strOnSale + "'"
                            + " WHERE	StyleNo = '" + strStyleNo + "';";

            MySqlCommand cmd = new MySqlCommand(query, Connection);
            cmd.ExecuteNonQuery();
        }

        public void UpdateOrderItemQuantity(String strOrderId, String strStyleNo, String strColor, String strQuantity)
        {
            DataTable dt = new DataTable();
            string query = "UPDATE	orderiteminfo"
                            + " SET		Quantity = '" + strQuantity + "'"
                            + " WHERE	OrderId = '" + strOrderId + "'"
                            + " AND StyleNo = '" + strStyleNo + "'"
                            + " AND	Color = '" + strColor + "';";

            MySqlCommand cmd = new MySqlCommand(query, Connection);
            cmd.ExecuteNonQuery();
        }

        public void UpdateOrderItemStatus(String strOrderId, String strStyleNo, String strColor, String strStatus)
        {
            DataTable dt = new DataTable();
            string query = "UPDATE	orderiteminfo"
                            + " SET		IsPacked = '" + strStatus + "'";

            if (strStatus == "1")
                query += " , PackedDate = NOW()";
            else
                query += " , PackedDate = null";

            query += " WHERE	OrderId = '" + strOrderId + "'"
                            + " AND StyleNo = '" + strStyleNo + "'"
                            + " AND	Color = '" + strColor + "';";

            MySqlCommand cmd = new MySqlCommand(query, Connection);
            cmd.ExecuteNonQuery();
        }

        public void UpdateDeleveryStatus(String strStyleNo, String strColor, String strEstimateDate)
        {
            DataTable dt = new DataTable();
            string query = "UPDATE	estimatedateinfo"
                            + " SET		Delivered = 'Y'"
                            + " WHERE	StyleNo = '" + strStyleNo + "'"
                            + " AND Color = '" + strColor + "'"
                            + " AND	EstimateDate = '" + strEstimateDate + "';";

            MySqlCommand cmd = new MySqlCommand(query, Connection);
            cmd.ExecuteNonQuery();
        }

        public void DeleteDeliveryEstimateDateInfo(String strStyleNo, String strColor, String strEstimateDate)
        {
            DataTable dt = new DataTable();
            string query = "DELETE  FROM	estimatedateinfo"
                            + " WHERE	StyleNo = '" + strStyleNo + "'"
                            + " AND Color = '" + strColor + "'"
                            + " AND	EstimateDate = '" + strEstimateDate + "';";

            MySqlCommand cmd = new MySqlCommand(query, Connection);
            cmd.ExecuteNonQuery();
        }
    }
}
