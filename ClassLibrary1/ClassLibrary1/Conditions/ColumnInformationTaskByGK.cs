using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class ColumnInformationTaskByGK : ConditionObject<ITask>
    {
        public ColumnInformationTaskByGK() : base("column-information-task-by-GK")
        {

        }

        public override bool Check(ITask target)
        {
            return target.Traits == TaskTraits.ConstructorTask;
        }
    }
}
