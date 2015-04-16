﻿using System.Data.Common;
using FS.Core.Client.OleDb.SqlQuery;
using FS.Core.Infrastructure;

namespace FS.Core.Client.OleDb
{
    public class OleDbProvider : DbProvider
    {
        public override DbProviderFactory GetDbProviderFactory
        {
            get { return DbProviderFactories.GetFactory("System.Data.OleDb"); }
        }
        public override IDbSqlQuery<TEntity> CreateSqlQuery<TEntity>(IQueueManger queueManger, IQueueSql queueSql)
        {
            return new SqlQuery<TEntity>(queueManger, queueSql);
        }

        public override IDbSqlProc<TEntity> CreateSqlProc<TEntity>(IQueueManger queueManger, IQueue queueSql)
        {
            return new SqlProc<TEntity>(queueManger, queueSql);
        }

        public override IDbSqlOper<TEntity> CreateSqlOper<TEntity>(IQueueManger queueManger, IQueueSql queueSql)
        {
            return new SqlOper<TEntity>(queueManger, queueSql);
        }
    }
}
