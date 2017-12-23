using System;
using System.Collections.Generic;
using System.Linq;
using EmergencyViewer.Data.Abstract;
using EmergencyViewer.Data.Concrete;
using EmergencyViewer.Data.Concrete.EF;


namespace EmergencyEventComponent
{
    public interface IEmergencyEventStorage
    {
        event Action<EmergencyEvent> EventItemAddedEvent;
        void AddEvent(EmergencyEvent eventItem);
        IEnumerable<EmergencyEvent> Filter(Func<EmergencyEvent, bool> predicate);
    }

    public class EmergencyEventStorage : IEmergencyEventStorage
    {
        public event Action<EmergencyEvent> EventItemAddedEvent;
        private readonly IRepository<EmergencyEvent> _eventRepository;

        public EmergencyEventStorage(IRepository<EmergencyEvent> repository)
        {
            _eventRepository = repository;
        }

        public void AddEvent(EmergencyEvent eventItem)
        {
            _eventRepository.Create(eventItem);
            EventItemAddedEvent?.Invoke(eventItem);
            _eventRepository.Save();
        }

        public IEnumerable<EmergencyEvent> Filter(Func<EmergencyEvent, bool> predicate)
        {
            return _eventRepository.GetAll().Where(predicate).ToList();   
        }
    }
}
