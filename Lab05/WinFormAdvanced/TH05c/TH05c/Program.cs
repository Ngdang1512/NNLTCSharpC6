namespace TH05c
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Bài 1
            Application.Run(new frmTuDien());

            // Bài 2
            //Application.Run(new frmListBox());

            // Bài 3
            //Application.Run(new frmDanhBa());
        }
    }
}