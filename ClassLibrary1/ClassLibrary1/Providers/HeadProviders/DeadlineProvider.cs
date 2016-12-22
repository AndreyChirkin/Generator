using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers
{
    public class DeadlineProvider : ValueProvider<IStage>
    {
        public DeadlineProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "deadline", collection, conditionCollection)
        {

        }

        public override void EmitValue(IStage target)
        {
            TextStyle textStyle = new TextStyle();
            Parser parser = new Parser(target.Terms.Html, Generator);
            parser.Render(parser.Html.ChildNodes, textStyle);
        }
    }
}
