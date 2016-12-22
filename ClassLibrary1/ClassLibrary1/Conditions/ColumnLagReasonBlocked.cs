using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class ColumnLagReasonBlocked : ConditionObject<ITask>
    {
        public ColumnLagReasonBlocked() : base("column-lag-reason-blocked")
        {

        }

        public ITask GetLatestUnfinishedPredecessor(ITask target)//логика условия - задача заблокирована 
        {
            //target.Project.SubProjects.Where(p => p.PercentComplete < 100).
            return target.Predecessors.Where(p => p.From.PercentComplete < 100 && p.Type == DependencyType.FinishFinish).OrderByDescending(t => t.From.Finish).Select(t => t.From).FirstOrDefault();
        }

        public override bool Check(ITask target)
        {
            return target.Finish < DateTime.Now && this.GetLatestUnfinishedPredecessor(target) != null;
        }
    }
}
