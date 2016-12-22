using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public abstract class ConditionObject<T>
    {
        protected ConditionObject(string name)
        {
            Name = name;
        }
        
        public String Name { get; }

        public abstract bool Check(T target);
    }
}
