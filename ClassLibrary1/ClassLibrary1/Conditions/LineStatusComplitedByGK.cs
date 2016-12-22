using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class LineStatusComplitedByGK : ConditionObject<ITask>
    {
        public LineStatusComplitedByGK() : base("line-status-completed-by-GK")
        {

        }

        public override bool Check(ITask target)
        {
            return target.State == TaskState.ConsidiredFinished;
        }
    }
}
