using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class Color
    {
        public Color()
        {
            red = 0;
            green = 0;
            blue = 0;
            a = 1;
        }

        public Color(byte r, byte g, byte b, double ap)
        {
            red = r;
            green = g;
            blue = b;
            a = ap;
        }
        public byte red { get; set; }

        public byte green { get; set; }

        public byte blue { get; set; }

        public double a { get; set; }
    }
}
