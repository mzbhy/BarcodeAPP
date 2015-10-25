namespace BarcodeApp
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBoxPortSelect = new System.Windows.Forms.ComboBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnTx = new System.Windows.Forms.Button();
            this.textBoxRx = new System.Windows.Forms.TextBox();
            this.mycomm = new System.IO.Ports.SerialPort(this.components);
            this.lblToolStripStatus = new System.Windows.Forms.Label();
            this.textBoxTx = new System.Windows.Forms.TextBox();
            this.radioBtnHEX = new System.Windows.Forms.RadioButton();
            this.radioBtnString = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxBaudSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxPortSelect
            // 
            this.comboBoxPortSelect.FormattingEnabled = true;
            this.comboBoxPortSelect.Location = new System.Drawing.Point(82, 40);
            this.comboBoxPortSelect.Name = "comboBoxPortSelect";
            this.comboBoxPortSelect.Size = new System.Drawing.Size(121, 20);
            this.comboBoxPortSelect.TabIndex = 0;
            this.comboBoxPortSelect.SelectedIndexChanged += new System.EventHandler(this.comboBoxPortSelect_SelectedIndexChanged);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(82, 119);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "打开串口";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnTx
            // 
            this.btnTx.Location = new System.Drawing.Point(82, 310);
            this.btnTx.Name = "btnTx";
            this.btnTx.Size = new System.Drawing.Size(75, 23);
            this.btnTx.TabIndex = 2;
            this.btnTx.Text = "发送";
            this.btnTx.UseVisualStyleBackColor = true;
            this.btnTx.Click += new System.EventHandler(this.btnTx_Click);
            // 
            // textBoxRx
            // 
            this.textBoxRx.Location = new System.Drawing.Point(242, 87);
            this.textBoxRx.Multiline = true;
            this.textBoxRx.Name = "textBoxRx";
            this.textBoxRx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRx.Size = new System.Drawing.Size(239, 246);
            this.textBoxRx.TabIndex = 3;
            // 
            // lblToolStripStatus
            // 
            this.lblToolStripStatus.AutoSize = true;
            this.lblToolStripStatus.Location = new System.Drawing.Point(12, 365);
            this.lblToolStripStatus.Name = "lblToolStripStatus";
            this.lblToolStripStatus.Size = new System.Drawing.Size(53, 12);
            this.lblToolStripStatus.TabIndex = 4;
            this.lblToolStripStatus.Text = "当前状态";
            // 
            // textBoxTx
            // 
            this.textBoxTx.Location = new System.Drawing.Point(37, 158);
            this.textBoxTx.Multiline = true;
            this.textBoxTx.Name = "textBoxTx";
            this.textBoxTx.Size = new System.Drawing.Size(166, 142);
            this.textBoxTx.TabIndex = 5;
            // 
            // radioBtnHEX
            // 
            this.radioBtnHEX.AutoSize = true;
            this.radioBtnHEX.Location = new System.Drawing.Point(113, 14);
            this.radioBtnHEX.Name = "radioBtnHEX";
            this.radioBtnHEX.Size = new System.Drawing.Size(53, 16);
            this.radioBtnHEX.TabIndex = 6;
            this.radioBtnHEX.Text = "HEX码";
            this.radioBtnHEX.UseVisualStyleBackColor = true;
            // 
            // radioBtnString
            // 
            this.radioBtnString.AutoSize = true;
            this.radioBtnString.Checked = true;
            this.radioBtnString.Location = new System.Drawing.Point(16, 14);
            this.radioBtnString.Name = "radioBtnString";
            this.radioBtnString.Size = new System.Drawing.Size(59, 16);
            this.radioBtnString.TabIndex = 7;
            this.radioBtnString.TabStop = true;
            this.radioBtnString.Text = "字符串";
            this.radioBtnString.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioBtnHEX);
            this.panel1.Controls.Add(this.radioBtnString);
            this.panel1.Location = new System.Drawing.Point(257, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 41);
            this.panel1.TabIndex = 8;
            // 
            // comboBoxBaudSelect
            // 
            this.comboBoxBaudSelect.FormattingEnabled = true;
            this.comboBoxBaudSelect.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "56000",
            "57600",
            "115200",
            "128000",
            "256000"});
            this.comboBoxBaudSelect.Location = new System.Drawing.Point(82, 78);
            this.comboBoxBaudSelect.Name = "comboBoxBaudSelect";
            this.comboBoxBaudSelect.Size = new System.Drawing.Size(121, 20);
            this.comboBoxBaudSelect.TabIndex = 9;
            this.comboBoxBaudSelect.SelectedIndexChanged += new System.EventHandler(this.comboBoxBaudSelect_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "串口号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "波特率";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemName,
            this.ItemISBN,
            this.ItemPrice});
            this.dataGridView1.Location = new System.Drawing.Point(140, 354);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(349, 109);
            this.dataGridView1.TabIndex = 12;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "名称";
            this.ItemName.Name = "ItemName";
            // 
            // ItemISBN
            // 
            this.ItemISBN.HeaderText = "ISBN";
            this.ItemISBN.Name = "ItemISBN";
            // 
            // ItemPrice
            // 
            this.ItemPrice.HeaderText = "价格";
            this.ItemPrice.Name = "ItemPrice";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 394);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "总价";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(14, 419);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(100, 21);
            this.textBoxPrice.TabIndex = 14;
            this.textBoxPrice.Text = "0.0";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(49, 389);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 475);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxBaudSelect);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxTx);
            this.Controls.Add(this.lblToolStripStatus);
            this.Controls.Add(this.textBoxRx);
            this.Controls.Add(this.btnTx);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.comboBoxPortSelect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPortSelect;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnTx;
        private System.Windows.Forms.TextBox textBoxRx;
        private System.IO.Ports.SerialPort mycomm;
        private System.Windows.Forms.Label lblToolStripStatus;
        private System.Windows.Forms.TextBox textBoxTx;
        private System.Windows.Forms.RadioButton radioBtnHEX;
        private System.Windows.Forms.RadioButton radioBtnString;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxBaudSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemISBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemPrice;
        private System.Windows.Forms.Button btnClear;
    }
}

