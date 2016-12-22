using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class ColumnDateDeadlineWeek : ConditionObject<ITask>
    {
        public ColumnDateDeadlineWeek() : base("column-date-deadline-week")
        {

        }

        public override bool Check(ITask target)
        {
            return target.Finish > DateTime.Now && (target.Finish - DateTime.Now).TotalDays < 7;
        }
    }
}
