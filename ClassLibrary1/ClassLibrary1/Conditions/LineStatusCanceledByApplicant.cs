using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class LineStatusCanceledByApplicant : ConditionObject<ITask>
    {
        public LineStatusCanceledByApplicant() : base("line-status-canceled-by-applicant")
        {

        }

        public override bool Check(ITask target)
        {
            return target.State == TaskState.CancelledByApplicant;
        }
    }
}
