using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Start
    {
        public static Func<StartupCommandFactory> command_factory_provider = () =>
            new StartupCommandFactory(null);


        public static StartupCommandPipelineBuilder by<CommandType>() where CommandType : StartupCommand
        {
            return new StartupCommandPipelineBuilder(new List<StartupCommand>()
                                                     , command_factory_provider());
        }

        public static void by_running_all_commands_in(string startup_pipeline_txt)
        {
            throw new NotImplementedException();
        }
    }
}