using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers
{
    public class DateProvider : ValueProvider<IMeeting>
    {
        public DateProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "date", collection, conditionCollection)
        {

        }

        public override void EmitValue(IMeeting target)
        {
            TextStyle textStyle = new TextStyle();
            StyleCollection.Apply(textStyle, "text-size-big");
            StyleCollection.Apply(textStyle, "text-style-bold");
            Generator.RenderText(textStyle, $"{target.DateTime.Text}");
        }
    }
}
