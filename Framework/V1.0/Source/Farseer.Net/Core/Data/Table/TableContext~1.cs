﻿using FS.Mapping.Table;

namespace FS.Core.Data.Table
{
    /// <summary>
    /// 表上下文
    /// </summary>
    public class TableContext<TEntity> : TableContext where TEntity : class, new()
    {
        /// <summary>
        /// 通过数据库配置，连接数据库
        /// </summary>
        /// <param name="dbIndex">数据库选项</param>
        /// <param name="tableName">表名称</param>
        public TableContext(string tableName = null,int dbIndex = 0) : base(dbIndex) { Init(tableName); }

        /// <summary>
        /// 通过自定义数据链接符，连接数据库
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="dbType">数据库类型</param>
        /// <param name="commandTimeout">SQL执行超时时间</param>
        /// <param name="tableName">表名称</param>
        public TableContext(string connectionString, DataBaseType dbType = DataBaseType.SqlServer, int commandTimeout = 30, string tableName = null) : base(connectionString, dbType, commandTimeout) { Init(tableName); }

        /// <summary>
        /// 强类型实体对象
        /// </summary>
        public TableSet<TEntity> Set { get; private set; }

        /// <summary>
        /// 提供快捷的数据库执行
        /// 根据实体类设置的特性，访问数据库
        /// </summary>
        public static TableSet<TEntity> Data
        {
            get
            {
                return new TableContext<TEntity>() { IsMergeCommand = false }.Set;
            }
        }

        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="tableName">表名</param>
        private void Init(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName)) { tableName = TableMapCache.GetMap(this.GetType()).ClassInfo.Name; }
            Set = new TableSet<TEntity>(this, tableName);
        }
    }
}