using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class ColumnStatusNeedResult : ConditionObject<ITask>
    {
        public ColumnStatusNeedResult() : base("column-status-need-result")
        {

        }

        public override bool Check(ITask target)
        {
            return target.State == TaskState.HighAttention;
        }
    }
}
