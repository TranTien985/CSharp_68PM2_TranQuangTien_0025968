using System;
using System.Drawing;
using System.Windows.Forms;

namespace CSharp_68PM2_TranQuangTien_0025968
{
    public partial class FrmQuanLySinhVien : Form
    {
        // Menu
        MenuStrip menu;
        ToolStripMenuItem mnSinhVien, mnLopHoc, mnDangXuat;

        // GroupBox
        GroupBox grpThongTin;

        // Label
        Label lblMaSV, lblHoTen, lblNgaySinh, lblGioiTinh, lblLop;
        Label lblTimKiem;

        // TextBox
        TextBox txtMaSV, txtHoTen, txtTimKiem;

        // DateTimePicker
        DateTimePicker dtNgaySinh;

        // ComboBox
        ComboBox cboGioiTinh, cboLop;

        // Button
        Button btnThem, btnSua, btnXoa, btnLamMoi, btnTim;
        Button btnFirst, btnPrev, btnNext, btnLast;

        // DataGridView
        DataGridView dgvSinhVien;

        // Label Page
        Label lblTrang;

        public FrmQuanLySinhVien()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // FrmQuanLySinhVien
            // 
            ClientSize = new Size(653, 329);
            Name = "FrmQuanLySinhVien";
            Text = "Quản Lý Sinh Viên";
            ResumeLayout(false);
        }

