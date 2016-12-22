using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers.TasksProviders
{
    public class NumberProvider : ValueProvider<ITask>
    {
        public NumberProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "number", collection, conditionCollection)
        {

        }

        public override void EmitValue(ITask target)
        {
            //target.IsSummary
            TextStyle textStyle = new TextStyle();
            if (ConditionCollection.ColumnCriticalWayTrue.Check(target))
                StyleCollection.Apply(textStyle, "text-style-bold");
            Generator.RenderText(textStyle, target.DisplayNumber);
        }
    }
}
