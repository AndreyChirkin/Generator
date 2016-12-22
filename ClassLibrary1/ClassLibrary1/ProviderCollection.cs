using ClassLibrary1.Providers;
using Mcst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ProviderCollection
    {
        public Dictionary<string, ValueProvider<ITask>> taskProviders_;

        public Dictionary<string, ValueProvider<IProject>> projectProviders_;

        public Dictionary<string, ValueProvider<IStage>> stageProviders_;

        public static Generator generator;

        public ProviderCollection(Generator gen)
        {
            generator = gen;
            var providers = AppDomain.CurrentDomain.GetAssemblies().Aggregate(Enumerable.Empty<Type>(), (tc, a) => tc.Concat(a.GetTypes())).Where(t => t.BaseType.IsConstructedGenericType && t.GetGenericTypeDefinition() == typeof(ValueProvider<>));
            
            //this.projectProviders_ = providers.Where(p => typeof(ValueProvider<IProject>).IsAssignableFrom(p.DeclaringType))
            //    .Select(p => (ValueProvider<IProject>)p.GetValue(this))
            //    .ToDictionary(c => c.Name);

            //var properties = this.GetType().GetProperties()
            //    .Where(p => p.PropertyType.BaseType.IsConstructedGenericType && p.PropertyType.BaseType.GetGenericTypeDefinition() == typeof(ValueProvider<>))
            //    .ToArray();

            //this.projectProviders_ = properties.Where(p => typeof(ValueProvider<IProject>).IsAssignableFrom(p.PropertyType))
            //    .Select(p => (ValueProvider<IProject>)p.GetValue(this))
            //    .ToDictionary(c => c.Name);

            //this.taskProviders_ = properties.Where(p => typeof(ValueProvider<ITask>).IsAssignableFrom(p.PropertyType))
            //    .Select(p => (ValueProvider<ITask>)p.GetValue(this))
            //    .ToDictionary(c => c.Name);

            //this.stageProviders_ = properties.Where(p => typeof(ValueProvider<IStage>).IsAssignableFrom(p.PropertyType))
            //    .Select(p => (ValueProvider<IStage>)p.GetValue(this))
            //    .ToDictionary(c => c.Name);
        }

        public ValueProvider<IProject> GetProjectProvider(string name)
        {
            return this.projectProviders_[name];
        }

        public ValueProvider<ITask> GetTaskProvider(string name)
        {
            return this.taskProviders_[name];
        }

        public ValueProvider<IStage> GetStageProvider(string name)
        {
            return this.stageProviders_[name];
        }

        public NameProvider NameProvider { get; } = new NameProvider(generator);
    }
}
