using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class PartColumnShiftCulprit : ConditionObject<ITask>
    {
        public PartColumnShiftCulprit() : base("part-column-shift-culprit")
        {

        }

        public override bool Check(ITask target)
        {
            return !(target.LagReason.IndexOf("(") == -1);
        }
    }
}
