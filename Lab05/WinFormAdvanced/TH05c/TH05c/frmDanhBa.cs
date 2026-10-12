namespace TH05c
{
    public partial class frmDanhBa : Form
    {
        private TreeView trvDanhBa;
        private TextBox txtFirstName;
        private TextBox txtLastName;

        public frmDanhBa()
        {
            InitializeComponent();
            TaoGiaoDien();
            TaoNodeAZ();
        }

        private void TaoGiaoDien()
        {
            Text = "Danh bạ";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(600, 500);

            Font = new Font("Tahoma", 10F);

            trvDanhBa = new TreeView
            {
                Location = new Point(20, 20),
                Size = new Size(260, 440)
            };

            Label lblFirst = new Label
            {
                Text = "First Name",
                Location = new Point(320, 80),
                AutoSize = true
            };

            txtFirstName = new TextBox
            {
                Location = new Point(410, 75),
                Size = new Size(150, 28)
            };

            Label lblLast = new Label
            {
                Text = "Last Name",
                Location = new Point(320, 130),
                AutoSize = true
            };

            txtLastName = new TextBox
            {
                Location = new Point(410, 125),
                Size = new Size(150, 28)
            };

            Button btnAdd = new Button
            {
                Text = "Add",
                Location = new Point(450, 180),
                Size = new Size(110, 35)
            };

            Button btnExit = new Button
            {
                Text = "Exit",
                Location = new Point(450, 240),
                Size = new Size(110, 35)
            };

            btnAdd.Click += btnAdd_Click;
            btnExit.Click += (s, e) => Close();

            Controls.AddRange(new Control[]
            {
                trvDanhBa,
                lblFirst,
                txtFirstName,
                lblLast,
                txtLastName,
                btnAdd,
                btnExit
            });
        }

        private void TaoNodeAZ()
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                trvDanhBa.Nodes.Add(
                    c.ToString(),
                    c.ToString());
            }
        }

        private void btnAdd_Click(
            object? sender,
            EventArgs e)
        {
            string firstName =
                txtFirstName.Text.Trim();

            string lastName =
                txtLastName.Text.Trim();

            if (firstName == "")
            {
                MessageBox.Show(
                    "Vui lòng nhập First Name.");

                txtFirstName.Focus();
                return;
            }

            char kyTuDau =
                char.ToUpper(firstName[0]);

            TreeNode? node =
                trvDanhBa.Nodes[
                    kyTuDau.ToString()
                ];

            if (node == null)
            {
                MessageBox.Show(
                    "Tên phải bắt đầu bằng chữ cái A-Z.");

                return;
            }

            string hoTen =
                firstName;

            if (lastName != "")
                hoTen += ", " + lastName;

            node.Nodes.Add(hoTen);
            node.Expand();

            txtFirstName.Clear();
            txtLastName.Clear();
            txtFirstName.Focus();
        }
    }
}