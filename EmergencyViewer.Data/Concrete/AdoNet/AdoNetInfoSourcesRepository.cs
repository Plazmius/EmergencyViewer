using System.Collections.Generic;
using System.Linq;
using EmergencyViewer.Data.Abstract;
using EmergencyViewer.Data.Entities;

namespace EmergencyViewer.Data.Concrete
{
    public class AdoNetInfoSourcesRepository : AdoNetRepository<InfoSource>, IRepository<InfoSource>
    {
        public IEnumerable<InfoSource> GetAll()
        {
            return ExecuteQuery("SELECT * FROM [dbo].[InfoSources]");
        }

        public InfoSource GetById(int id)
        {
            return ExecuteQuery("SELECT * FROM [dbo].[InfoSources] WHERE [Id] = @id",
                    new KeyValuePair<string, object>("@id", id))
                .FirstOrDefault();
        }

        public void Create(InfoSource item)
        {
            var query = "INSERT INTO " +
                        "[dbo].[InfoSources] (Name, Description, TrustLevel) " +
                        "VALUES (@name, @description, @trustLevel)";
            var parameters = new[]
            {
                new KeyValuePair<string, object>("@name", item.Name),
                new KeyValuePair<string, object>("@description", item.Description),
                new KeyValuePair<string, object>("@trustLevel", item.TrustLevel), 
            };

            ExecuteNonQuery(query, parameters);
        }

        public void Update(InfoSource item)
        {
            var query = "UPDATE [dbo].[InfoSources] " +
                        "SET [Name] = @name, [Description] = @description, [TrustLevel] = @trustLevel " +
                        "WHERE [Id] = @id";
            var parameters = new[]
            {
                new KeyValuePair<string, object>("@id", item.Id),
                new KeyValuePair<string, object>("@name", item.Name),
                new KeyValuePair<string, object>("@description", item.Description),
                new KeyValuePair<string, object>("@trustLevel", item.TrustLevel),
            };

            ExecuteNonQuery(query, parameters);
        }

        public void Delete(int id)
        {
            ExecuteNonQuery("DELETE FROM [dbo].[InfoSources] WHERE [Id] = @id",
                new KeyValuePair<string, object>("@id", id));
        }
    }
}