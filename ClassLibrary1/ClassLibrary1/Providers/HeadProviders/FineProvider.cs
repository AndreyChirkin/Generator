using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers
{
    public class FineProvider : ValueProvider<IMessage>
    {
        public FineProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "fine", collection, conditionCollection)
        {

        }

        public override void EmitValue(IMessage target)
        {
            TextStyle textStyle = new TextStyle();
            StyleCollection.Apply(textStyle, "text-style-bold");
            StyleCollection.Apply(textStyle, "text-style-italic");
            // Generator.RenderText(textStyle, target.Terms.);
            //target.Others.First().Text.
        }
    }
}
