using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Startup
    {
        public static void run()
        {
            var all_factories = new Dictionary<Type, DependencyFactory>();
            Container.facade_resolver = () => new BasicDependencyContainer(
                new BasicDependencyRegistry(all_factories));

            //your code below here
            var stub_set_of_commands = new StubSetOfCommands();
            var default_command_registry = new DefaultCommandRegistry(stub_set_of_commands);
            var default_front_controller = new DefaultFrontController(default_command_registry);
            var stub_request_factory = new StubRequestFactory();

            TemplateRegistry template_registry = new StubTemplateRegistry();
            Renderer renderer = new DefaultRenderer(template_registry);
            Catalog repository = new StubCatalog();

            add_factory<FrontController>(all_factories, () => default_front_controller);
            add_factory<RequestFactory>(all_factories, () => stub_request_factory);
            add_factory<CommandRegistry>(all_factories, () => default_command_registry);
            add_factory<TemplateRegistry>(all_factories, () => template_registry);
            add_factory<Renderer>(all_factories, () => renderer);
            add_factory<Catalog>(all_factories, () => repository);
            add_factory<ViewMainDepartments>(all_factories, () => new ViewMainDepartments(repository, renderer));
        }

        public static void add_factory<T>(Dictionary<Type, DependencyFactory> dict, Func<object> factory)
        {
            dict.Add(typeof(T), new BasicDependencyFactory(factory));
        }
    }
}