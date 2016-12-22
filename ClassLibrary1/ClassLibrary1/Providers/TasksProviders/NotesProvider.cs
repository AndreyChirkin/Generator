using ClassLibrary1.Conditions;
using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Providers.TasksProviders
{
    public class NotesProvider : ValueProvider<ITask>
    {
        public NotesProvider(Generator gen, StyleCollection collection, ConditionCollection conditionCollection) : base(gen, "notes", collection, conditionCollection)
        {

        }

        public override void EmitValue(ITask target)
        {
            TextStyle textStyle = new TextStyle();
            foreach (var note in target.Notes)
            {
                Parser parser = new Parser(note.HtmlText, Generator);
                parser.Render(parser.Html.ChildNodes, textStyle);
            }
        }
    }
}
