namespace TH04d
{
    public partial class frmBaiTapVeNha : Form
    {
        private TextBox txtHoTen;
        private TextBox txtDiaChi;
        private TextBox txtSoNgayO;

        private RadioButton rdoPhongDon;
        private RadioButton rdoPhongDoi;
        private RadioButton rdoPhongBa;

        private CheckBox chkTivi;
        private CheckBox chkInternet;
        private CheckBox chkMayNuocNong;

        private CheckBox chkKaraoke;
        private CheckBox chkAnSang;

        private TextBox txtThanhTien;
        private TextBox txtTongSoLuot;
        private TextBox txtTongSoTien;

        private Button btnThanhToan;
        private Button btnNhapMoi;
        private Button btnTongKet;
        private Button btnThoat;

        private ErrorProvider errorProvider1;

        private int tongSoLuot = 0;
        private decimal tongSoTien = 0;

        public frmBaiTapVeNha()
        {
            InitializeComponent();
            TaoGiaoDien();
            KhoiTaoForm();
        }

        private void TaoGiaoDien()
        {
            Text = "Khách sạn Thanh Thanh - Trả phòng";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(720, 430);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Font = new Font("Tahoma", 9F);

            Label lblTieuDe = new Label();
            lblTieuDe.Text = "KHÁCH SẠN THANH THANH - TRẢ PHÒNG";
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font(
                "Tahoma",
                15F,
                FontStyle.Bold
            );
            lblTieuDe.ForeColor = Color.DarkOrange;
            lblTieuDe.Location = new Point(150, 20);

            Label lblHoTen = new Label();
            lblHoTen.Text = "Họ và tên:";
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(35, 75);

            txtHoTen = new TextBox();
            txtHoTen.Location = new Point(110, 70);
            txtHoTen.Size = new Size(200, 23);

            Label lblDiaChi = new Label();
            lblDiaChi.Text = "Địa chỉ:";
            lblDiaChi.AutoSize = true;
            lblDiaChi.Location = new Point(35, 110);

            txtDiaChi = new TextBox();
            txtDiaChi.Location = new Point(110, 105);
            txtDiaChi.Size = new Size(200, 23);

            Label lblSoNgay = new Label();
            lblSoNgay.Text = "Số ngày ở:";
            lblSoNgay.AutoSize = true;
            lblSoNgay.Location = new Point(35, 145);

            txtSoNgayO = new TextBox();
            txtSoNgayO.Location = new Point(110, 140);
            txtSoNgayO.Size = new Size(80, 23);

            txtSoNgayO.KeyPress += txtSoNgayO_KeyPress;

            GroupBox grpLoaiPhong = new GroupBox();
            grpLoaiPhong.Text = "Loại phòng";
            grpLoaiPhong.Location = new Point(35, 185);
            grpLoaiPhong.Size = new Size(150, 135);

            rdoPhongDon = new RadioButton();
            rdoPhongDon.Text = "Phòng đơn";
            rdoPhongDon.Location = new Point(15, 30);
            rdoPhongDon.AutoSize = true;

            rdoPhongDoi = new RadioButton();
            rdoPhongDoi.Text = "Phòng đôi";
            rdoPhongDoi.Location = new Point(15, 65);
            rdoPhongDoi.AutoSize = true;

            rdoPhongBa = new RadioButton();
            rdoPhongBa.Text = "Phòng ba";
            rdoPhongBa.Location = new Point(15, 100);
            rdoPhongBa.AutoSize = true;

            grpLoaiPhong.Controls.Add(rdoPhongDon);
            grpLoaiPhong.Controls.Add(rdoPhongDoi);
            grpLoaiPhong.Controls.Add(rdoPhongBa);

            GroupBox grpTienNghi = new GroupBox();
            grpTienNghi.Text = "Tiện nghi";
            grpTienNghi.Location = new Point(200, 185);
            grpTienNghi.Size = new Size(150, 135);

            chkTivi = new CheckBox();
            chkTivi.Text = "Tivi";
            chkTivi.Location = new Point(15, 30);
            chkTivi.AutoSize = true;

            chkInternet = new CheckBox();
            chkInternet.Text = "Internet";
            chkInternet.Location = new Point(15, 65);
            chkInternet.AutoSize = true;

            chkMayNuocNong = new CheckBox();
            chkMayNuocNong.Text = "Máy nước nóng";
            chkMayNuocNong.Location = new Point(15, 100);
            chkMayNuocNong.AutoSize = true;

            grpTienNghi.Controls.Add(chkTivi);
            grpTienNghi.Controls.Add(chkInternet);
            grpTienNghi.Controls.Add(chkMayNuocNong);

            GroupBox grpDichVu = new GroupBox();
            grpDichVu.Text = "Dịch vụ";
            grpDichVu.Location = new Point(365, 185);
            grpDichVu.Size = new Size(135, 135);

            chkKaraoke = new CheckBox();
            chkKaraoke.Text = "Karaoke";
            chkKaraoke.Location = new Point(15, 35);
            chkKaraoke.AutoSize = true;

            chkAnSang = new CheckBox();
            chkAnSang.Text = "Ăn sáng";
            chkAnSang.Location = new Point(15, 75);
            chkAnSang.AutoSize = true;

            grpDichVu.Controls.Add(chkKaraoke);
            grpDichVu.Controls.Add(chkAnSang);

            btnThanhToan = new Button();
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.Location = new Point(530, 70);
            btnThanhToan.Size = new Size(130, 35);
            btnThanhToan.Click += btnThanhToan_Click;

            btnNhapMoi = new Button();
            btnNhapMoi.Text = "Nhập mới";
            btnNhapMoi.Location = new Point(530, 115);
            btnNhapMoi.Size = new Size(130, 35);
            btnNhapMoi.Click += btnNhapMoi_Click;

            Label lblThanhTien = new Label();
            lblThanhTien.Text = "Thành tiền:";
            lblThanhTien.AutoSize = true;
            lblThanhTien.Location = new Point(530, 170);

            txtThanhTien = new TextBox();
            txtThanhTien.Location = new Point(530, 195);
            txtThanhTien.Size = new Size(130, 23);
            txtThanhTien.ReadOnly = true;

            btnTongKet = new Button();
            btnTongKet.Text = "Tổng kết";
            btnTongKet.Location = new Point(530, 235);
            btnTongKet.Size = new Size(130, 35);
            btnTongKet.Click += btnTongKet_Click;

            Label lblThongKe = new Label();
            lblThongKe.Text = "Thông tin tổng kết";
            lblThongKe.Font = new Font(
                "Tahoma",
                9F,
                FontStyle.Bold
            );
            lblThongKe.AutoSize = true;
            lblThongKe.Location = new Point(530, 290);

            Label lblTongLuot = new Label();
            lblTongLuot.Text = "Số lượt người:";
            lblTongLuot.AutoSize = true;
            lblTongLuot.Location = new Point(530, 320);

            txtTongSoLuot = new TextBox();
            txtTongSoLuot.Location = new Point(620, 315);
            txtTongSoLuot.Size = new Size(60, 23);
            txtTongSoLuot.ReadOnly = true;

            Label lblTongTien = new Label();
            lblTongTien.Text = "Tổng số tiền:";
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new Point(530, 350);

            txtTongSoTien = new TextBox();
            txtTongSoTien.Location = new Point(620, 345);
            txtTongSoTien.Size = new Size(60, 23);
            txtTongSoTien.ReadOnly = true;

            btnThoat = new Button();
            btnThoat.Text = "Thoát";
            btnThoat.Location = new Point(365, 345);
            btnThoat.Size = new Size(135, 35);
            btnThoat.Click += btnThoat_Click;

            errorProvider1 = new ErrorProvider();
            errorProvider1.ContainerControl = this;

            txtHoTen.TextChanged += KiemTraDuLieuNhap;
            txtDiaChi.TextChanged += KiemTraDuLieuNhap;
            txtSoNgayO.TextChanged += KiemTraDuLieuNhap;

            rdoPhongDon.CheckedChanged += KiemTraDuLieuNhap;
            rdoPhongDoi.CheckedChanged += KiemTraDuLieuNhap;
            rdoPhongBa.CheckedChanged += KiemTraDuLieuNhap;

            FormClosing += frmBaiTapVeNha_FormClosing;

            Controls.Add(lblTieuDe);

            Controls.Add(lblHoTen);
            Controls.Add(txtHoTen);

            Controls.Add(lblDiaChi);
            Controls.Add(txtDiaChi);

            Controls.Add(lblSoNgay);
            Controls.Add(txtSoNgayO);

            Controls.Add(grpLoaiPhong);
            Controls.Add(grpTienNghi);
            Controls.Add(grpDichVu);

            Controls.Add(btnThanhToan);
            Controls.Add(btnNhapMoi);

            Controls.Add(lblThanhTien);
            Controls.Add(txtThanhTien);

            Controls.Add(btnTongKet);

            Controls.Add(lblThongKe);
            Controls.Add(lblTongLuot);
            Controls.Add(txtTongSoLuot);

            Controls.Add(lblTongTien);
            Controls.Add(txtTongSoTien);

            Controls.Add(btnThoat);
        }

