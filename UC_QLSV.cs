using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharp_68PM2_TranQuangTien_0025968
{
    public partial class UC_QLSV : UserControl
    {
        public UC_QLSV()
        {
            InitializeComponent();
        }

        private void UC_QLSV_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadDSLH4CBX();
        }

        public void LoadData()
        {
            try
            {
                db = new dbDataContext();
                var dssv = from sv in db.SinhViens
                           select new
                           {
                               MaSV = sv.MaSV,
                               HoTen = sv.HoTen,
                               NgaySinh = sv.NgaySinh,
                               GioiTinh = sv.GioiTinh,
                               MaLop = sv.MaLop
                           };
                dgvSinhVien.DataSource = dssv.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu sinh viên: " + ex.Message);
            }
        }

        public void LoadDSLH4CBX()
        {
            try
            {
                List<LopHoc> dslh = db.LopHocs.ToList();
                cboLop.DataSource = dslh;
                cboLop.DisplayMember = "TenLop";
                cboLop.ValueMember = "MaLop";
            }
            catch { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSV.Text.Trim()) || string.IsNullOrEmpty(txtHoTen.Text.Trim()))
            {
                MessageBox.Show("Vui lòng điền đầy đủ Mã SV và Họ Tên!", "Thông báo");
                return;
            }

            var checkExist = db.SinhViens.SingleOrDefault(s => s.MaSV == txtMaSV.Text.Trim());
            if (checkExist != null)
            {
                MessageBox.Show("Mã sinh viên này đã tồn tại trong hệ thống!", "Trùng mã");
                return;
            }

            try
            {
                SinhVien sv = new SinhVien();
                sv.MaSV = txtMaSV.Text.Trim();
                sv.HoTen = txtHoTen.Text.Trim();
                sv.GioiTinh = cboGioiTinh.Text;
                sv.NgaySinh = dtpNgaySinh.Value;
                sv.MaLop = cboLop.SelectedValue.ToString();

                db.SinhViens.InsertOnSubmit(sv);
                db.SubmitChanges();

                MessageBox.Show("Thêm sinh viên mới thành công!", "Thành công");
                LoadData();
                btnLamMoi_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sinh viên: " + ex.Message, "Lỗi");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSV.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa đổi thông tin!", "Thông báo");
                return;
            }

            try
            {
                string maSV = txtMaSV.Text.Trim();
                SinhVien sv = db.SinhViens.SingleOrDefault(s => s.MaSV == maSV);

                if (sv != null)
                {
                    sv.HoTen = txtHoTen.Text.Trim();
                    sv.GioiTinh = cboGioiTinh.Text;
                    sv.NgaySinh = dtpNgaySinh.Value;
                    sv.MaLop = cboLop.SelectedValue.ToString();

                    db.SubmitChanges();
                    MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thành công");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên tương ứng để chỉnh sửa (Không được sửa Mã SV)!", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Lỗi");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSV.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn sinh viên muốn xóa khỏi danh sách!", "Thông báo");
                return;
            }

            try
            {
                string maSV = txtMaSV.Text.Trim();
                SinhVien sv = db.SinhViens.SingleOrDefault(s => s.MaSV == maSV);

                if (sv != null)
                {
                    DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sinh viên: {sv.HoTen} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        db.SinhViens.DeleteOnSubmit(sv);
                        db.SubmitChanges();

                        MessageBox.Show("Đã xóa sinh viên thành công!", "Thành công");
                        LoadData();
                        btnLamMoi_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Sinh viên này không tồn tại hoặc đã bị xóa trước đó!", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sinh viên: " + ex.Message, "Lỗi");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtTimKiem.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            if (cboGioiTinh.Items.Count > 0) cboGioiTinh.SelectedIndex = 0;
            if (cboLop.Items.Count > 0) cboLop.SelectedIndex = 0;
            txtMaSV.Focus();
            LoadData();
        }

        private void ThucHienTimKiem()
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            db = new dbDataContext();

            var ketQua = from sv in db.SinhViens
                         where sv.MaSV.Contains(tuKhoa) || sv.HoTen.Contains(tuKhoa) || sv.MaLop.Contains(tuKhoa)
                         select new
                         {
                             MaSV = sv.MaSV,
                             HoTen = sv.HoTen,
                             NgaySinh = sv.NgaySinh,
                             GioiTinh = sv.GioiTinh,
                             MaLop = sv.MaLop
                         };

            dgvSinhVien.DataSource = ketQua.ToList();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            ThucHienTimKiem();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            ThucHienTimKiem();
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];
                txtMaSV.Text = row.Cells["MaSV"].Value?.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();

                if (row.Cells["NgaySinh"].Value != null)
                    dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);

                cboGioiTinh.Text = row.Cells["GioiTinh"].Value?.ToString();
                cboLop.SelectedValue = row.Cells["MaLop"].Value?.ToString();
            }
        }


    }
}
