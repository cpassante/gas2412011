using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.tasks.startup;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs.tasks
{
    public class StartupSpecs
    {
        public abstract class concern : Observes
        {
            
        }

        [Subject(typeof(Startup))]
        public class should_find_startup_command_from_name : concern
        {
            static string name = "SomeCommand";

            Establish e = () =>
            {
                locator = new DefaultClassLocator();
            };

            Because b = () =>
            {
                result = locator.find(name);
            };

            It should_find_correct_class = () =>
            {
                result.ShouldBeOfType(typeof(SomeCommand).FullName);
            };

            public static ClassLocator locator;
            public static Type result;
        }
    }

    public class SomeCommand : StartupCommand
    {
        public void run()
        {
            throw new NotImplementedException();
        }
    }
}