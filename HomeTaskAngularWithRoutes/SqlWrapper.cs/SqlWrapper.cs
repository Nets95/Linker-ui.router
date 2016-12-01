using System;
using System.Collections.Generic;
using LinkEntities.LinkEntity;
using System.Data;
using System.Data.SqlClient;

namespace SQL.cs
{
    public class SqlWrapper
    {
        private readonly string _connectionString;

        public SqlWrapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public object ExecuteReader(CommandType commandType, string commandText, SqlParameter[] parameters = null, Func<SqlDataReader, LinkEntity> callback = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(commandText, connection) { CommandType = CommandType.StoredProcedure })
                {
                    if (parameters != null)
                    { 
                        command.Parameters.AddRange(parameters);
                    }
                    connection.Open();
                    command.CommandTimeout = 0;

                    var reader = command.ExecuteReader();
                    object result;
                    using (reader)
                    {
                        var list = new List<LinkEntity>();

                        while (reader.Read())
                        {
                            if (callback != null)   
                            {
                                var item = callback(reader);
                                if (!Equals(item, default(LinkEntity)))
                                {
                                    list.Add(item);
                                }
                            }
                        }
                        result = list;
                    }
                    return result;
                }
            }
        }


    }
}
