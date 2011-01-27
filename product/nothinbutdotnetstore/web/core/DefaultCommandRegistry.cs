using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.infrastructure.documentation;

namespace nothinbutdotnetstore.web.core
{
    [Registry]
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<RequestCommand> all_commands;

        public DefaultCommandRegistry(IEnumerable<RequestCommand> all_commands
            )
        {
            this.all_commands = all_commands;
        }

        public RequestCommand get_command_that_can_run(Request request)
        {

            return all_commands.FirstOrDefault(x => x.can_process(request))
                ?? new MissingRequestCommand();
        }
    }
}