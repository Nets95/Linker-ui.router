using System.Data.SqlClient;
using DAL.Abstraction.Repository;
using LinkEntities.LinkEntity;
using System.Collections.Generic;
using System;
using SQL.cs;
using System.Data;
using Parser;


namespace DAL.Cocreate.Repository
{
    public class Operations : IOperations
    {
        private readonly string _connection;
        private SqlWrapper _wrapper;
        private static Operations _instance;

        public Operations Instance
        {
            get
            {
                return _instance = new Operations(_connection);
            }
        }
        public Operations(string connection)
        {
            _connection = connection;
            _wrapper = new SqlWrapper(connection);
        }

        public List<LinkEntity> GetAllLinks()
        {
            return (List<LinkEntity>)Instance.ExecuteReader(SqlStoredProcedures.SpSelectAll, LinkParser.Instance.MakeResult);
        }

        public LinkEntity Add(LinkEntity link)
        {
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter(SqlParameters.LinkTitle, link.LinkTitle.ToString()),
                new SqlParameter(SqlParameters.CurrentDate, link.CurrentDate)
                };
                Instance.ExecuteReader(SqlStoredProcedures.SpInsert, parameters: parameters);
                return link;
        }


        public LinkEntity Remoove(LinkEntity link)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(SqlParameters.SpLinkTitle, link.LinkTitle)
            };
            Instance.ExecuteReader(SqlStoredProcedures.SpRemooveLink, parameters: parameters);
            return link;
        }

        public LinkEntity Update(LinkEntity link, string updatedLinkTitle)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(SqlParameters.SpLinkTitle, link.LinkTitle),
                new SqlParameter(SqlParameters.SpUpdatedLinkTitle, updatedLinkTitle)
            };
            link.LinkTitle = updatedLinkTitle;
            Instance.ExecuteReader(SqlStoredProcedures.SpUpdateLink, parameters: parameters);
            return link;
        }

        public IEnumerable<LinkEntity> ExecuteReader(string spName, Func<SqlDataReader, LinkEntity> callback = null, SqlParameter[] parameters = null)
        {
            return (IEnumerable<LinkEntity>)_wrapper.ExecuteReader(CommandType.StoredProcedure, spName, parameters, callback);
        }
    }
}
