using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Runtime.Serialization;
using System.Windows.Forms;
using EmergencyViewer.Data.Entities;

namespace EmergencyEventComponent
{
    public partial class EmergencyEventComponent : UserControl
    {
        public EmergencyEventStorage EmergencyEventRepository { get; set; }

        public EmergencyEventComponent()
        {
            InitializeComponent();
            EmergencyEventRepository = new EmergencyEventStorage();
        }
        
        public void AddToTable(EmergencyEventViewModel emergencyEvent)
        {
            //MessageBox.Show($"Attention! New emergency: {eventItem.Name}");
            if (emergencyEvent.OccuranceDate < dateToPicker.Value &&
                emergencyEvent.OccuranceDate > dateFromPicker.Value)
            {
                eventsGrid.Rows.Add(emergencyEvent.Name,
                    emergencyEvent.EventTypeName,
                    emergencyEvent.Description,
                    emergencyEvent.OccuranceDate.ToShortDateString());
            }
        }

        private void showEvents_Click(object sender, EventArgs e)
        {
            if (dateFromPicker.Value > dateToPicker.Value)
            {
                ShowLocalizedMessageBox("InvalidDateRange");
                return;
            }

            eventsGrid.Rows.Clear();
            var eventsToShow = EmergencyEventRepository
                .Filter(ev => ev.OccuranceDate < dateToPicker.Value && ev.OccuranceDate > dateFromPicker.Value)
                .Select(ev => new EmergencyEventViewModel(ev.Name, 
                    ev.Description, 
                    ev.OccuranceDate.GetValueOrDefault(), 
                    (EmergencyEventType)ev.EventType.GetValueOrDefault()));

            foreach (var emergencyEvent in eventsToShow)
            {
                eventsGrid.Rows.Add(emergencyEvent.Name, 
                    emergencyEvent.EventTypeName, 
                    emergencyEvent.Description, 
                    emergencyEvent.OccuranceDate.ToShortDateString());
            }
        }

        public void ShowLocalizedMessageBox(string key)
        {
            var rm = new ResourceManager("EmergencyEventComponent.Localization.MessageResources", typeof(EmergencyEventComponent).Assembly);
            // Assign the string for the "strMessage" key to a message box.
            MessageBox.Show(rm.GetString(key));
        }

        public DateTime DateFrom
        {
            get => dateFromPicker.Value;
            set => dateFromPicker.Value = value;
        }
        public DateTime DateTo
        {
            get => dateToPicker.Value;
            set => dateToPicker.Value = value;
        }
    }
}
