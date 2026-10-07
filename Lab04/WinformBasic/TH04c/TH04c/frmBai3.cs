namespace TH04c
{
    public partial class frmBai3 : Form
    {
        private TextBox txtA;
        private TextBox txtB;
        private TextBox txtUCLN;
        private TextBox txtBCNN;

        private Button btnThucHien;
        private Button btnTiepTuc;
        private Button btnThoat;

        private ErrorProvider errorProvider1;

        public frmBai3()
        {
            InitializeComponent();
            TaoGiaoDien();
        }

        private void TaoGiaoDien()
        {
            Text = "Ước Số - Bội Số";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(380, 270);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Font = new Font("Tahoma", 9F, FontStyle.Regular);

            Label lblTieuDe = new Label();
            lblTieuDe.Text = "Ước Số Chung - Bội Số Chung";
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Tahoma", 13F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.Red;
            lblTieuDe.Location = new Point(55, 20);

            Label lblA = new Label();
            lblA.Text = "Nhập số a:";
            lblA.AutoSize = true;
            lblA.Location = new Point(65, 70);

            txtA = new TextBox();
            txtA.Location = new Point(175, 66);
            txtA.Size = new Size(120, 22);

            Label lblB = new Label();
            lblB.Text = "Nhập số b:";
            lblB.AutoSize = true;
            lblB.Location = new Point(65, 105);

            txtB = new TextBox();
            txtB.Location = new Point(175, 101);
            txtB.Size = new Size(120, 22);

            Label lblUCLN = new Label();
            lblUCLN.Text = "Ước số chung lớn nhất:";
            lblUCLN.AutoSize = true;
            lblUCLN.Location = new Point(35, 140);

            txtUCLN = new TextBox();
            txtUCLN.Location = new Point(175, 136);
            txtUCLN.Size = new Size(120, 22);
            txtUCLN.ReadOnly = true;

            Label lblBCNN = new Label();
            lblBCNN.Text = "Bội số chung nhỏ nhất:";
            lblBCNN.AutoSize = true;
            lblBCNN.Location = new Point(35, 175);

            txtBCNN = new TextBox();
            txtBCNN.Location = new Point(175, 171);
            txtBCNN.Size = new Size(120, 22);
            txtBCNN.ReadOnly = true;

            btnThucHien = new Button();
            btnThucHien.Text = "Thực Hiện";
            btnThucHien.Location = new Point(45, 215);
            btnThucHien.Size = new Size(90, 32);
            btnThucHien.Click += btnThucHien_Click;

            btnTiepTuc = new Button();
            btnTiepTuc.Text = "Tiếp Tục";
            btnTiepTuc.Location = new Point(145, 215);
            btnTiepTuc.Size = new Size(90, 32);
            btnTiepTuc.Click += btnTiepTuc_Click;

            btnThoat = new Button();
            btnThoat.Text = "Thoát";
            btnThoat.Location = new Point(245, 215);
            btnThoat.Size = new Size(90, 32);
            btnThoat.Click += btnThoat_Click;

            errorProvider1 = new ErrorProvider();
            errorProvider1.ContainerControl = this;

            txtA.KeyPress += txtSo_KeyPress;
            txtB.KeyPress += txtSo_KeyPress;

            FormClosing += frmBai3_FormClosing;

            Controls.Add(lblTieuDe);

            Controls.Add(lblA);
            Controls.Add(txtA);

            Controls.Add(lblB);
            Controls.Add(txtB);

            Controls.Add(lblUCLN);
            Controls.Add(txtUCLN);

            Controls.Add(lblBCNN);
            Controls.Add(txtBCNN);

            Controls.Add(btnThucHien);
            Controls.Add(btnTiepTuc);
            Controls.Add(btnThoat);
        }

        private bool KiemTraDuLieu(out int a, out int b)
        {
            errorProvider1.Clear();

            bool hopLeA = int.TryParse(txtA.Text, out a);
            bool hopLeB = int.TryParse(txtB.Text, out b);

            if (!hopLeA)
            {
                errorProvider1.SetError(
                    txtA,
                    "Vui lòng nhập số nguyên a!"
                );
            }

            if (!hopLeB)
            {
                errorProvider1.SetError(
                    txtB,
                    "Vui lòng nhập số nguyên b!"
                );
            }

            return hopLeA && hopLeB;
        }

        private int UCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (b != 0)
            {
                int temp = a % b;
                a = b;
                b = temp;
            }

            return a;
        }

        private int BCNN(int a, int b)
        {
            if (a == 0 || b == 0)
                return 0;

            return Math.Abs(a / UCLN(a, b) * b);
        }

        private void btnThucHien_Click(object? sender, EventArgs e)
        {
            if (!KiemTraDuLieu(out int a, out int b))
                return;

            if (a == 0 && b == 0)
            {
                MessageBox.Show(
                    "Không thể tính UCLN và BCNN khi cả a và b đều bằng 0.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            txtUCLN.Text = UCLN(a, b).ToString();
            txtBCNN.Text = BCNN(a, b).ToString();
        }

        private void btnTiepTuc_Click(object? sender, EventArgs e)
        {
            txtA.Clear();
            txtB.Clear();
            txtUCLN.Clear();
            txtBCNN.Clear();

            errorProvider1.Clear();

            txtA.Focus();
        }

        private void btnThoat_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void txtSo_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void frmBai3_FormClosing(
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