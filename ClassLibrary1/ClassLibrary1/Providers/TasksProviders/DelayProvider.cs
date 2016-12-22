using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers.TasksProviders
{
    public class DelayProvider : ValueProvider<ITask>
    {
        public DelayProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "delay", collection, conditionCollection)
        {

        }

        public override void EmitValue(ITask target)
        {
            TextStyle textStyle = new TextStyle();
            var text = "";

            if (ConditionCollection.ColumnShiftLegal.Check(target) || ConditionCollection.ColumnShiftIllegal.Check(target) || ConditionCollection.ColumnShiftGestation.Check(target) || ConditionCollection.ColumnShiftRequested.Check(target))
                StyleCollection.Apply(textStyle, "text-style-bold");
            var days = (target.Finish - target.BaselineFinish).TotalDays;
            if (days > 30.4375)
            {
                var monthes = days / 30.4375;
                if (monthes > 10)
                {
                    text = $"{ monthes.ToString("N0")} мес.";
                }
                else
                {
                    text = $"{ monthes.ToString("N1")} мес.";
                }
            }
            else
            {
                var weeks = days / 7;
                text = $"{weeks.ToString("N1")} нед.";
            }

            Generator.RenderText(textStyle, text);
        }
    }
}
