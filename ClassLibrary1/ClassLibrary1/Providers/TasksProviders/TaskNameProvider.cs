using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers.TasksProviders
{
    public class TaskNameProvider : ValueProvider<ITask>
    {
        public TaskNameProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "taskname", collection, conditionCollection)
        {

        }

        public override void EmitValue(ITask target)
        {
            TextStyle textStyle = new TextStyle();
            Generator.RenderText(textStyle, target.Name);
        }
    }
}
