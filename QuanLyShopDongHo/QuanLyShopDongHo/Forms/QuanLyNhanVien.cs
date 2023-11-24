using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyShopDongHo.Forms
{
    public partial class QuanLyNhanVien : Form
    {
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            cbbvaitro.Items.Add("Quản trị");
            cbbvaitro.Items.Add("Nhân viên");
            btnthem.Enabled = true;
            btncapnhat.Enabled = false;
            btnxoa.Enabled = false;
            upDateDGV();
        }
        private void upDateDGV()
        {
            using (QuanLyShopDongHoEntities db = new QuanLyShopDongHoEntities())
            {
                dataGridView1.Rows.Clear();
                db.NhanViens.ToList().ForEach(kh =>
                {
                    dataGridView1.Rows.Add(
                        kh.MaNV,
                        kh.HoTen,
                        kh.VaiTro,
                        kh.NgaySinh.ToString().Split(' ')[0],
                        kh.SDT,
                        kh.Email
                        ); ;

                });
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (checkk())
            {
                try
                {
                    NhanVien them = new NhanVien();
                    them.MaNV = txtmanv.Text;
                    them.HoTen = txthoten.Text;
                    them.VaiTro = cbbvaitro.Text;
                    them.NgaySinh = DateTime.ParseExact(txtngaysinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    them.SDT = txtsdt.Text;
                    them.Email = txtemail.Text;
                    them.MatKhau = "e99a18c428cb38d5f260853678922e03";
                    using (QuanLyShopDongHoEntities db = new QuanLyShopDongHoEntities())
                    {
                        db.NhanViens.Add(them);
                        db.SaveChanges();
                    }
                    rong();
                    upDateDGV();
                }
                catch (Exception)
                {
                    MessageBox.Show("Dữ liệu không hợp lệ");
                    return;
                }
            }
        }
        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(email, pattern);
        }
        private bool checkk()
        {
            if (txtmanv.Text == "" || txthoten.Text == "" || txtngaysinh.Text == "" || cbbvaitro.Text == ""
               || txtsdt.Text == "" || txtemail.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return false;
            }

            if (txtmanv.Text.Length > 8)
            {
                MessageBox.Show("Mã người học không được quá 8 ký tự");
                return false;
            }
            int number;
            if (int.TryParse(txtsdt.Text, out number))
            {
                if (txtsdt.Text.Length <= 0 || txtsdt.Text.Length > 10 || txtsdt.Text.Length != 10)
                {
                    MessageBox.Show("Số điện thoại phải đầy đủ 10 số.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng không nhập kí tự vào số điện thoại.");
                return false;
            }


            string email = txtemail.Text;
            if (IsValidEmail(email))
            { }
            else
            {
                MessageBox.Show("Email không hợp lệ.");
                return false;
            }

            DateTime nam;
            if (DateTime.TryParse(txtngaysinh.Text, out nam))
            {
                int namhientai = DateTime.Now.Year;
                int tinh = nam.Year;
                int sautinh = namhientai - tinh;
                if (sautinh < 18)
                {
                    MessageBox.Show("Tuổi không hợp lệ, từ 18 tuổi trở lên mới có thể được nhận!!!");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập theo dạng datetime.");
                return false;
            }
            return true;
        }
        private void rong()
        {
            txtmanv.Text = "";
            txthoten.Text = "";
            txttim.Text = "";
            cbbvaitro.Text = "";
            txtngaysinh.Text = "";
            txtsdt.Text = "";
            txtemail.Text = "";
            btnthem.Enabled = true;
            btncapnhat.Enabled = false;
            btnxoa.Enabled = false;
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            rong();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            using (QuanLyShopDongHoEntities db = new QuanLyShopDongHoEntities())
            {
                NhanVien xoa = db.NhanViens.Where(x => x.MaNV == txtmanv.Text)
                    .FirstOrDefault();
                db.NhanViens.Remove(xoa);
                db.SaveChanges();
            }
            rong();
            upDateDGV();

        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            if (checkk())
            {
                try
                {
                    using (QuanLyShopDongHoEntities db = new QuanLyShopDongHoEntities())
                    {
                        NhanVien sua = db.NhanViens.Where(x => x.MaNV == txtmanv.Text)
                            .FirstOrDefault();
                        sua.HoTen = txthoten.Text;
                        sua.VaiTro = cbbvaitro.Text;
                        sua.NgaySinh = DateTime.ParseExact(txtngaysinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        sua.Email = txtemail.Text;
                        sua.SDT = txtsdt.Text;
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
                List<NhanVien> list = db.NhanViens
                    .Where(x => x.MaNV == txttim.Text)
                    .ToList();//sắp xếp ở đây

                if (!list.Any())
                {
                    MessageBox.Show("Không tìm thấy");
                }
                else
                {
                    list.ForEach(nh =>
                    {
                        txtmanv.Text = nh.MaNV;
                        txthoten.Text = nh.HoTen;
                        txtngaysinh.Text = nh.NgaySinh.ToString();
                        cbbvaitro.Text = nh.VaiTro;
                        txtemail.Text = nh.Email;
                        txtsdt.Text = nh.SDT;
                    });
                    btncapnhat.Enabled = true;
                    btnthem.Enabled = false;
                    btnxoa.Enabled = true;
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
                NhanVien kh = db.NhanViens.Where(x => x.MaNV == manh).FirstOrDefault();
                txtmanv.Text = kh.MaNV;
                txthoten.Text = kh.HoTen;
                txtngaysinh.Text = kh.NgaySinh.ToString().Split(' ')[0];
                cbbvaitro.Text = kh.VaiTro;
                txtemail.Text = kh.Email;
                txtsdt.Text = kh.SDT;
            }
            btncapnhat.Enabled = true;
            btnthem.Enabled = false;
            btnxoa.Enabled = true;
        }
    }
}
