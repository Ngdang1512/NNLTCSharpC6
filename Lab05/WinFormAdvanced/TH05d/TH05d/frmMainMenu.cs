using System;
using System.Drawing;
using System.Windows.Forms;
using TH05c;

namespace TH05d
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
            TaoGiaoDien();
        }

        private void TaoGiaoDien()
        {
            Text = "BTVN_Tuan6";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(900, 600);

            IsMdiContainer = true;

            MenuStrip menu = new MenuStrip();

            ToolStripMenuItem menuBai1 =
                new ToolStripMenuItem("Từ điển");

            menuBai1.Click += menuBai1_Click;

            ToolStripMenuItem menuBai2 =
                new ToolStripMenuItem("ListBox");

            menuBai2.Click += menuBai2_Click;

            ToolStripMenuItem menuBai3 =
                new ToolStripMenuItem("Danh bạ");

            menuBai3.Click += menuBai3_Click;

            ToolStripMenuItem menuBai4 =
                new ToolStripMenuItem("Đếm ngược");

            menuBai4.Click += menuBai4_Click;

            ToolStripMenuItem menuKetThuc =
                new ToolStripMenuItem("Kết thúc");

            menuKetThuc.Click += menuKetThuc_Click;

            menu.Items.Add(menuBai1);
            menu.Items.Add(menuBai2);
            menu.Items.Add(menuBai3);
            menu.Items.Add(menuBai4);
            menu.Items.Add(menuKetThuc);

            MainMenuStrip = menu;

            Controls.Add(menu);
        }

        private void DongFormCon()
        {
            foreach (Form f in MdiChildren)
            {
                f.Close();
            }
        }

        private void menuBai1_Click(
            object? sender,
            EventArgs e)
        {
            DongFormCon();

            frmTuDien form =
                new frmTuDien();

            form.MdiParent = this;
            form.Show();
        }

        private void menuBai2_Click(
            object? sender,
            EventArgs e)
        {
            DongFormCon();

            frmListBox form =
                new frmListBox();

            form.MdiParent = this;
            form.Show();
        }

        private void menuBai3_Click(
            object? sender,
            EventArgs e)
        {
            DongFormCon();

            frmDanhBa form =
                new frmDanhBa();

            form.MdiParent = this;
            form.Show();
        }

        private void menuBai4_Click(
            object? sender,
            EventArgs e)
        {
            DongFormCon();

            frmDemNguoc form =
                new frmDemNguoc();

            form.MdiParent = this;
            form.Show();
        }

        private void menuKetThuc_Click(
            object? sender,
            EventArgs e)
        {
            DialogResult r =
                MessageBox.Show(
                    "Bạn có chắc chắn muốn thoát không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (r == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}