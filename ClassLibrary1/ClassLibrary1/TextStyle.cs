using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class TextStyle
    {
        public String font;//можно перечисление
 
        public int fontSize { get; set; }

        public Color textColor { get; set; }

        public bool bold { get; set; }

        public bool italic { get; set; }

        public bool underlined { get; set; }
    }
}
