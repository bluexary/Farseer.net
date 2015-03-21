﻿using System.Collections.Generic;
using System.Data.Common;
using FS.Core.Context;

namespace FS.Core.Infrastructure
{
    /// <summary>
    /// 数据库持久化
    /// </summary>
    public interface IQueryProc : IQuery
    {
        /// <summary>
        /// 当前组查询队列（支持批量提交SQL）
        /// </summary>
        IQueueProc Queue { get; }

        /// <summary>
        /// 当前所有持久化列表
        /// </summary>
        List<IQueueProc> GroupQueueList { get; set; }

        /// <summary>
        /// 根据索引，返回IQueryQueue
        /// </summary>
        /// <param name="index"></param>
        IQueueProc GetQueue(int index);

        /// <summary>
        /// 提交所有GetQueue，完成数据库交互
        /// </summary>
        int Commit();

        /// <summary>
        /// 清除当前队列
        /// </summary>
        void Clear();

        /// <summary>
        /// 将GroupQueryQueue提交到组中，并创建新的GroupQueryQueue
        /// </summary>
        void Append();
    }
}