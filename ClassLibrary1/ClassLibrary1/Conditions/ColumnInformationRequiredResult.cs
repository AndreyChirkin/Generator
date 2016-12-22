using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class ColumnInformationRequiredResult : ConditionObject<ITask>
    {
        public ColumnInformationRequiredResult() : base("column-information-required-result")
        {

        }

        public override bool Check(ITask target)
        {
            return target.Traits == TaskTraits.MandatoryResult;
        }
    }
}
