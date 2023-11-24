using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace QuanLyShopDongHo.Forms
{
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string matKhauCu = MaHoaPass(txtMatKhauCu.Text);
            using (QuanLyShopDongHoEntities db = new QuanLyShopDongHoEntities())
            {
                var MaNV = db.NhanViens.Where(x => x.MaNV == txtTaiKhoan.Text && x.MatKhau == matKhauCu).Select(x => x.MaNV);
                var MKCu = db.NhanViens.Where(x => x.MaNV == txtTaiKhoan.Text && x.MatKhau == matKhauCu).Select(x => x.MatKhau);
                if (MaNV.Contains(txtTaiKhoan.Text) && MKCu.Contains(matKhauCu))
                {
                    if (txtMatKhauMoi.Text == txtMatKhauXacNhan.Text)
                    {
                        var MaCanDoi = db.NhanViens.Where(x => x.MaNV == txtTaiKhoan.Text).FirstOrDefault();
                        MaCanDoi.MatKhau = MaHoaPass(txtMatKhauMoi.Text);
                        db.SaveChanges();
                        MessageBox.Show("Mật khẩu đã đổi thành công của nhân viên có mã: " + txtTaiKhoan.Text, "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu xác nhận lại không đúng", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Mã nhân viên hoặc mật khẩu cũ không đúng", "Thông báo");
                }
            }
        }

        private string MaHoaPass(string chuoi)
        {
            using(MD5 mD5 = MD5.Create())
            {
                byte[] pass = Encoding.UTF8.GetBytes(chuoi);
                byte[] hash = mD5.ComputeHash(pass);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    builder.Append(hash[i].ToString("x2"));
                }
                return builder.ToString();
            }         
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }

        private void chkHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienMK.Checked)
            {
                txtMatKhauCu.UseSystemPasswordChar = false;
                txtMatKhauMoi.UseSystemPasswordChar = false;
                txtMatKhauXacNhan.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhauCu.UseSystemPasswordChar = true;
                txtMatKhauMoi.UseSystemPasswordChar = true;
                txtMatKhauXacNhan.UseSystemPasswordChar = true;
            }
        }
    }
}
