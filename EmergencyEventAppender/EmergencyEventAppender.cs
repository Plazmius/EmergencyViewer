using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmergencyViewer.Data.Abstract;
using EmergencyViewer.Data.Concrete;
using EmergencyViewer.Data.Entities;

namespace EmergencyEventAppender
{
    [Export(typeof(UserControl))]
    [DisplayName("Emergency events adding component.")]
    public partial class EmergencyEventAppender : UserControl
    {
        private IRepository<EmergencyEvent> _eventRepository;
        private IRepository<InfoSource> _sourcesRepository;
        public event EventHandler<EmergencyEventAddedEventArgs> EmergencyEventAddedEvent; 

        public EmergencyEventAppender()
        {
            InitializeComponent();
            _eventRepository = new AdoNetEventRepository();
            _sourcesRepository = new AdoNetInfoSourcesRepository();

            infoSourceComboBox.DataSource = _sourcesRepository.GetAll();
            infoSourceComboBox.DisplayMember = "Name";
            typeComboBox.DataSource = Enum.GetValues(typeof(EmergencyEventType));
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var newEvent = new EmergencyEvent
            {
                Name = nameTextBox.Text,
                Description = descriptionRichTextBox.Text,
                InfoSourceId = ((InfoSource) infoSourceComboBox.SelectedValue).Id,
                OccuranceDate = occuranceDatePicker.Value
            };
            Enum.TryParse(typeComboBox.SelectedValue.ToString(), out EmergencyEventType type);
            newEvent.EventType = type;

            _eventRepository.Create(newEvent);
            _eventRepository.Save();
            
            EmergencyEventAddedEvent?.Invoke(this, new EmergencyEventAddedEventArgs(newEvent));
        }
    }
}
