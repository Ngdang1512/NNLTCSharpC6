namespace TH04c
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            //Application.Run(new frmBai1());
            //Application.Run(new frmBai2());
            Application.Run(new frmBai3());
            //Application.Run(new frmBai4());
            //Application.Run(new frmBai5());
        }
    }
}