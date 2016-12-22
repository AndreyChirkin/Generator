using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers
{
    public class DeadlineHeadProvider : ValueProvider<IMeeting>
    {
        public DeadlineHeadProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "deadline-head", collection, conditionCollection)
        {

        }

        public override void EmitValue(IMeeting target)
        {
            TextStyle textStyle = new TextStyle();
            StyleCollection.Apply(textStyle, "text-style-bold");
            Generator.RenderText(textStyle, "Сроки выполнения");
        }
    }
}
