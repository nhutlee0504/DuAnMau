using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace QL_ShopDongHo.Forms
{
    public partial class QuanLyDonHang : Form
    {
        public QuanLyDonHang()
        {
            InitializeComponent();
        }

        private void QuanLyDonHang_Load(object sender, EventArgs e)
        {
            ShowDH();
            using (var db = new QuanLyShopDongHoEntities())
            {
                db.DonHangs.ToList().ForEach(x => cboMaDonTim.Items.Add(x.MaDon));
                db.KhachHangs.ToList().ForEach(x => cboSDT.Items.Add(x.SDT));
            }
            btnThanhToan.Enabled = false;
        }

        private void ShowDH()
        {
            using (var db = new QuanLyShopDongHoEntities())
            {
                dgvDonHang.Rows.Clear();
                db.DonHangs.ToList().ForEach(x => dgvDonHang.Rows.Add(x.MaDon, x.TenKH, x.SDT, x.LoaiSP, x.SoLuong, x.NgayIn, x.MaNV));
            }
        }

        private void btnTaoDon_Click_1(object sender, EventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (var db = new QuanLyShopDongHoEntities())
            {
                var tim = db.DonHangs.Select(x => x.MaDon);
                if (tim.Contains(cboMaDonTim.Text))
                {
                    List<DonHang> tenKH = db.DonHangs.Where(x => x.MaDon.Contains(cboMaDonTim.Text)).ToList();
                    dgvDonHang.Rows.Clear();
                    tenKH.ForEach(x =>
                    {
                        dgvDonHang.Rows.Add(x.MaDon, x.TenKH, x.SDT, x.LoaiSP, x.SoLuong, x.NgayIn, x.MaNV);
                    });
                    txtMaDon.Text = dgvDonHang.Rows[0].Cells[0].Value.ToString();
                    txtTenKhachHang.Text = dgvDonHang.Rows[0].Cells[1].Value.ToString();
                    cboSDT.Text = dgvDonHang.Rows[0].Cells[1].Value.ToString();
                    txtLoaiSanPham.Text = dgvDonHang.Rows[0].Cells[3].Value.ToString();
                    txtSoLuong.Text = dgvDonHang.Rows[0].Cells[4].Value.ToString();
                    dtpNgayIn.Text = dgvDonHang.Rows[0].Cells[5].Value.ToString();
                    txtMaNhanVien.Text = dgvDonHang.Rows[0].Cells[6].Value.ToString();
                    btnThanhToan.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowDH();
                }
            }
        }
    }
}
