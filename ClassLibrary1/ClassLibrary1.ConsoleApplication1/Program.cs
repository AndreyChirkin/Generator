using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary1.ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlGenerator test = new HtmlGenerator();
            Color white = new Color(255, 255, 255, 1);
            Color black = new Color(0, 0, 0, 1);
            Color brown = new Color(100, 40, 0, 1);
            Color lightBrown = new Color(230,40, 0, 0.7);
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
            ts1.font="Arial";
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
            ts2.font="Arial";
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

            cs4.Colspan=2;
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

            test.RenderCell(cs4);
            test.RenderText(ts3, "причина отставания");
            test.RenderEnd();


            while (test.state != HtmlGenerator.State.begin)
            {
                test.RenderEnd();
            }
            File.WriteAllText("C:\\Users\\user\\Desktop\\RESULT.html", test.Result);

        }
    }
}
