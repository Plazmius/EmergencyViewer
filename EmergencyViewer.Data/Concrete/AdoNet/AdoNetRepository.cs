using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EmergencyViewer.Data.Util;

namespace EmergencyViewer.Data.Concrete
{
    public class AdoNetRepository<T>
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;

        public AdoNetRepository()
        {
            //TODO: move this to config
            _connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EventsDb;Integrated Security=True;Pooling=False");
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        protected IEnumerable<T> ExecuteQuery(string query, params KeyValuePair<string, object>[] queryParameters)
        {
            using (var cmd = CreateQueryCommand(query, queryParameters))
            {
                return cmd.ToList<T>();
            }
        }

        protected void ExecuteNonQuery(string query, params KeyValuePair<string, object>[] queryParameters)
        {
            using (var cmd = CreateQueryCommand(query, queryParameters))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public void Save()
        {
            _transaction.Commit();
            _transaction = _connection.BeginTransaction();
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }

        private IDbCommand CreateCommand()
        {
            var command = _connection.CreateCommand();
            command.Transaction = _transaction;
            return command;
        }
        private IDbCommand CreateQueryCommand(string query, params KeyValuePair<string, object>[] queryParameters)
        {
            var command = CreateCommand();
            command.CommandText = query;
            foreach (var parameter in queryParameters)
            {
                command.Parameters.Add(command.CreateParameter(parameter.Key, parameter.Value));
            }
            return command;
        }
    }
}