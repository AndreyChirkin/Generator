using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers.TasksProviders
{
    public class TrueDeadlineProvider : ValueProvider<ITask>
    {
        public TrueDeadlineProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "true-deadline", collection, conditionCollection)
        {

        }

        public override void EmitValue(ITask target)
        {
            TextStyle textStyle = new TextStyle();
            String text;

            text = target.Finish.ToString("dd.MM.yy");

            if (ConditionCollection.ColumnDateDeadlineSoon.Check(target))
            {
                StyleCollection.Apply(textStyle, "text-style-bold");
                if (ConditionCollection.ColumnDateDeadlineWeek.Check(target))
                    StyleCollection.Apply(textStyle, "text-color-red");
                if (ConditionCollection.ColumnDateDeadlineSquander.Check(target))
                    StyleCollection.Apply(textStyle, "text-color-white");
                if (ConditionCollection.ColumnDateUnknown.Check(target))
                {
                    StyleCollection.Apply(textStyle, "text-color-yellow");
                    StyleCollection.Apply(textStyle, "text-size-big");
                    text = "???";
                }
            }

            Generator.RenderText(textStyle, text);
        }
    }
}
