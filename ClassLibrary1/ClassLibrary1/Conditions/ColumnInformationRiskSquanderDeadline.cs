using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class ColumnInformationRiskSquanderDeadline : ConditionObject<ITask>
    {
        public ColumnInformationRiskSquanderDeadline() : base("column-information-risk-squander-deadline")
        {

        }

        public override bool Check(ITask target)
        {
            return target.Traits == TaskTraits.RiskOfStageFail;
        }
    }
}
