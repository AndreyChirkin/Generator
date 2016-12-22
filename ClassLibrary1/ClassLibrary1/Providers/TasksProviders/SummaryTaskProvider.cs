using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers.TasksProviders
{
    public class SummaryTaskProvider : ValueProvider<ITask>
    {
        public SummaryTaskProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "SummaryTask", collection, conditionCollection)
        {

        }

        public override void EmitValue(ITask target)
        {
            TextStyle textStyle = new TextStyle();
            Generator.RenderText(textStyle, $"{target.DisplayNumber} {target.Name}");
            StyleCollection.Apply(textStyle, "text-color-brown");
            Generator.RenderText(textStyle, target.Assignments.IsEmpty ? "" : $" отв. {string.Join(", ", target.Assignments.Select(a => a.Employee.LastName))}");
        }
    }
}
