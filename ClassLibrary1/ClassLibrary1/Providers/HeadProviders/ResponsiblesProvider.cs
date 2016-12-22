using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers
{
    public class ResponsiblesProvider : ValueProvider<IMeeting>
    {
        public ResponsiblesProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "responsibles", collection, conditionCollection)
        {

        }

        public override void EmitValue(IMeeting target)
        {
            TextStyle textStyle = new TextStyle();
            StyleCollection.Apply(textStyle, "text-style-bold");
            Generator.RenderText(textStyle, "Подготовил: ");
            StyleCollection.Apply(textStyle, "text-color-brown");
            Generator.RenderText(textStyle, target.Manager.Text);
            StyleCollection.Apply(textStyle, "text-color-black");
            Generator.RenderText(textStyle, "  Проведет: ");
            StyleCollection.Apply(textStyle, "text-color-brown");
            Generator.RenderText(textStyle, target.Leader.Text);
        }
    }
}
