﻿using FS.Mapping.Table;
using FS.Mapping.Table.Attribute;

namespace Demo.VO.Members
{
    public class ValueUserVO 
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Proc()]
        public int? ID { get; set; }
    }
}