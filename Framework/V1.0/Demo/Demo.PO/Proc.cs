﻿using Demo.VO.Members;
using FS.Core.Data.Proc;
using FS.Mapping.Table;

namespace Demo.PO
{
    public class Proc : ProcContext
    {
        [DB(Name = "sp_Info_User")]
        public ProcSet<InfoUserVO> InfoUser { get; set; }

        [DB(Name = "sp_Insert_User")]
        public ProcSet<InsertUserVO> InsertUser { get; set; }

        [DB(Name = "sp_List_User")]
        public ProcSet<ListUserVO> ListUser { get; set; }

        [DB(Name = "sp_Value_User")]
        public ProcSet<ValueUserVO> ValueUser { get; set; }
    }
}