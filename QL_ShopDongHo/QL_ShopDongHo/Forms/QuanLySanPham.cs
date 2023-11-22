﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_ShopDongHo.Forms
{
    public partial class QuanLySanPham : Form
    {
        public QuanLySanPham()
        {
            InitializeComponent();
        }

        private void QuanLySanPham_Load(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            btncapnhat.Enabled = false;
            btnxoa.Enabled = false;
            upDateDGV();
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            rong();
        }

        private void upDateDGV()
        {
            using (QuanLyShopDongHoEntities db = new QuanLyShopDongHoEntities())
            {
                dataGridView1.Rows.Clear();
                db.SanPhams.ToList().ForEach(kh =>
                {
                    dataGridView1.Rows.Add(
                        kh.MaSanPham,
                        //kh.HinhAnh,
                        kh.TenSanPham,
                        kh.SoLuong,
                        kh.GiaNhap,
                        kh.NgayNhap.ToString().Split(' ')[0],
                        kh.Mota
                        );

                });
            }
        }

        private void btnthemhinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog filelog = new OpenFileDialog();
            DialogResult result = filelog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = filelog.FileName;
                pictureBox1.Image = Image.FromFile(file);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Tag = file;

            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (checkk())
            {
                try
                {
                    string file = pictureBox1.Tag.ToString();
                    SanPham them = new SanPham();
                    them.TenSanPham = txttensp.Text;
                    them.SoLuong = int.Parse(txtsoluong.Text);
                    them.GiaNhap = float.Parse(txtgianhap.Text);
                    them.Mota = richTextBox1.Text;
                    them.HinhAnh = file;
                    pictureBox1.Tag = file;
                    them.NgayNhap = DateTime.ParseExact(txtngaynhap.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    using (QuanLyShopDongHoEntities db = new QuanLyShopDongHoEntities())
                    {
                        db.SanPhams.Add(them);
                        db.SaveChanges();
                    }
                    rong();
                    upDateDGV();
                }
                catch (Exception)
                {
                    MessageBox.Show("Dữ liệu không hợp lệ.");
                    return;
                }
            }
        }
        private void rong()
        {
            txtma.Text = "";
            txttensp.Text = "";
            txttim.Text = "";
            txtsoluong.Text = "";
            txtgianhap.Text = "";
            txtngaynhap.Text = "";
            richTextBox1.Text = "";
            pictureBox1.Image = null;
            btnthem.Enabled = true;
            btncapnhat.Enabled = false;
            btnxoa.Enabled = false;
        }

        private bool checkk()
        {
            if (txttensp.Text == "" ||
                txtsoluong.Text == "" || txtgianhap.Text == "" || pictureBox1.Tag == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return false;
            }
            string file = pictureBox1.Tag.ToString();
            if (file.Equals(""))
            {
                MessageBox.Show("Thiếu hình ảnh");
                return false;
            }


            //if (txtma.Text.Length > 8)
            //{
            //    MessageBox.Show("Mã sản phẩm không được quá 8 ký tự.");
            //    return false;
            //}

            int number;
            //if (int.TryParse(txtthoiluong.Text, out number))
            //{
            //    if (number < 0)
            //    {
            //        MessageBox.Show("Thời lượng học phải là số nguyên dương");
            //        return false;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng nhập số nguyên dương.");
            //    return false;
            //}
            if (int.TryParse(txtsoluong.Text, out number))
            {
                if (number < 0)
                {
                    MessageBox.Show("Vui lòng nhập số nguyên dương.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số nguyên dương.");
                return false;
            }
            return true;
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            if (checkk())
            {
                try
                {                                 
                    using (QuanLyShopDongHoEntities db = new QuanLyShopDongHoEntities())
                    {
                        SanPham sua = db.SanPhams.Where(x => x.MaSanPham.ToString() == txtma.Text)
                            .FirstOrDefault();
                        string file = pictureBox1.Tag.ToString();
                        sua.TenSanPham = txttensp.Text;
                        sua.SoLuong = int.Parse(txtsoluong.Text);
                        sua.GiaNhap = float.Parse(txtgianhap.Text);
                        sua.NgayNhap = DateTime.ParseExact(txtngaynhap.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); 
                        sua.Mota = richTextBox1.Text;
                        sua.HinhAnh = file;
                        pictureBox1.Tag = file;
                        db.SaveChanges();
                    }
                    rong();
                    upDateDGV();
                }
                catch (Exception)
                {
                    MessageBox.Show("Dữ liệu không hợp lệ.");
                    return;
                }
            }
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            using (QuanLyShopDongHoEntities db = new QuanLyShopDongHoEntities())
            {
                List<SanPham> list = db.SanPhams
                    .Where(x => x.MaSanPham.ToString() == txttim.Text)
                    .ToList();//sắp xếp ở đây

                if (!list.Any())
                {
                    MessageBox.Show("Không tìm thấy");
                }
                else
                {
                    list.ForEach(nh =>
                    {
                        txtma.Text = nh.MaSanPham.ToString();
                        txttensp.Text = nh.TenSanPham;
                        txtsoluong.Text = nh.SoLuong.ToString();
                        txtgianhap.Text = nh.GiaNhap.ToString();
                        txtngaynhap.Text = nh.NgayNhap.ToString().Split(' ')[0];
                        string file = nh.HinhAnh.ToString();
                        pictureBox1.Image = Image.FromFile(@"" + file);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.Tag = file;
                        richTextBox1.Text = nh.Mota;
                    });
                    btncapnhat.Enabled = true;
                    btnthem.Enabled = false;
                    btnxoa.Enabled = true;
                    //txttimchuyende.Text = "";
                    //if (lblvaitro.Text == "Admin")
                    //{
                    //    btnthem.Enabled = false;
                    //    txtmachuyende.Enabled = false;
                    //    btncapnhat.Enabled = true;
                    //    btnxoa.Enabled = true;
                    //}
                    //else if (lblvaitro.Text == "Nhân Viên")
                    //{
                    //    btnthem.Enabled = false;
                    //    txtmachuyende.Enabled = false;
                    //    btncapnhat.Enabled = true;
                    //    btnxoa.Enabled = false;
                    //}
                }

            }

        }

        private void CellClick_dgv(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.SelectedCells[0].RowIndex;
            var rowData = dataGridView1.Rows[row];
            String manh = rowData.Cells[0].Value.ToString();
            using (QuanLyShopDongHoEntities db = new QuanLyShopDongHoEntities())
            {
                SanPham kh = db.SanPhams.Where(x => x.MaSanPham.ToString() == manh).FirstOrDefault();
                txtma.Text = kh.MaSanPham.ToString();
                txttensp.Text = kh.TenSanPham;
                txtsoluong.Text = kh.SoLuong.ToString();
                txtgianhap.Text = kh.GiaNhap.ToString();
                txtngaynhap.Text = kh.NgayNhap.ToString().Split(' ')[0];
                string file = kh.HinhAnh.ToString();
                pictureBox1.Image = Image.FromFile(@"" + file);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Tag = file;
                richTextBox1.Text = kh.Mota;
            }
            btncapnhat.Enabled = true;
            btnthem.Enabled = false;
            btnxoa.Enabled = true;


        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            using (QuanLyShopDongHoEntities db = new QuanLyShopDongHoEntities())
            {
                SanPham xoa = db.SanPhams.Where(x => x.MaSanPham.ToString() == txtma.Text)
                    .FirstOrDefault();
                db.SanPhams.Remove(xoa);
                db.SaveChanges();
            }
            rong();
            upDateDGV();

        }
    }
}
