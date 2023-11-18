using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace QL_ShopDongHo.Forms
{
    public partial class QuanLyKhachHang : Form
    {
        public QuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            ShowKH();
        }
        private void ShowKH()
        {
            using (var db = new QuanLyShopDongHoEntities())
            {
                dgvKhachHang.Rows.Clear();
                db.KhachHangs.ToList().ForEach(x => dgvKhachHang.Rows.Add(x.TenKH, x.SDT, x.DiaChi));
            }
        }

        private bool checkForm()
        {
            using (var db = new QuanLyShopDongHoEntities())
            {
                string isNumber = @"^[-+]?[0-9]*.?[0-9]+$";
                Regex regex = new Regex(isNumber);
                var sdtTrung = db.KhachHangs.Select(x => x.SDT).FirstOrDefault();
                if (txtTenKhachHang.Text == "" || txtSDT.Text == "" || txtDiaChi.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (txtSDT.Text.Length > 10 || txtSDT.Text.Length < 10)
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại đủ 10 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (regex.IsMatch(txtSDT.Text) == false)
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                    return true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new QuanLyShopDongHoEntities())
                {
                    if (checkForm())
                    {
                        KhachHang kh = new KhachHang();
                        kh.TenKH = txtTenKhachHang.Text;
                        kh.SDT = txtSDT.Text;
                        kh.DiaChi = txtDiaChi.Text;
                        db.KhachHangs.Add(kh);
                        db.SaveChanges();
                    }
                }
                ShowKH();
            }
            catch (Exception)
            {

                MessageBox.Show("Số điện thoại đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            using (var db = new QuanLyShopDongHoEntities())
            {
                if (checkForm())
                {
                    var capNhat = db.KhachHangs.Where(x => x.SDT == txtSDT.Text).FirstOrDefault();
                    capNhat.TenKH = txtTenKhachHang.Text;
                    capNhat.DiaChi = txtDiaChi.Text;
                    db.SaveChanges();
                }
            }
            txtTenKhachHang.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtTenKhachTim.Text = "";
            ShowKH();
            btnThem.Enabled = true;
            txtSDT.ReadOnly = false;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new QuanLyShopDongHoEntities())
                {
                    var xoa = db.KhachHangs.Where(x => x.SDT == txtSDT.Text).FirstOrDefault();
                    db.KhachHangs.Remove(xoa);
                    db.SaveChanges();
                    txtTenKhachHang.Text = "";
                    txtSDT.Text = "";
                    txtDiaChi.Text = "";
                    txtTenKhachTim.Text = "";
                    ShowKH();
                    btnThem.Enabled = true;
                    txtSDT.ReadOnly = false;
                    btnCapNhat.Enabled = false;
                    btnXoa.Enabled = false;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Vui lòng chọn khách hàng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenKhachHang.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtTenKhachTim.Text = "";
            ShowKH();
            btnThem.Enabled = true;
            txtSDT.ReadOnly = false;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (var db = new QuanLyShopDongHoEntities())
            {
                var tim = db.KhachHangs.Select(x => x.TenKH);
                if (tim.Contains(txtTenKhachTim.Text))
                {
                    List<KhachHang> tenKH = db.KhachHangs.Where(x => x.TenKH.Contains(txtTenKhachTim.Text)).ToList();
                    dgvKhachHang.Rows.Clear();
                    tenKH.ForEach(x =>
                    {
                        dgvKhachHang.Rows.Add(x.TenKH, x.SDT, x.DiaChi);
                    });
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowKH();
                }
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (var db = new QuanLyShopDongHoEntities())
            {
                txtTenKhachHang.Text = dgvKhachHang.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtSDT.Text = dgvKhachHang.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.Rows[e.RowIndex].Cells[2].Value.ToString();
                btnThem.Enabled = false;
                txtSDT.ReadOnly = true;
                btnCapNhat.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle,
              Color.Silver, 3, ButtonBorderStyle.Solid,
              Color.Silver, 3, ButtonBorderStyle.Solid,
              Color.Silver, 3, ButtonBorderStyle.Solid,
              Color.Silver, 3, ButtonBorderStyle.Solid);
        }
    }
}
