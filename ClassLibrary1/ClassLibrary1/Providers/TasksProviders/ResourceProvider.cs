using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers.TasksProviders
{
    public class ResourceProvider : ValueProvider<ITask>
    {
        public ResourceProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "resource", collection, conditionCollection)
        {

        }

        public override void EmitValue(ITask target)
        {
            TextStyle textStyle = new TextStyle();
            if (ConditionCollection.ColumnResourceUnknown.Check(target))
            {
                StyleCollection.Apply(textStyle, "text-style-bold");
                StyleCollection.Apply(textStyle, "text-size-big");
                Generator.RenderText(textStyle, "???");
            }

            foreach(var assignment in target.Assignments)
            {
                Generator.RenderText(textStyle, String.Join(", ", assignment.Employee.ShortName));
            }
            
        }
    }
}
