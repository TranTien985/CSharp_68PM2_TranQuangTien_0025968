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
