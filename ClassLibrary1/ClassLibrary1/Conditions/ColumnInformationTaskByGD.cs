using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class ColumnInformationTaskByGD : ConditionObject<ITask>
    {
        public ColumnInformationTaskByGD() : base("column-information-task-by-GD")
        {

        }

        public override bool Check(ITask target)
        {
            return target.Traits == TaskTraits.DirectorTask;
        }
    }
}
