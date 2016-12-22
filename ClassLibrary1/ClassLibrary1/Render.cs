using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClassLibrary1
{
    [XmlRoot("Render")]
    public class Render
    {
        public Style[] styles;

        [XmlElement("Tasks")]
        public Tasks tasks;

        [XmlElement("Head")]
        public Head head;
    }

    public class Style
    {
        [XmlAttribute("name")]
        public string name { get; set; }

        [XmlAttribute("target")]
        public string target { get; set; }
        
        public Setter[] setters;
    }

    public class Setter
    {
        [XmlAttribute("path")]
        public string path { get; set; }

        [XmlAttribute("value")]
        public string value { get; set; }
    }

    public class Tasks
    {
        public Column[] Columns;
        public Condition[] conditions;
        public Application[] StylesApplications;
    }

    public class Column
    {
        [XmlAttribute("name")]
        public string name { get; set; }

        [XmlAttribute("rusname")]
        public string rusName { get; set; }
    }

    public class Condition
    {
        [XmlAttribute("name")]
        public string name { get; set; }
    }

    public class Application
    {
        [XmlAttribute("conditions")]
        public string conditions { get; set; }

        [XmlAttribute("styles")]
        public string styles { get; set; }

        [XmlAttribute("columns")]
        public string columns { get; set; }

        [XmlAttribute("priority")]
        public int priority { get; set; }

        [XmlAttribute("final")]
        public bool final { get; set; }
    }

    public class Head
    {
        public Cell[] Cells;
        public ApplicationForCell[] StylesApplications;
    }

    public class Cell
    {
        [XmlAttribute("name")]
        public string name { get; set; }
    }

    public class ApplicationForCell
    {
        [XmlAttribute("style")]
        public string style { get; set; }

        [XmlAttribute("cells")]
        public string cells { get; set; }

        //[XmlAttribute("priority")]
        //public int priority { get; set; }
    }
}
