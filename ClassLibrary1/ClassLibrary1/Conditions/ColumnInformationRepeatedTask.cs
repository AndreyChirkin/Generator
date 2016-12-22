using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class ColumnInformationRepeatedTask : ConditionObject<ITask>
    {
        public ColumnInformationRepeatedTask() : base("column-information-repeated-task")
        {

        }

        public override bool Check(ITask target)
        {
            return target.Traits == TaskTraits.PermanentTask;
        }
    }
}
