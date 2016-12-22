using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class LineStatusRemoveFromControl : ConditionObject<ITask>
    {
        public LineStatusRemoveFromControl() : base("line-status-remove-from-control")
        {

        }

        public override bool Check(ITask target)
        {
            return target.State == TaskState.OutOfControl;
        }
    }
}