        private void KhoiTao()
        {
            // Form
            this.Text = "Quản Lý Sinh Viên";
            this.Size = new Size(1400, 900);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.Gainsboro;

            // ================= MENU =================
            menu = new MenuStrip();

            mnSinhVien = new ToolStripMenuItem("Quản Lý Sinh Viên");
            mnLopHoc = new ToolStripMenuItem("Quản Lý Lớp Học");
            mnDangXuat = new ToolStripMenuItem("Đăng xuất");

            mnDangXuat.ForeColor = Color.Red;
            mnSinhVien.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            menu.Items.Add(mnSinhVien);
            menu.Items.Add(mnLopHoc);
            menu.Items.Add(mnDangXuat);

            this.Controls.Add(menu);

            // ================= GROUPBOX =================
            grpThongTin = new GroupBox();
            grpThongTin.Text = "Thông tin sinh viên";
            grpThongTin.Location = new Point(15, 60);
            grpThongTin.Size = new Size(470, 600);

            this.Controls.Add(grpThongTin);

            // ================= LABEL + TEXTBOX =================

            lblMaSV = new Label();
            lblMaSV.Text = "Mã sinh viên:";
            lblMaSV.Location = new Point(20, 40);

            txtMaSV = new TextBox();
            txtMaSV.Location = new Point(20, 70);
            txtMaSV.Size = new Size(420, 30);

            lblHoTen = new Label();
            lblHoTen.Text = "Họ và tên:";
            lblHoTen.Location = new Point(20, 130);

            txtHoTen = new TextBox();
            txtHoTen.Location = new Point(20, 160);
            txtHoTen.Size = new Size(420, 30);

            lblNgaySinh = new Label();
            lblNgaySinh.Text = "Ngày sinh:";
            lblNgaySinh.Location = new Point(20, 220);

            dtNgaySinh = new DateTimePicker();
            dtNgaySinh.Format = DateTimePickerFormat.Short;
            dtNgaySinh.Location = new Point(20, 250);
            dtNgaySinh.Size = new Size(420, 30);

            lblGioiTinh = new Label();
            lblGioiTinh.Text = "Giới tính:";
            lblGioiTinh.Location = new Point(20, 310);

            cboGioiTinh = new ComboBox();
            cboGioiTinh.Location = new Point(20, 340);
            cboGioiTinh.Size = new Size(420, 30);

            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");

            cboGioiTinh.SelectedIndex = 0;

            lblLop = new Label();
            lblLop.Text = "Lớp:";
            lblLop.Location = new Point(20, 400);

            cboLop = new ComboBox();
            cboLop.Location = new Point(20, 430);
            cboLop.Size = new Size(420, 30);

            cboLop.Items.Add("68PM1 – Lớp 68PM1");
            cboLop.Items.Add("68PM2 – Lớp 68PM2");

            cboLop.SelectedIndex = 0;

            grpThongTin.Controls.Add(lblMaSV);
            grpThongTin.Controls.Add(txtMaSV);

            grpThongTin.Controls.Add(lblHoTen);
            grpThongTin.Controls.Add(txtHoTen);

            grpThongTin.Controls.Add(lblNgaySinh);
            grpThongTin.Controls.Add(dtNgaySinh);

            grpThongTin.Controls.Add(lblGioiTinh);
            grpThongTin.Controls.Add(cboGioiTinh);

            grpThongTin.Controls.Add(lblLop);
            grpThongTin.Controls.Add(cboLop);

            // ================= BUTTON =================

            btnThem = new Button();
            btnThem.Text = "Thêm";
            btnThem.BackColor = Color.DodgerBlue;
            btnThem.ForeColor = Color.White;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Location = new Point(15, 680);
            btnThem.Size = new Size(220, 60);

            btnSua = new Button();
            btnSua.Text = "Sửa";
            btnSua.BackColor = Color.MediumSeaGreen;
            btnSua.ForeColor = Color.White;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Location = new Point(245, 680);
            btnSua.Size = new Size(220, 60);

            btnXoa = new Button();
            btnXoa.Text = "Xóa";
            btnXoa.BackColor = Color.Tomato;
            btnXoa.ForeColor = Color.White;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Location = new Point(15, 760);
            btnXoa.Size = new Size(220, 60);

            btnLamMoi = new Button();
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.BackColor = Color.SlateGray;
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Location = new Point(245, 760);
            btnLamMoi.Size = new Size(220, 60);

            this.Controls.Add(btnThem);
            this.Controls.Add(btnSua);
            this.Controls.Add(btnXoa);
            this.Controls.Add(btnLamMoi);

            // ================= TÌM KIẾM =================

            lblTimKiem = new Label();
            lblTimKiem.Text = "Tìm kiếm (Tên / Mã SV / Lớp):";
            lblTimKiem.Location = new Point(510, 60);

            txtTimKiem = new TextBox();
            txtTimKiem.Location = new Point(510, 90);
            txtTimKiem.Size = new Size(350, 30);

            btnTim = new Button();
            btnTim.Text = "Tìm";
            btnTim.BackColor = Color.DarkSlateBlue;
            btnTim.ForeColor = Color.White;
            btnTim.FlatStyle = FlatStyle.Flat;
            btnTim.Location = new Point(880, 85);
            btnTim.Size = new Size(130, 45);

            this.Controls.Add(lblTimKiem);
            this.Controls.Add(txtTimKiem);
            this.Controls.Add(btnTim);

            // ================= DATAGRIDVIEW =================

            dgvSinhVien = new DataGridView();
            dgvSinhVien.Location = new Point(510, 160);
            dgvSinhVien.Size = new Size(850, 580);

            dgvSinhVien.ColumnCount = 5;

            dgvSinhVien.Columns[0].Name = "Mã SV";
            dgvSinhVien.Columns[1].Name = "Họ và Tên";
            dgvSinhVien.Columns[2].Name = "Giới Tính";
            dgvSinhVien.Columns[3].Name = "Ngày Sinh";
            dgvSinhVien.Columns[4].Name = "Lớp";

            dgvSinhVien.Rows.Add("1", "Hiếu", "Nam", "11/03/2026", "68PM1");
            dgvSinhVien.Rows.Add("2", "Nguyễn Văn B", "Nam", "11/03/2026", "68PM2");
            dgvSinhVien.Rows.Add("3", "Trần Văn C", "Nam", "21/03/2026", "68PM2");

            this.Controls.Add(dgvSinhVien);

            // ================= PHÂN TRANG =================

            btnFirst = new Button();
            btnFirst.Text = "<<";
            btnFirst.Location = new Point(510, 760);
            btnFirst.Size = new Size(70, 60);

            btnPrev = new Button();
            btnPrev.Text = "<";
            btnPrev.Location = new Point(580, 760);
            btnPrev.Size = new Size(70, 60);

            lblTrang = new Label();
            lblTrang.Text = "Trang 1/1 | 3 bản ghi";
            lblTrang.AutoSize = true;
            lblTrang.Location = new Point(780, 785);

            btnNext = new Button();
            btnNext.Text = ">";
            btnNext.Location = new Point(980, 760);
            btnNext.Size = new Size(70, 60);

            btnLast = new Button();
            btnLast.Text = ">>";
            btnLast.Location = new Point(1050, 760);
            btnLast.Size = new Size(70, 60);

            this.Controls.Add(btnFirst);
            this.Controls.Add(btnPrev);
            this.Controls.Add(lblTrang);
            this.Controls.Add(btnNext);
            this.Controls.Add(btnLast);
        }
    }
}