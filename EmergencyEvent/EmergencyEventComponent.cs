using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Resources;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmergencyViewer.Data.Abstract;
using EmergencyViewer.Data.Entities;

namespace EmergencyEventComponent
{
    [Export(typeof(UserControl))]
    [DisplayName("Emergency events viewving component.")]
    public partial class EmergencyEventComponent : UserControl
    {
        public IEmergencyEventStorage Storage { get; set; }

        public EmergencyEventComponent(IEmergencyEventStorage storage)
        {
            InitializeComponent();
            Storage = storage;
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

        private async void showEvents_Click(object sender, EventArgs e)
        {
            if (dateFromPicker.Value > dateToPicker.Value)
            {
                ShowLocalizedMessageBox("InvalidDateRange");
                return;
            }

            eventsGrid.Rows.Clear();

            var eventsToShow = await GetEventsInRangeAsync();

            foreach (var emergencyEvent in eventsToShow.Take(10000))
            {
                eventsGrid.Rows.Add(emergencyEvent.Name,
                    emergencyEvent.EventTypeName,
                    emergencyEvent.Description,
                    emergencyEvent.OccuranceDate.ToShortDateString());
            }
        }

        public async Task<IEnumerable<EmergencyEventViewModel>> GetEventsInRangeAsync()
        {
            ChangeControlAvailability(false);
            var results = await Task.Run(() =>
            {
                return Storage
                    .Filter(ev => ev.OccuranceDate < dateToPicker.Value && ev.OccuranceDate > dateFromPicker.Value)
                    .Select(ev => new EmergencyEventViewModel(ev.Name,
                        ev.Description,
                        ev.OccuranceDate.GetValueOrDefault(),
                        (EmergencyEventType)ev.EventType.GetValueOrDefault()));
            });
            ChangeControlAvailability(true);
            return results;
        }

        public IEnumerable<EmergencyEventViewModel> GetEventsInRange()
        {
            Func<IEnumerable<EmergencyEventViewModel>> getEventsToShow = () =>
            {
                var evsToShow = Storage
                    .Filter(ev => ev.OccuranceDate < dateToPicker.Value && ev.OccuranceDate > dateFromPicker.Value)
                    .Select(ev => new EmergencyEventViewModel(ev.Name,
                        ev.Description,
                        ev.OccuranceDate.GetValueOrDefault(),
                        (EmergencyEventType)ev.EventType.GetValueOrDefault()));

                return evsToShow;
            };

            ChangeControlAvailability(false);

            Action<IAsyncResult> enableControlsCallBack = res =>
            {
                Action enableControls = () => ChangeControlAvailability(true);
                Invoke(enableControls);
            };

            var result = getEventsToShow.BeginInvoke(new AsyncCallback(enableControlsCallBack), this);
            var eventsToShow = getEventsToShow.EndInvoke(result);
            return eventsToShow;
        }

        public void ShowLocalizedMessageBox(string key)
        {
            var rm = new ResourceManager("EmergencyEventComponent.Localization.MessageResources", typeof(EmergencyEventComponent).Assembly);
            // Assign the string for the "strMessage" key to a message box.
            MessageBox.Show(rm.GetString(key));
        }

        private void ChangeControlAvailability(bool availability)
        {
            dateToPicker.Enabled = availability;
            dateFromPicker.Enabled = availability;
            eventsGrid.Enabled = availability;
            showEvents.Enabled = availability;
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
