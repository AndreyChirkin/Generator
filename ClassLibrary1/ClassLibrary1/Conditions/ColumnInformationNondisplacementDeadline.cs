using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class ColumnInformationNondisplacementDeadline : ConditionObject<ITask>
    {
        public ColumnInformationNondisplacementDeadline() : base("column-information-nondisplacement-deadline")
        {

        }

        public override bool Check(ITask target)
        {
            return target.Traits == TaskTraits.StrictDate;
        }
    }
}
