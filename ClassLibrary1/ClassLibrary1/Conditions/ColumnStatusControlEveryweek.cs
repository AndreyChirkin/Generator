using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class ColumnStatusControlEveryweek : ConditionObject<ITask>
    {
        public ColumnStatusControlEveryweek() : base("column-status-control-everyweek")
        {

        }

        public override bool Check(ITask target)
        {
            return target.State == TaskState.WeekControl;
        }
    }
}
