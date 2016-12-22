using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class LineStatusUnknown : ConditionObject<ITask>
    {
        public LineStatusUnknown() : base("line-status-unknown")
        {

        }

        public override bool Check(ITask target)
        {
            return target.State == TaskState.Unknown;
        }
    }
}
