using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers
{
    public class StageNumberProvider : ValueProvider<IStage>
    {
        public StageNumberProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "stage-number", collection, conditionCollection)
        {

        }

        public override void EmitValue(IStage target)
        {
            TextStyle textStyle = new TextStyle();
            StyleCollection.Apply(textStyle, "text-style-bold");
            StyleCollection.Apply(textStyle, "text-style-italic");
            Generator.RenderText(textStyle, target.DisplayNumber.Text);
        }
    }
}
