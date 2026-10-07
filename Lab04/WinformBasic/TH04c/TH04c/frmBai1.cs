namespace TH04c
{
    public partial class frmBai1 : Form
    {
        TextBox txtA;
        TextBox txtB;
        TextBox txtKetQua;

        Button btnCong;
        Button btnTru;
        Button btnNhan;
        Button btnChia;

        ErrorProvider errorProvider1;

        public frmBai1()
        {
            InitializeComponent();
            TaoGiaoDien();
        }

        private void TaoGiaoDien()
        {
            // Form
            this.Text = "Cộng trừ nhân chia";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(500, 300);

            // Label a
            Label lblA = new Label();
            lblA.Text = "a =";
            lblA.Location = new Point(60, 50);
            lblA.AutoSize = true;

            // TextBox a
            txtA = new TextBox();
            txtA.Location = new Point(120, 45);
            txtA.Size = new Size(120, 25);

            // Label b
            Label lblB = new Label();
            lblB.Text = "b =";
            lblB.Location = new Point(270, 50);
            lblB.AutoSize = true;

            // TextBox b
            txtB = new TextBox();
            txtB.Location = new Point(320, 45);
            txtB.Size = new Size(120, 25);

            // Label kết quả
            Label lblKetQua = new Label();
            lblKetQua.Text = "Kết quả";
            lblKetQua.Location = new Point(60, 100);
            lblKetQua.AutoSize = true;

            // TextBox kết quả
            txtKetQua = new TextBox();
            txtKetQua.Location = new Point(120, 95);
            txtKetQua.Size = new Size(320, 25);
            txtKetQua.ReadOnly = true;

            // Button +
            btnCong = new Button();
            btnCong.Text = "+";
            btnCong.Location = new Point(60, 150);
            btnCong.Size = new Size(80, 40);
            btnCong.Click += btnCong_Click;

            // Button -
            btnTru = new Button();
            btnTru.Text = "-";
            btnTru.Location = new Point(160, 150);
            btnTru.Size = new Size(80, 40);
            btnTru.Click += btnTru_Click;

            // Button x
            btnNhan = new Button();
            btnNhan.Text = "x";
            btnNhan.Location = new Point(260, 150);
            btnNhan.Size = new Size(80, 40);
            btnNhan.Click += btnNhan_Click;

            // Button /
            btnChia = new Button();
            btnChia.Text = "/";
            btnChia.Location = new Point(360, 150);
            btnChia.Size = new Size(80, 40);
            btnChia.Click += btnChia_Click;

            // ErrorProvider
            errorProvider1 = new ErrorProvider();
            errorProvider1.ContainerControl = this;

            // Chặn nhập chữ
            txtA.KeyPress += txtSo_KeyPress;
            txtB.KeyPress += txtSo_KeyPress;

            // Xác nhận đóng form
            this.FormClosing += frmBai1_FormClosing;

            // Add controls
            this.Controls.Add(lblA);
            this.Controls.Add(txtA);

            this.Controls.Add(lblB);
            this.Controls.Add(txtB);

            this.Controls.Add(lblKetQua);
            this.Controls.Add(txtKetQua);

            this.Controls.Add(btnCong);
            this.Controls.Add(btnTru);
            this.Controls.Add(btnNhan);
            this.Controls.Add(btnChia);
        }

        private bool KiemTraDuLieu(out double a, out double b)
        {
            errorProvider1.Clear();

            bool hopLeA = double.TryParse(txtA.Text, out a);
            bool hopLeB = double.TryParse(txtB.Text, out b);

            if (!hopLeA)
            {
                errorProvider1.SetError(
                    txtA,
                    "Vui lòng nhập số a!"
                );
            }

            if (!hopLeB)
            {
                errorProvider1.SetError(
                    txtB,
                    "Vui lòng nhập số b!"
                );
            }

            return hopLeA && hopLeB;
        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu(out double a, out double b))
            {
                txtKetQua.Text = (a + b).ToString();
            }
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu(out double a, out double b))
            {
                txtKetQua.Text = (a - b).ToString();
            }
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu(out double a, out double b))
            {
                txtKetQua.Text = (a * b).ToString();
            }
        }

        private void btnChia_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu(out double a, out double b))
            {
                if (b == 0)
                {
                    MessageBox.Show(
                        "Không thể chia cho 0!",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                txtKetQua.Text = (a / b).ToString();
            }
        }

        private void txtSo_KeyPress(
            object sender,
            KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '-'
                && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void frmBai1_FormClosing(
            object sender,
            FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show(
                "Bạn có muốn thoát chương trình không?",
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