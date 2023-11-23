
namespace QuanLyShopDongHo.Forms
{
    partial class QuanLySanPham
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnthemhinh = new System.Windows.Forms.Button();
            this.txtma = new System.Windows.Forms.TextBox();
            this.btnlammoi = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btncapnhat = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txtgianhap = new System.Windows.Forms.TextBox();
            this.txtsoluong = new System.Windows.Forms.TextBox();
            this.txttim = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btntim = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txttensp = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtngaynhap = new System.Windows.Forms.TextBox();
            this.manv = new System.Windows.Forms.Label();
            this.vaitro = new System.Windows.Forms.Label();
            this.tennv = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSanPham,
            this.TenSanPham,
            this.SoLuong,
            this.GiaNhap,
            this.NgayNhap,
            this.MoTa});
            this.dataGridView1.Location = new System.Drawing.Point(34, 448);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(747, 234);
            this.dataGridView1.TabIndex = 67;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellClick_dgv);
            // 
            // MaSanPham
            // 
            this.MaSanPham.HeaderText = "Mã sản phẩm";
            this.MaSanPham.MinimumWidth = 8;
            this.MaSanPham.Name = "MaSanPham";
            this.MaSanPham.Width = 150;
            // 
            // TenSanPham
            // 
            this.TenSanPham.HeaderText = "Tên sản phẩm";
            this.TenSanPham.MinimumWidth = 8;
            this.TenSanPham.Name = "TenSanPham";
            this.TenSanPham.Width = 150;
            // 
            // SoLuong
            // 
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.MinimumWidth = 8;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Width = 150;
            // 
            // GiaNhap
            // 
            this.GiaNhap.HeaderText = "Giá nhập";
            this.GiaNhap.MinimumWidth = 8;
            this.GiaNhap.Name = "GiaNhap";
            this.GiaNhap.Width = 150;
            // 
            // NgayNhap
            // 
            this.NgayNhap.HeaderText = "Ngày nhập";
            this.NgayNhap.MinimumWidth = 8;
            this.NgayNhap.Name = "NgayNhap";
            this.NgayNhap.Width = 150;
            // 
            // MoTa
            // 
            this.MoTa.HeaderText = "Mô tả";
            this.MoTa.MinimumWidth = 8;
            this.MoTa.Name = "MoTa";
            this.MoTa.Width = 150;
            // 
            // btnthemhinh
            // 
            this.btnthemhinh.BackColor = System.Drawing.Color.LightBlue;
            this.btnthemhinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnthemhinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnthemhinh.Location = new System.Drawing.Point(801, 260);
            this.btnthemhinh.Name = "btnthemhinh";
            this.btnthemhinh.Size = new System.Drawing.Size(127, 46);
            this.btnthemhinh.TabIndex = 66;
            this.btnthemhinh.Text = "Thêm hình ảnh";
            this.btnthemhinh.UseVisualStyleBackColor = false;
            this.btnthemhinh.Click += new System.EventHandler(this.btnthemhinh_Click);
            // 
            // txtma
            // 
            this.txtma.Enabled = false;
            this.txtma.Location = new System.Drawing.Point(198, 195);
            this.txtma.Name = "txtma";
            this.txtma.Size = new System.Drawing.Size(196, 26);
            this.txtma.TabIndex = 63;
            // 
            // btnlammoi
            // 
            this.btnlammoi.BackColor = System.Drawing.Color.LightBlue;
            this.btnlammoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlammoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnlammoi.Location = new System.Drawing.Point(801, 636);
            this.btnlammoi.Name = "btnlammoi";
            this.btnlammoi.Size = new System.Drawing.Size(127, 46);
            this.btnlammoi.TabIndex = 62;
            this.btnlammoi.Text = "Làm mới";
            this.btnlammoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnlammoi.UseVisualStyleBackColor = false;
            this.btnlammoi.Click += new System.EventHandler(this.btnlammoi_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.BackColor = System.Drawing.Color.LightBlue;
            this.btnxoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnxoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnxoa.Location = new System.Drawing.Point(801, 574);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(127, 46);
            this.btnxoa.TabIndex = 61;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnxoa.UseVisualStyleBackColor = false;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btncapnhat
            // 
            this.btncapnhat.BackColor = System.Drawing.Color.LightBlue;
            this.btncapnhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncapnhat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncapnhat.Location = new System.Drawing.Point(801, 511);
            this.btncapnhat.Name = "btncapnhat";
            this.btncapnhat.Size = new System.Drawing.Size(127, 46);
            this.btncapnhat.TabIndex = 60;
            this.btncapnhat.Text = "Cập nhật ";
            this.btncapnhat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btncapnhat.UseVisualStyleBackColor = false;
            this.btncapnhat.Click += new System.EventHandler(this.btncapnhat_Click);
            // 
            // btnthem
            // 
            this.btnthem.BackColor = System.Drawing.Color.LightBlue;
            this.btnthem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnthem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnthem.Location = new System.Drawing.Point(801, 448);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(127, 46);
            this.btnthem.TabIndex = 59;
            this.btnthem.Text = "Thêm";
            this.btnthem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnthem.UseVisualStyleBackColor = false;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.BackColor = System.Drawing.Color.LightBlue;
            this.btnthoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnthoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnthoat.Location = new System.Drawing.Point(801, 17);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(127, 46);
            this.btnthoat.TabIndex = 58;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnthoat.UseVisualStyleBackColor = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(576, 326);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(205, 103);
            this.richTextBox1.TabIndex = 57;
            this.richTextBox1.Text = "";
            // 
            // txtgianhap
            // 
            this.txtgianhap.Location = new System.Drawing.Point(576, 261);
            this.txtgianhap.Name = "txtgianhap";
            this.txtgianhap.Size = new System.Drawing.Size(205, 26);
            this.txtgianhap.TabIndex = 49;
            // 
            // txtsoluong
            // 
            this.txtsoluong.Location = new System.Drawing.Point(198, 260);
            this.txtsoluong.Name = "txtsoluong";
            this.txtsoluong.Size = new System.Drawing.Size(196, 26);
            this.txtsoluong.TabIndex = 55;
            // 
            // txttim
            // 
            this.txttim.Location = new System.Drawing.Point(204, 30);
            this.txttim.Name = "txttim";
            this.txttim.Size = new System.Drawing.Size(257, 26);
            this.txttim.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btntim);
            this.panel1.Controls.Add(this.txttim);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(34, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 78);
            this.panel1.TabIndex = 54;
            // 
            // btntim
            // 
            this.btntim.BackColor = System.Drawing.Color.LightBlue;
            this.btntim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntim.Location = new System.Drawing.Point(501, 20);
            this.btntim.Name = "btntim";
            this.btntim.Size = new System.Drawing.Size(114, 46);
            this.btntim.TabIndex = 15;
            this.btntim.Text = "Tìm kiếm";
            this.btntim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btntim.UseVisualStyleBackColor = false;
            this.btntim.Click += new System.EventHandler(this.btntim_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(16, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tìm sản phẩm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(50, 325);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 25);
            this.label8.TabIndex = 53;
            this.label8.Text = "Ngày nhập:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(50, 261);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 25);
            this.label7.TabIndex = 52;
            this.label7.Text = "Số lượng:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(434, 326);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 25);
            this.label6.TabIndex = 51;
            this.label6.Text = "Mô tả";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(434, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 25);
            this.label5.TabIndex = 50;
            this.label5.Text = "Giá nhập:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(434, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 25);
            this.label4.TabIndex = 48;
            this.label4.Text = "Tên sản phẩm:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(50, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 25);
            this.label3.TabIndex = 47;
            this.label3.Text = "Mã sản phẩm:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(24, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(430, 58);
            this.label1.TabIndex = 46;
            this.label1.Text = "Quản lý sản phẩm";
            // 
            // txttensp
            // 
            this.txttensp.Location = new System.Drawing.Point(576, 191);
            this.txttensp.Name = "txttensp";
            this.txttensp.Size = new System.Drawing.Size(205, 26);
            this.txttensp.TabIndex = 56;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(801, 97);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 135);
            this.pictureBox1.TabIndex = 65;
            this.pictureBox1.TabStop = false;
            // 
            // txtngaynhap
            // 
            this.txtngaynhap.Location = new System.Drawing.Point(198, 325);
            this.txtngaynhap.Name = "txtngaynhap";
            this.txtngaynhap.Size = new System.Drawing.Size(196, 26);
            this.txtngaynhap.TabIndex = 68;
            // 
            // manv
            // 
            this.manv.AutoSize = true;
            this.manv.Location = new System.Drawing.Point(655, 30);
            this.manv.Name = "manv";
            this.manv.Size = new System.Drawing.Size(60, 20);
            this.manv.TabIndex = 71;
            this.manv.Text = "label11";
            // 
            // vaitro
            // 
            this.vaitro.AutoSize = true;
            this.vaitro.Location = new System.Drawing.Point(559, 30);
            this.vaitro.Name = "vaitro";
            this.vaitro.Size = new System.Drawing.Size(60, 20);
            this.vaitro.TabIndex = 70;
            this.vaitro.Text = "label10";
            // 
            // tennv
            // 
            this.tennv.AutoSize = true;
            this.tennv.Location = new System.Drawing.Point(460, 30);
            this.tennv.Name = "tennv";
            this.tennv.Size = new System.Drawing.Size(51, 20);
            this.tennv.TabIndex = 69;
            this.tennv.Text = "label9";
            // 
            // QuanLySanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 724);
            this.Controls.Add(this.manv);
            this.Controls.Add(this.vaitro);
            this.Controls.Add(this.tennv);
            this.Controls.Add(this.txtngaynhap);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnthemhinh);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtma);
            this.Controls.Add(this.btnlammoi);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btncapnhat);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.txtgianhap);
            this.Controls.Add(this.txtsoluong);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txttensp);
            this.Name = "QuanLySanPham";
            this.Text = "QuanLySanPham";
            this.Load += new System.EventHandler(this.QuanLySanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnthemhinh;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtma;
        private System.Windows.Forms.Button btnlammoi;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btncapnhat;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox txtgianhap;
        private System.Windows.Forms.TextBox txtsoluong;
        private System.Windows.Forms.TextBox txttim;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btntim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txttensp;
        private System.Windows.Forms.TextBox txtngaynhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoTa;
        private System.Windows.Forms.Label manv;
        private System.Windows.Forms.Label vaitro;
        private System.Windows.Forms.Label tennv;
    }
}