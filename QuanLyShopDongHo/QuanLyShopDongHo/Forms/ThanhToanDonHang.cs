using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace QuanLyShopDongHo.Forms
{
    public partial class ThanhToanDonHang : Form
    {
        private PrintDocument printDocument = new PrintDocument();

        public ThanhToanDonHang(string maDH)
        {
            InitializeComponent();
            lblMaDon.Text = maDH;
            label11.Height = 2;
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

        private void btnXuatDon_Click(object sender, EventArgs e)
        {
            PrintDialog print = new PrintDialog();
            printDocument.DefaultPageSettings.PaperSize = new PaperSize("MyPaper", 228, 300);
            print.AllowSomePages = true;
            print.ShowHelp = true;
            print.Document = printDocument;
            DialogResult result = print.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument.PrintPage += new PrintPageEventHandler(document_PrintPage);
                printDocument.Print();
            }
        }

        private void document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
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

            string title = "\t\t\t\t\tĐƠN HÀNG";
            string text = Environment.NewLine + "\t\t" + lbl2 + maDon + Environment.NewLine
             + "\t\t" + lbl4 + sdt + Environment.NewLine
             + "\t\t" + lbl3 + tenKH + Environment.NewLine
             + "\t\t" + lbl10 + ngayIn + Environment.NewLine
             + "\t\t" + lbl5 + "\t" + lbl6 + "\t\t" + lbl8 + "\t" + lbl7 + Environment.NewLine
             + "\t\t" + maLoai + "\t\t" + tenLoai + "\t" + soLuong + "\t\t" + donGia + Environment.NewLine
             + "\t\t" + label11.Text
             + Environment.NewLine + "\t\t\t\t\t\t\t" + lbl9 + tongTien;

            System.Drawing.Font printFont1 = new System.Drawing.Font
                ("Times New Roman", 12, System.Drawing.FontStyle.Bold);
            e.Graphics.DrawString(title, printFont1,
                System.Drawing.Brushes.Black, 10, 10);
            System.Drawing.Font printFont2 = new System.Drawing.Font
                ("Times New Roman", 12, System.Drawing.FontStyle.Regular);
            e.Graphics.DrawString(text, printFont2,
                System.Drawing.Brushes.Black, 10, 10);
            MessageBox.Show("Đơn hàng đã được xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
