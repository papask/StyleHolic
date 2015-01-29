namespace BackorderManagement
{
    partial class GetBackorderInformation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.wbOrderInfo = new System.Windows.Forms.WebBrowser();
            this.cbPOList = new System.Windows.Forms.ComboBox();
            this.btnGetOrderNumber = new System.Windows.Forms.Button();
            this.dgResult = new System.Windows.Forms.DataGridView();
            this.VenderCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VenderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StyleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillingAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShippingMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgResult)).BeginInit();
            this.SuspendLayout();
            // 
            // wbOrderInfo
            // 
            this.wbOrderInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wbOrderInfo.Location = new System.Drawing.Point(8, 53);
            this.wbOrderInfo.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbOrderInfo.Name = "wbOrderInfo";
            this.wbOrderInfo.ScriptErrorsSuppressed = true;
            this.wbOrderInfo.Size = new System.Drawing.Size(1138, 498);
            this.wbOrderInfo.TabIndex = 1;
            this.wbOrderInfo.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbOrderInfo_DocumentCompleted);
            // 
            // cbPOList
            // 
            this.cbPOList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPOList.FormattingEnabled = true;
            this.cbPOList.Location = new System.Drawing.Point(8, 27);
            this.cbPOList.Name = "cbPOList";
            this.cbPOList.Size = new System.Drawing.Size(158, 20);
            this.cbPOList.TabIndex = 3;
            this.cbPOList.SelectedIndexChanged += new System.EventHandler(this.cbPOList_SelectedIndexChanged);
            // 
            // btnGetOrderNumber
            // 
            this.btnGetOrderNumber.Location = new System.Drawing.Point(175, 27);
            this.btnGetOrderNumber.Name = "btnGetOrderNumber";
            this.btnGetOrderNumber.Size = new System.Drawing.Size(119, 23);
            this.btnGetOrderNumber.TabIndex = 4;
            this.btnGetOrderNumber.Text = "Get PO Number";
            this.btnGetOrderNumber.UseVisualStyleBackColor = true;
            this.btnGetOrderNumber.Click += new System.EventHandler(this.btnGetOrderNumber_Click);
            // 
            // dgResult
            // 
            this.dgResult.AllowUserToAddRows = false;
            this.dgResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VenderCode,
            this.VenderName,
            this.StyleName,
            this.ColorName,
            this.SizeInfo,
            this.TotalQty,
            this.TotalValue,
            this.BillingAddr,
            this.ShippingMethod,
            this.OrderNumber,
            this.Column1,
            this.Column2});
            this.dgResult.Location = new System.Drawing.Point(8, 557);
            this.dgResult.Name = "dgResult";
            this.dgResult.RowTemplate.Height = 23;
            this.dgResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgResult.Size = new System.Drawing.Size(1138, 157);
            this.dgResult.TabIndex = 5;
            this.dgResult.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgResult_KeyUp);
            // 
            // VenderCode
            // 
            this.VenderCode.FillWeight = 70F;
            this.VenderCode.HeaderText = "VENDER CODE";
            this.VenderCode.Name = "VenderCode";
            this.VenderCode.Width = 70;
            // 
            // VenderName
            // 
            this.VenderName.HeaderText = "VENDER NAME";
            this.VenderName.Name = "VenderName";
            this.VenderName.Width = 140;
            // 
            // StyleName
            // 
            this.StyleName.HeaderText = "STYLE";
            this.StyleName.Name = "StyleName";
            this.StyleName.Width = 120;
            // 
            // ColorName
            // 
            this.ColorName.HeaderText = "COLOR";
            this.ColorName.Name = "ColorName";
            // 
            // SizeInfo
            // 
            this.SizeInfo.HeaderText = "SIZE";
            this.SizeInfo.Name = "SizeInfo";
            this.SizeInfo.Width = 120;
            // 
            // TotalQty
            // 
            this.TotalQty.HeaderText = "TOTAL QTY";
            this.TotalQty.Name = "TotalQty";
            this.TotalQty.ReadOnly = true;
            // 
            // TotalValue
            // 
            this.TotalValue.HeaderText = "TOTAL";
            this.TotalValue.Name = "TotalValue";
            // 
            // BillingAddr
            // 
            this.BillingAddr.HeaderText = "CUSTOMER (BILLING)";
            this.BillingAddr.Name = "BillingAddr";
            this.BillingAddr.Width = 300;
            // 
            // ShippingMethod
            // 
            this.ShippingMethod.FillWeight = 140F;
            this.ShippingMethod.HeaderText = "SHIPMENT";
            this.ShippingMethod.Name = "ShippingMethod";
            this.ShippingMethod.Width = 140;
            // 
            // OrderNumber
            // 
            this.OrderNumber.HeaderText = "PO#";
            this.OrderNumber.Name = "OrderNumber";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ImageURL";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "CustomerID";
            this.Column2.Name = "Column2";
            // 
            // GetBackorderInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 726);
            this.ControlBox = false;
            this.Controls.Add(this.dgResult);
            this.Controls.Add(this.btnGetOrderNumber);
            this.Controls.Add(this.cbPOList);
            this.Controls.Add(this.wbOrderInfo);
            this.Name = "GetBackorderInformation";
            this.Text = "GetBackorderInformation";
            ((System.ComponentModel.ISupportInitialize)(this.dgResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbOrderInfo;
        private System.Windows.Forms.ComboBox cbPOList;
        private System.Windows.Forms.Button btnGetOrderNumber;
        private System.Windows.Forms.DataGridView dgResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn VenderCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn VenderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StyleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillingAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShippingMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}