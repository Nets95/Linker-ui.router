using LinkEntities.LinkEntity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace DAL.Abstraction.Repository
{
    public interface IOperations
    {
        LinkEntity Add(LinkEntity link);

        LinkEntity Remoove(LinkEntity link);

        LinkEntity Update(LinkEntity link, string updatedLinkTitle);

        List<LinkEntity> GetAllLinks();

        IEnumerable<LinkEntity> ExecuteReader(string spName, Func<SqlDataReader, LinkEntity> callback, SqlParameter[] parameters = null);
    }
}
