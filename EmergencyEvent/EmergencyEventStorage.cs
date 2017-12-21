using System;
using System.Collections.Generic;
using System.Linq;
using EmergencyViewer.Data.Abstract;
using EmergencyViewer.Data.Concrete;
using EmergencyViewer.Data.Concrete.EF;


namespace EmergencyEventComponent
{
    public class EmergencyEventStorage
    {
        public event Action<EmergencyEvent> EventItemAddedEvent;
     
        public void AddEvent(EmergencyEvent eventItem)
        {
            using (var repository = new EfEventRepository())
            {
                repository.Create(eventItem);
                EventItemAddedEvent?.Invoke(eventItem);
                repository.Save();
            }
        }

        public IEnumerable<EmergencyEvent> Filter(Func<EmergencyEvent, bool> predicate)
        {
            //TODO: Implement Get(predicate) method
            //return _eventRepository.GetAll().Where(predicate);
            using (var repository = new EfEventRepository())
            {
                return repository.Get(predicate);
            }
        }
    }
}
