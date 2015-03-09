﻿using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using FS.Core.Infrastructure;

namespace FS.Core.Client.SqlServer.Assemble
{
    public class WhereAssemble  : SqlAssemble
    {
        public WhereAssemble(IQuery queryProvider) : base(queryProvider) { }

        public string Execute(Expression exp, ref IList<DbParameter> param)
        {
            return "";
        }
    }
}
