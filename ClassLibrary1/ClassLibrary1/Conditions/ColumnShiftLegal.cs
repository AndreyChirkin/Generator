using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class ColumnShiftLegal : ConditionObject<ITask>
    {
        public ColumnShiftLegal() : base("column-shift-legal")
        {

        }

        public override bool Check(ITask target)
        {
            return target.LastShiftConformityState == Conformity.Confirmed && target.Lag.Ticks > 0;
        }
    }
}
