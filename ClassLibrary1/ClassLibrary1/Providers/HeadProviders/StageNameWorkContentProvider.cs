using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers
{
    public class StageNameWorkContentProvider : ValueProvider<IStage>
    {
        public StageNameWorkContentProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "stage-name-work-content", collection, conditionCollection)
        {

        }

        public override void EmitValue(IStage target)
        {
            TextStyle textStyle = new TextStyle();
            Parser parser = new Parser(target.Tasks.Html, Generator);
            parser.Render(parser.Html.ChildNodes, textStyle);
        }
    }
}
