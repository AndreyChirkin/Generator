using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers
{
    public class ResultHeadProvider : ValueProvider<IMeeting>
    {
        public ResultHeadProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "result-head", collection, conditionCollection)
        {

        }

        public override void EmitValue(IMeeting target)
        {
            TextStyle textStyle = new TextStyle();
            StyleCollection.Apply(textStyle, "text-style-bold");
            Generator.RenderText(textStyle, "Результат (что предъявляется)");
        }
    }
}
