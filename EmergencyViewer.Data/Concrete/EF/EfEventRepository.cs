using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EmergencyViewer.Data.Abstract;
using EmergencyViewer.Data.Entities;

namespace EmergencyViewer.Data.Concrete.EF
{
    public class EfEventRepository : IRepository<EmergencyEvent>
    {
        private readonly EventsDb _db = new EventsDb();

        public EfEventRepository()
        {
            _db.Database.Log = s => Debug.WriteLine(s);
        }

        public IEnumerable<EmergencyEvent> GetAll()
        {
            return _db.EmergencyEvents;
        }

        public IEnumerable<EmergencyEvent> Get(Func<EmergencyEvent, bool> predicate)
        {
            return _db.EmergencyEvents.Where(predicate).ToList();
        }

        public EmergencyEvent GetById(int id)
        {
            return _db.EmergencyEvents.Find(id);
        }

        public void Create(EmergencyEvent item)
        {
            _db.EmergencyEvents.Add(item);
        }

        public void Update(EmergencyEvent item)
        {
            Delete(item.Id);
            Create(item);
        }

        public void Delete(int id)
        {
            var toDelete = GetById(id);
            _db.EmergencyEvents.Remove(toDelete);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}