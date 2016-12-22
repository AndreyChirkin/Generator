using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers.TasksProviders
{
    public class SummaryTaskL0Provider : ValueProvider<ITask>
    {
        public SummaryTaskL0Provider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "SummaryTaskL0", collection, conditionCollection)
        {

        }

        public override void EmitValue(ITask target)
        {
            TextStyle textStyle = new TextStyle();
            StyleCollection.Apply(textStyle, "text-style-bold");
            StyleCollection.Apply(textStyle, "text-size-big");
            Generator.RenderText(textStyle, target.Name);
        }
    }
}
