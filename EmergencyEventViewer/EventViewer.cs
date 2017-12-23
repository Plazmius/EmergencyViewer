using System.Collections.Generic;
using System.Windows.Forms;
using EmergencyEventComponent;
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Globalization;
using System.IO;
using System.Linq;
using CustomAttributes;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using EmergencyEventComponent.Exceptions;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Serialization;
using AutoMapper;
using CommonServiceLocator;
using EmergencyViewer.Data.Entities;

namespace EmergencyEventViewer
{
    public partial class EventViewer : Form
    {
        [ImportMany(typeof(UserControl))]
        private IEnumerable<UserControl> _userControls;

        public EventViewer()
        {
            InitializeComponent();

            Import();

            tabControl1.TabPages.Clear();
            var emergencyEventComponent = _userControls
                .FirstOrDefault(control => control is EmergencyEventComponent.EmergencyEventComponent) as EmergencyEventComponent.EmergencyEventComponent;
            var emergencyEventAppender = _userControls
                .FirstOrDefault(control => control is EmergencyEventAppender.EmergencyEventAppender) as EmergencyEventAppender.EmergencyEventAppender;
            if (emergencyEventAppender != null)
            {
                emergencyEventAppender.EmergencyEventAddedEvent += (sender, args) =>
                {
                    emergencyEventComponent1.AddToTable(new EmergencyEventViewModel(args.EmergencyEvent.Name,
                        args.EmergencyEvent.Description,
                        args.EmergencyEvent.OccuranceDate,
                        args.EmergencyEvent.EventType));
                };
            }

            if (emergencyEventComponent != null)
            {
                emergencyEventComponent.Controls.Find("showEvents", false).First().Click += (e, a) => { SaveState(emergencyEventComponent); };
                RestoreState(emergencyEventComponent);
            }

            foreach (var uc in _userControls)
            {
                var tp = new TabPage
                {
                    Text = ((DisplayNameAttribute)uc.GetType().GetCustomAttributes(typeof(DisplayNameAttribute), false).FirstOrDefault())?.DisplayName
                };
                tp.Controls.Add(uc);
                tabControl1.TabPages.Add(tp);
            }


            Mapper.Initialize(cfg => cfg.CreateMap<EmergencyEvent, EmergencyEventViewModel>());
        }

        private void componentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var componentType = typeof(EmergencyEventViewModel);
            var attribute = componentType.GetCustomAttribute<ComponentInfoAttribute>();

            if (attribute != null)
            {
                MessageBox.Show($"Author: {attribute.Author}, Version: {attribute.Version}, Description {attribute.Description}");
            }
        }

        private void RestoreState(EmergencyEventComponent.EmergencyEventComponent component)
        {
            if (!File.Exists(AppState.StateFileName))
            {
                return;
            }
            var file = new FileStream(AppState.StateFileName, FileMode.Open);
            try
            {
                var serializer = new XmlSerializer(typeof(AppState));
                var state = (AppState)serializer.Deserialize(file);
                Height = state.Height;
                Width = state.Width;
                component.DateFrom = state.DateFrom;
                component.DateTo = state.DateTo;
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
            }
            finally
            {
                file.Close();
            }
        }

        private void SaveState(EmergencyEventComponent.EmergencyEventComponent component)
        {
            var file = new FileStream(AppState.StateFileName, FileMode.Create);
            var state = new AppState
            {
                DateFrom = component.DateFrom,
                DateTo = component.DateTo,
                Height = Height,
                Width = Width
            };
            try
            {
                var serializer = new XmlSerializer(typeof(AppState));
                serializer.Serialize(file, state);
                //var formatter = new BinaryFormatter();
                //formatter.Serialize(file, state);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                file.Close();
            }
        }

        private void emergencyEventComponent1_Load(object sender, EventArgs e)
        {

        }

        private void emergencyEventAppender1_Load(object sender, EventArgs e)
        {

        }

        public void Import()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(
                new DirectoryCatalog(
                    Path.GetDirectoryName(
                        Assembly.GetExecutingAssembly().Location)));

            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeExportedValue("EventStorage", ServiceLocator.Current.GetInstance<IEmergencyEventStorage>());

            container.ComposeParts(this);
        }

    }

    public class AppState : ISerializable
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public static string StateFileName = "emergencyViewerState.xml";

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Width), Width);
            info.AddValue(nameof(Height), Height);
            info.AddValue(nameof(DateFrom), DateFrom);
            info.AddValue(nameof(DateTo), DateTo);
        }
    }
}
