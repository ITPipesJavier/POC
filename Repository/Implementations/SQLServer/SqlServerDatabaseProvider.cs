using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Repository.Interfaces;

namespace Repository.Implementations.SQLServer
{
    public class SqlServerDatabaseProvider : IDatabaseProvider
    {
        private readonly string _connectionString;

        public SqlServerDatabaseProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public T QuerySingle<T>(string sql, object parameters)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var command = CreateCommand(connection, sql, parameters))
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return MapReaderToObject<T>(reader);
                    }

                    return default(T);
                }
            }
        }

        public IEnumerable<T> Query<T>(string sql, object parameters)
        {
            var result = new List<T>();

            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var command = CreateCommand(connection, sql, parameters))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(MapReaderToObject<T>(reader));
                    }
                }
            }

            return result;
        }

        public int Execute(string sql, object parameters)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var command = CreateCommand(connection, sql, parameters))
                {
                    return command.ExecuteNonQuery();
                }
            }
        }

        private SqlCommand CreateCommand(SqlConnection connection, string sql, object parameters)
        {
            var command = connection.CreateCommand();
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            if (parameters != null)
            {
                var props = parameters.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var prop in props)
                {
                    var value = prop.GetValue(parameters, null) ?? DBNull.Value;
                    command.Parameters.AddWithValue("@" + prop.Name, value);
                }
            }

            return command;
        }

        private T MapReaderToObject<T>(IDataReader reader)
        {
            var obj = Activator.CreateInstance<T>();
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            for (int i = 0; i < reader.FieldCount; i++)
            {
                var columnName = reader.GetName(i);
                var prop = Array.Find(props, p => p.Name.Equals(columnName, StringComparison.OrdinalIgnoreCase));

                if (prop != null && reader[columnName] != DBNull.Value)
                {
                    prop.SetValue(obj, Convert.ChangeType(reader[columnName], prop.PropertyType), null);
                }
            }

            return obj;
        }
    }
}
