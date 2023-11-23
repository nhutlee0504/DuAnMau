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
using System.Data.SqlClient;

namespace QuanLyShopDongHo.Forms
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
                db.ChiTietSanPhams.ToList().ForEach(x => cboLoaiSP.Items.Add(x.LoaiSP));
            }
            dtpNgayIn.Text = DateTime.Now.ToString("dd/MM/yyyy");
            btnThanhToan.Enabled = false;
        }

        private void ShowDH()
        {
            using (var db = new QuanLyShopDongHoEntities())
            {
                dgvDonHang.Rows.Clear();
                db.DonHangs.ToList().ForEach(x => dgvDonHang.Rows.Add(x.MaDon, x.TenKH, x.SDT, x.LoaiSP, x.ChiTietSanPham.TenLoai, x.SoLuong, x.NgayIn, x.MaNV));
            }
        }

        private void btnTaoDon_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new QuanLyShopDongHoEntities())
                {
                    DonHang dh = new DonHang();
                    dh.MaDon = taoMaDH();
                    dh.TenKH = db.KhachHangs.Where(x => x.SDT == cboSDT.Text).Select(x => x.TenKH).FirstOrDefault();
                    dh.SDT = cboSDT.Text;
                    dh.LoaiSP = cboLoaiSP.Text;
                    dh.SoLuong = int.Parse(txtSoLuong.Text);
                    dh.NgayIn = dtpNgayIn.Value;
                    dh.MaNV = txtMaNhanVien.Text;

                    string isNumber = @"^[-+]?[0-9]*.?[0-9]+$";
                    Regex regex = new Regex(isNumber);
                    var maDHTrung = db.DonHangs.Select(x => x.MaDon);
                    var maNV = db.NhanViens.Select(x => x.MaNV);
                    var SDT = db.KhachHangs.Select(x => x.SDT);
                    var loaiSP = db.ChiTietSanPhams.Select(x => x.LoaiSP);
                    if (cboSDT.Text == "" || cboLoaiSP.Text == "" || txtSoLuong.Text == "" || txtMaNhanVien.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaDon.Focus();
                    }
                    else if (maDHTrung.Contains(txtMaDon.Text))
                    {
                        MessageBox.Show("Mã đơn hàng đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaDon.Focus();
                    }
                    else if (cboSDT.Text.Length > 10 || cboSDT.Text.Length < 10)
                    {
                        MessageBox.Show("Vui lòng nhập số điện thoại đủ 10 số nguyên dương", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cboSDT.Focus();
                    }
                    else if (SDT.Contains(cboSDT.Text) == false)
                    {
                        MessageBox.Show("Số điện thoại không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cboSDT.Focus();
                    }
                    else if (regex.IsMatch(cboSDT.Text) == false)
                    {
                        MessageBox.Show("Vui lòng nhập số điện thoại là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cboSDT.Focus();
                    }
                    else if (int.Parse(txtSoLuong.Text) <= 0)
                    {
                        MessageBox.Show("Vui lòng nhập số lượng lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cboSDT.Focus();
                    }
                    else if (maNV.Contains(txtMaNhanVien.Text) == false)
                    {
                        MessageBox.Show("Mã nhân viên không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cboSDT.Focus();
                    }
                    else if (loaiSP.Contains(cboLoaiSP.Text) == false)
                    {
                        MessageBox.Show("Mã loại sản phẩm không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cboLoaiSP.Focus();
                    }
                    else
                    {
                        db.DonHangs.Add(dh);
                        db.SaveChanges();
                        ShowDH();
                        Rong();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập số lượng là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            using (var db = new QuanLyShopDongHoEntities())
            {
                txtMaDon.Text = "";
                txtTenKhachHang.Text = "";
                cboSDT.Text = "";
                cboLoaiSP.Text = "";
                txtTenLoai.Text = "";
                txtSoLuong.Text = "";
                txtMaNhanVien.Text = "";
                dtpNgayIn.Text = DateTime.Now.ToString("dd/MM/yyyy");
                cboMaDonTim.Text = "";
                btnThanhToan.Enabled = false;
                btnTaoDon.Enabled = true;
                ShowDH();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (var db = new QuanLyShopDongHoEntities())
            {
                List<DonHang> maDon = db.DonHangs.Where(x => x.MaDon.Contains(cboMaDonTim.Text)).ToList();
                if (maDon.Count > 0)
                {
                    dgvDonHang.Rows.Clear();
                    maDon.ForEach(x =>
                    {
                        dgvDonHang.Rows.Add(x.MaDon, x.TenKH, x.SDT, x.LoaiSP, x.ChiTietSanPham.TenLoai,x.SoLuong, x.NgayIn, x.MaNV);
                    });
                    txtMaDon.Text = dgvDonHang.Rows[0].Cells[0].Value.ToString();
                    txtTenKhachHang.Text = dgvDonHang.Rows[0].Cells[1].Value.ToString();
                    cboSDT.Text = dgvDonHang.Rows[0].Cells[2].Value.ToString();
                    cboLoaiSP.Text = dgvDonHang.Rows[0].Cells[3].Value.ToString();
                    txtSoLuong.Text = dgvDonHang.Rows[0].Cells[5].Value.ToString();
                    dtpNgayIn.Text = dgvDonHang.Rows[0].Cells[6].Value.ToString();
                    txtMaNhanVien.Text = dgvDonHang.Rows[0].Cells[7].Value.ToString();
                    btnTaoDon.Enabled = false;
                    btnThanhToan.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowDH();
                    btnTaoDon.Enabled = true;
                    btnThanhToan.Enabled = false;
                    Rong();
                }
            }
        }

        private string taoMaDH()
        {
            SqlConnection conn = new SqlConnection(@"server = .; database = QuanLyShopDongHo; integrated security = true");
            string query = "select * from DonHang";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            string ma = "";
            if (table.Rows.Count <= 0)
            {
                ma = "DH01";
            }
            else
            {
                int index;
                ma = "DH";
                index = int.Parse(table.Rows[table.Rows.Count - 1][0].ToString().Substring(2, 2));
                index += 1;
                if (index < 10)
                {
                    ma += "0";
                }
                ma += index.ToString();
            }
            return ma;
        }

        private void dgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtMaDon.Text = dgvDonHang.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenKhachHang.Text = dgvDonHang.Rows[e.RowIndex].Cells[1].Value.ToString();
            cboSDT.Text = dgvDonHang.Rows[e.RowIndex].Cells[2].Value.ToString();
            cboLoaiSP.Text = dgvDonHang.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtTenLoai.Text = dgvDonHang.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSoLuong.Text = dgvDonHang.Rows[e.RowIndex].Cells[5].Value.ToString();
            dtpNgayIn.Text = dgvDonHang.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtMaNhanVien.Text = dgvDonHang.Rows[e.RowIndex].Cells[7].Value.ToString();
            btnTaoDon.Enabled = false;
            btnThanhToan.Enabled = true;
        }

        private void Rong()
        {
            txtMaDon.Text = "";
            txtTenKhachHang.Text = "";
            cboSDT.Text = "";
            cboLoaiSP.Text = "";
            txtTenLoai.Text = "";
            txtSoLuong.Text = "";
            txtMaNhanVien.Text = "";
            dtpNgayIn.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cboMaDonTim.Text = "";
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
