using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Windows.Forms;
using EmergencyViewer.Data.Entities;

namespace EmergencyEventComponent
{
    [Serializable]
    public partial class EmergencyEventComponent : UserControl
    {
        public EmergencyEventStorage EmergencyEventRepository { get; set; }

        public EmergencyEventComponent()
        {
            InitializeComponent();
            EmergencyEventRepository = new EmergencyEventStorage();
        }

        //public EmergencyEventComponent(IEnumerable<EmergencyEventViewModel> events)
        //{
        //    InitializeComponent();
        //    EmergencyEventRepository = new EmergencyEventRepository(new List<EmergencyEventViewModel>(events)/*, onNewEvent*/);
        //    EmergencyEventRepository.EventItemAddedEvent += onNewEvent;
        //}

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
    }
}
