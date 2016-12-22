using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class LineStatusStopped : ConditionObject<ITask>
    {
        public LineStatusStopped() : base("line-status-stopped")
        {

        }

        public override bool Check(ITask target)
        {
            return target.State == TaskState.TemporarilyStopped;
        }
    }
}
