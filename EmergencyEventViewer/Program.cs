using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace EmergencyEventViewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AskLanguage());
            Application.Run(new EventViewer());
        }

        private static string AskLanguage()
        {
            using (var languageSelector = new LanguageSelector())
            {
                if (languageSelector.ShowDialog() == DialogResult.OK)
                {
                    return languageSelector.SelectedCulture;
                }
                return "en-US";
            }
        }
    }
}
