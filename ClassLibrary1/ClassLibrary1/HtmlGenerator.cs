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

        public enum State { begin, table, row, cell, paragraph };

        public HtmlGenerator()
        {
            Result = "";
            state = State.begin;
        }

        public void RenderBegin()
        {
            if (state != State.begin)
                throw new InvalidOperationException();
            Result += String.Format("<!DOCTYPE HTML>\n<html>\n<head>\n<meta charset='utf-8'>\n</head>\n <body>\n<table style='border-collapse: collapse' cols='7' border='1' cellspacing='0'>\n");
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
            string displayNone = "";
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

            if (c_style.hide)
                displayNone += "display: none; ";

            switch (c_style.backgroundType)
            {
                case CellStyle.BackgroundType.Solid:
                    Result += $"<td style='height:1px; {displayNone}background-color: {backgroundColor}; border: {c_style.BorderDepth}px {borderType} {borderColor}' align='{c_style.align}' colspan='{c_style.Colspan}'>\n";
                    break;
                case CellStyle.BackgroundType.Gradient:
                    Result += $"<td style='height:1px; {displayNone}background: {backgroundColor}; background: linear-gradient(to top, {sideGradintColor} 0%,{backgroundColor} 50%,{backgroundColor} 50%,{sideGradintColor} 100%); border:{c_style.BorderDepth}px {borderType} {borderColor}' align='{c_style.align}' colspan='{c_style.Colspan}'>\n";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            state = State.cell;
        }

        public void RenderParagraph(TextStyle t_style)
        {
            if (state != State.cell)
                throw new InvalidOperationException();

            Result += $"<p style='text-align: {t_style.align}'>\n";

            state = State.paragraph;
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

            if (t_style.capital)
                text_Style += "small-caps ";

            text_Style += t_style.fontSize.ToString() + "px ";
            text_Style += t_style.font;

            if (t_style.underlined)
                text_Style += "; text-decoration: underline";

            textColor += "rgba(" + t_style.textColor.red + "," + t_style.textColor.green + "," + t_style.textColor.blue + "," + t_style.textColor.a.ToString(CultureInfo.CreateSpecificCulture("en-US")) + ")";



            Result += $"<span style='font: {text_Style}; color: {textColor}'>{text}</span>";
        }
        
        public void RenderTextBlock(CellStyle c_style, TextStyle t_style, String text)
        {
            if (text == null)
                throw new ArgumentNullException();

            if (t_style == null)
                throw new ArgumentNullException();

            if (c_style == null)
                throw new ArgumentNullException();

            String text_Style = "";
            String textColor = "";

            if (t_style.bold)
                text_Style += "bold ";

            if (t_style.italic)
                text_Style += "italic ";

            text_Style += t_style.fontSize.ToString() + "px ";
            text_Style += t_style.font;

            if (t_style.underlined)
                text_Style += "; text-decoration: underline";

            textColor += "rgba(" + t_style.textColor.red + "," + t_style.textColor.green + "," + t_style.textColor.blue + "," + t_style.textColor.a.ToString(CultureInfo.CreateSpecificCulture("en-US")) + ")";

            String backgroundColor = "";
            String sideGradintColor = "";

            backgroundColor += "rgba(" + c_style.BackgroundColor.red + "," + c_style.BackgroundColor.green + "," + c_style.BackgroundColor.blue + "," + c_style.BackgroundColor.a.ToString(CultureInfo.CreateSpecificCulture("en-US")) + ")";
            sideGradintColor += "rgba(" + c_style.SideGradientColor.red + "," + c_style.SideGradientColor.green + "," + c_style.SideGradientColor.blue + "," + c_style.SideGradientColor.a.ToString(CultureInfo.CreateSpecificCulture("en-US")) + ")";
           
            switch (c_style.backgroundType)
            {
                case CellStyle.BackgroundType.Solid:
                    Result += $"<span style='height:50%; display: block; background-color: {backgroundColor}; font: {text_Style}; color: {textColor}'>{text}</span>\n";
                    break;
                case CellStyle.BackgroundType.Gradient:
                    Result += $"<span style='height:50%; display: block; background: {backgroundColor}; background: linear-gradient(to top, {sideGradintColor} 0%,{backgroundColor} 50%,{backgroundColor} 50%,{sideGradintColor} 100%); font: {text_Style}; color: {textColor}'>{text}</span>\n";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

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
                case State.paragraph:
                    Result += "</p>\n";
                    state = State.cell;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
