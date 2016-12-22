using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class ColumnPriorityTop : ConditionObject<ITask>
    {
        public ColumnPriorityTop() : base("column-priority-top")
        {

        }

        public override bool Check(ITask target)
        {
            return target.Priority == TaskPriority.P10;
        }
    }
}
