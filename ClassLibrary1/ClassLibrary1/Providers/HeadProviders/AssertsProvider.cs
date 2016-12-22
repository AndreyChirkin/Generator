using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mcst.Model;

namespace ClassLibrary1.Providers
{
    class AssertsProvider:ValueProvider<IMeeting>
    {
        public AssertsProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) :base(gen, "asserts", collection, conditionCollection)
        {

        }

        public override void EmitValue(IMeeting target)
        {
            
            TextStyle textStyle = new TextStyle();
            StyleCollection.Apply(textStyle, "text-style-bold");
            Generator.RenderText(textStyle, "Утверждаю ГК ОКР");
            Generator.RenderText(textStyle, target.Project.Constructor.ShortName);
        }
    }
}
