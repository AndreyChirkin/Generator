using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class ColumnCriticalWayTrue : ConditionObject<ITask>
    {
        public ColumnCriticalWayTrue() : base("column-critical-way-true")
        {

        }

        public override bool Check(ITask target)
        {
            return target.IsCritical;
        }
    }
}
