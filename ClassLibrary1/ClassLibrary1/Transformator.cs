using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Transformator
    {
        public Settings Settings { get; set; }

        public Dictionary<string, ValueProvider<ITask>> taskProvidersCollection_;

        public Dictionary<string, ValueProvider<IProject>> projectProvidersCollection_;

        public Dictionary<string, ValueProvider<IStage>> stageProvidersCollection_;

        public ConditionCollection conditionCollection_;


        public Transformator(Render render, Settings settings)
        {
            this.Settings = settings;

            conditionCollection_ = new ConditionCollection();



        }

        public void RenderTable(Generator generator)
        {

        }

        public void RenderTask(Generator generator)
        {

        }
    }

    public class SetterObject
    {
        public SetterObject(Type t, string path, object value)
        {
            if (t == null || path == null || value == null)
                throw new ArgumentNullException();

            //this.value = value;

            var segments = path.Split('.');
            this.path = new PropertyInfo[segments.Length];
            PropertyInfo property = null;
            var type = t;
            object obj = t;

            for (var i=0; i<segments.Length; i++)
            {
                if (property != null)
                {
                    type = property.PropertyType;

                }
                property = type.GetProperty(segments[i]);
                this.path[i] = property;
            }

            if (property == null) throw new ArgumentException();

            if (this.path.Last().PropertyType.IsEnum)
            {
                this.value = Enum.Parse(this.path.Last().PropertyType, (string)value);
            }
            else
            {
                this.value = Convert.ChangeType(value, property.PropertyType);
            }
        }

        public PropertyInfo[] path;

        public object value;

        public void Set(object target)
        {
            Type type = target.GetType();
            PropertyInfo property = null;
            foreach (var segment in path)
            {
                if (property != null)
                {
                    target = property.GetValue(target);
                    type = target.GetType();
                }
                property = segment;
            }

            if (property == null) throw new ArgumentException();
            
            property.SetValue(target, this.value);
        }
    }

    public class StyleObject
    {
        public StyleObject(Type t, SetterObject[] setters, String name)
        {
            if (t == null || setters == null || name == null)
                throw new ArgumentNullException();

            this.name = name;

            this.setters = new SetterObject[setters.Length];
            this.setters = setters;

            targetType = t;
        }

        public Type targetType;

        public SetterObject[] setters;

        public String name;
        
        public void Apply(object target)
        {
            if (target.GetType() != targetType || target == null)
                throw new ArgumentException();
            foreach (var setter in setters)
            {
                setter.Set(target);
            }
        }
    }

    public class StyleCollection
    {
        public StyleCollection(StyleObject[] styles)
        {
            if (styles == null)
                throw new ArgumentNullException();
            this.styles = new StyleObject[styles.Length];
            this.styles = styles;
        }

        public StyleObject[] styles;

        public void Apply(CellStyle cellStyle, String name)
        {
            if (cellStyle == null)
                throw new ArgumentNullException();
            if (name == null)
                throw new ArgumentNullException();
            styles.First(s => s.name == name).Apply((cellStyle));
        }

        public void Apply(TextStyle textStyle, String name)
        {
            if (textStyle == null)
                throw new ArgumentNullException();
            if (name == null)
                throw new ArgumentNullException();
            styles.First(s => s.name == name).Apply((textStyle));
        }

        public StyleObject GetCellStyleByName(String name)
        {
            return styles.First(s => s.name == name);
        }

        public StyleObject GetTextStyleByName(String name)
        {
            return styles.First(s => s.name == name);
        }
    }
}
