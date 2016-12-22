using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers
{
    public class TopicProvider : ValueProvider<IMeeting>
    {
        public TopicProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "topic", collection, conditionCollection)
        {

        }

        public override void EmitValue(IMeeting target)
        {
            TextStyle textStyle = new TextStyle();

            if (target.Stages.Value.Count() != 0)
            {
                StyleCollection.Apply(textStyle, "text-style-bold");
                Generator.RenderText(textStyle, "Будут обсуждаться: ");

                StyleCollection.Apply(textStyle, "text-color-violet");

                if (target.Stages.Value.Count() > 1)
                {
                    Generator.RenderText(textStyle, "работы этапов ");
                    foreach (var stage in target.Stages.Value)
                    {
                        Generator.RenderText(textStyle, $"{stage.DisplayNumber.Text}");
                        if (stage != target.Stages.Value.Last())
                            Generator.RenderText(textStyle, ", ");
                    }
                }

                Generator.RenderText(textStyle, $"работы этапа {target.Stages.Value.First().DisplayNumber.Text}");
            }

        }
    }
}
