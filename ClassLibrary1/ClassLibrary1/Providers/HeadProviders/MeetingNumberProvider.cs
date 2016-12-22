using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers
{
    public class MeetingNumberProvider : ValueProvider<IMeeting>
    {
        public MeetingNumberProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "meeting-number", collection, conditionCollection)
        {

        }

        public override void EmitValue(IMeeting target)
        {
            TextStyle textStyle = new TextStyle();
            StyleCollection.Apply(textStyle, "text-size-big");
            StyleCollection.Apply(textStyle, "text-style-bold");
            Generator.RenderText(textStyle, $"Исходный материал для оперативного совещания № {target.Number.Text}");
        }
    }
}
