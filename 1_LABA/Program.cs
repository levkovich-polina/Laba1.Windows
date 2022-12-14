using _1_LABA.Forms;

namespace _1_LABA
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
            var authenticationManager = new AuthenticationManager();
            Application.Run(new MainForm(authenticationManager));
        }
    }
}