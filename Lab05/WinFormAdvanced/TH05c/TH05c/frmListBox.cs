namespace TH05c
{
    public partial class frmListBox : Form
    {
        private TextBox txtNhap;
        private ListBox lstSo;

        public frmListBox()
        {
            InitializeComponent();
            TaoGiaoDien();
        }

        private void TaoGiaoDien()
        {
            Text = "ListBox";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(650, 520);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Font = new Font("Tahoma", 10F);

            Label lblTieuDe = new Label
            {
                Text = "LISTBOX",
                Font = new Font("Tahoma", 18F, FontStyle.Bold),
                ForeColor = Color.DarkOrange,
                AutoSize = true,
                Location = new Point(280, 20)
            };

            Label lblNhap = new Label
            {
                Text = "Nhập số tự nhiên N",
                Location = new Point(30, 75),
                AutoSize = true
            };

            txtNhap = new TextBox
            {
                Location = new Point(30, 100),
                Size = new Size(200, 30)
            };

            Button btnNhap = new Button
            {
                Text = "Nhập",
                Location = new Point(30, 140),
                Size = new Size(200, 35)
            };

            btnNhap.Click += btnNhap_Click;

            lstSo = new ListBox
            {
                Location = new Point(30, 190),
                Size = new Size(200, 240),
                SelectionMode = SelectionMode.MultiExtended
            };

            string[] tenNut =
            {
                "Tổng các phần tử trong List",
                "Xóa phần tử đầu và cuối",
                "Xóa phần tử đang chọn",
                "Tăng mỗi phần tử lên 2",
                "Thay bằng bình phương",
                "Chọn số chẵn",
                "Chọn số lẻ"
            };

            EventHandler[] events =
            {
                btnTong_Click,
                btnXoaDauCuoi_Click,
                btnXoaChon_Click,
                btnTangHai_Click,
                btnBinhPhuong_Click,
                btnChonChan_Click,
                btnChonLe_Click
            };

            for (int i = 0; i < tenNut.Length; i++)
            {
                Button btn = new Button
                {
                    Text = tenNut[i],
                    Location = new Point(290, 80 + i * 52),
                    Size = new Size(300, 38)
                };

                btn.Click += events[i];
                Controls.Add(btn);
            }

            Button btnKetThuc = new Button
            {
                Text = "KẾT THÚC",
                Location = new Point(30, 450),
                Size = new Size(560, 40)
            };

            btnKetThuc.Click += (s, e) => Close();

            txtNhap.KeyPress += txtNhap_KeyPress;

            Controls.AddRange(new Control[]
            {
                lblTieuDe,
                lblNhap,
                txtNhap,
                btnNhap,
                lstSo,
                btnKetThuc
            });
        }

        private void btnNhap_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtNhap.Text, out int n) || n < 0)
            {
                MessageBox.Show("Vui lòng nhập số tự nhiên.");
                return;
            }

            lstSo.Items.Add(n);

            txtNhap.Clear();
            txtNhap.Focus();
        }

        private void btnTong_Click(object? sender, EventArgs e)
        {
            int tong = 0;

            foreach (var item in lstSo.Items)
                tong += Convert.ToInt32(item);

            MessageBox.Show(
                "Tổng các phần tử = " + tong);
        }

        private void btnXoaDauCuoi_Click(
            object? sender,
            EventArgs e)
        {
            if (lstSo.Items.Count == 0)
                return;

            if (lstSo.Items.Count == 1)
            {
                lstSo.Items.Clear();
                return;
            }

            lstSo.Items.RemoveAt(lstSo.Items.Count - 1);
            lstSo.Items.RemoveAt(0);
        }

        private void btnXoaChon_Click(
            object? sender,
            EventArgs e)
        {
            while (lstSo.SelectedItems.Count > 0)
            {
                lstSo.Items.Remove(
                    lstSo.SelectedItems[0]);
            }
        }

        private void btnTangHai_Click(
            object? sender,
            EventArgs e)
        {
            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                int x = Convert.ToInt32(lstSo.Items[i]);
                lstSo.Items[i] = x + 2;
            }
        }

        private void btnBinhPhuong_Click(
            object? sender,
            EventArgs e)
        {
            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                int x = Convert.ToInt32(lstSo.Items[i]);
                lstSo.Items[i] = x * x;
            }
        }

        private void btnChonChan_Click(
            object? sender,
            EventArgs e)
        {
            lstSo.ClearSelected();

            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                int x = Convert.ToInt32(lstSo.Items[i]);

                if (x % 2 == 0)
                    lstSo.SetSelected(i, true);
            }
        }

        private void btnChonLe_Click(
            object? sender,
            EventArgs e)
        {
            lstSo.ClearSelected();

            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                int x = Convert.ToInt32(lstSo.Items[i]);

                if (x % 2 != 0)
                    lstSo.SetSelected(i, true);
            }
        }

        private void txtNhap_KeyPress(
            object? sender,
            KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}