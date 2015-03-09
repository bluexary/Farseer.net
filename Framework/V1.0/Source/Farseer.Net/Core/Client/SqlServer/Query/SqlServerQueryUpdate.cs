﻿using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using FS.Core.Client.SqlServer.Assemble;
using FS.Core.Infrastructure;
using FS.Core.Infrastructure.Query;

namespace FS.Core.Client.SqlServer.Query
{
    /// <summary>
    /// 组查询队列（支持批量提交SQL）
    /// </summary>
    public class SqlServerQueryUpdate : IQueryQueueUpdate
    {
        private readonly IQuery _queryProvider;

        public SqlServerQueryUpdate(IQuery queryProvider)
        {
            _queryProvider = queryProvider;
        }

        public void Query<T>(T entity) where T : class,new()
        {
            _queryProvider.QueryQueue.Sql = new StringBuilder();
            IList<DbParameter> param = new List<DbParameter>();
            var strWhereSql = new WhereAssemble(_queryProvider).Execute(_queryProvider.QueryQueue.ExpWhere, ref param);
            var strAssemble = new AssignAssemble(_queryProvider).Execute(entity, ref param);

            _queryProvider.QueryQueue.Sql.AppendFormat("UPDATE {0} SET ", _queryProvider.DbProvider.KeywordAegis(_queryProvider.TableContext.TableName));
            _queryProvider.QueryQueue.Sql.Append(strAssemble);
            if (!string.IsNullOrWhiteSpace(strWhereSql)) { _queryProvider.QueryQueue.Sql.Append(string.Format(" WHERE {0} ", strWhereSql)); }

            _queryProvider.QueryQueue.Param = param;

            // 非合并提交，则直接提交
            if (!_queryProvider.TableContext.IsMergeCommand) { _queryProvider.QueryQueue.Execute(); return; }

            _queryProvider.Append();
        }
    }
}
