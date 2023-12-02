using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace QuanLyShopDongHo.Forms
{
    public partial class ThanhToanDonHang : Form
    {
        public ThanhToanDonHang(string maDH)
        {
            InitializeComponent();
            lblMaDon.Text = maDH;
        }

        private void ThanhToanDonHang_Load(object sender, EventArgs e)
        {
            using (var db = new QuanLyShopDongHoEntities())
            {
                lblSDT.Text = db.DonHangs.Where(x => x.MaDon == lblMaDon.Text)
                              .Select(x => x.SDT).FirstOrDefault().ToString();
                lblTenKH.Text = db.DonHangs.Where(x => x.MaDon == lblMaDon.Text)
                              .Select(x => x.TenKH).FirstOrDefault().ToString();
                lblNgayIn.Text = db.DonHangs.Where(x => x.MaDon == lblMaDon.Text)
                              .Select(x => x.NgayIn).FirstOrDefault().ToString("dd/MM/yyyy");
                lblMaLoai.Text = db.DonHangs.Where(x => x.MaDon == lblMaDon.Text)
                              .Select(x => x.LoaiSP).FirstOrDefault().ToString();
                lblTenLoai.Text = db.DonHangs.Where(x => x.MaDon == lblMaDon.Text)
                              .Select(x => x.ChiTietSanPham.TenLoai).FirstOrDefault().ToString();
                lblSoLuong.Text = db.DonHangs.Where(x => x.MaDon == lblMaDon.Text)
                              .Select(x => x.SoLuong).FirstOrDefault().ToString();
                lblDonGia.Text = db.DonHangs.Where(x => x.MaDon == lblMaDon.Text)
                              .Select(x => x.ChiTietSanPham.GiaBan).FirstOrDefault().ToString("#,##0");
                int soLuong = int.Parse(lblSoLuong.Text);
                double donGia = float.Parse(lblDonGia.Text);
                double tongTien = soLuong * donGia;
                lblTongTien.Text = tongTien.ToString("#,##0");
            }
        }

        private void btnXuatWord_Click(object sender, EventArgs e)
        {
            Word.Application wordApp = new Word.Application();
            Word.Document doc = wordApp.Documents.Add();
            try
            {
                string lbl1 = label1.Text;
                string lbl2 = label2.Text;
                string maDon = lblMaDon.Text;
                string lbl4 = label4.Text;
                string sdt = lblSDT.Text;
                string lbl3 = label3.Text;
                string tenKH = lblTenKH.Text;
                string lbl10 = label10.Text;
                string ngayIn = lblNgayIn.Text;
                string lbl5 = label5.Text;
                string lbl6 = label6.Text;
                string lbl7 = label7.Text;
                string lbl8 = label8.Text;
                string maLoai = lblMaLoai.Text;
                string tenLoai = lblTenLoai.Text;
                string soLuong = lblSoLuong.Text;
                string donGia = lblDonGia.Text;
                string lbl9 = label9.Text;
                string tongTien = lblTongTien.Text;
                doc.Content.Text += "\t\t\t\t\t" + lbl1 + Environment.NewLine
                    + lbl2 + maDon + Environment.NewLine
                    + lbl4 + sdt + Environment.NewLine
                    + lbl3 + tenKH + Environment.NewLine
                    + lbl10 + ngayIn + Environment.NewLine
                    + lbl5 + "\t\t" + lbl6 + "\t\t" + lbl8 + "\t\t" + lbl7 + Environment.NewLine
                    + maLoai + "\t\t\t" + tenLoai + "\t\t" + soLuong + "\t\t" + donGia + Environment.NewLine
                    + Environment.NewLine + "\t\t\t\t\t\t\t" + lbl9 + tongTien;

                doc.SaveAs2($@"D:\DuAn1\{maDon}.docx");
                doc.Close();
                wordApp.Quit();
                MessageBox.Show("Xuất Word thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xuất Word: " + ex);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
            }

        }
    }
}