        private void KhoiTaoForm()
        {
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtSoNgayO.Clear();
            txtThanhTien.Clear();

            rdoPhongDon.Checked = false;
            rdoPhongDoi.Checked = false;
            rdoPhongBa.Checked = false;

            chkTivi.Checked = false;
            chkInternet.Checked = false;
            chkMayNuocNong.Checked = false;

            chkKaraoke.Checked = false;
            chkAnSang.Checked = false;

            btnThanhToan.Enabled = false;
            btnNhapMoi.Enabled = false;
            btnTongKet.Enabled = false;

            errorProvider1.Clear();

            txtHoTen.Focus();
        }

        private void KiemTraDuLieuNhap(object? sender, EventArgs e)
        {
            bool coTen =
                !string.IsNullOrWhiteSpace(txtHoTen.Text);

            bool coDiaChi =
                !string.IsNullOrWhiteSpace(txtDiaChi.Text);

            bool soNgayHopLe =
                int.TryParse(txtSoNgayO.Text, out int soNgay)
                && soNgay > 0;

            bool coLoaiPhong =
                rdoPhongDon.Checked
                || rdoPhongDoi.Checked
                || rdoPhongBa.Checked;

            btnThanhToan.Enabled =
                coTen
                && coDiaChi
                && soNgayHopLe
                && coLoaiPhong;
        }

