using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;
using Mcst.Extensions;
using AngleSharp.Parser.Html;
using Mcst.Model;
using Mcst.Convertion;

namespace ClassLibrary1.ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            /* HtmlGenerator test = new HtmlGenerator();
             Color white = new Color(255, 255, 255, 1);
             Color black = new Color(0, 0, 0, 1);
             Color brown = new Color(100, 40, 0, 1);
             Color lightBrown = new Color(230, 40, 0, 0.7);
             test.RenderBegin();
             test.RenderRow();

             CellStyle cs1 = new CellStyle();
             cs1.BorderDepth = 1;
             cs1.Colspan = 3;
             cs1.BorderColor = black;
             cs1.BackgroundColor = white;
             cs1.SideGradientColor = white;

             test.RenderCell(cs1);

             TextStyle ts1 = new TextStyle();
             ts1.font = "Arial";
             ts1.fontSize = 20;
             ts1.bold = true;
             ts1.textColor = black;

             test.RenderText(ts1, "ПРОЦЕССОР 9");
             test.RenderEnd();

             CellStyle cs2 = new CellStyle();
             cs2.BorderDepth = 1;
             cs2.Colspan = 1;
             cs2.BorderColor = black;
             cs2.BackgroundColor = white;
             cs2.SideGradientColor = white;

             test.RenderCell(cs2);
             test.RenderEnd();

             CellStyle cs3 = new CellStyle();
             cs3.BorderDepth = 1;
             cs3.Colspan = 3;
             cs3.BorderColor = black;
             cs3.BackgroundColor = white;
             cs3.SideGradientColor = white;

             test.RenderCell(cs3);

             TextStyle ts2 = new TextStyle();
             ts2.font = "Arial";
             ts2.fontSize = 11;
             ts2.textColor = black;

             test.RenderText(ts2, "Утверждаю ГК ОКР Волконский В.Ю.");

             test.RenderEnd();
             test.RenderEnd();

             test.RenderRow();

             CellStyle cs4 = new CellStyle();
             cs4.BorderDepth = 1;
             cs4.Colspan = 4;
             cs4.BorderColor = black;
             cs4.BackgroundColor = white;
             cs4.SideGradientColor = white;

             test.RenderCell(cs4);

             TextStyle ts3 = new TextStyle();
             ts3.font = "Arial";
             ts3.fontSize = 16;
             ts3.textColor = black;
             ts3.bold = true;

             test.RenderText(ts3, "Исходный материал для оперативного совещания №114");
             test.RenderEnd();

             cs4.Colspan = 2;
             cs4.align = CellStyle.Align.center;

             test.RenderCell(cs4);
             test.RenderText(ts3, "20.09.16");
             test.RenderEnd();

             cs4.Colspan = 1;

             test.RenderCell(cs4);
             test.RenderEnd();
             test.RenderEnd();
             test.RenderRow();

             cs4.backgroundType = CellStyle.BackgroundType.Gradient;
             cs4.BackgroundColor = lightBrown;
             cs4.SideGradientColor = white;
             cs4.BorderColor = brown;
             cs4.BorderDepth = 2;
             cs4.align = CellStyle.Align.left;

             test.RenderCell(cs4);

             ts3.fontSize = 12;

             test.RenderText(ts3, "№ этапа");
             test.RenderEnd();

             cs4.Colspan = 2;

             test.RenderCell(cs4);
             test.RenderText(ts3, "Наименование этапа, содержание работ этапа");
             test.RenderEnd();

             cs4.Colspan = 1;
             test.RenderCell(cs4);
             test.RenderText(ts3, "Результат (что предъявляется)");
             test.RenderEnd();

             cs4.Colspan = 3;
             test.RenderCell(cs4);
             test.RenderText(ts3, "Сроки выполнения");
             test.RenderEnd();
             test.RenderEnd();
             test.RenderRow();

             ts3.fontSize = 10;
             cs4.Colspan = 1;
             cs4.BackgroundColor = white;
             cs4.backgroundType = CellStyle.BackgroundType.Solid;

             test.RenderCell(cs4);
             test.RenderText(ts3, "№ пп,");
             test.RenderEnd();

             test.RenderCell(cs4);
             test.RenderText(ts3, "ответственный");
             test.RenderEnd();

             test.RenderCell(cs4);
             test.RenderText(ts3, "задание согласно плану ОКР");
             test.RenderEnd();

             test.RenderCell(cs4);
             test.RenderText(ts3, "статус выполнения заданий");
             test.RenderEnd();

             test.RenderCell(cs4);
             test.RenderText(ts3, "первоначальный срок выполнения");
             test.RenderEnd();

             test.RenderCell(cs4);
             test.RenderText(ts3, "ожидаемый срок выполнения");
             test.RenderEnd();

             CellStyle cs5 = new CellStyle();
             cs5.BackgroundColor = white;
             cs5.SideGradientColor = black;
             cs5.backgroundType = CellStyle.BackgroundType.Gradient;
             test.RenderCell(cs4);
             test.RenderTextBlock(cs5, ts3, "причина отставания");
             test.RenderTextBlock(cs4, ts3, "причина отставания");
             test.RenderEnd();


             while (test.state != HtmlGenerator.State.begin)
             {
                 test.RenderEnd();
             }
             File.WriteAllText("D:\\Users\\chirkin_a\\Desktop\\RESULT.html", test.Result);*/
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //Render render = new Render();
            //XmlSerializer mySer = new XmlSerializer(typeof(Render));
            //FileStream myFileStream = new FileStream("D:/Users/chirkin_a/Source/Repos/Generator/ClassLibrary1/ClassLibrary1/testXml.xml", FileMode.Open);
            //render = (Render)
            //    mySer.Deserialize(myFileStream);

            //TextStyle ts = new TextStyle();
            //CellStyle cs = new CellStyle();
            //var setters_ = new SetterObject[render.styles.First(s => s.name == "background-gradient-orange").setters.Length];
            //for(var i =0;i< render.styles.First(s => s.name == "background-gradient-orange").setters.Length;i++)
            //{
            //    SetterObject set = new SetterObject(cs.GetType(), render.styles.First(s => s.name == "background-gradient-orange").setters[i].path, render.styles.First(s => s.name == "background-gradient-orange").setters[i].value);
            //    setters_[i] = set;
            //}
            //StyleObject st = new StyleObject(cs.GetType(), setters_, render.styles.First(s => s.name == "background-gradient-orange").name);
            //st.Apply(cs);
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //var path = "BackgroundColor.red";
            //var value = "150";
            //var converter = Activator.CreateInstance(Type.GetType("ClassLibrary1.Color"));
            //CellStyle cs = new CellStyle();

            //var segments = path.Split('.');
            //var type = cs.GetType();

            //object obj = cs;
            //PropertyInfo property = null;
            //foreach (var segment in segments)
            //{
            //    if (property != null)
            //    {
            //        obj = property.GetValue(obj);
            //        type = obj.GetType();
            //    }
            //    property = type.GetProperty(segment);
            //}
            //if (property == null) throw new ArgumentException();
            //property.SetValue(obj, Convert.ChangeType(value, property.PropertyType));

            //cs.BackgroundColor.red = Convert.ToByte("150");

            //var assemnblies = AppDomain.CurrentDomain.GetAssemblies();
            //foreach (var a in assemnblies)
            //{
            //    var types = a.GetTypes().Where(t => typeof(string).IsAssignableFrom(t))
            //        .Select(t => (string)Activator.CreateInstance(t))
            //        .ToDictionary(p => p.Name);

            //}
            var gen = new HtmlGenerator();
            gen.state = HtmlGenerator.State.cell;
            TextStyle t = new TextStyle();
            var parser = new HtmlParser();
            FileStream fs = new FileStream("D:\\Users\\chirkin_a\\Desktop\\testHtml.txt", FileMode.Open, FileAccess.Read);
            //var doc = parser.Parse(fs);
            var p = new Parser(fs, gen);
            p.Render(p.Html.ChildNodes, (TextStyle)t.Clone());
            File.WriteAllText("D:\\Users\\chirkin_a\\Desktop\\testResult.html", gen.Result);

            var type = typeof(TaskTraits);
            var traits = TaskTraits.DirectorTask | TaskTraits.MandatoryResult | TaskTraits.RiskOfStageFail;
            var str = Enum.GetValues(typeof(TaskTraits)).Cast<TaskTraits>().Where(tr => traits.HasFlag(tr))
                .Select(tr => type.GetMember(tr.ToString())[0].GetCustomAttribute<EnumStringAttribute>().Value);

            Console.WriteLine(string.Join("\r\n", str));

            //foreach (var item in GenerateStrings())
            //{
            //    Console.WriteLine($"Вы ввели {item}");
            //}
            Console.Write("Нажмите любую клавишу...");
            Console.ReadKey();
        }

        static IEnumerable<string> GenerateStrings()
        {
            Console.Write("Введите число строк: ");
            var num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                Console.Write($"Введите строку №{i + 1}: ");
                var input = Console.ReadLine();
                if (StringComparer.OrdinalIgnoreCase.Equals(input, "another"))
                {
                    foreach (var item in GenerateAnotherStrings())
                    {
                        yield return item;
                    }
                }
                yield return input;
            }
        }

        static IEnumerable<string> GenerateAnotherStrings()
        {
            yield return "a";
            yield return "b";
            yield return "c";
        }
    }
}
