using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_ShopDongHo.Forms
{

    public partial class QuanLyLoaiSanPham : Form
    {

        public QuanLyLoaiSanPham()
        {
            InitializeComponent();
        }

        private void QuanLyLoaiSanPham_Load(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            btncapnhat.Enabled = false;
            btnxoa.Enabled = false;
            using (QuanLyShopDongHoEntities db = new QuanLyShopDongHoEntities())
            {
                cbbmasp.Items.Clear();
                db.SanPhams.ToList().ForEach(row => cbbmasp.Items.Add(row.MaSanPham));

            }

            upDateDGV();
        }
        private void upDateDGV()
        {
            using (QuanLyShopDongHoEntities db = new QuanLyShopDongHoEntities())
            {
                dataGridView1.Rows.Clear();
                db.LoaiSanPhams.ToList().ForEach(lsp =>
                {
                    dataGridView1.Rows.Add(
                        lsp.LoaiSP,
                        lsp.TenLoai,
                        lsp.MaSP,
                        lsp.GiaBan,
                        lsp.KhuyenMai,
                        lsp.MoTa
                        );

                });
            }
        }
        private void rong()
        {
            txtloaisp.Text = "";
            txttenloai.Text = "";
            txtgiaban.Text = "";
            cbbmasp.Text = "";
            txtkhuyenmai.Text = "";
            richTextBox1.Text = "";
            btnthem.Enabled = true;
            btncapnhat.Enabled = false;
            btnxoa.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            using (QuanLyShopDongHoEntities db = new QuanLyShopDongHoEntities())
            {
                LoaiSanPham xoa = db.LoaiSanPhams.Where(x => x.LoaiSP == txtloaisp.Text)
                    .FirstOrDefault();
                db.LoaiSanPhams.Remove(xoa);
                db.SaveChanges();
            }
            rong();
            upDateDGV();
            btnthem.Enabled = true;
            btncapnhat.Enabled = false;
            btnxoa.Enabled = false;
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            rong();
            btnthem.Enabled = true;
            btncapnhat.Enabled = false;
            btnxoa.Enabled = false;
        }
        private bool Checkk()
        {
            if (txtloaisp.Text == "" || txttenloai.Text == "" || txtgiaban.Text == "" || txtkhuyenmai.Text == "" || cbbmasp.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return false;
            }
            if (txtloaisp.Text.Length > 8)
            {
                MessageBox.Show("Loại sản phẩm không quá 8 ký tự.");
                return false;
            }

            return true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (Checkk())
            {
                try
                {

                    LoaiSanPham them = new LoaiSanPham();
                    them.LoaiSP = txtloaisp.Text;
                    them.TenLoai = txttenloai.Text;
                    them.GiaBan = float.Parse(txtgiaban.Text);
                    them.MoTa = richTextBox1.Text;
                    using (QuanLyShopDongHoEntities db = new QuanLyShopDongHoEntities())
                    {
                        //LoaiSanPham kmduocchon = db.LoaiSanPhams
                        //    .Where(x => x.LoaiSP == cbbkhuyenmai.SelectedItem.ToString()).FirstOrDefault();
                        //SanPham spduocchon = db.SanPhams
                        //    .Where(x => x. == cbbmasp.SelectedItem.ToString()).FirstOrDefault();
                        //them.KhuyenMai = kmduocchon.KhuyenMai;
                        //them.MaSP = spduocchon.MaSanPham;
                        //db.LoaiSanPhams.Add(them);
                        //db.SaveChanges();
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
    }

}

