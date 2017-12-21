using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using CustomAttributes;
using EmergencyEventComponent.Exceptions;
using EmergencyViewer.Data.Entities;

namespace EmergencyEventComponent
{
    [ComponentInfo(Author = "Artem", Description = "Emergency Event component for showing info", Version = "1.3.0.0")]
    public class EmergencyEventViewModel
    {
        public int Id { get; set; }
        public string Name { get; }
        public string Description { get; }
        public DateTime OccuranceDate { get; }
        public EmergencyEventType EventType { get; }
        public int InfoSourceId { get; set; }
        private readonly Regex _nameRegex = new Regex(@"^([a-zA-Z0-9]+\s?)*$");

        public string EventTypeName
        {
            get
            {
                var fieldInfo = EventType.GetType().GetField(EventType.ToString());
                var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attributes.Length > 0 ? attributes[0].Description : EventType.ToString();
            }
        }

        public EmergencyEventViewModel(string name, string description, DateTime date, EmergencyEventType eventType)
        {
            if (date > DateTime.Now || date < new DateTime(1900, 1, 1))
            {
                throw new InvalidDateException(date, $"Date {date} is not in acceptable date range");
            }
            if (!_nameRegex.IsMatch(name))
            {
                throw new InvalidStringException(name, $"{name} is not a valid string for {nameof(name)} field");
            }
            Name = name;
            Description = description;
            OccuranceDate = date;
            EventType = eventType;
        }
    }
}
