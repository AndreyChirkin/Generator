using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface Generator
    {
        //генерация начального тега
        void RenderBegin();

        //генерация строки
        void RenderRow();

        //генерация ячейки
        void RenderCell(CellStyle c_style);

        void RenderParagraph(TextStyle t_style);

        //генерация текста
        void RenderText(TextStyle t_style, String text);

        void RenderTextBlock(CellStyle c_style, TextStyle t_style, String text);

        //генерация закрывающего тега
        void RenderEnd();
    }
}
