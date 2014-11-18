namespace GetWebPageText
{
    partial class Form1
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
            this.btnGetData = new System.Windows.Forms.Button();
            this.wbMain = new System.Windows.Forms.WebBrowser();
            this.cbPOList = new System.Windows.Forms.ComboBox();
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
            this.btnBack = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dgResult)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(203, 6);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(129, 21);
            this.btnGetData.TabIndex = 1;
            this.btnGetData.Text = "Get PO Number";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // wbMain
            // 
            this.wbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wbMain.Location = new System.Drawing.Point(6, 33);
            this.wbMain.MinimumSize = new System.Drawing.Size(23, 18);
            this.wbMain.Name = "wbMain";
            this.wbMain.ScriptErrorsSuppressed = true;
            this.wbMain.Size = new System.Drawing.Size(1009, 425);
            this.wbMain.TabIndex = 2;
            this.wbMain.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbMain_DocumentCompleted);
            // 
            // cbPOList
            // 
            this.cbPOList.FormattingEnabled = true;
            this.cbPOList.Location = new System.Drawing.Point(13, 7);
            this.cbPOList.Name = "cbPOList";
            this.cbPOList.Size = new System.Drawing.Size(174, 20);
            this.cbPOList.TabIndex = 3;
            this.cbPOList.Text = "ORDER NUMBER";
            this.cbPOList.SelectedIndexChanged += new System.EventHandler(this.cbPOList_SelectedIndexChanged);
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
            this.OrderNumber});
            this.dgResult.Location = new System.Drawing.Point(15, 508);
            this.dgResult.Name = "dgResult";
            this.dgResult.RowTemplate.Height = 23;
            this.dgResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgResult.Size = new System.Drawing.Size(1026, 256);
            this.dgResult.TabIndex = 4;
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
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(344, 6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(129, 21);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Go Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(15, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1026, 490);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.wbMain);
            this.tabPage1.Controls.Add(this.btnBack);
            this.tabPage1.Controls.Add(this.btnGetData);
            this.tabPage1.Controls.Add(this.cbPOList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1018, 464);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Get Order Information";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 774);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dgResult);
            this.Name = "Form1";
            this.Text = "Get Order Information";
            ((System.ComponentModel.ISupportInitialize)(this.dgResult)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.WebBrowser wbMain;
        private System.Windows.Forms.ComboBox cbPOList;
        private System.Windows.Forms.DataGridView dgResult;
        private System.Windows.Forms.Button btnBack;
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
    }
}

