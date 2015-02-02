namespace BackorderManagement
{
    partial class BackorderManage
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dvStyleList = new System.Windows.Forms.DataGridView();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dvRemainItemList = new System.Windows.Forms.DataGridView();
            this.Column23 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvCustomerList = new System.Windows.Forms.DataGridView();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.dvRemainQuantityList = new System.Windows.Forms.DataGridView();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmPacked = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.packedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.didntPackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canceledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSearchStyle = new System.Windows.Forms.TextBox();
            this.btnSearchStyle = new System.Windows.Forms.Button();
            this.cbStoreList = new System.Windows.Forms.ComboBox();
            this.lbSeletedStyle = new System.Windows.Forms.Label();
            this.cbShowAll = new System.Windows.Forms.CheckBox();
            this.dvOrderQtyByDate = new System.Windows.Forms.DataGridView();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cbShowAllForRemainItems = new System.Windows.Forms.CheckBox();
            this.cmStyleStatus = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.outOfStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onSaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dvStyleList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvRemainItemList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvCustomerList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvRemainQuantityList)).BeginInit();
            this.cmPacked.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvOrderQtyByDate)).BeginInit();
            this.cmStyleStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // dvStyleList
            // 
            this.dvStyleList.AllowUserToAddRows = false;
            this.dvStyleList.AllowUserToDeleteRows = false;
            this.dvStyleList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dvStyleList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvStyleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvStyleList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Column10,
            this.Column22});
            this.dvStyleList.Location = new System.Drawing.Point(8, 102);
            this.dvStyleList.MultiSelect = false;
            this.dvStyleList.Name = "dvStyleList";
            this.dvStyleList.RowHeadersVisible = false;
            this.dvStyleList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvStyleList.Size = new System.Drawing.Size(301, 511);
            this.dvStyleList.TabIndex = 68;
            this.dvStyleList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvStyleList_CellClick);
            this.dvStyleList.SelectionChanged += new System.EventHandler(this.dvStyleList_SelectionChanged);
            this.dvStyleList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dvStyleList_MouseClick);
            this.dvStyleList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dvStyleList_MouseDown);
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Vender";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Style No.";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column22
            // 
            this.Column22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column22.HeaderText = "InStock";
            this.Column22.Name = "Column22";
            this.Column22.Width = 70;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(591, 297);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 12);
            this.label7.TabIndex = 67;
            this.label7.Text = "Remain items";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(320, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 221);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 64;
            this.pictureBox1.TabStop = false;
            // 
            // dvRemainItemList
            // 
            this.dvRemainItemList.AllowUserToAddRows = false;
            this.dvRemainItemList.AllowUserToDeleteRows = false;
            this.dvRemainItemList.AllowUserToOrderColumns = true;
            this.dvRemainItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dvRemainItemList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvRemainItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvRemainItemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column23,
            this.Column8,
            this.Column13,
            this.Column1,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column12,
            this.Column14});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvRemainItemList.DefaultCellStyle = dataGridViewCellStyle1;
            this.dvRemainItemList.Location = new System.Drawing.Point(591, 312);
            this.dvRemainItemList.MultiSelect = false;
            this.dvRemainItemList.Name = "dvRemainItemList";
            this.dvRemainItemList.ReadOnly = true;
            this.dvRemainItemList.RowHeadersVisible = false;
            this.dvRemainItemList.RowTemplate.Height = 150;
            this.dvRemainItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dvRemainItemList.Size = new System.Drawing.Size(562, 301);
            this.dvRemainItemList.TabIndex = 65;
            this.dvRemainItemList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvRemainItemList_CellContentClick);
            this.dvRemainItemList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dvRemainItemList_MouseClick);
            this.dvRemainItemList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dvRemainItemList_MouseDown);
            // 
            // Column23
            // 
            this.Column23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column23.Frozen = true;
            this.Column23.HeaderText = "";
            this.Column23.Name = "Column23";
            this.Column23.ReadOnly = true;
            this.Column23.Width = 50;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column8.Frozen = true;
            this.Column8.HeaderText = "Image";
            this.Column8.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column13.HeaderText = "Vender";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.FillWeight = 29.02169F;
            this.Column1.HeaderText = "StyleNo";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 170;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column5.FillWeight = 29.02169F;
            this.Column5.HeaderText = "Color";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column6.FillWeight = 29.02169F;
            this.Column6.HeaderText = "Quantity";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 60;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column7.FillWeight = 29.02169F;
            this.Column7.HeaderText = "Packed";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 50;
            // 
            // Column12
            // 
            this.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column12.FillWeight = 29.02169F;
            this.Column12.HeaderText = "PO No.";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 150;
            // 
            // Column14
            // 
            this.Column14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column14.HeaderText = "Order date";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // dvCustomerList
            // 
            this.dvCustomerList.AllowUserToAddRows = false;
            this.dvCustomerList.AllowUserToDeleteRows = false;
            this.dvCustomerList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dvCustomerList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvCustomerList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dvCustomerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvCustomerList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column11,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column15});
            this.dvCustomerList.Location = new System.Drawing.Point(826, 62);
            this.dvCustomerList.MultiSelect = false;
            this.dvCustomerList.Name = "dvCustomerList";
            this.dvCustomerList.ReadOnly = true;
            this.dvCustomerList.RowHeadersVisible = false;
            this.dvCustomerList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dvCustomerList.Size = new System.Drawing.Size(323, 221);
            this.dvCustomerList.TabIndex = 63;
            this.dvCustomerList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvCustomerList_CellClick);
            this.dvCustomerList.SelectionChanged += new System.EventHandler(this.dvCustomerList_SelectionChanged);
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Order Date";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Customer";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Color";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Quantity";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "CustomerId";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(828, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 12);
            this.label6.TabIndex = 62;
            this.label6.Text = "Customer list";
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(193, 45);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(116, 23);
            this.btnReload.TabIndex = 69;
            this.btnReload.Text = "Reload Style List";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(1029, 286);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(123, 23);
            this.btnPrint.TabIndex = 70;
            this.btnPrint.Text = "Print remain items";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // dvRemainQuantityList
            // 
            this.dvRemainQuantityList.AllowUserToAddRows = false;
            this.dvRemainQuantityList.AllowUserToDeleteRows = false;
            this.dvRemainQuantityList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvRemainQuantityList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column16,
            this.Column17,
            this.Column18});
            this.dvRemainQuantityList.Location = new System.Drawing.Point(527, 62);
            this.dvRemainQuantityList.MultiSelect = false;
            this.dvRemainQuantityList.Name = "dvRemainQuantityList";
            this.dvRemainQuantityList.ReadOnly = true;
            this.dvRemainQuantityList.RowHeadersVisible = false;
            this.dvRemainQuantityList.RowTemplate.Height = 23;
            this.dvRemainQuantityList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvRemainQuantityList.Size = new System.Drawing.Size(293, 221);
            this.dvRemainQuantityList.TabIndex = 71;
            // 
            // Column16
            // 
            this.Column16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column16.HeaderText = "Color";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            // 
            // Column17
            // 
            this.Column17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column17.HeaderText = "Qty";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            this.Column17.Width = 40;
            // 
            // Column18
            // 
            this.Column18.HeaderText = "Estimate Date";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            this.Column18.Width = 120;
            // 
            // cmPacked
            // 
            this.cmPacked.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.packedToolStripMenuItem,
            this.didntPackToolStripMenuItem,
            this.canceledToolStripMenuItem});
            this.cmPacked.Name = "cmPacked";
            this.cmPacked.Size = new System.Drawing.Size(137, 70);
            // 
            // packedToolStripMenuItem
            // 
            this.packedToolStripMenuItem.Name = "packedToolStripMenuItem";
            this.packedToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.packedToolStripMenuItem.Text = "Packed";
            this.packedToolStripMenuItem.Click += new System.EventHandler(this.packedToolStripMenuItem_Click);
            // 
            // didntPackToolStripMenuItem
            // 
            this.didntPackToolStripMenuItem.Name = "didntPackToolStripMenuItem";
            this.didntPackToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.didntPackToolStripMenuItem.Text = "Didn\'t pack";
            this.didntPackToolStripMenuItem.Click += new System.EventHandler(this.didntPackToolStripMenuItem_Click);
            // 
            // canceledToolStripMenuItem
            // 
            this.canceledToolStripMenuItem.Name = "canceledToolStripMenuItem";
            this.canceledToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.canceledToolStripMenuItem.Text = "Canceled";
            this.canceledToolStripMenuItem.Click += new System.EventHandler(this.canceledToolStripMenuItem_Click);
            // 
            // txtSearchStyle
            // 
            this.txtSearchStyle.Location = new System.Drawing.Point(8, 75);
            this.txtSearchStyle.Name = "txtSearchStyle";
            this.txtSearchStyle.Size = new System.Drawing.Size(178, 21);
            this.txtSearchStyle.TabIndex = 72;
            this.txtSearchStyle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchStyle_KeyDown);
            // 
            // btnSearchStyle
            // 
            this.btnSearchStyle.Location = new System.Drawing.Point(193, 75);
            this.btnSearchStyle.Name = "btnSearchStyle";
            this.btnSearchStyle.Size = new System.Drawing.Size(116, 23);
            this.btnSearchStyle.TabIndex = 73;
            this.btnSearchStyle.Text = "Search Style";
            this.btnSearchStyle.UseVisualStyleBackColor = true;
            this.btnSearchStyle.Click += new System.EventHandler(this.btnSearchStyle_Click);
            // 
            // cbStoreList
            // 
            this.cbStoreList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStoreList.FormattingEnabled = true;
            this.cbStoreList.Items.AddRange(new object[] {
            "Styleholic",
            "American Chic",
            "Ray"});
            this.cbStoreList.Location = new System.Drawing.Point(88, 45);
            this.cbStoreList.Name = "cbStoreList";
            this.cbStoreList.Size = new System.Drawing.Size(98, 20);
            this.cbStoreList.TabIndex = 74;
            // 
            // lbSeletedStyle
            // 
            this.lbSeletedStyle.AutoSize = true;
            this.lbSeletedStyle.Location = new System.Drawing.Point(320, 44);
            this.lbSeletedStyle.Name = "lbSeletedStyle";
            this.lbSeletedStyle.Size = new System.Drawing.Size(0, 12);
            this.lbSeletedStyle.TabIndex = 75;
            // 
            // cbShowAll
            // 
            this.cbShowAll.AutoSize = true;
            this.cbShowAll.Location = new System.Drawing.Point(8, 48);
            this.cbShowAll.Name = "cbShowAll";
            this.cbShowAll.Size = new System.Drawing.Size(74, 16);
            this.cbShowAll.TabIndex = 76;
            this.cbShowAll.Text = "Show All";
            this.cbShowAll.UseVisualStyleBackColor = true;
            this.cbShowAll.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // dvOrderQtyByDate
            // 
            this.dvOrderQtyByDate.AllowUserToAddRows = false;
            this.dvOrderQtyByDate.AllowUserToDeleteRows = false;
            this.dvOrderQtyByDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dvOrderQtyByDate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvOrderQtyByDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvOrderQtyByDate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column19,
            this.Column21,
            this.Column20});
            this.dvOrderQtyByDate.Location = new System.Drawing.Point(322, 312);
            this.dvOrderQtyByDate.MultiSelect = false;
            this.dvOrderQtyByDate.Name = "dvOrderQtyByDate";
            this.dvOrderQtyByDate.ReadOnly = true;
            this.dvOrderQtyByDate.RowHeadersVisible = false;
            this.dvOrderQtyByDate.RowTemplate.Height = 23;
            this.dvOrderQtyByDate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvOrderQtyByDate.Size = new System.Drawing.Size(263, 301);
            this.dvOrderQtyByDate.TabIndex = 77;
            // 
            // Column19
            // 
            this.Column19.HeaderText = "Order date";
            this.Column19.Name = "Column19";
            this.Column19.ReadOnly = true;
            // 
            // Column21
            // 
            this.Column21.HeaderText = "Color";
            this.Column21.Name = "Column21";
            this.Column21.ReadOnly = true;
            // 
            // Column20
            // 
            this.Column20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column20.HeaderText = "Qty";
            this.Column20.Name = "Column20";
            this.Column20.ReadOnly = true;
            this.Column20.Width = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(320, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 12);
            this.label1.TabIndex = 78;
            this.label1.Text = "Quantity By Date";
            // 
            // cbShowAllForRemainItems
            // 
            this.cbShowAllForRemainItems.AutoSize = true;
            this.cbShowAllForRemainItems.Location = new System.Drawing.Point(680, 293);
            this.cbShowAllForRemainItems.Name = "cbShowAllForRemainItems";
            this.cbShowAllForRemainItems.Size = new System.Drawing.Size(74, 16);
            this.cbShowAllForRemainItems.TabIndex = 79;
            this.cbShowAllForRemainItems.Text = "Show All";
            this.cbShowAllForRemainItems.UseVisualStyleBackColor = true;
            this.cbShowAllForRemainItems.CheckedChanged += new System.EventHandler(this.cbShowAllForRemainItems_CheckedChanged);
            // 
            // cmStyleStatus
            // 
            this.cmStyleStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.outOfStockToolStripMenuItem,
            this.onSaleToolStripMenuItem});
            this.cmStyleStatus.Name = "cmStyleStatus";
            this.cmStyleStatus.Size = new System.Drawing.Size(142, 48);
            // 
            // outOfStockToolStripMenuItem
            // 
            this.outOfStockToolStripMenuItem.Name = "outOfStockToolStripMenuItem";
            this.outOfStockToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.outOfStockToolStripMenuItem.Text = "Out of stock";
            this.outOfStockToolStripMenuItem.Click += new System.EventHandler(this.outOfStockToolStripMenuItem_Click);
            // 
            // onSaleToolStripMenuItem
            // 
            this.onSaleToolStripMenuItem.Name = "onSaleToolStripMenuItem";
            this.onSaleToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.onSaleToolStripMenuItem.Text = "In Stock";
            this.onSaleToolStripMenuItem.Click += new System.EventHandler(this.onSaleToolStripMenuItem_Click);
            // 
            // BackorderManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 626);
            this.ControlBox = false;
            this.Controls.Add(this.cbShowAllForRemainItems);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dvOrderQtyByDate);
            this.Controls.Add(this.cbShowAll);
            this.Controls.Add(this.lbSeletedStyle);
            this.Controls.Add(this.cbStoreList);
            this.Controls.Add(this.btnSearchStyle);
            this.Controls.Add(this.txtSearchStyle);
            this.Controls.Add(this.dvRemainQuantityList);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.dvStyleList);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dvRemainItemList);
            this.Controls.Add(this.dvCustomerList);
            this.Controls.Add(this.label6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BackorderManage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "BackorderManage";
            ((System.ComponentModel.ISupportInitialize)(this.dvStyleList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvRemainItemList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvCustomerList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvRemainQuantityList)).EndInit();
            this.cmPacked.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvOrderQtyByDate)).EndInit();
            this.cmStyleStatus.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvStyleList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dvRemainItemList;
        private System.Windows.Forms.DataGridView dvCustomerList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.DataGridView dvRemainQuantityList;
        private System.Windows.Forms.ContextMenuStrip cmPacked;
        private System.Windows.Forms.ToolStripMenuItem packedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem didntPackToolStripMenuItem;
        private System.Windows.Forms.TextBox txtSearchStyle;
        private System.Windows.Forms.Button btnSearchStyle;
        private System.Windows.Forms.ComboBox cbStoreList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.Label lbSeletedStyle;
        private System.Windows.Forms.CheckBox cbShowAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridView dvOrderQtyByDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.ToolStripMenuItem canceledToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbShowAllForRemainItems;
        private System.Windows.Forms.ContextMenuStrip cmStyleStatus;
        private System.Windows.Forms.ToolStripMenuItem outOfStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onSaleToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column23;
        private System.Windows.Forms.DataGridViewImageColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;



    }
}