using System.Collections.Generic;
using System.Windows.Forms;
using EmergencyEventComponent;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using CustomAttributes;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using EmergencyEventComponent.Exceptions;
using System.Threading.Tasks;
using System.Threading;
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
                var file = new FileStream("emergencyViewerState.dat", FileMode.Create);

                try
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(file, emergencyEventComponent1);
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
            if (!File.Exists("emergencyViewerState.dat")) return;
            var file = new FileStream("emergencyViewerState.dat", FileMode.Open);
            try
            {

                var formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                emergencyEventComponent1 =
                    (EmergencyEventComponent.EmergencyEventComponent)formatter.Deserialize(file);
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
}
