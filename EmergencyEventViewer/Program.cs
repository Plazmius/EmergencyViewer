using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using CommonServiceLocator;
using EmergencyEventComponent;
using EmergencyViewer.Data.Abstract;
using EmergencyViewer.Data.Concrete;
using EmergencyViewer.Data.Concrete.EF;
using Microsoft.Practices.Unity.Configuration;
using Unity;
using Unity.ServiceLocation;

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
            ConfigDependecies();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AskLanguage());
            Application.Run(new EventViewer());
            
        }

        private static void ConfigDependecies()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IRepository<EmergencyEvent>, EfEventRepository>();
            container.RegisterType<IRepository<EmergencyViewer.Data.Entities.EmergencyEvent>, AdoNetEventRepository>();
            container.RegisterType<IEmergencyEventStorage, EmergencyEventStorage>();
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));
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
