using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class ColumnResourceUnknown : ConditionObject<ITask>
    {
        public ColumnResourceUnknown() : base("column-resource-unknown")
        {

        }

        public override bool Check(ITask target)
        {
            return target.Assignments.IsEmpty;
        }
    }
}
