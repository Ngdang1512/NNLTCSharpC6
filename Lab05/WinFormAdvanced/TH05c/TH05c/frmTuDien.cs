using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TH05c
{
    public partial class frmTuDien : Form
    {
        private ComboBox cboAnh;
        private ComboBox cboViet;

        private TextBox txtNghiaViet;
        private TextBox txtNghiaAnh;

        private ListBox lstAnh;
        private ListBox lstViet;

        private Button btnTraAnh;
        private Button btnTraViet;
        private Button btnThoat;

        private TabControl tabControl;

        private readonly List<KeyValuePair<string, string>> tuDien =
            new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("student", "sinh viên, học sinh"),
                new KeyValuePair<string, string>("teacher", "giáo viên"),
                new KeyValuePair<string, string>("worker", "công nhân"),
                new KeyValuePair<string, string>("hat", "cái nón"),
                new KeyValuePair<string, string>("head", "cái đầu"),
                new KeyValuePair<string, string>("mouse", "con chuột"),
                new KeyValuePair<string, string>("cat", "con mèo"),
                new KeyValuePair<string, string>("dog", "con chó"),
                new KeyValuePair<string, string>("snake", "con rắn"),
                new KeyValuePair<string, string>("lamb", "con cừu"),
                new KeyValuePair<string, string>("loan", "khoản vay"),
                new KeyValuePair<string, string>("frog", "con ếch"),
                new KeyValuePair<string, string>("sheep", "con cừu")
            };

        public frmTuDien()
        {
            InitializeComponent();

            TaoGiaoDien();
            NapDuLieu();
        }

        private void TaoGiaoDien()
        {
            Text = "TỪ ĐIỂN ANH VIỆT - VIỆT ANH";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(650, 470);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Font = new Font("Tahoma", 10F);

            tabControl = new TabControl();

            tabControl.Location = new Point(20, 20);
            tabControl.Size = new Size(610, 380);

            TabPage tabAnhViet =
                new TabPage("ANH - VIỆT");

            TabPage tabVietAnh =
                new TabPage("VIỆT - ANH");


            Label lblAnh = new Label();

            lblAnh.Text = "Tiếng Anh";
            lblAnh.Location = new Point(20, 25);
            lblAnh.AutoSize = true;

            cboAnh = new ComboBox();

            cboAnh.Location = new Point(20, 50);
            cboAnh.Size = new Size(240, 30);

            cboAnh.DropDownStyle =
                ComboBoxStyle.DropDown;

            cboAnh.AutoCompleteMode =
                AutoCompleteMode.SuggestAppend;

            cboAnh.AutoCompleteSource =
                AutoCompleteSource.ListItems;

            cboAnh.KeyDown += cboAnh_KeyDown;

            lstAnh = new ListBox();

            lstAnh.Location = new Point(20, 90);
            lstAnh.Size = new Size(240, 220);

            lstAnh.SelectedIndexChanged +=
                lstAnh_SelectedIndexChanged;

            lstAnh.DoubleClick +=
                lstAnh_DoubleClick;

            Label lblViet = new Label();

            lblViet.Text = "Tiếng Việt";
            lblViet.Location = new Point(320, 25);
            lblViet.AutoSize = true;

            txtNghiaViet = new TextBox();

            txtNghiaViet.Location =
                new Point(320, 50);

            txtNghiaViet.Size =
                new Size(240, 260);

            txtNghiaViet.Multiline = true;
            txtNghiaViet.ReadOnly = true;

            btnTraAnh = new Button();

            btnTraAnh.Text = "Enter";
            btnTraAnh.Location =
                new Point(20, 320);

            btnTraAnh.Size =
                new Size(110, 35);

            btnTraAnh.Click +=
                btnTraAnh_Click;

            tabAnhViet.Controls.Add(lblAnh);
            tabAnhViet.Controls.Add(cboAnh);
            tabAnhViet.Controls.Add(lstAnh);

            tabAnhViet.Controls.Add(lblViet);
            tabAnhViet.Controls.Add(txtNghiaViet);

            tabAnhViet.Controls.Add(btnTraAnh);

            Label lblViet2 = new Label();

            lblViet2.Text = "Tiếng Việt";
            lblViet2.Location =
                new Point(20, 25);

            lblViet2.AutoSize = true;

            cboViet = new ComboBox();

            cboViet.Location =
                new Point(20, 50);

            cboViet.Size =
                new Size(240, 30);

            cboViet.DropDownStyle =
                ComboBoxStyle.DropDown;

            cboViet.AutoCompleteMode =
                AutoCompleteMode.SuggestAppend;

            cboViet.AutoCompleteSource =
                AutoCompleteSource.ListItems;

            cboViet.KeyDown +=
                cboViet_KeyDown;

            lstViet = new ListBox();

            lstViet.Location =
                new Point(20, 90);

            lstViet.Size =
                new Size(240, 220);

            lstViet.SelectedIndexChanged +=
                lstViet_SelectedIndexChanged;

            lstViet.DoubleClick +=
                lstViet_DoubleClick;

            Label lblAnh2 = new Label();

            lblAnh2.Text = "Tiếng Anh";
            lblAnh2.Location =
                new Point(320, 25);

            lblAnh2.AutoSize = true;

            txtNghiaAnh = new TextBox();

            txtNghiaAnh.Location =
                new Point(320, 50);

            txtNghiaAnh.Size =
                new Size(240, 260);

            txtNghiaAnh.Multiline = true;
            txtNghiaAnh.ReadOnly = true;

            btnTraViet = new Button();

            btnTraViet.Text = "Enter";

            btnTraViet.Location =
                new Point(20, 320);

            btnTraViet.Size =
                new Size(110, 35);

            btnTraViet.Click +=
                btnTraViet_Click;

            tabVietAnh.Controls.Add(lblViet2);
            tabVietAnh.Controls.Add(cboViet);
            tabVietAnh.Controls.Add(lstViet);

            tabVietAnh.Controls.Add(lblAnh2);
            tabVietAnh.Controls.Add(txtNghiaAnh);

            tabVietAnh.Controls.Add(btnTraViet);

            tabControl.TabPages.Add(tabAnhViet);
            tabControl.TabPages.Add(tabVietAnh);

            btnThoat = new Button();

            btnThoat.Text = "Thoát";

            btnThoat.Location =
                new Point(510, 415);

            btnThoat.Size =
                new Size(120, 35);

            btnThoat.Click += btnThoat_Click;


            Controls.Add(tabControl);
            Controls.Add(btnThoat);

            FormClosing +=
                frmTuDien_FormClosing;
        }

        private void NapDuLieu()
        {
            foreach (var item in tuDien)
            {
                cboAnh.Items.Add(item.Key);
                lstAnh.Items.Add(item.Key);

                cboViet.Items.Add(item.Value);
                lstViet.Items.Add(item.Value);
            }
        }

        private void btnTraAnh_Click(
            object? sender,
            EventArgs e)
        {
            string tu;

            if (lstAnh.SelectedItem != null)
            {
                tu =
                    lstAnh.SelectedItem.ToString()!;
            }
            else
            {
                tu =
                    cboAnh.Text.Trim();
            }

            if (string.IsNullOrWhiteSpace(tu))
            {
                MessageBox.Show(
                    "Vui lòng chọn hoặc nhập từ cần tra.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            var ketQua =
                tuDien.FirstOrDefault(
                    x => x.Key.Equals(
                        tu,
                        StringComparison.OrdinalIgnoreCase));

            if (!ketQua.Equals(
                default(KeyValuePair<string, string>)))
            {
                txtNghiaViet.Text =
                    ketQua.Value;
            }
            else
            {
                txtNghiaViet.Text =
                    "Không tìm thấy từ.";
            }
        }

        private void btnTraViet_Click(
            object? sender,
            EventArgs e)
        {
            string tu;

            // Nếu đang chọn từ trong ListBox
            if (lstViet.SelectedItem != null)
            {
                tu =
                    lstViet.SelectedItem.ToString()!;
            }
            else
            {
                tu =
                    cboViet.Text.Trim();
            }

            if (string.IsNullOrWhiteSpace(tu))
            {
                MessageBox.Show(
                    "Vui lòng chọn hoặc nhập từ cần tra.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            var ketQua =
                tuDien.FirstOrDefault(
                    x => x.Value.Equals(
                        tu,
                        StringComparison.OrdinalIgnoreCase));

            if (!ketQua.Equals(
                default(KeyValuePair<string, string>)))
            {
                txtNghiaAnh.Text =
                    ketQua.Key;
            }
            else
            {
                txtNghiaAnh.Text =
                    "Không tìm thấy từ.";
            }
        }

        private void lstAnh_SelectedIndexChanged(
            object? sender,
            EventArgs e)
        {
            if (lstAnh.SelectedItem != null)
            {
                cboAnh.Text =
                    lstAnh.SelectedItem.ToString();
            }
        }

        private void lstViet_SelectedIndexChanged(
            object? sender,
            EventArgs e)
        {
            if (lstViet.SelectedItem != null)
            {
                cboViet.Text =
                    lstViet.SelectedItem.ToString();
            }
        }

        private void lstAnh_DoubleClick(
            object? sender,
            EventArgs e)
        {
            if (lstAnh.SelectedItem == null)
                return;

            cboAnh.Text =
                lstAnh.SelectedItem.ToString();

            btnTraAnh.PerformClick();
        }

        private void lstViet_DoubleClick(
            object? sender,
            EventArgs e)
        {
            if (lstViet.SelectedItem == null)
                return;

            cboViet.Text =
                lstViet.SelectedItem.ToString();

            btnTraViet.PerformClick();
        }

        private void cboAnh_KeyDown(
            object? sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Bỏ lựa chọn ListBox cũ
                // để ưu tiên từ đang gõ trong ComboBox
                lstAnh.ClearSelected();

                btnTraAnh.PerformClick();

                e.SuppressKeyPress = true;
            }
        }

        private void cboViet_KeyDown(
            object? sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lstViet.ClearSelected();

                btnTraViet.PerformClick();

                e.SuppressKeyPress = true;
            }
        }

        private void btnThoat_Click(
            object? sender,
            EventArgs e)
        {
            Close();
        }

        private void frmTuDien_FormClosing(
            object? sender,
            FormClosingEventArgs e)
        {
            DialogResult r =
                MessageBox.Show(
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