namespace BackorderManagement
{
    partial class StyleManage
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
            this.dvStyleList = new System.Windows.Forms.DataGridView();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbSearchType = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStyleNo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtColorName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVenderName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVenderCode = new System.Windows.Forms.TextBox();
            this.dvColorList = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvEstimateList = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddEstimateDate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbColorList = new System.Windows.Forms.ComboBox();
            this.dpEstimateDate = new System.Windows.Forms.DateTimePicker();
            this.cmEstimate = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deliveredToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbStoreList = new System.Windows.Forms.ComboBox();
            this.txtEstimateQuantity = new System.Windows.Forms.NumericUpDown();
            this.cbOnSale = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvStyleList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvColorList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvEstimateList)).BeginInit();
            this.cmEstimate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEstimateQuantity)).BeginInit();
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
            this.Column10});
            this.dvStyleList.Location = new System.Drawing.Point(7, 68);
            this.dvStyleList.MultiSelect = false;
            this.dvStyleList.Name = "dvStyleList";
            this.dvStyleList.RowHeadersVisible = false;
            this.dvStyleList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvStyleList.Size = new System.Drawing.Size(301, 551);
            this.dvStyleList.TabIndex = 69;
            this.dvStyleList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvStyleList_CellClick);
            this.dvStyleList.SelectionChanged += new System.EventHandler(this.dvStyleList_SelectionChanged);
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Style No.";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(314, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 221);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 70;
            this.pictureBox1.TabStop = false;
            // 
            // cbSearchType
            // 
            this.cbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchType.FormattingEnabled = true;
            this.cbSearchType.Items.AddRange(new object[] {
            "Style No",
            "Vender name",
            "Customer name"});
            this.cbSearchType.Location = new System.Drawing.Point(13, 34);
            this.cbSearchType.Name = "cbSearchType";
            this.cbSearchType.Size = new System.Drawing.Size(109, 20);
            this.cbSearchType.TabIndex = 71;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(129, 34);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(179, 21);
            this.txtSearch.TabIndex = 72;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(315, 33);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 73;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 74;
            this.label1.Text = "Style No";
            // 
            // txtStyleNo
            // 
            this.txtStyleNo.Location = new System.Drawing.Point(131, 22);
            this.txtStyleNo.Name = "txtStyleNo";
            this.txtStyleNo.ReadOnly = true;
            this.txtStyleNo.Size = new System.Drawing.Size(175, 21);
            this.txtStyleNo.TabIndex = 75;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbOnSale);
            this.groupBox1.Controls.Add(this.txtQuantity);
            this.groupBox1.Controls.Add(this.btnSaveChanges);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtColorName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCustomerName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtVenderName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtVenderCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtStyleNo);
            this.groupBox1.Location = new System.Drawing.Point(315, 304);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 315);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Style info";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(131, 201);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(175, 21);
            this.txtQuantity.TabIndex = 87;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(201, 268);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(105, 23);
            this.btnSaveChanges.TabIndex = 86;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 12);
            this.label8.TabIndex = 84;
            this.label8.Text = "Quantity";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 12);
            this.label7.TabIndex = 82;
            this.label7.Text = "Color Name";
            // 
            // txtColorName
            // 
            this.txtColorName.Location = new System.Drawing.Point(131, 167);
            this.txtColorName.Name = "txtColorName";
            this.txtColorName.ReadOnly = true;
            this.txtColorName.Size = new System.Drawing.Size(175, 21);
            this.txtColorName.TabIndex = 83;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 12);
            this.label6.TabIndex = 80;
            this.label6.Text = "Customer Name";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(131, 131);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(175, 21);
            this.txtCustomerName.TabIndex = 81;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 78;
            this.label3.Text = "Vender Name";
            // 
            // txtVenderName
            // 
            this.txtVenderName.Location = new System.Drawing.Point(131, 94);
            this.txtVenderName.Name = "txtVenderName";
            this.txtVenderName.Size = new System.Drawing.Size(175, 21);
            this.txtVenderName.TabIndex = 79;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 12);
            this.label2.TabIndex = 76;
            this.label2.Text = "Vender Code";
            // 
            // txtVenderCode
            // 
            this.txtVenderCode.Location = new System.Drawing.Point(131, 58);
            this.txtVenderCode.Name = "txtVenderCode";
            this.txtVenderCode.ReadOnly = true;
            this.txtVenderCode.Size = new System.Drawing.Size(175, 21);
            this.txtVenderCode.TabIndex = 77;
            // 
            // dvColorList
            // 
            this.dvColorList.AllowUserToAddRows = false;
            this.dvColorList.AllowUserToDeleteRows = false;
            this.dvColorList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvColorList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvColorList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.Column2,
            this.Column7});
            this.dvColorList.Location = new System.Drawing.Point(520, 68);
            this.dvColorList.MultiSelect = false;
            this.dvColorList.Name = "dvColorList";
            this.dvColorList.ReadOnly = true;
            this.dvColorList.RowHeadersVisible = false;
            this.dvColorList.RowTemplate.Height = 23;
            this.dvColorList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvColorList.Size = new System.Drawing.Size(626, 221);
            this.dvColorList.TabIndex = 77;
            this.dvColorList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvColorList_CellClick);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Customer Name";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Color";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Quantity";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Order number";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // dvEstimateList
            // 
            this.dvEstimateList.AllowUserToAddRows = false;
            this.dvEstimateList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvEstimateList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvEstimateList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column8,
            this.Column6});
            this.dvEstimateList.Location = new System.Drawing.Point(641, 352);
            this.dvEstimateList.Name = "dvEstimateList";
            this.dvEstimateList.ReadOnly = true;
            this.dvEstimateList.RowHeadersVisible = false;
            this.dvEstimateList.RowTemplate.Height = 23;
            this.dvEstimateList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvEstimateList.Size = new System.Drawing.Size(505, 267);
            this.dvEstimateList.TabIndex = 78;
            this.dvEstimateList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dvEstimateList_MouseClick);
            this.dvEstimateList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dvEstimateList_MouseDown);
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Color";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Estimate Date";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Quantity";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column6.HeaderText = "Delivered";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // btnAddEstimateDate
            // 
            this.btnAddEstimateDate.Location = new System.Drawing.Point(1069, 323);
            this.btnAddEstimateDate.Name = "btnAddEstimateDate";
            this.btnAddEstimateDate.Size = new System.Drawing.Size(75, 23);
            this.btnAddEstimateDate.TabIndex = 79;
            this.btnAddEstimateDate.Text = "Add Date";
            this.btnAddEstimateDate.UseVisualStyleBackColor = true;
            this.btnAddEstimateDate.Click += new System.EventHandler(this.btnAddEstimateDate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(518, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 80;
            this.label4.Text = "Color List";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(641, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 12);
            this.label5.TabIndex = 81;
            this.label5.Text = "Estimate Delivery Date";
            // 
            // cbColorList
            // 
            this.cbColorList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColorList.FormattingEnabled = true;
            this.cbColorList.Location = new System.Drawing.Point(643, 325);
            this.cbColorList.Name = "cbColorList";
            this.cbColorList.Size = new System.Drawing.Size(158, 20);
            this.cbColorList.TabIndex = 82;
            // 
            // dpEstimateDate
            // 
            this.dpEstimateDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpEstimateDate.Location = new System.Drawing.Point(807, 324);
            this.dpEstimateDate.Name = "dpEstimateDate";
            this.dpEstimateDate.Size = new System.Drawing.Size(181, 21);
            this.dpEstimateDate.TabIndex = 83;
            // 
            // cmEstimate
            // 
            this.cmEstimate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deliveredToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.cmEstimate.Name = "cmEstimate";
            this.cmEstimate.Size = new System.Drawing.Size(125, 48);
            // 
            // deliveredToolStripMenuItem
            // 
            this.deliveredToolStripMenuItem.Name = "deliveredToolStripMenuItem";
            this.deliveredToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.deliveredToolStripMenuItem.Text = "Delivered";
            this.deliveredToolStripMenuItem.Click += new System.EventHandler(this.deliveredToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // cbStoreList
            // 
            this.cbStoreList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStoreList.FormattingEnabled = true;
            this.cbStoreList.Items.AddRange(new object[] {
            "Styleholic",
            "American Chic",
            "Ray"});
            this.cbStoreList.Location = new System.Drawing.Point(397, 33);
            this.cbStoreList.Name = "cbStoreList";
            this.cbStoreList.Size = new System.Drawing.Size(121, 20);
            this.cbStoreList.TabIndex = 84;
            // 
            // txtEstimateQuantity
            // 
            this.txtEstimateQuantity.Location = new System.Drawing.Point(994, 324);
            this.txtEstimateQuantity.Name = "txtEstimateQuantity";
            this.txtEstimateQuantity.Size = new System.Drawing.Size(69, 21);
            this.txtEstimateQuantity.TabIndex = 88;
            // 
            // cbOnSale
            // 
            this.cbOnSale.AutoSize = true;
            this.cbOnSale.Location = new System.Drawing.Point(237, 238);
            this.cbOnSale.Name = "cbOnSale";
            this.cbOnSale.Size = new System.Drawing.Size(69, 16);
            this.cbOnSale.TabIndex = 88;
            this.cbOnSale.Text = "On Sale";
            this.cbOnSale.UseVisualStyleBackColor = true;
            // 
            // StyleManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 626);
            this.ControlBox = false;
            this.Controls.Add(this.txtEstimateQuantity);
            this.Controls.Add(this.cbStoreList);
            this.Controls.Add(this.dpEstimateDate);
            this.Controls.Add(this.cbColorList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddEstimateDate);
            this.Controls.Add(this.dvEstimateList);
            this.Controls.Add(this.dvColorList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbSearchType);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dvStyleList);
            this.Name = "StyleManage";
            this.Text = "StyleManage";
            ((System.ComponentModel.ISupportInitialize)(this.dvStyleList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvColorList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvEstimateList)).EndInit();
            this.cmEstimate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEstimateQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvStyleList;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbSearchType;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStyleNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtColorName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVenderName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVenderCode;
        private System.Windows.Forms.DataGridView dvColorList;
        private System.Windows.Forms.DataGridView dvEstimateList;
        private System.Windows.Forms.Button btnAddEstimateDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ComboBox cbColorList;
        private System.Windows.Forms.DateTimePicker dpEstimateDate;
        private System.Windows.Forms.NumericUpDown txtQuantity;
        private System.Windows.Forms.ContextMenuStrip cmEstimate;
        private System.Windows.Forms.ToolStripMenuItem deliveredToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.ComboBox cbStoreList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.NumericUpDown txtEstimateQuantity;
        private System.Windows.Forms.CheckBox cbOnSale;
    }
}