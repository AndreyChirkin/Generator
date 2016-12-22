using Mcst.Model;
using Mcst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Mcst.Convertion;
using Mcst.Extensions;

namespace ClassLibrary1.Providers.TasksProviders
{
    public class InformationProvider : ValueProvider<ITask>
    {
        public InformationProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "information", collection, conditionCollection)
        {

        }

        public override void EmitValue(ITask target)
        {
            TextStyle textStyle = new TextStyle();
            StyleCollection.Apply(textStyle, "text-style-bold");

            if (!(ConditionCollection.ColumnPriorityHigh.Check(target) || ConditionCollection.ColumnPriorityTop.Check(target) || ConditionCollection.ColumnInformationTaskByGK.Check(target)))
            {
                StyleCollection.Apply(textStyle, "text-color-yellow");
            }

            if (target.State != TaskState.Undone)
            {
                Generator.RenderText(textStyle, target.State.ToString() + " ");
                if (target.PercentComplete < 100)
                    RenderTraits(textStyle, target);
            }
        }

        public void RenderTraits(TextStyle textStyle, ITask target)
        {
            if (target.Priority > TaskPriority.P7)
            {
                Generator.RenderText(textStyle, "Высокий приоритет ");
            }

            if (target.IsExternal)
            {
                Generator.RenderText(textStyle, "Пункт плана головного исполнителя ");
            }

            foreach (var trait in target.Traits.GetDisplayValues())
            {
                Generator.RenderText(textStyle, trait + " ");
            }
        }
    }
}
