using System.Text.RegularExpressions;

namespace TH04c
{
    public partial class frmBai2 : Form
    {
        private TextBox txtTenDangNhap;
        private TextBox txtEmail;
        private TextBox txtMatKhau;
        private TextBox txtXacNhanMatKhau;

        private Button btnDangKy;

        private ErrorProvider errorProvider1;

        public frmBai2()
        {
            InitializeComponent();
            TaoGiaoDien();
        }

        private void TaoGiaoDien()
        {
            Text = "Đăng ký tài khoản";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(360, 250);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Font = new Font("Tahoma", 9F, FontStyle.Regular);

            Label lblTieuDe = new Label();
            lblTieuDe.Text = "Đăng ký tài khoản";
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.DodgerBlue;
            lblTieuDe.Location = new Point(105, 20);

            Label lblTenDangNhap = new Label();
            lblTenDangNhap.Text = "Tên đăng nhập";
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Location = new Point(35, 70);

            txtTenDangNhap = new TextBox();
            txtTenDangNhap.Location = new Point(145, 66);
            txtTenDangNhap.Size = new Size(150, 22);

            Label lblBatBuoc1 = new Label();
            lblBatBuoc1.Text = "(*)";
            lblBatBuoc1.AutoSize = true;
            lblBatBuoc1.Location = new Point(305, 70);

            Label lblEmail = new Label();
            lblEmail.Text = "Địa chỉ email";
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(35, 105);

            txtEmail = new TextBox();
            txtEmail.Location = new Point(145, 101);
            txtEmail.Size = new Size(150, 22);

            Label lblBatBuoc2 = new Label();
            lblBatBuoc2.Text = "(*)";
            lblBatBuoc2.AutoSize = true;
            lblBatBuoc2.Location = new Point(305, 105);

            Label lblMatKhau = new Label();
            lblMatKhau.Text = "Mật khẩu";
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new Point(35, 140);

            txtMatKhau = new TextBox();
            txtMatKhau.Location = new Point(145, 136);
            txtMatKhau.Size = new Size(150, 22);
            txtMatKhau.UseSystemPasswordChar = true;

            Label lblBatBuoc3 = new Label();
            lblBatBuoc3.Text = "(*)";
            lblBatBuoc3.AutoSize = true;
            lblBatBuoc3.Location = new Point(305, 140);

            Label lblXacNhan = new Label();
            lblXacNhan.Text = "Xác nhận mật khẩu";
            lblXacNhan.AutoSize = true;
            lblXacNhan.Location = new Point(35, 175);

            txtXacNhanMatKhau = new TextBox();
            txtXacNhanMatKhau.Location = new Point(145, 171);
            txtXacNhanMatKhau.Size = new Size(150, 22);
            txtXacNhanMatKhau.UseSystemPasswordChar = true;

            btnDangKy = new Button();
            btnDangKy.Text = "Đăng ký";
            btnDangKy.Location = new Point(145, 205);
            btnDangKy.Size = new Size(150, 32);

            errorProvider1 = new ErrorProvider();
            errorProvider1.ContainerControl = this;

            txtEmail.Leave += txtEmail_Leave;
            txtXacNhanMatKhau.KeyDown += txtXacNhanMatKhau_KeyDown;
            btnDangKy.Click += btnDangKy_Click;
            FormClosing += frmBai2_FormClosing;

            AcceptButton = btnDangKy;

            Controls.Add(lblTieuDe);

            Controls.Add(lblTenDangNhap);
            Controls.Add(txtTenDangNhap);
            Controls.Add(lblBatBuoc1);

            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblBatBuoc2);

            Controls.Add(lblMatKhau);
            Controls.Add(txtMatKhau);
            Controls.Add(lblBatBuoc3);

            Controls.Add(lblXacNhan);
            Controls.Add(txtXacNhanMatKhau);

            Controls.Add(btnDangKy);
        }

        private bool KiemTraDuLieu()
        {
            errorProvider1.Clear();

            bool hopLe = true;

            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                errorProvider1.SetError(
                    txtTenDangNhap,
                    "Tên đăng nhập không được để trống!"
                );

                hopLe = false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(
                    txtEmail,
                    "Email không được để trống!"
                );

                hopLe = false;
            }
            else if (!KiemTraEmail(txtEmail.Text))
            {
                errorProvider1.SetError(
                    txtEmail,
                    "Email không đúng định dạng!"
                );

                hopLe = false;
            }

            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                errorProvider1.SetError(
                    txtMatKhau,
                    "Mật khẩu không được để trống!"
                );

                hopLe = false;
            }

            if (string.IsNullOrWhiteSpace(txtXacNhanMatKhau.Text))
            {
                errorProvider1.SetError(
                    txtXacNhanMatKhau,
                    "Vui lòng xác nhận mật khẩu!"
                );

                hopLe = false;
            }
            else if (txtMatKhau.Text != txtXacNhanMatKhau.Text)
            {
                errorProvider1.SetError(
                    txtXacNhanMatKhau,
                    "Mật khẩu xác nhận không khớp!"
                );

                hopLe = false;
            }

            return hopLe;
        }

        private bool KiemTraEmail(string email)
        {
            string mau = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(email, mau);
        }

        private void txtEmail_Leave(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(
                    txtEmail,
                    "Email không được để trống!"
                );
            }
            else if (!KiemTraEmail(txtEmail.Text))
            {
                errorProvider1.SetError(
                    txtEmail,
                    "Email không đúng định dạng!"
                );
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }
        }

        private void btnDangKy_Click(object? sender, EventArgs e)
        {
            if (!KiemTraDuLieu())
                return;

            string thongTin =
                "THÔNG TIN ĐĂNG KÝ\n\n" +
                "Tên đăng nhập: " + txtTenDangNhap.Text + "\n" +
                "Địa chỉ email: " + txtEmail.Text + "\n" +
                "Mật khẩu: " + txtMatKhau.Text + "\n" +
                "Xác nhận mật khẩu: " + txtXacNhanMatKhau.Text;

            MessageBox.Show(
                thongTin,
                "Thông tin đăng ký",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void txtXacNhanMatKhau_KeyDown(
            object? sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangKy.PerformClick();
            }
        }

        private void frmBai2_FormClosing(
            object? sender,
            FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}