using HuxingModel.Global;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingService
{
    public class PhotoClient:BaseService, IDisposable
    {

        public SqlSugarClient DbContext;

     
        public PhotoClient()
        {
            if (DbContext == null)
            {
                DbContext = new SqlSugarClient(new ConnectionConfig
                {
                    ConnectionString = DatabaseConfigModel.Photo,
                    DbType = DbType.MySql,
                    IsAutoCloseConnection = true,
                    IsShardSameThread = true,
                    InitKeyType=InitKeyType.Attribute
                });
            }
        }

        public void Dispose()
        {
            if (DbContext != null)
            {
                DbContext.Dispose();
            }
        }
    }
}
