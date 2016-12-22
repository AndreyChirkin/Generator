using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1.Conditions
{
    public class LineStatusComplited : ConditionObject<ITask>
    {
        public LineStatusComplited() : base("line-status-completed")
        {
            //ConditionCollection cc;
            //var lsc = cc.GetCondition<LineStatusCompiled>();
            //if (lsc.Check(task))
            //{
            //    var predecessor = lsc.GetLatestUnfinishedPredecessor(task);
            //    gen.EmitValue($"ЗАБЛОКИРОВАН пунктом {predecessor.DisplayNumber}", ...);

            //}   код поставщика значения в lag-rason
        }

        public override bool Check(ITask target)
        {
            return target.State == TaskState.Finished;
        }
    }
}
