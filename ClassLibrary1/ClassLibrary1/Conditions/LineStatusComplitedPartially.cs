using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class LineStatusComplitedPartially : ConditionObject<ITask>
    {
        public LineStatusComplitedPartially() : base("line-status-completed-partially")
        {

        }

        public override bool Check(ITask target)
        {
            return target.State == TaskState.PartiallyFinished;
        }
    }
}
