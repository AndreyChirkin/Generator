using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Mcst.Infrastructure;
using Mcst.Model;

namespace ClassLibrary1
{
    public class Parser
    {
        public IHtmlDocument Html { get; set; }

        private TextStyle ParentStyle { get; set; }

        public Generator Generator { get; set; }

        public Parser(String text, Generator gen)
        {
            ParentStyle = new TextStyle();
            Generator = gen;
            var parser = new HtmlParser();
            Html = parser.Parse(text);
        }

        public Parser(Stream text, Generator gen)
        {
            ParentStyle = new TextStyle();
            Generator = gen;
            var parser = new HtmlParser();
            Html = parser.Parse(text);
        }

        public void Render(INodeList children, TextStyle parentStyle)
        {
            TextStyle currentStyle = new TextStyle();

            foreach (var child in children)
            {
                currentStyle = (TextStyle)parentStyle.Clone();

                if (child.NodeType == NodeType.Element)
                {
                    var element = child as IElement;
                    if (element == null)
                        throw new InvalidOperationException("Type converting is impossible");

                    var IsDivOrParagraph1 = false;

                    switch (element.TagName)
                    {
                        case "P":
                            IsDivOrParagraph1 = true;

                            if (IfAttributeExist(element, "style"))
                            {
                                var value = GetAttribute(element, "style").Value;
                                Regex regex = new Regex("text-align:(left|right|center|justify);");
                                if (regex.IsMatch(value))
                                {
                                    Match match = regex.Match(value);
                                    switch (match.Groups[1].Value)
                                    {
                                        case "left":
                                            currentStyle.align = TextStyle.Align.left;
                                            break;
                                        case "right":
                                            currentStyle.align = TextStyle.Align.right;
                                            break;
                                        case "center":
                                            currentStyle.align = TextStyle.Align.center;
                                            break;
                                        case "justify":
                                            currentStyle.align = TextStyle.Align.justify;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                            Generator.RenderParagraph(currentStyle);

                            break;
                        case "DIV":
                            IsDivOrParagraph1 = true;

                            if (IfAttributeExist(element, "style"))
                            {
                                var value = GetAttribute(element, "style").Value;
                                Regex regex = new Regex("text-align:(left|right|center|justify);");
                                if (regex.IsMatch(value))
                                {
                                    Match match = regex.Match(value);
                                    switch (match.Groups[2].Value)
                                    {
                                        case "left":
                                            currentStyle.align = TextStyle.Align.left;
                                            break;
                                        case "right":
                                            currentStyle.align = TextStyle.Align.right;
                                            break;
                                        case "center":
                                            currentStyle.align = TextStyle.Align.center;
                                            break;
                                        case "justify":
                                            currentStyle.align = TextStyle.Align.justify;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                            Generator.RenderParagraph(currentStyle);
                            break;
                        case "SPAN":
                            if (IfAttributeExist(element, "style"))
                            {
                                var value = GetAttribute(element, "style").Value;
                                Regex regex = new Regex("text-decoration: underline;");
                                if (regex.IsMatch(value))
                                {
                                    currentStyle.underlined = true;
                                }

                                //regex = new Regex(@"color: rgb\(([0-9]*), ([0-9]*), ([0-9]*)\);");
                                regex = new Regex(@"color:#([abcdef0-9]{6});");
                                if (regex.IsMatch(value))
                                {
                                    Match match = regex.Match(value);

                                    currentStyle.textColor = new Color();
                                    currentStyle.textColor = ConvertHexStrToColor(match.Groups[1].Value);

                                }

                                regex = new Regex("font-family: (.*);");
                                if (regex.IsMatch(value))
                                {
                                    Match match = regex.Match(value);
                                    currentStyle.font = match.Groups[1].Value;
                                }

                                regex = new Regex("font-size: (.*)px;");
                                if (regex.IsMatch(value))
                                {
                                    Match match = regex.Match(value);
                                    currentStyle.fontSize = Int32.Parse(match.Groups[1].Value);
                                }
                            }
                            //if (element.Children.Length == 0)
                            //    Generator.RenderText(parentStyle, child.TextContent);
                            break;
                        case "STRONG":
                            currentStyle.bold = true;
                            //if (element.Children.Length == 0)
                            //    Generator.RenderText(parentStyle, child.TextContent);
                            break;
                        case "EM":
                            currentStyle.italic = true;
                            //if (element.Children.Length == 0)
                            //    Generator.RenderText(parentStyle, child.TextContent);
                            break;
                        default:
                            break;
                    }

                    Render(child.ChildNodes, (TextStyle)currentStyle.Clone());

                    if (IsDivOrParagraph1)
                    {
                        Generator.RenderEnd();
                        //parentStyle = new TextStyle();
                    }
                }
                else if (child.NodeType == NodeType.Text)
                {
                    var text = child as IText;
                    if (text == null)
                        throw new InvalidOperationException("Type converting is impossible");
                    Generator.RenderText(currentStyle, text.Data);
                    
                }

                

            }

                
        }

        private bool IfAttributeExist(IElement target, String name)
        {
            return target.Attributes.FirstOrDefault(s => s.Name == name) != null;
        }

        private IAttr GetAttribute(IElement target, String name)
        {
            return target.Attributes.FirstOrDefault(s => s.Name == name);
        }

        private Color ConvertHexStrToColor(String target)
        {
            var hexValues = new String[3];
            var byteValues = new byte[3];

            Color color = new Color();

            var startIndex = 0;

            for (var i = 0; i < 3; i++)
            {
                hexValues[i] = target.Substring(startIndex, 2);
                startIndex += 2;
            }

            for (var i = 0; i < 3; i++)
            {
                byteValues[i] = Convert.ToByte(hexValues[i], 16);
            }

            color.red = byteValues[0];
            color.green = byteValues[1];
            color.blue = byteValues[2];

            return color;
        }
        
    }

    
}
