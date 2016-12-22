using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class ColumnDateUnknown : ConditionObject<ITask>
    {
        public ColumnDateUnknown() : base("column-date-unknown")
        {

        }

        public override bool Check(ITask target)
        {
            return target.Finish == DateTime.MinValue;
        }
    }
}
