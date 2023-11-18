using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAn1_DongHo.Forms
{
    public partial class QLDonHang : Form
    {
        public QLDonHang()
        {
            InitializeComponent();
        }

        private void QLDonHang_Load(object sender, EventArgs e)
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
    }
}
