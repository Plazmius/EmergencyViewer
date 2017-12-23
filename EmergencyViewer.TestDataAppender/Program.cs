using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmergencyViewer.Data.Concrete;
using EmergencyViewer.Data.Concrete.EF;
using EmergencyViewer.Data.Entities;

namespace EmergencyViewer.TestDataAppender
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new AdoNetEventRepository();

            for (var i = 0; i < 500000; i++)
            {
                var random = new Random();
                Console.Write(".");
                repository.Create(new Data.Entities.EmergencyEvent
                {
                    Description = $"TestEvent{i}",
                    EventType = (EmergencyEventType)random.Next(0, 6),
                    Name = $"TestEventName{i}",
                    OccuranceDate = DateTime.Now,
                    InfoSourceId = random.Next(1, 4)
                });                
            }

            repository.Save();
            Console.WriteLine("Completed!");
        }
    }
}
