using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers.TasksProviders
{
    public class LagReasonProvider : ValueProvider<ITask>
    {
        public LagReasonProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "lag-reason", collection, conditionCollection)
        {

        }

        public override void EmitValue(ITask target)
        {
            TextStyle textStyle1 = new TextStyle();
            TextStyle textStyle2 = new TextStyle();
            CellStyle cellStyle = new CellStyle();

            //block1
            if (ConditionCollection.ColumnShiftLegal.Check(target) && ConditionCollection.PartColumnShiftReason.Check(target))
            {
                StyleCollection.Apply(textStyle1, "text-color-red");
                StyleCollection.Apply(textStyle1, "text-style-bold");
            }

            if (ConditionCollection.ColumnShiftIllegal.Check(target) && ConditionCollection.PartColumnShiftReason.Check(target))
            {
                StyleCollection.Apply(textStyle1, "text-color-black");
                StyleCollection.Apply(textStyle1, "text-style-bold");
            }

            if (ConditionCollection.ColumnShiftGestation.Check(target) && ConditionCollection.PartColumnShiftReason.Check(target))
            {
                StyleCollection.Apply(textStyle1, "text-color-black");
                StyleCollection.Apply(textStyle1, "text-style-bold");
            }
            Generator.RenderTextBlock(cellStyle, textStyle1, target.LagReason.Substring(0, target.LagReason.IndexOf("(") - 1));

            //block2
            if (ConditionCollection.ColumnShiftLegal.Check(target) && ConditionCollection.PartColumnShiftCulprit.Check(target))
            {
                StyleCollection.Apply(textStyle2, "text-color-black");
                StyleCollection.Apply(textStyle2, "text-style-bold");
            }

            if (ConditionCollection.ColumnShiftIllegal.Check(target) && ConditionCollection.PartColumnShiftCulprit.Check(target))
            {
                StyleCollection.Apply(textStyle2, "text-color-yellow");
                StyleCollection.Apply(textStyle2, "text-style-bold");
            }

            if (ConditionCollection.ColumnShiftGestation.Check(target) && ConditionCollection.PartColumnShiftCulprit.Check(target))
            {
                StyleCollection.Apply(textStyle2, "text-color-yellow");
                StyleCollection.Apply(textStyle2, "text-style-bold");
            }
            if (ConditionCollection.PartColumnShiftCulprit.Check(target))
                Generator.RenderTextBlock(cellStyle, textStyle2, target.LagReason.Substring(target.LagReason.IndexOf("(")));

            
        }
    }
}
