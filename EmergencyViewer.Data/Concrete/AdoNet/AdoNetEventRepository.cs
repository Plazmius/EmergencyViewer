using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using EmergencyViewer.Data.Abstract;
using EmergencyViewer.Data.Entities;
using EmergencyViewer.Data.Util;

namespace EmergencyViewer.Data.Concrete
{
    public class AdoNetEventRepository : AdoNetRepository<EmergencyEvent>, IRepository<EmergencyEvent>
    {
        public IEnumerable<EmergencyEvent> GetAll()
        {
            return ExecuteQuery("SELECT * FROM [dbo].[EmergencyEvents]");
        }

        public EmergencyEvent GetById(int id)
        {
            return ExecuteQuery("SELECT * FROM [dbo].[EmergencyEvents] WHERE [Id] = @id",
                    new KeyValuePair<string, object>("@id", id))
                .FirstOrDefault();
        }

        public void Create(EmergencyEvent item)
        {
            var query = "INSERT INTO " +
                        "[dbo].[EmergencyEvents] (Name, Description, OccuranceDate, EventType, InfoSourceId) " +
                        "VALUES (@name, @description, @occuranceDate, @eventType, @InfoSourceId)";
            var parameters = new[]
            {
                new KeyValuePair<string, object>("@name", item.Name),
                new KeyValuePair<string, object>("@description", item.Description),
                new KeyValuePair<string, object>("@occuranceDate", item.OccuranceDate),
                new KeyValuePair<string, object>("@eventType", item.EventType),
                new KeyValuePair<string, object>("@InfoSourceId", item.InfoSourceId)
            };

            ExecuteNonQuery(query, parameters);
        }

        public void Update(EmergencyEvent item)
        {
            var query = "UPDATE [dbo].[EmergencyEvents]" +
                        "SET [Name] = @name, [Description] = @description, [OccuranceDate] = @occuranceDate, [EventType] = @eventType, [InfoSourceId] = @InfoSourceId" +
                        "WHERE [Id] = @id";
            var parameters = new[]
            {
                new KeyValuePair<string, object>("@id", item.Id),
                new KeyValuePair<string, object>("@name", item.Name),
                new KeyValuePair<string, object>("@description", item.Description),
                new KeyValuePair<string, object>("@occuranceDate", item.OccuranceDate),
                new KeyValuePair<string, object>("@eventType", item.EventType),
                new KeyValuePair<string, object>("@InfoSourceId", item.InfoSourceId)
            };

            ExecuteNonQuery(query, parameters);
        }

        public void Delete(int id)
        {
            ExecuteNonQuery("DELETE FROM [dbo].[EmergencyEvents] WHERE [Id] = @id",
                new KeyValuePair<string, object>("@id", id));
        }
    }
}