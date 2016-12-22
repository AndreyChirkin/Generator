using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers.TasksProviders
{
    public class ShiftCountProvider : ValueProvider<ITask>
    {
        public ShiftCountProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "shift-count", collection, conditionCollection)
        {

        }

        public override void EmitValue(ITask target)
        {
            TextStyle textStyle = new TextStyle();
        }
    }
}
