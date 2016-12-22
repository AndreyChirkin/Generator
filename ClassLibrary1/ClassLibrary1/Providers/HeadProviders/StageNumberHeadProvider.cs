using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers
{
    public class StageNumberHeadProvider : ValueProvider<IMeeting>
    {
        public StageNumberHeadProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "stage-number-head", collection, conditionCollection)
        {

        }

        public override void EmitValue(IMeeting target)
        {
            TextStyle textStyle = new TextStyle();
            StyleCollection.Apply(textStyle, "text-style-bold");
            Generator.RenderText(textStyle, "№ этапа");
        }
    }
}
