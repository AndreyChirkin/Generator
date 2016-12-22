using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class TextStyle : ICloneable
    {
        public TextStyle()
        {
            font = "Times New Roman";
            fontSize = 16;
            textColor = new Color(0, 0, 0, 1);
            bold = false;
            italic = false;
            underlined = false;
            capital = false;
            align = Align.left;
        }

        public Align align { get; set; }

        public enum Align { left, center, right, justify };

        public String font;//можно перечисление
 
        public int fontSize { get; set; }

        public Color textColor { get; set; }

        public bool bold { get; set; }

        public bool italic { get; set; }

        public bool underlined { get; set; }

        public bool capital { get; set; }

        public object Clone()
        {
            return new TextStyle
            {
                align = this.align,
                font = this.font,
                fontSize = this.fontSize,
                textColor = this.textColor,
                bold = this.bold,
                italic = this.italic,
                underlined = this.underlined,
                capital = this.capital
            };
        }
    }
}
