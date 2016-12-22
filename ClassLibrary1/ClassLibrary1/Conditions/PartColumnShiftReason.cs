using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class PartColumnShiftReason : ConditionObject<ITask>
    {
        public PartColumnShiftReason() : base("part-column-shift-reason")
        {

        }

        public override bool Check(ITask target)
        {
            return !String.IsNullOrEmpty(target.LagReason);
        }
    }
}
