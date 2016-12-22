using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers.TasksProviders
{
    public class SummaryTaskL1Provider : ValueProvider<ITask>
    {
        public SummaryTaskL1Provider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "SummaryTaskL1", collection, conditionCollection)
        {

        }

        public override void EmitValue(ITask target)
        {
            TextStyle textStyle = new TextStyle();
            StyleCollection.Apply(textStyle, "text-style-bold");
            Generator.RenderText(textStyle, $"{target.DisplayNumber} {target.Name}");
            StyleCollection.Apply(textStyle, "text-color-brown");
            Generator.RenderText(textStyle, target.Assignments.IsEmpty ? "" : $" отв. {string.Join(", ", target.Assignments.Select(a => a.Employee.LastName))}");
        }
    }
}
