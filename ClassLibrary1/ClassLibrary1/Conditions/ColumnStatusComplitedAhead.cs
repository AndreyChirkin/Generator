using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class ColumnStatusComplitedAhead : ConditionObject<ITask>
    {
        public ColumnStatusComplitedAhead() : base("column-status-completed-ahead")
        {

        }

        public override bool Check(ITask target)
        {
            return target.State == TaskState.FinishedAhead;
        }
    }
}
