using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class ColumnDateDeadlineSoon : ConditionObject<ITask>
    {
        public ColumnDateDeadlineSoon() : base("column-date-deadline-soon")
        {

        }

        public override bool Check(ITask target)
        {
            return (target.Finish - DateTime.Now).TotalDays < 20 && (target.Finish - DateTime.Now).TotalDays > 0;
        }
    }
}
