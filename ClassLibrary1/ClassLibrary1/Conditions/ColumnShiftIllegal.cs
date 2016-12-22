using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class ColumnShiftIllegal : ConditionObject<ITask>
    {
        public ColumnShiftIllegal() : base("column-shift-illegal")
        {

        }

        public override bool Check(ITask target)
        {
            return target.LastShiftConformityState == Conformity.Unconfirmed && target.Lag.Ticks > 0;
        }
    }
}
