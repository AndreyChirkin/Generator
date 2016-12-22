using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public abstract class ValueProvider<T>
    {
        protected ValueProvider(Generator gen, string name, StyleCollection collection, ConditionCollection conditionCollection)
        {
            Name = name;
            Generator = gen;
            StyleCollection = collection;
            ConditionCollection = conditionCollection;
        }

        public abstract void EmitValue(T target);

        public String Name { get; }

        protected Generator Generator { get; }

        public StyleCollection StyleCollection { get; }

        public ConditionCollection ConditionCollection { get; }
    }
}
