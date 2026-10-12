using System;
using System.Drawing;
using System.Windows.Forms;

namespace TH05d
{
    public partial class frmDemNguoc : Form
    {
        private Label lblThoiGian;
        private Button btnBatDau;

        private System.Windows.Forms.Timer timer;

        private int tongSoGiay = 30 * 60;

        public frmDemNguoc()
        {
            InitializeComponent();
            TaoGiaoDien();
        }

        private void TaoGiaoDien()
        {
            Text = "Đồng hồ";
            StartPosition = FormStartPosition.CenterScreen;

            ClientSize = new Size(300, 200);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Font = new Font("Tahoma", 10F);

            lblThoiGian = new Label();

            lblThoiGian.Text = "30:00";

            lblThoiGian.Font =
                new Font(
                    "Tahoma",
                    22F,
                    FontStyle.Bold
                );

            lblThoiGian.AutoSize = true;

            lblThoiGian.Location =
                new Point(105, 45);

            btnBatDau = new Button();

            btnBatDau.Text = "Bắt đầu";

            btnBatDau.Location =
                new Point(95, 105);

            btnBatDau.Size =
                new Size(110, 40);

            btnBatDau.Click +=
                btnBatDau_Click;

            timer =
                new System.Windows.Forms.Timer();

            timer.Interval = 1000;

            timer.Tick += timer_Tick;

            Controls.Add(lblThoiGian);
            Controls.Add(btnBatDau);
        }

        private void btnBatDau_Click(
            object? sender,
            EventArgs e)
        {
            if (!timer.Enabled)
            {
                timer.Start();

                btnBatDau.Text = "Dừng";
            }
            else
            {
                timer.Stop();

                btnBatDau.Text = "Tiếp tục";
            }
        }

        private void timer_Tick(
            object? sender,
            EventArgs e)
        {
            if (tongSoGiay > 0)
            {
                tongSoGiay--;

                int phut =
                    tongSoGiay / 60;

                int giay =
                    tongSoGiay % 60;

                lblThoiGian.Text =
                    $"{phut:00}:{giay:00}";
            }
            else
            {
                timer.Stop();

                lblThoiGian.Text = "00:00";

                btnBatDau.Text = "Bắt đầu";

                MessageBox.Show(
                    "Đã hết thời gian!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
    }
}