using System;

namespace nothinbutdotnetstore.specs.tasks
{
    public interface ClassLocator
    {
        Type find(string name);
    }
}