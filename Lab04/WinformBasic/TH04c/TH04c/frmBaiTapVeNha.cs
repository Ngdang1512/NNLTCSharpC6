namespace TH04c
{
    public partial class frmBaiTapVeNha : Form
    {
        private TextBox txtManHinh;

        private double soThuNhat = 0;
        private string phepTinh = "";
        private bool batDauSoMoi = true;

        public frmBaiTapVeNha()
        {
            InitializeComponent();
            TaoGiaoDien();
        }

        private void TaoGiaoDien()
        {
            Text = "Máy Tính Bỏ Túi";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(310, 400);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Font = new Font("Tahoma", 11F);

            Label lblTieuDe = new Label();
            lblTieuDe.Text = "MÁY TÍNH BỎ TÚI";
            lblTieuDe.Font = new Font("Tahoma", 16F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.Blue;
            lblTieuDe.AutoSize = true;
            lblTieuDe.Location = new Point(52, 20);

            txtManHinh = new TextBox();
            txtManHinh.Location = new Point(25, 65);
            txtManHinh.Size = new Size(260, 35);
            txtManHinh.Font = new Font("Tahoma", 16F);
            txtManHinh.Text = "0";
            txtManHinh.ReadOnly = true;
            txtManHinh.TextAlign = HorizontalAlignment.Right;

            TaoButtonSo("7", 25, 120);
            TaoButtonSo("8", 90, 120);
            TaoButtonSo("9", 155, 120);
            TaoButtonPhepTinh("/", 220, 120);

            TaoButtonSo("4", 25, 175);
            TaoButtonSo("5", 90, 175);
            TaoButtonSo("6", 155, 175);
            TaoButtonPhepTinh("x", 220, 175);

            TaoButtonSo("1", 25, 230);
            TaoButtonSo("2", 90, 230);
            TaoButtonSo("3", 155, 230);
            TaoButtonPhepTinh("-", 220, 230);

            TaoButtonSo("0", 25, 285);

            Button btnXoa = TaoButton("C", 90, 285);
            btnXoa.Click += btnXoa_Click;

            Button btnBang = TaoButton("=", 155, 285);
            btnBang.Click += btnBang_Click;

            TaoButtonPhepTinh("+", 220, 285);

            Button btnThoat = new Button();
            btnThoat.Text = "Thoát";
            btnThoat.Location = new Point(90, 345);
            btnThoat.Size = new Size(130, 35);
            btnThoat.Click += btnThoat_Click;

            Controls.Add(lblTieuDe);
            Controls.Add(txtManHinh);
            Controls.Add(btnThoat);

            FormClosing += frmBaiTapVeNha_FormClosing;
        }

        private Button TaoButton(string text, int x, int y)
        {
            Button btn = new Button();

            btn.Text = text;
            btn.Location = new Point(x, y);
            btn.Size = new Size(55, 45);
            btn.Font = new Font("Tahoma", 12F, FontStyle.Bold);

            Controls.Add(btn);

            return btn;
        }

        private void TaoButtonSo(string so, int x, int y)
        {
            Button btn = TaoButton(so, x, y);
            btn.Click += btnSo_Click;
        }

        private void TaoButtonPhepTinh(string phepTinh, int x, int y)
        {
            Button btn = TaoButton(phepTinh, x, y);
            btn.Click += btnPhepTinh_Click;
        }

        private void btnSo_Click(object? sender, EventArgs e)
        {
            Button btn = (Button)sender!;

            if (txtManHinh.Text == "0" || batDauSoMoi)
            {
                txtManHinh.Text = btn.Text;
                batDauSoMoi = false;
            }
            else
            {
                txtManHinh.Text += btn.Text;
            }
        }

        private void btnPhepTinh_Click(object? sender, EventArgs e)
        {
            Button btn = (Button)sender!;

            soThuNhat = double.Parse(txtManHinh.Text);
            phepTinh = btn.Text;

            batDauSoMoi = true;
        }

        private void btnBang_Click(object? sender, EventArgs e)
        {
            if (phepTinh == "")
                return;

            double soThuHai = double.Parse(txtManHinh.Text);
            double ketQua = 0;

            switch (phepTinh)
            {
                case "+":
                    ketQua = soThuNhat + soThuHai;
                    break;

                case "-":
                    ketQua = soThuNhat - soThuHai;
                    break;

                case "x":
                    ketQua = soThuNhat * soThuHai;
                    break;

                case "/":
                    if (soThuHai == 0)
                    {
                        MessageBox.Show(
                            "Không thể chia cho 0!",
                            "Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );

                        return;
                    }

                    ketQua = soThuNhat / soThuHai;
                    break;
            }

            txtManHinh.Text = ketQua.ToString();

            phepTinh = "";
            batDauSoMoi = true;
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            txtManHinh.Text = "0";

            soThuNhat = 0;
            phepTinh = "";
            batDauSoMoi = true;
        }

        private void btnThoat_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void frmBaiTapVeNha_FormClosing(
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