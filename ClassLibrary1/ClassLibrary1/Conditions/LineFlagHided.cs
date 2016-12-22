using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Conditions
{
    public class LineFlagHided : ConditionObject<ITask>
    {
        public LineFlagHided() : base("line-flag-hided")
        {

        }

        public override bool Check(ITask target)
        {
            return target.IsHidden;
        }
    }
}
