using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class ColumnInformationNeedCorrectionDeadline : ConditionObject<ITask>
    {
        public ColumnInformationNeedCorrectionDeadline() : base("column-information-need-correction-dedline")
        {

        }

        public override bool Check(ITask target)
        {
            return target.Traits == TaskTraits.LeftShiftRequired;
        }
    }
}
