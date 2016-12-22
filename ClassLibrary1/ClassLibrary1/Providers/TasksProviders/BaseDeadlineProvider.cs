using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers.TasksProviders
{
    public class BaseDeadlineProvider : ValueProvider<ITask>
    {
        public BaseDeadlineProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "base-deadline", collection, conditionCollection)
        {

        }

        public override void EmitValue(ITask target)
        {
            TextStyle textStyle = new TextStyle();
            Generator.RenderText(textStyle, target.BaselineFinish.ToString("dd.MM.yy"));
        }
    }
}
//\\(public \w+\(Generator \w+, StyleCollection \w+)(\) : base\(\w+, "[-\w]+", \w+)\)
//$1, ConditionCollection conditionCollection$2, conditionCollection)