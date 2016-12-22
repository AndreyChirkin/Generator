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
            hide = false;

            borderDepth = 0;

            backgroundType = BackgroundType.Solid;
            BackgroundColor = new Color(255, 255, 255, 1);
            SideGradientColor = new Color(255, 255, 255, 1);

            borderType = BorderType.Solid;
            BorderColor = new Color(0, 0, 0, 1);

            borderDepth = 1;

            colspan = 1;
            align = Align.left;
        }

        public CellStyle(int value)
        {
            borderDepth = value;
        }

        public bool hide { get; set; }

        public BackgroundType backgroundType { get; set; }

        public BorderType borderType { get; set; }

        private int borderDepth;

        private int colspan;

        public Align align { get; set; }

        //выравнивание
        public enum Align { left, center, right, justify };

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
