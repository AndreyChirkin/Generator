using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers
{
    public class ResultProvider : ValueProvider<IStage>
    {
        public ResultProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "result", collection, conditionCollection)
        {

        }

        public override void EmitValue(IStage target)
        {
            TextStyle textStyle = new TextStyle();
            Parser parser = new Parser(target.Results.Html, Generator);
            parser.Render(parser.Html.ChildNodes, textStyle);
        }
    }
}
