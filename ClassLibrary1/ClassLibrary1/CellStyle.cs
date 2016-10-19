using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class CellStyle
    {
        public CellStyle()
        {
            borderDepth = 0;
        }

        public CellStyle(int value)
        {
            borderDepth = value;
        }

        public BackgroundType backgroundType;

        public BorderType borderType;

        private int borderDepth;

        private int colspan;

        public Align align;

        //выравнивание
        public enum Align { left, center, right };

        //тип фона
        public enum BackgroundType { Solid, Gradient };

        //тип границы
        public enum BorderType { Solid, Hatch };

        //цвет фона
        public Color BackgroundColor { get; set; }

        //боковой цвет градиента
        public Color SideGradientColor { get; set; }

        //толщина границы
        public int BorderDepth
        {
            get { return this.borderDepth; }
            set
            {
                if (value >= 0)
                    borderDepth = value;
                else
                    throw new System.IndexOutOfRangeException();
            }
        }

        public int Colspan
        {
            get { return this.colspan; }
            set
            {
                if (value > 0)
                    colspan = value;
                else
                    throw new System.IndexOutOfRangeException();
            }
        }
            
        //цвет границы
        public Color BorderColor { get; set; }
    }
}
