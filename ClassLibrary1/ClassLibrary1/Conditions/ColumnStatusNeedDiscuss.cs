﻿using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class ColumnStatusNeedDiscuss : ConditionObject<ITask>
    {
        public ColumnStatusNeedDiscuss() : base("column-status-need-discuss")
        {

        }

        public override bool Check(ITask target)
        {
            return target.State == TaskState.Attention;
        }
    }
}
