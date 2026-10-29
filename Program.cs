namespace Hotel_Reservation_System
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            try
            {
                // AdminLoginForm shows BOTH Admin and Coordinator login panels side-by-side
                Application.Run(new Forms.AdminLoginForm());
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText("app_crash.log", ex.ToString());
                MessageBox.Show(ex.ToString(), "Fatal Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}