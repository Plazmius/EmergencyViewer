using System;
using System.Collections.Generic;
using System.Data;
using EmergencyViewer.Data.Entities;

namespace EmergencyViewer.Data.Util
{
    public static class AdoNetExtensions
    {
        public static IDbDataParameter CreateParameter(this IDbCommand command, string name, object value)
        {
            var parameter = command.CreateParameter();
            parameter.Value = value;
            parameter.ParameterName = name;
            return parameter;
        }

        public static IEnumerable<T> ToList<T>(this IDbCommand command)
        {
            using (var record = command.ExecuteReader())
            {
                var items = new List<T>();
                while (record.Read())
                {

                    items.Add(Map<T>(record));
                }
                return items;
            }
        }

        public static T Map<T>(this IDataRecord record)
        {
            var objT = Activator.CreateInstance<T>();
            foreach (var property in typeof(T).GetProperties())
            {
                if (!record.IsDBNull(record.GetOrdinal(property.Name)))
                    property.SetValue(objT, record[property.Name]);
            }
            return objT;
        }
    }
}