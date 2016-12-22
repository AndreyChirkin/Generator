using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class ColumnShiftRequested : ConditionObject<ITask>
    {
        public ColumnShiftRequested() : base("column-shift-requested")
        {

        }

        public override bool Check(ITask target)
        {
            return target.LastShiftConformityState == Conformity.Pending && target.Lag.Ticks > 0;
        }
    }
}
