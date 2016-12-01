using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkEntities.LinkEntity;
using System.Data.SqlClient;
using System.Data;
using SQL.cs;

namespace Parser
{
    public static class Extension
    {
        public static bool ColumnExists(this IDataRecord reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (string.Equals(reader.GetName(i), columnName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
    public class LinkParser
    {
        private static LinkParser _instance;

        public LinkParser(){}

        public static LinkParser Instance
        {
            get { return _instance ?? (_instance = new LinkParser()); }        
        }

        public LinkEntity MakeResult(SqlDataReader reader)
        {
            LinkEntity link = new LinkEntity();

            if (reader.ColumnExists(SqlParameters.LinkTitle))
            {
                link.Id = reader[SqlParameters.Id] is DBNull
                    ? 0 :
                    Convert.ToInt32(reader[SqlParameters.Id]);
            }
            if (reader.ColumnExists(SqlParameters.LinkTitle))
            {
                link.LinkTitle = reader[SqlParameters.LinkTitle] is DBNull
                    ? string.Empty :
                    reader[SqlParameters.LinkTitle].ToString();
            }
            if (reader.ColumnExists(SqlParameters.CurrentDate))
            {
                link.CurrentDate = reader[SqlParameters.CurrentDate] is DBNull
                    ? string.Empty :
                    reader[SqlParameters.CurrentDate].ToString();
            }

            return link;
        }
    }
}
