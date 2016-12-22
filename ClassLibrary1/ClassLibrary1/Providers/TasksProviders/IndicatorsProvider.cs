using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers.TasksProviders
{
    public class IndicatorsProvider : ValueProvider<ITask>
    {
        public IndicatorsProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "indicators", collection, conditionCollection)
        {

        }

        public override void EmitValue(ITask target)
        {
            TextStyle textStyle = new TextStyle();
            if (target.Priority > TaskPriority.P7)
                Generator.RenderText(textStyle, "!!! ");
            if (target.IsMilestone)
                Generator.RenderText(textStyle, "|>");

            //foreach (var emp in target.Assignments)
            //{
            //    Generator.RenderText(null, emp.Employee.ShortName);
            //}
            //target.BaselineFinish.ToString("dd.MM.yy");
            //target.Traits = TaskTraits.
        }
    }
}
