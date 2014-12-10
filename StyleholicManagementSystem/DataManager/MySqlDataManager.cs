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

        public DataTable GetStyleListFromStoreID(String strStoreID)
        {
            DataTable dt = new DataTable();
            string query = "Select * from styleinfo where storeid = '" + strStoreID + "'";
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
                si.ImageUrl = dt.Rows[0]["imageurl"].ToString();
                try
                {
                    si.StyleImage = (byte[])dt.Rows[0]["StyleImage"];
                }
                catch (Exception ex)
                {
                    si.StyleImage = null;
                }
                si.Vender = dt.Rows[0]["vender"].ToString();
                si.Created = Convert.ToDateTime(dt.Rows[0]["created"]);
                si.LastModified = Convert.ToDateTime(dt.Rows[0]["LastModified"]);
            }

            return si;
        }

        public DataTable GetCustomerListByStyleID(String strStyleID)
        {
            DataTable dt = new DataTable();
            string query = "SELECT	a.CustomerName, b.*"
                        +" FROM	customerinfo a"
			            + " INNER JOIN orderiteminfo b ON a.CustomerId = b.CustomerId"
                        + " INNER JOIN styleinfo c ON b.StyleId = c.StyleNo"
                        + " WHERE	b.StyleId = '" + strStyleID + "';";

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

        public DataTable GetRemainItemListFromCustomerID(String strCustomerID)
        {
            DataTable dt = new DataTable();
            string query = "SELECT	b.*, d.StyleImage, d.ImageUrl, d.Vender, d.VenderName, c.OrderDate"
                            + " FROM	customerinfo a"
		                    + " INNER JOIN orderiteminfo b ON a.CustomerId = b.CustomerId"
                            + " INNER JOIN orderinfo c ON b.OrderId = c.OrderId"
                            + " INNER JOIN styleinfo d ON b.styleId = d.StyleNo"
                            + " WHERE	a.CustomerId = '" + strCustomerID + "';";

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
                MySqlParameter paramCustomerID = new MySqlParameter("?customerId", MySqlDbType.VarChar, 45);
                MySqlParameter paramCustomerName = new MySqlParameter("?customerName", MySqlDbType.VarChar, 45);
                //MySqlParameter fileContentParameter = new MySqlParameter("?rawData", MySqlDbType.Blob, rawData.Length);

                paramCustomerID.Value = strCustomerID;
                paramCustomerName.Value = strCustomerName;

                command.Parameters.Add(paramCustomerID);
                command.Parameters.Add(paramCustomerName);

                command.ExecuteNonQuery();

            }

            return strCustomerID;
        }

        public String InsertStyleInfo(String strStoreID, String strStyleNo, String strImageURL, byte[] arrImage, String strVender, String strVenderName)
        {
            using (MySqlCommand command = new MySqlCommand())
            {
                command.Connection = Connection;
                command.CommandText = "CALL spInsertStyleInfo(?StoreId, ?StyleNo, ?ImageUrl, ?styleImage, ?Vender, ?VenderName);";
                MySqlParameter paramStoreID = new MySqlParameter("?StoreId", MySqlDbType.VarChar, 45);
                MySqlParameter paramStyleNo = new MySqlParameter("?StyleNo", MySqlDbType.VarChar, 45);
                MySqlParameter paramImageURL = new MySqlParameter("?ImageUrl", MySqlDbType.VarChar, 1000);
                MySqlParameter paramImage = new MySqlParameter("?styleImage", MySqlDbType.LongBlob, arrImage == null ? 0 : arrImage.Length);
                MySqlParameter paramVender = new MySqlParameter("?Vender", MySqlDbType.VarChar, 45);
                MySqlParameter paramVenderName = new MySqlParameter("?VenderName", MySqlDbType.VarChar, 45);

                paramStoreID.Value = strStoreID;
                paramStyleNo.Value = strStyleNo;
                paramImageURL.Value = strImageURL;
                paramImage.Value = arrImage;
                paramVender.Value = strVender;
                paramVenderName.Value = strVenderName;

                command.Parameters.Add(paramStoreID);
                command.Parameters.Add(paramStyleNo);
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
                MySqlParameter paramStyleNo = new MySqlParameter("?StyleNo", MySqlDbType.VarChar, 45);
                MySqlParameter paramCustomerID = new MySqlParameter("?CustomerID", MySqlDbType.VarChar, 45);
                MySqlParameter paramColor = new MySqlParameter("?Color", MySqlDbType.VarChar, 45);
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
    }
}
