using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace TH05d
{
    public partial class frmQuanLyLop : Form
    {
        private TextBox txtMaKhoa;
        private TextBox txtMaLop;
        private TextBox txtTenLop;

        private Button btnThem;
        private Button btnXoa;
        private Button btnSua;
        private Button btnXoaTrang;
        private Button btnThoat;

        private readonly string connectionString =
            @"Data Source=.;
              Initial Catalog=QLSinhVien;
              Integrated Security=True;
              TrustServerCertificate=True";

        public frmQuanLyLop()
        {
            InitializeComponent();
            TaoGiaoDien();
        }

        private void TaoGiaoDien()
        {

            Text = "Quản lý lớp";

            StartPosition =
                FormStartPosition.CenterScreen;

            ClientSize =
                new Size(470, 330);

            FormBorderStyle =
                FormBorderStyle.FixedSingle;

            MaximizeBox = false;

            Font = new Font("Tahoma", 10F);


            Label lblTieuDe =
                new Label();

            lblTieuDe.Text =
                "QUẢN LÝ LỚP";

            lblTieuDe.Font =
                new Font(
                    "Tahoma",
                    17F,
                    FontStyle.Bold
                );

            lblTieuDe.ForeColor =
                Color.Blue;

            lblTieuDe.AutoSize = true;

            lblTieuDe.Location =
                new Point(145, 25);


            Label lblMaKhoa =
                new Label();

            lblMaKhoa.Text =
                "Mã khoa:";

            lblMaKhoa.AutoSize = true;

            lblMaKhoa.Location =
                new Point(55, 90);

            txtMaKhoa =
                new TextBox();

            txtMaKhoa.Location =
                new Point(155, 85);

            txtMaKhoa.Size =
                new Size(240, 27);


            Label lblMaLop =
                new Label();

            lblMaLop.Text =
                "Mã lớp:";

            lblMaLop.AutoSize = true;

            lblMaLop.Location =
                new Point(55, 135);

            txtMaLop =
                new TextBox();

            txtMaLop.Location =
                new Point(155, 130);

            txtMaLop.Size =
                new Size(240, 27);


            Label lblTenLop =
                new Label();

            lblTenLop.Text =
                "Tên lớp:";

            lblTenLop.AutoSize = true;

            lblTenLop.Location =
                new Point(55, 180);

            txtTenLop =
                new TextBox();

            txtTenLop.Location =
                new Point(155, 175);

            txtTenLop.Size =
                new Size(240, 27);


            btnThem =
                new Button();

            btnThem.Text = "Thêm";

            btnThem.Location =
                new Point(40, 230);

            btnThem.Size =
                new Size(80, 35);

            btnThem.Click +=
                btnThem_Click;

            btnXoa =
                new Button();

            btnXoa.Text = "Xóa";

            btnXoa.Location =
                new Point(130, 230);

            btnXoa.Size =
                new Size(80, 35);

            btnXoa.Click +=
                btnXoa_Click;


            btnSua =
                new Button();

            btnSua.Text = "Sửa";

            btnSua.Location =
                new Point(220, 230);

            btnSua.Size =
                new Size(80, 35);

            btnSua.Click +=
                btnSua_Click;


            btnXoaTrang =
                new Button();

            btnXoaTrang.Text =
                "Xóa trắng";

            btnXoaTrang.Location =
                new Point(310, 230);

            btnXoaTrang.Size =
                new Size(100, 35);

            btnXoaTrang.Click +=
                btnXoaTrang_Click;


            btnThoat =
                new Button();

            btnThoat.Text =
                "Thoát";

            btnThoat.Location =
                new Point(175, 280);

            btnThoat.Size =
                new Size(120, 35);

            btnThoat.Click +=
                btnThoat_Click;


            Controls.Add(lblTieuDe);

            Controls.Add(lblMaKhoa);
            Controls.Add(txtMaKhoa);

            Controls.Add(lblMaLop);
            Controls.Add(txtMaLop);

            Controls.Add(lblTenLop);
            Controls.Add(txtTenLop);

            Controls.Add(btnThem);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);

            Controls.Add(btnXoaTrang);
            Controls.Add(btnThoat);
        }


        private void btnThem_Click(
            object? sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                    txtMaKhoa.Text)
                ||
                string.IsNullOrWhiteSpace(
                    txtMaLop.Text)
                ||
                string.IsNullOrWhiteSpace(
                    txtTenLop.Text))
            {
                MessageBox.Show(
                    "Mã khoa, mã lớp và tên lớp không được để trống.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {
                using SqlConnection conn =
                    new SqlConnection(
                        connectionString
                    );

                conn.Open();

                string sql =
                    @"INSERT INTO Lop
                      (MaLop, TenLop, MaKhoa)
                      VALUES
                      (@MaLop, @TenLop, @MaKhoa)";

                using SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@MaLop",
                    txtMaLop.Text.Trim()
                );

                cmd.Parameters.AddWithValue(
                    "@TenLop",
                    txtTenLop.Text.Trim()
                );

                cmd.Parameters.AddWithValue(
                    "@MaKhoa",
                    txtMaKhoa.Text.Trim()
                );

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "Thêm lớp thành công.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                XoaTrang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Thêm thất bại.\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void btnXoa_Click(
            object? sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                txtMaLop.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập mã lớp cần xóa."
                );

                txtMaLop.Focus();

                return;
            }

            DialogResult r =
                MessageBox.Show(
                    "Bạn có chắc muốn xóa lớp này?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (r != DialogResult.Yes)
                return;

            try
            {
                using SqlConnection conn =
                    new SqlConnection(
                        connectionString
                    );

                conn.Open();

                string sql =
                    @"DELETE FROM Lop
                      WHERE MaLop = @MaLop";

                using SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@MaLop",
                    txtMaLop.Text.Trim()
                );

                int soDong =
                    cmd.ExecuteNonQuery();

                if (soDong > 0)
                {
                    MessageBox.Show(
                        "Xóa lớp thành công."
                    );

                    XoaTrang();
                }
                else
                {
                    MessageBox.Show(
                        "Không tìm thấy mã lớp."
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Xóa thất bại.\n\n" +
                    ex.Message
                );
            }
        }


        private void btnSua_Click(
            object? sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                txtMaLop.Text))
            {
                MessageBox.Show(
                    "Mã lớp không được để trống."
                );

                return;
            }

            if (string.IsNullOrWhiteSpace(
                    txtMaKhoa.Text)
                &&
                string.IsNullOrWhiteSpace(
                    txtTenLop.Text))
            {
                MessageBox.Show(
                    "Phải nhập ít nhất Mã khoa hoặc Tên lớp để sửa."
                );

                return;
            }

            try
            {
                using SqlConnection conn =
                    new SqlConnection(
                        connectionString
                    );

                conn.Open();

                string sql;

                if (!string.IsNullOrWhiteSpace(
                        txtMaKhoa.Text)
                    &&
                    !string.IsNullOrWhiteSpace(
                        txtTenLop.Text))
                {
                    sql =
                        @"UPDATE Lop
                          SET MaKhoa = @MaKhoa,
                              TenLop = @TenLop
                          WHERE MaLop = @MaLop";
                }

                else if (!string.IsNullOrWhiteSpace(
                    txtMaKhoa.Text))
                {
                    sql =
                        @"UPDATE Lop
                          SET MaKhoa = @MaKhoa
                          WHERE MaLop = @MaLop";
                }

                else
                {
                    sql =
                        @"UPDATE Lop
                          SET TenLop = @TenLop
                          WHERE MaLop = @MaLop";
                }

                using SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@MaLop",
                    txtMaLop.Text.Trim()
                );

                if (!string.IsNullOrWhiteSpace(
                    txtMaKhoa.Text))
                {
                    cmd.Parameters.AddWithValue(
                        "@MaKhoa",
                        txtMaKhoa.Text.Trim()
                    );
                }

                if (!string.IsNullOrWhiteSpace(
                    txtTenLop.Text))
                {
                    cmd.Parameters.AddWithValue(
                        "@TenLop",
                        txtTenLop.Text.Trim()
                    );
                }

                int soDong =
                    cmd.ExecuteNonQuery();

                if (soDong > 0)
                {
                    MessageBox.Show(
                        "Cập nhật lớp thành công."
                    );

                    XoaTrang();
                }
                else
                {
                    MessageBox.Show(
                        "Không tìm thấy mã lớp."
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Cập nhật thất bại.\n\n"
                    + ex.Message
                );
            }
        }

        private void btnXoaTrang_Click(
            object? sender,
            EventArgs e)
        {
            XoaTrang();
        }

        private void XoaTrang()
        {
            txtMaKhoa.Clear();
            txtMaLop.Clear();
            txtTenLop.Clear();

            txtMaKhoa.Focus();
        }


        private void btnThoat_Click(
            object? sender,
            EventArgs e)
        {
            Close();
        }
    }
}