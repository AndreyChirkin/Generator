using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class ColumnPriorityHigh : ConditionObject<ITask>
    {
        public ColumnPriorityHigh() : base("column-priority-high")
        {

        }

        public override bool Check(ITask target)
        {
            return target.Priority == TaskPriority.P8 || target.Priority == TaskPriority.P9;
        }
    }
}
