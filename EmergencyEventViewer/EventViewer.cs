using System.Collections.Generic;
using System.Windows.Forms;
using EmergencyEventComponent;
using System;
using System.Collections;
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
using EmergencyViewer.Data.Entities;

namespace EmergencyEventViewer
{
    public partial class EventViewer : Form
    {
        public EventViewer()
        {
            InitializeComponent();
            RestoreState();

            Mapper.Initialize(cfg => cfg.CreateMap<EmergencyEvent, EmergencyEventViewModel>());
            emergencyEventAppender1.EmergencyEventAddedEvent += (sender, args) =>
            {
                emergencyEventComponent1.AddToTable(new EmergencyEventViewModel(args.EmergencyEvent.Name,
                    args.EmergencyEvent.Description,
                    args.EmergencyEvent.OccuranceDate,
                    args.EmergencyEvent.EventType));
            };

            emergencyEventComponent1.Controls.Find("showEvents", false).First().Click += (e, a) =>
            {
                var file = new FileStream(AppState.StateFileName, FileMode.Create);
                var state = new AppState
                {
                    DateFrom = emergencyEventComponent1.DateFrom,
                    DateTo = emergencyEventComponent1.DateTo,
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
            };
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

        private void RestoreState()
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
                emergencyEventComponent1.DateFrom = state.DateFrom;
                emergencyEventComponent1.DateTo = state.DateTo;
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

        private void emergencyEventComponent1_Load(object sender, EventArgs e)
        {

        }

        private void emergencyEventAppender1_Load(object sender, EventArgs e)
        {

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
