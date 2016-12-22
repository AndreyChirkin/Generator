using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers
{
    public class StageNameWorkContentHeadProvider : ValueProvider<IMeeting>
    {
        public StageNameWorkContentHeadProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "stage-name-work-content-head", collection, conditionCollection)
        {

        }

        public override void EmitValue(IMeeting target)
        {
            TextStyle textStyle = new TextStyle();
            StyleCollection.Apply(textStyle, "text-style-bold");
            Generator.RenderText(textStyle, "Наименование этапа. Содержание работ этапа.");
        }
    }
}
