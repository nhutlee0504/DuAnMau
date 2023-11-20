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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(txtMaNV.Text == "" || txtMK.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu");
                return;
            }

            using (QuanLyShopDongHoEntities db = new QuanLyShopDongHoEntities())
            {
                List<NhanVien> list = db.NhanViens
                   .Where(x => (x.MaNV == txtMaNV.Text))
                   .ToList();//sắp xếp ở đây
                if (!list.Any())
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
                }
                else
                {
                    list.ForEach(tk =>
                    {
                        if(tk.MatKhau == txtMK.Text && tk.VaiTro == "Quản Trị")
                        {
                            string inputdata1 = tk.HoTen.ToString();
                            string inputdata2 = tk.VaiTro.ToString();
                            string inputdata3 = tk.MaNV.ToString();
                            TrangChu tc = new TrangChu(inputdata1, inputdata2, inputdata3);
                            MessageBox.Show("Đăng nhập thành công với vai trò 'Quản Trị'");
                            this.Hide();
                            tc.Show();
                            DangNhap dn = new DangNhap();
                            dn.Dispose();
                        }
                        else if(tk.MatKhau == txtMK.Text && tk.VaiTro == "Nhân Viên")
                        {
                            string inputdata1 = tk.HoTen.ToString();
                            string inputdata2 = tk.VaiTro.ToString();
                            string inputdata3 = tk.MaNV.ToString();
                            TrangChu tc = new TrangChu(inputdata1, inputdata2, inputdata3);
                            MessageBox.Show("Đăng nhập thành công với vai trò 'Nhân Viên'");
                            this.Hide();
                            tc.Show();
                            DangNhap dn = new DangNhap();
                            dn.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
                            return;
                        }
                    });
                }
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            txtMK.PasswordChar = '\u2022';
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtMK.PasswordChar = '\0';
            }
            else
            {
                txtMK.PasswordChar = '\u2022';
            }
        }
    }
}
