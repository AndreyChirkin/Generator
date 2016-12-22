using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers
{
    public class EmptyAfterDateProvider : ValueProvider<IMeeting>
    {
        public EmptyAfterDateProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "empty-after-date", collection, conditionCollection)
        {

        }

        public override void EmitValue(IMeeting target)
        {

        }
    }
}
