using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class PartColumnRiskBad : ConditionObject<ITask>
    {
        public PartColumnRiskBad() : base("part-column-risk-bad")
        {

        }

        public override bool Check(ITask target)
        {
            return !String.IsNullOrEmpty(target.Risk);
        }
    }
}
