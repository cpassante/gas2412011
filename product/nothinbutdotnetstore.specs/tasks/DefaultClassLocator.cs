using System;
using Enumerable = System.Linq.Enumerable;

namespace nothinbutdotnetstore.specs.tasks
{
    public class DefaultClassLocator : ClassLocator
    {
        public Type find(string name)
        {
            return Enumerable.FirstOrDefault<Type>(Assembly.GetExecutingAssembly().GetTypes(), type => type.Name.Equals(name));
        }
    }
}