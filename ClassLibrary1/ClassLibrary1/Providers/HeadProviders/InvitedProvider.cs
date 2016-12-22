using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers
{
    public class InvitedProvider : ValueProvider<IMeeting>
    {
        public InvitedProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "invited", collection, conditionCollection)
        {

        }

        public override void EmitValue(IMeeting target)
        {
            TextStyle textStyle = new TextStyle();
            StyleCollection.Apply(textStyle, "text-style-bold");
            Generator.RenderText(textStyle, "Приглашаются: ");
            StyleCollection.Apply(textStyle, "text-color-brown");
            foreach (var emploee in target.InvitedEmployees.Value)
                Generator.RenderText(textStyle, $"{emploee.ShortName} ");
        }
    }
}
