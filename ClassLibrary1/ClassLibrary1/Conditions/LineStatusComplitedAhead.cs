using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1.Conditions
{
    public class LineStatusComplitedAhead : ConditionObject<ITask>
    {
        public LineStatusComplitedAhead() : base("line-status-completed-ahead")
        {

        }

        public override bool Check(ITask target)
        {
            return target.State == TaskState.FinishedAhead;
        }
    }
}
