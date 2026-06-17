using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharp_68PM2_TranQuangTien_0025968
{
    public partial class UC_QLLH : UserControl
    {
        public UC_QLLH()
        {
            InitializeComponent();
        }

        private void dgvLopHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSV.Text.Trim()) || string.IsNullOrEmpty(txtHoTen.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã Lớp (Mã ID) và Tên lớp!", "Thông báo");
                return;
            }

            var checkLop = db.LopHocs.SingleOrDefault(l => l.MaLop == txtMaSV.Text.Trim());
            if (checkLop != null)
            {
                MessageBox.Show("Mã lớp học này đã tồn tại!", "Trùng mã");
                return;
            }

            try
            {
                LopHoc lh = new LopHoc();
                lh.MaLop = txtMaSV.Text.Trim();
                lh.TenLop = txtHoTen.Text.Trim();
                lh.GhiChu = textBox1.Text.Trim();

                db.LopHocs.InsertOnSubmit(lh);
                db.SubmitChanges();

                MessageBox.Show("Thêm lớp học thành công!", "Thông báo");
                LoadDataLop();
                btnLamMoi_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm lớp: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSV.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn lớp học cần chỉnh sửa thông tin!", "Thông báo");
                return;
            }

            try
            {
                string maLop = txtMaSV.Text.Trim();
                LopHoc lh = db.LopHocs.SingleOrDefault(l => l.MaLop == maLop);

                if (lh != null)
                {
                    lh.TenLop = txtHoTen.Text.Trim();
                    lh.GhiChu = textBox1.Text.Trim();

                    db.SubmitChanges();
                    MessageBox.Show("Cập nhật dữ liệu lớp học thành công!", "Thông báo");
                    LoadDataLop();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu lớp cần sửa đổi!", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSV.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn lớp học muốn xóa!", "Thông báo");
                return;
            }

            try
            {
                string maLop = txtMaSV.Text.Trim();
                LopHoc lh = db.LopHocs.SingleOrDefault(l => l.MaLop == maLop);

                if (lh != null)
                {
                    int hasSv = db.SinhViens.Count(s => s.MaLop == maLop);
                    if (hasSv > 0)
                    {
                        MessageBox.Show($"Không thể xóa lớp này vì đang có {hasSv} sinh viên học tập bên trong!", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa lớp {lh.TenLop}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        db.LopHocs.DeleteOnSubmit(lh);
                        db.SubmitChanges();

                        MessageBox.Show("Xóa lớp học thành công!", "Thông báo");
                        LoadDataLop();
                        btnLamMoi_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa lớp học: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            textBox1.Clear();
            txtMaSV.Focus();
        }


        private void dgvLopHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLopHoc.Rows[e.RowIndex];
                txtMaSV.Text = row.Cells["MaLop"].Value?.ToString();
                txtHoTen.Text = row.Cells["TenLop"].Value?.ToString();
                textBox1.Text = row.Cells["GhiChu"].Value?.ToString();
            }
        }
    }

}
