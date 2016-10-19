using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary1.Test
{
    [TestFixture]
    public class GeneratorTests
    {
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            Assert.Pass("Your first passing test");
        }

        [Test]
        public void TestCellStyleDeafultConstructor()
        {
            CellStyle cellStyle = new CellStyle();
            Assert.AreEqual(0, cellStyle.BorderDepth);
            CellStyle test = new CellStyle();
            Assert.IsNotNull(test.BorderDepth);
        }

        [Test]
        public void TestCellStyleConstructor()
        {
            CellStyle cellStyle = new CellStyle(2);
            Assert.AreEqual(2, cellStyle.BorderDepth);
        }

        [Test]
        public void TestType()
        {
            CellStyle test = new CellStyle();
            Assert.IsNull(test.BackgroundColor);
            Assert.IsNull(test.BorderColor);
        }

        [Test]
        public void TestCellStyleSetBorderDepth()
        {
            CellStyle test = new CellStyle();
            test.BorderDepth = 1;
            Assert.AreEqual(1, test.BorderDepth);
        }

        [Test]
        public void TestTextStyleInitialisation()
        {
            TextStyle test = new TextStyle();
            test.font = "Arial";
            test.fontSize = 14;
            test.bold = false;
            test.italic = true;
            test.underlined = false;
            Assert.AreEqual(test.font, "Arial");
            Assert.AreEqual(test.fontSize, 14);
            Assert.IsFalse(test.bold);
            Assert.IsTrue(test.italic);
            Assert.False(test.underlined);
        }

        [Test]
        public void TestHtmlGeneratorConstructor()
        {
            HtmlGenerator test = new HtmlGenerator();
            Assert.That(test.state == HtmlGenerator.State.begin);
            Assert.That(test.Result == "");
        }

        [Test]
        public void TestHtmlGeneratorRenderBegin()
        {
            String expectedResult = "<!DOCTYPE HTML>\n<html>\n<head>\n<meta charset='utf-8'>\n</head>\n <body>\n<table cols='7' width='1100' border='1' cellspacing='0'>\n";
            HtmlGenerator test = new HtmlGenerator();
            test.RenderBegin();
            Assert.That(expectedResult == test.Result);
        }

        [Test]
        public void TestHtmlGeneratorRenderBeginException()
        {
            HtmlGenerator test = new HtmlGenerator();
            test.state = HtmlGenerator.State.table;
            Assert.That(() => test.RenderBegin(), Throws.InvalidOperationException);
        }

        [Test]
        public void TestHtmlGeneratorRenderRow()
        {
            String expectedResult = "<tr>\n";
            HtmlGenerator test = new HtmlGenerator();
            test.state = HtmlGenerator.State.table;
            test.RenderRow();
            Assert.That(expectedResult == test.Result);
        }

        [Test]
        public void TestHtmlGeneratorRenderRowException()
        {
            HtmlGenerator test = new HtmlGenerator();
            test.state = HtmlGenerator.State.begin;
            Assert.That(() => test.RenderRow(), Throws.InvalidOperationException);
        }

        //[Test]
        //public void TestHtmlGeneratorRenderCell()
        //{
        //    String expectedResult = "<td style='font: bold italic 14pt Arial; color: rgba(255,0,0,1); background: -webkit-linear-gradient(top, rgba(255,255,0,1) 0%,rgba(255,0,0,1) 50%,rgba(255,0,0,1) 50%,rgba(255,255,0,1) 100%); border:3px dotted rgba(255,0,0,1)'>";
        //    HtmlGenerator test = new HtmlGenerator();
        //    test.state = HtmlGenerator.State.row;
        //    CellStyle cs = new CellStyle();
        //    TextStyle ts = new TextStyle();
        //    Color col = new Color(255, 0, 0, 1);
        //    Color col1 = new Color(255, 255, 0, 1);
        //    cs.BorderDepth = 3;
        //    cs.BackgroundColor = col;
        //    cs.SideGradientColor = col1;
        //    cs.backgroundType = CellStyle.BackgroundType.Gradient;
        //    cs.borderType = CellStyle.BorderType.Hatch;
        //    cs.BorderColor = col;
        //    ts.font = "Arial";
        //    ts.fontSize = 14;
        //    ts.textColor = col;
        //    ts.bold = true;
        //    ts.italic = true;
        //    ts.underlined = false;
        //    test.RenderCell(ts, cs);
        //    Assert.That(expectedResult == test.Result);
        //}

        //[Test]
        //public void TestHtmlGeneratorRenderCellItalicText()
        //{
        //    String expectedResult = "<td style='font: italic 14pt Arial; color: rgba(255,0,0,1); background: -webkit-linear-gradient(top, rgba(255,255,0,1) 0%,rgba(255,0,0,1) 50%,rgba(255,0,0,1) 50%,rgba(255,255,0,1) 100%); border:3px dotted rgba(255,0,0,1)'>";
        //    HtmlGenerator test = new HtmlGenerator();
        //    test.state = HtmlGenerator.State.row;
        //    CellStyle cs = new CellStyle();
        //    TextStyle ts = new TextStyle();
        //    Color col = new Color(255, 0, 0, 1);
        //    Color col1 = new Color(255, 255, 0, 1);
        //    cs.BorderDepth = 3;
        //    cs.BackgroundColor = col;
        //    cs.SideGradientColor = col1;
        //    cs.backgroundType = CellStyle.BackgroundType.Gradient;
        //    cs.borderType = CellStyle.BorderType.Hatch;
        //    cs.BorderColor = col;
        //    ts.font = "Arial";
        //    ts.fontSize = 14;
        //    ts.textColor = col;
        //    ts.bold = false;
        //    ts.italic = true;
        //    ts.underlined = false;
        //    test.RenderCell(ts, cs);
        //    Assert.That(expectedResult == test.Result);
        //}

        //[Test]
        //public void TestHtmlGeneratorRenderCellBoldText()
        //{
        //    String expectedResult = "<td style='font: bold 14pt Arial; color: rgba(255,0,0,1); background: -webkit-linear-gradient(top, rgba(255,255,0,1) 0%,rgba(255,0,0,1) 50%,rgba(255,0,0,1) 50%,rgba(255,255,0,1) 100%); border:3px dotted rgba(255,0,0,1)'>";
        //    HtmlGenerator test = new HtmlGenerator();
        //    test.state = HtmlGenerator.State.row;
        //    CellStyle cs = new CellStyle();
        //    TextStyle ts = new TextStyle();
        //    Color col = new Color(255, 0, 0, 1);
        //    Color col1 = new Color(255, 255, 0, 1);
        //    cs.BorderDepth = 3;
        //    cs.BackgroundColor = col;
        //    cs.SideGradientColor = col1;
        //    cs.backgroundType = CellStyle.BackgroundType.Gradient;
        //    cs.borderType = CellStyle.BorderType.Hatch;
        //    cs.BorderColor = col;
        //    ts.font = "Arial";
        //    ts.fontSize = 14;
        //    ts.textColor = col;
        //    ts.bold = true;
        //    ts.italic = false;
        //    ts.underlined = false;
        //    test.RenderCell(ts, cs);
        //    Assert.That(expectedResult == test.Result);
        //}

        //[Test]
        //public void TestHtmlGeneratorRenderCellUnderlinedText()
        //{
        //    String expectedResult = "<td style='font: bold 14pt Arial; text-decoration: underline; color: rgba(255,0,0,1); background: -webkit-linear-gradient(top, rgba(255,255,0,1) 0%,rgba(255,0,0,1) 50%,rgba(255,0,0,1) 50%,rgba(255,255,0,1) 100%); border:3px dotted rgba(255,0,0,1)'>";
        //    HtmlGenerator test = new HtmlGenerator();
        //    test.state = HtmlGenerator.State.row;
        //    CellStyle cs = new CellStyle();
        //    TextStyle ts = new TextStyle();
        //    Color col = new Color(255, 0, 0, 1);
        //    Color col1 = new Color(255, 255, 0, 1);
        //    cs.BorderDepth = 3;
        //    cs.BackgroundColor = col;
        //    cs.SideGradientColor = col1;
        //    cs.backgroundType = CellStyle.BackgroundType.Gradient;
        //    cs.borderType = CellStyle.BorderType.Hatch;
        //    cs.BorderColor = col;
        //    ts.font = "Arial";
        //    ts.fontSize = 14;
        //    ts.textColor = col;
        //    ts.bold = true;
        //    ts.italic = false;
        //    ts.underlined = true;
        //    test.RenderCell(ts, cs);
        //    Assert.That(expectedResult == test.Result);
        //}

        //[Test]
        //public void TestHtmlGeneratorRenderCellSolidBorder()
        //{
        //    String expectedResult = "<td style='font: bold 14pt Arial; text-decoration: underline; color: rgba(255,0,0,1); background: -webkit-linear-gradient(top, rgba(255,255,0,1) 0%,rgba(255,0,0,1) 50%,rgba(255,0,0,1) 50%,rgba(255,255,0,1) 100%); border:3px solid rgba(255,0,0,1)'>";
        //    HtmlGenerator test = new HtmlGenerator();
        //    test.state = HtmlGenerator.State.row;
        //    CellStyle cs = new CellStyle();
        //    TextStyle ts = new TextStyle();
        //    Color col = new Color(255, 0, 0, 1);
        //    Color col1 = new Color(255, 255, 0, 1);
        //    cs.BorderDepth = 3;
        //    cs.BackgroundColor = col;
        //    cs.SideGradientColor = col1;
        //    cs.backgroundType = CellStyle.BackgroundType.Gradient;
        //    cs.borderType = CellStyle.BorderType.Solid;
        //    cs.BorderColor = col;
        //    ts.font = "Arial";
        //    ts.fontSize = 14;
        //    ts.textColor = col;
        //    ts.bold = true;
        //    ts.italic = false;
        //    ts.underlined = true;
        //    test.RenderCell(ts, cs);
        //    Assert.That(expectedResult == test.Result);
        //}

        [Test]
        public void TestHtmlGeneratorRenderCellOperException()
        {
            HtmlGenerator test = new HtmlGenerator();
            test.state = HtmlGenerator.State.table;
            Assert.That(() => test.RenderCell(null), Throws.InvalidOperationException);
        }

        [Test]
        public void TestHtmlGeneratorRenderCellNullArgException()
        {
            HtmlGenerator test = new HtmlGenerator();
            test.state = HtmlGenerator.State.row;
            Assert.That(() => test.RenderCell(null), Throws.ArgumentNullException);
        }

        [Test]
        public void TestFile()
        {
            String s = "124шрифт";
            HtmlGenerator test = new HtmlGenerator();
            CellStyle cs = new CellStyle();
            TextStyle ts = new TextStyle();
            Color col = new Color(255,0,0,1);
            Color col1 = new Color(255,255,0,1);
            cs.BorderDepth = 3;
            cs.BackgroundColor = col;
            cs.SideGradientColor = col1;
            cs.backgroundType = CellStyle.BackgroundType.Gradient;
            cs.borderType = CellStyle.BorderType.Solid;
            cs.BorderColor = col;
            cs.align = CellStyle.Align.right;
            cs.Colspan = 2;
            ts.font = "Arial";
            ts.fontSize = 14;
            ts.textColor = col;
            ts.bold = true;
            ts.italic = true;
            ts.underlined = false;
             
            CellStyle cs1 = new CellStyle();
            cs1.BorderDepth = 3;
            cs1.BackgroundColor = col;
            cs1.SideGradientColor = col1;
            cs1.backgroundType = CellStyle.BackgroundType.Gradient;
            cs1.borderType = CellStyle.BorderType.Hatch;
            cs1.BorderColor = col;
            cs1.align = CellStyle.Align.right;
            cs1.Colspan = 1;

            //ts.textColor = new Color(255, 255, 255, 1);
            test.RenderBegin(); 
            Assert.AreEqual(test.state, HtmlGenerator.State.table);
            test.RenderRow();
            Assert.AreEqual(test.state, HtmlGenerator.State.row);
            test.RenderCell(cs);
            test.RenderText(ts,s);
            test.RenderEnd();
            test.RenderEnd();
            test.RenderRow();
            test.RenderCell(cs1);
            test.RenderText(ts, s);
            test.RenderEnd();
            test.RenderCell(cs1);
            test.RenderText(ts, s);
            Assert.IsNotEmpty(test.Result);
            while(test.state!=HtmlGenerator.State.begin)
            {
                test.RenderEnd();
            }
            File.WriteAllText("D:\\Users\\chirkin_a\\Desktop\\NewFile.html", test.Result);
            Assert.AreEqual(test.state, HtmlGenerator.State.begin);
        }
    }
}