        private decimal TinhTien()
        {
            int soNgay = int.Parse(txtSoNgayO.Text);

            decimal tienPhong = 0;

            if (rdoPhongDon.Checked)
            {
                tienPhong = 300000;
            }
            else if (rdoPhongDoi.Checked)
            {
                tienPhong = 350000;
            }
            else if (rdoPhongBa.Checked)
            {
                tienPhong = 400000;
            }

            decimal tong = tienPhong * soNgay;

            if (chkTivi.Checked)
                tong += 10000;

            if (chkInternet.Checked)
                tong += 10000;

            if (chkMayNuocNong.Checked)
                tong += 10000;

            if (chkKaraoke.Checked)
                tong += 50000;

            if (chkAnSang.Checked)
                tong += 15000 * soNgay;

            return tong;
        }

        private void btnThanhToan_Click(
            object? sender,
            EventArgs e)
        {
            if (!int.TryParse(txtSoNgayO.Text, out int soNgay)
                || soNgay <= 0)
            {
                errorProvider1.SetError(
                    txtSoNgayO,
                    "Số ngày ở phải lớn hơn 0!"
                );

                return;
            }

            errorProvider1.Clear();

            decimal thanhTien = TinhTien();

            txtThanhTien.Text =
                thanhTien.ToString("N0") + " VNĐ";

            tongSoLuot++;
            tongSoTien += thanhTien;

            btnNhapMoi.Enabled = true;
            btnTongKet.Enabled = true;

            btnThanhToan.Enabled = false;
        }

        private void btnNhapMoi_Click(
            object? sender,
            EventArgs e)
        {
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtSoNgayO.Clear();
            txtThanhTien.Clear();

            rdoPhongDon.Checked = false;
            rdoPhongDoi.Checked = false;
            rdoPhongBa.Checked = false;

            chkTivi.Checked = false;
            chkInternet.Checked = false;
            chkMayNuocNong.Checked = false;

            chkKaraoke.Checked = false;
            chkAnSang.Checked = false;

            errorProvider1.Clear();

            btnThanhToan.Enabled = false;
            btnNhapMoi.Enabled = false;

            btnTongKet.Enabled = tongSoLuot > 0;

            txtHoTen.Focus();
        }

        private void btnTongKet_Click(
            object? sender,
            EventArgs e)
        {
            txtTongSoLuot.Text =
                tongSoLuot.ToString();

            txtTongSoTien.Text =
                tongSoTien.ToString("N0") + " VNĐ";

            tongSoLuot = 0;
            tongSoTien = 0;

            btnTongKet.Enabled = false;
        }

        private void txtSoNgayO_KeyPress(
            object? sender,
            KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnThoat_Click(
            object? sender,
            EventArgs e)
        {
            Close();
        }

        private void frmBaiTapVeNha_FormClosing(
            object? sender,
            FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình không?",
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