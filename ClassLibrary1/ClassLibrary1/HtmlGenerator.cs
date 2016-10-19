using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ClassLibrary1
{
    public class HtmlGenerator : Generator
    {
        public String Result { get; private set; }

        //public String state;
        public State state;

        public enum State { begin, table, row, cell };

        public HtmlGenerator()
        {
            Result = "";
            state = State.begin;
        }

        public void RenderBegin()
        {
            if (state != State.begin)
                throw new InvalidOperationException();
            Result += String.Format("<!DOCTYPE HTML>\n<html>\n<head>\n<meta charset='utf-8'>\n</head>\n <body>\n<table cols='7' width='1100' border='1' cellspacing='0'>\n");
            state = State.table;//InvalidOperationException
        }

        public void RenderRow()
        {
            if (state != State.table)
                throw new InvalidOperationException();
            Result += "<tr>\n";
            state = State.row;
        }

        public void RenderCell(CellStyle c_style)
        {
            if (state != State.row)
                throw new InvalidOperationException();

            if (c_style == null)
                throw new ArgumentNullException();

            String backgroundColor = "";
            String sideGradintColor = "";
            String borderColor = "";
            String borderType = "";

            backgroundColor += "rgba(" + c_style.BackgroundColor.red + "," + c_style.BackgroundColor.green + "," + c_style.BackgroundColor.blue + "," + c_style.BackgroundColor.a.ToString(CultureInfo.CreateSpecificCulture("en-US")) + ")";
            sideGradintColor += "rgba(" + c_style.SideGradientColor.red + "," + c_style.SideGradientColor.green + "," + c_style.SideGradientColor.blue + "," + c_style.SideGradientColor.a.ToString(CultureInfo.CreateSpecificCulture("en-US")) + ")";
            borderColor += "rgba(" + c_style.BorderColor.red + "," + c_style.BorderColor.green + "," + c_style.BorderColor.blue + "," + c_style.BorderColor.a.ToString(CultureInfo.CreateSpecificCulture("en-US")) + ")";
            
            switch (c_style.borderType)
            {
                case (CellStyle.BorderType.Solid):
                    borderType += "solid";
                    break;
                case (CellStyle.BorderType.Hatch):
                    borderType += "dotted";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (c_style.backgroundType)
            {
                case CellStyle.BackgroundType.Solid:
                    Result += String.Format("<td style='background-color: {0}; border: {1}px {2} {3}' align='{4}' colspan='{5}'>\n", backgroundColor, c_style.BorderDepth, borderType, borderColor, c_style.align, c_style.Colspan);
                    break;
                case CellStyle.BackgroundType.Gradient:
                    Result += String.Format("<td style='background: linear-gradient(to top, {0} 0%,{1} 50%,{1} 50%,{0} 100%); border:{2}px {3} {4}' align='{5}' colspan='{6}'>\n", sideGradintColor, backgroundColor, c_style.BorderDepth, borderType, borderColor, c_style.align, c_style.Colspan);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            state = State.cell;
        }

        public void RenderText(TextStyle t_style, String text)
        {
            if (text == null)
                throw new ArgumentNullException();

            if (t_style == null)
                throw new ArgumentNullException();

            String text_Style = "";
            String textColor = "";

            if (t_style.bold)
                text_Style += "bold ";

            if (t_style.italic)
                text_Style += "italic ";

            text_Style += t_style.fontSize.ToString() + "pt ";
            text_Style += t_style.font;

            if (t_style.underlined)
                text_Style += "; text-decoration: underline";

            textColor += "rgba(" + t_style.textColor.red + "," + t_style.textColor.green + "," + t_style.textColor.blue + "," + t_style.textColor.a.ToString(CultureInfo.CreateSpecificCulture("en-US")) + ")";



            Result += String.Format("<span style='font: {0}; color: {1}'>{2}</span>\n", text_Style, textColor, text);
        }

        public void RenderEnd()  
        {
            switch (state)
            {
               case State.table:
                    Result += "</table>\n</body>\n</html>";
                    state = State.begin;
                    break;
                case State.row:
                    Result += "</tr>\n";
                    state = State.table;
                    break;
                case State.cell:
                    Result += "</td>\n";
                    state = State.row;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
