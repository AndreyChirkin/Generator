using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers
{
    public class NameProvider:ValueProvider<IMeeting>
    {
        public NameProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "name", collection, conditionCollection)
        {
            
        }

        public override void EmitValue(IMeeting target)
        {
            TextStyle textStyle = new TextStyle();
            StyleCollection.Apply(textStyle, "text-size-very-big");
            StyleCollection.Apply(textStyle, "text-style-bold");
            StyleCollection.Apply(textStyle, "text-style-capital");
            Generator.RenderText(textStyle, target.Project.Name);
        }
    }
}
